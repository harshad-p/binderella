namespace RecipeBook.Models;

public class Recipe
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string ChefName { get; set; } = "";

    /// <summary>Optional link to the YouTube video / source this recipe came from.</summary>
    public string? ChefUrl { get; set; }

    public byte[]? ImageData { get; set; }

    public string? ImageContentType { get; set; }

    /// <summary>A fun closing line, e.g. "The Chicken Masala is ready!"</summary>
    public string? ClosingLine { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.Now;

    /// <summary>CSS font-family value used to render this recipe's title/ingredients/steps.</summary>
    public string FontFamily { get; set; } = "'Nunito Sans', sans-serif";

    public List<RecipeIngredient> Ingredients { get; set; } = new();

    public List<RecipeStep> Steps { get; set; } = new();
}
