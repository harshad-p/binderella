namespace RecipeBook.Models;

public class RecipeIngredient
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    /// <summary>Free text amount, e.g. "2 cups" or "a pinch" — kept simple on purpose.</summary>
    public string Quantity { get; set; } = "";

    public string Name { get; set; } = "";

    public int SortOrder { get; set; }
}
