namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeIngredientResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Quantity { get; set; } = string.Empty;

    public int Position { get; set; }
}
