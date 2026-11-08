namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeSourceResponse
{
    public RecipeSourceType Type { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Url { get; set; }
}
