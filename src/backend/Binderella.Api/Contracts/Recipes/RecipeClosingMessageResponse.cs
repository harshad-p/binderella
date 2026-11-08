namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeClosingMessageResponse
{
    public RecipeClosingMessageType Type { get; set; }

    public string? CustomText { get; set; }
}
