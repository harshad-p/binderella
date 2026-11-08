namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public string LanguageCode { get; set; } = string.Empty;

    public RecipeSourceResponse? Source { get; set; }

    public List<RecipeIngredientResponse> Ingredients { get; set; } = [];

    public List<RecipeStepResponse> Steps { get; set; } = [];

    public RecipeClosingMessageResponse ClosingMessage { get; set; } = null!;

    public DateTimeOffset CreatedAtUtc { get; set; }

    public DateTimeOffset UpdatedAtUtc { get; set; }
}
