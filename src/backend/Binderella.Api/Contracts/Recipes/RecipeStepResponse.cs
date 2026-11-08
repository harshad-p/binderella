namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeStepResponse
{
    public Guid Id { get; set; }

    public string Instruction { get; set; } = string.Empty;

    public int Position { get; set; }
}
