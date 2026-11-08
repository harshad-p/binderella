using System.ComponentModel.DataAnnotations;

namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeStepRequest
{
    [Required]
    public string Instruction { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Position { get; set; }
}
