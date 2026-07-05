namespace RecipeBook.Models;

public class RecipeStep
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public string Description { get; set; } = "";

    public int SortOrder { get; set; }
}
