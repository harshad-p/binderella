using System.ComponentModel.DataAnnotations;

namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeSourceRequest
{
    [EnumDataType(typeof(RecipeSourceType))]
    public RecipeSourceType Type { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Url { get; set; }
}
