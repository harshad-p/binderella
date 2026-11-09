using System.ComponentModel.DataAnnotations;

namespace Binderella.Api.Contracts.Recipes;

public sealed class UpdateRecipeRequest
{
    private List<RecipeIngredientRequest> _ingredients = [];
    private List<RecipeStepRequest> _steps = [];

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string LanguageCode { get; set; } = string.Empty;

    public RecipeSourceRequest? Source { get; set; }

    [Required]
    [MinLength(1)]
    public List<RecipeIngredientRequest> Ingredients
    {
        get => _ingredients;
        set => _ingredients = value ?? [];
    }

    [Required]
    [MinLength(1)]
    public List<RecipeStepRequest> Steps
    {
        get => _steps;
        set => _steps = value ?? [];
    }

    [Required]
    public RecipeClosingMessageRequest ClosingMessage { get; set; } = null!;
}
