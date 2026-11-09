namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeImageResponse
{
    public Guid Id { get; set; }

    public string Url { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long SizeBytes { get; set; }
}
