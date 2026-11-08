using System.ComponentModel.DataAnnotations;

namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeIngredientRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Quantity { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Position { get; set; }
}
