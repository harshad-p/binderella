using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Binderella.Api.IntegrationTests;

public sealed class RecipesApiTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Post_valid_recipe_returns_created_recipe_and_location(bool useCustomMessage)
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = CreateClient(factory);
        var request = ValidRecipe();
        if (useCustomMessage)
        {
            request["source"] = null;
            request["closingMessage"] = new JsonObject
            {
                ["type"] = "Custom",
                ["customText"] = "Share with friends!"
            };
        }

        using var response = await client.PostAsJsonAsync("/api/recipes", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var recipe = await ReadRecipe(response);
        Assert.True(recipe.ContainsKey("image"));
        Assert.Null(recipe["image"]);
        Assert.NotEqual(Guid.Empty, recipe["id"]!.GetValue<Guid>());
        var itemIds = recipe["ingredients"]!.AsArray().Concat(recipe["steps"]!.AsArray())
            .Select(item => item!["id"]!.GetValue<Guid>()).ToArray();
        Assert.All(itemIds, id => Assert.NotEqual(Guid.Empty, id));
        Assert.Equal(itemIds.Length, itemIds.Distinct().Count());
        var createdAt = recipe["createdAtUtc"]!.GetValue<DateTimeOffset>();
        Assert.NotEqual(default, createdAt);
        Assert.Equal(TimeSpan.Zero, createdAt.Offset);
        Assert.Equal(createdAt, recipe["updatedAtUtc"]!.GetValue<DateTimeOffset>());
        AssertSubmittedFields(request, recipe);
        Assert.Equal(useCustomMessage ? "Custom" : "EnjoyYourMeal",
            recipe["closingMessage"]!["type"]!.GetValue<string>());
        if (!useCustomMessage)
        {
            Assert.Equal("YouTubeChannel", recipe["source"]!["type"]!.GetValue<string>());
        }

        Assert.NotNull(response.Headers.Location);
        Assert.Equal($"/api/recipes/{recipe["id"]!.GetValue<Guid>()}",
            new Uri(client.BaseAddress!, response.Headers.Location).AbsolutePath);
    }

    [Fact]
    public async Task Get_created_recipe_returns_same_recipe_across_requests()
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = CreateClient(factory);
        using var created = await client.PostAsJsonAsync("/api/recipes", ValidRecipe());
        Assert.Equal(HttpStatusCode.Created, created.StatusCode);
        var postedRecipe = await ReadRecipe(created);

        using var response = await client.GetAsync(created.Headers.Location);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var retrievedRecipe = await ReadRecipe(response);
        Assert.True(retrievedRecipe.ContainsKey("image"));
        Assert.Null(retrievedRecipe["image"]);
        Assert.Equal(postedRecipe["id"]!.GetValue<Guid>(), retrievedRecipe["id"]!.GetValue<Guid>());
        Assert.True(JsonNode.DeepEquals(postedRecipe, retrievedRecipe));
    }

    [Fact]
    public async Task Get_unknown_guid_returns_not_found()
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = CreateClient(factory);

        using var response = await client.GetAsync($"/api/recipes/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData("Title")]
    [InlineData("TitleLength")]
    [InlineData("LanguageCode")]
    [InlineData("Source.Name")]
    [InlineData("Ingredients")]
    [InlineData("NullIngredients")]
    [InlineData("Ingredients[0].Name")]
    [InlineData("Ingredients[0].Quantity")]
    [InlineData("Ingredients[0].Position")]
    [InlineData("Steps")]
    [InlineData("NullSteps")]
    [InlineData("Steps[0].Instruction")]
    [InlineData("Steps[0].Position")]
    [InlineData("ClosingMessage")]
    [InlineData("ClosingMessage.CustomText")]
    public async Task Post_invalid_recipe_returns_validation_problem(string invalidField)
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = CreateClient(factory);
        var request = ValidRecipe();
        switch (invalidField)
        {
            case "Title": request["title"] = " "; break;
            case "TitleLength": request["title"] = new string('x', 201); break;
            case "LanguageCode": request["languageCode"] = ""; break;
            case "Source.Name": request["source"]!["name"] = ""; break;
            case "Ingredients": request["ingredients"] = new JsonArray(); break;
            case "NullIngredients": request["ingredients"] = null; break;
            case "Ingredients[0].Name": request["ingredients"]![0]!["name"] = ""; break;
            case "Ingredients[0].Quantity": request["ingredients"]![0]!["quantity"] = ""; break;
            case "Ingredients[0].Position": request["ingredients"]![0]!["position"] = 0; break;
            case "Steps": request["steps"] = new JsonArray(); break;
            case "NullSteps": request["steps"] = null; break;
            case "Steps[0].Instruction": request["steps"]![0]!["instruction"] = ""; break;
            case "Steps[0].Position": request["steps"]![0]!["position"] = -1; break;
            case "ClosingMessage": request["closingMessage"] = null; break;
            case "ClosingMessage.CustomText":
                request["closingMessage"]!["type"] = "Custom";
                request["closingMessage"]!["customText"] = new string('x', 301);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(invalidField));
        }

        using var response = await client.PostAsJsonAsync("/api/recipes", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
        var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        Assert.NotNull(problem);
        Assert.Equal(400, problem.Status);
        var expectedField = invalidField switch
        {
            "TitleLength" => "Title",
            "NullIngredients" => "Ingredients",
            "NullSteps" => "Steps",
            _ => invalidField
        };
        Assert.Contains(problem.Errors.Keys, key =>
            string.Equals(expectedField, key, StringComparison.OrdinalIgnoreCase));
    }

    private static HttpClient CreateClient(WebApplicationFactory<Program> factory) =>
        factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost"),
            AllowAutoRedirect = false
        });

    private static async Task<JsonObject> ReadRecipe(HttpResponseMessage response) =>
        (await response.Content.ReadFromJsonAsync<JsonObject>())!;

    // Compare every submitted field while allowing server-generated response fields.
    private static void AssertSubmittedFields(JsonNode? expected, JsonNode? actual)
    {
        if (expected is JsonObject expectedObject)
        {
            var actualObject = Assert.IsType<JsonObject>(actual);
            foreach (var field in expectedObject)
            {
                Assert.True(actualObject.ContainsKey(field.Key));
                AssertSubmittedFields(field.Value, actualObject[field.Key]);
            }
        }
        else if (expected is JsonArray expectedArray)
        {
            var actualArray = Assert.IsType<JsonArray>(actual);
            Assert.Equal(expectedArray.Count, actualArray.Count);
            for (var index = 0; index < expectedArray.Count; index++)
            {
                AssertSubmittedFields(expectedArray[index], actualArray[index]);
            }
        }
        else
        {
            Assert.True(JsonNode.DeepEquals(expected, actual));
        }
    }

    private static JsonObject ValidRecipe() => JsonNode.Parse("""
        {
          "title": "Chicken Masala",
          "languageCode": "en",
          "source": {
            "type": "YouTubeChannel",
            "name": "Example Kitchen",
            "url": "https://www.youtube.com/@examplekitchen"
          },
          "ingredients": [
            { "name": "Chicken", "quantity": "500 g", "position": 3 },
            { "name": "Masala", "quantity": "2 tbsp", "position": 1 }
          ],
          "steps": [
            { "instruction": "Coat the chicken.", "position": 4 },
            { "instruction": "Cook through.", "position": 2 }
          ],
          "closingMessage": { "type": "EnjoyYourMeal", "customText": null }
        }
        """)!.AsObject();
}
