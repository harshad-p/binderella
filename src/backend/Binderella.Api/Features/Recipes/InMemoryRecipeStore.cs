using System.Collections.Concurrent;
using Binderella.Api.Contracts.Recipes;

namespace Binderella.Api.Features.Recipes;

public sealed class InMemoryRecipeStore : IRecipeStore
{
    private readonly ConcurrentDictionary<Guid, StoredRecipe> _recipes = new();

    public RecipeResponse Create(CreateRecipeRequest request)
    {
        var now = DateTimeOffset.UtcNow;
        var recipe = new StoredRecipe(
            Guid.NewGuid(),
            request.Title,
            request.LanguageCode,
            request.Source is null ? null : new StoredSource(
                request.Source.Type, request.Source.Name, request.Source.Url),
            request.Ingredients.Select(ingredient => new StoredIngredient(
                Guid.NewGuid(), ingredient.Name, ingredient.Quantity, ingredient.Position)).ToArray(),
            request.Steps.Select(step => new StoredStep(
                Guid.NewGuid(), step.Instruction, step.Position)).ToArray(),
            new StoredClosingMessage(request.ClosingMessage.Type, request.ClosingMessage.CustomText),
            now,
            now);

        if (!_recipes.TryAdd(recipe.Id, recipe))
        {
            throw new InvalidOperationException("A recipe with the generated ID already exists.");
        }

        return ToResponse(recipe);
    }

    public RecipeResponse? GetById(Guid id) =>
        _recipes.TryGetValue(id, out var recipe) ? ToResponse(recipe) : null;

    private static RecipeResponse ToResponse(StoredRecipe recipe) => new()
    {
        Id = recipe.Id,
        Title = recipe.Title,
        Image = null,
        LanguageCode = recipe.LanguageCode,
        Source = recipe.Source is null ? null : new RecipeSourceResponse
        {
            Type = recipe.Source.Type,
            Name = recipe.Source.Name,
            Url = recipe.Source.Url
        },
        Ingredients = recipe.Ingredients.Select(ingredient => new RecipeIngredientResponse
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Quantity = ingredient.Quantity,
            Position = ingredient.Position
        }).ToList(),
        Steps = recipe.Steps.Select(step => new RecipeStepResponse
        {
            Id = step.Id,
            Instruction = step.Instruction,
            Position = step.Position
        }).ToList(),
        ClosingMessage = new RecipeClosingMessageResponse
        {
            Type = recipe.ClosingMessage.Type,
            CustomText = recipe.ClosingMessage.CustomText
        },
        CreatedAtUtc = recipe.CreatedAtUtc,
        UpdatedAtUtc = recipe.UpdatedAtUtc
    };

    // Snapshots copy request data; no request or response DTO is retained in storage.
    private sealed record StoredRecipe(
        Guid Id, string Title, string LanguageCode,
        StoredSource? Source, StoredIngredient[] Ingredients, StoredStep[] Steps,
        StoredClosingMessage ClosingMessage, DateTimeOffset CreatedAtUtc, DateTimeOffset UpdatedAtUtc);

    private sealed record StoredSource(RecipeSourceType Type, string Name, string? Url);
    private sealed record StoredIngredient(Guid Id, string Name, string Quantity, int Position);
    private sealed record StoredStep(Guid Id, string Instruction, int Position);
    private sealed record StoredClosingMessage(RecipeClosingMessageType Type, string? CustomText);
}
