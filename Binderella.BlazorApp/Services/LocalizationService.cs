namespace RecipeBook.Services;

/// <summary>
/// Simple in-memory UI localization service (English / Marathi).
/// This translates app chrome (buttons, labels) -- NOT recipe content itself,
/// which the user types directly in whatever language/script they want.
///
/// NOTE: Marathi strings below were machine-translated. Please have a fluent
/// Marathi speaker review them before relying on this for real use.
/// </summary>
public class LocalizationService
{
    public event Action? OnChange;

    private string _language = "en";

    public string Language
    {
        get => _language;
        set
        {
            if (_language != value && Translations.ContainsKey(value))
            {
                _language = value;
                OnChange?.Invoke();
            }
        }
    }

    public string T(string key)
    {
        if (Translations.TryGetValue(_language, out var dict) && dict.TryGetValue(key, out var value))
        {
            return value;
        }
        // fall back to English, then to the raw key if even that's missing
        return Translations["en"].GetValueOrDefault(key, key);
    }

    private static readonly Dictionary<string, Dictionary<string, string>> Translations = new()
    {
        ["en"] = new()
        {
            ["AppName"] = "Binderella",
            ["MyRecipes"] = "My Recipes",
            ["AddNewRecipe"] = "+ Add New Recipe",
            ["SearchPlaceholder"] = "Search recipes...",
            ["EmptyState"] = "No recipes yet. Click \"Add New Recipe\" to write down your first one!",
            ["Loading"] = "Loading...",
            ["By"] = "by",
            ["Back"] = "← Back to all recipes",
            ["Print"] = "🖨️ Print",
            ["Edit"] = "✏️ Edit",
            ["Delete"] = "🗑️ Delete",
            ["DeleteConfirm"] = "Delete \"{0}\"? This cannot be undone.",
            ["Ingredients"] = "Ingredients",
            ["Recipe"] = "Recipe",
            ["EditRecipeTitle"] = "Edit Recipe",
            ["AddRecipeTitle"] = "Add a New Recipe",
            ["RecipeTitleLabel"] = "Recipe Title",
            ["RecipeTitlePlaceholder"] = "e.g. Chicken Masala",
            ["ChefNameLabel"] = "Chef / Source Name",
            ["ChefNamePlaceholder"] = "e.g. Mom, or a YouTube channel name",
            ["ChefUrlLabel"] = "Chef / Source Link (optional)",
            ["PhotoLabel"] = "Photo (optional)",
            ["FontLabel"] = "Font",
            ["FontHint"] = "Mangal and Kohinoor look best if already installed on this computer (Windows/Mac include them by default). Noto Sans Devanagari always works, even without them.",
            ["IngredientsLabel"] = "Ingredients",
            ["AmountPlaceholder"] = "Amount (e.g. 2 cups)",
            ["IngredientNamePlaceholder"] = "Ingredient name",
            ["AddIngredient"] = "+ Add Ingredient",
            ["StepsLabel"] = "Steps",
            ["StepPlaceholder"] = "Describe this step",
            ["AddStep"] = "+ Add Step",
            ["ClosingLineLabel"] = "Closing Line (optional, something fun!)",
            ["ClosingLinePlaceholder"] = "e.g. The Chicken Masala is ready!",
            ["Save"] = "💾 Save Recipe",
            ["Cancel"] = "Cancel",
        },
        ["mr"] = new()
        {
            ["AppName"] = "Binderella",
            ["MyRecipes"] = "माझ्या पाककृती",
            ["AddNewRecipe"] = "+ नवीन पाककृती जोडा",
            ["SearchPlaceholder"] = "पाककृती शोधा...",
            ["EmptyState"] = "अजून पाककृती नाही. सुरुवात करण्यासाठी \"नवीन पाककृती जोडा\" वर क्लिक करा!",
            ["Loading"] = "लोड होत आहे...",
            ["By"] = "यांची",
            ["Back"] = "← सर्व पाककृतींकडे परत",
            ["Print"] = "🖨️ छापा",
            ["Edit"] = "✏️ संपादित करा",
            ["Delete"] = "🗑️ काढून टाका",
            ["DeleteConfirm"] = "\"{0}\" काढून टाकायची? ही क्रिया पूर्ववत करता येणार नाही.",
            ["Ingredients"] = "साहित्य",
            ["Recipe"] = "कृती",
            ["EditRecipeTitle"] = "पाककृती संपादित करा",
            ["AddRecipeTitle"] = "नवीन पाककृती जोडा",
            ["RecipeTitleLabel"] = "पाककृतीचे नाव",
            ["RecipeTitlePlaceholder"] = "उदा. चिकन मसाला",
            ["ChefNameLabel"] = "आचारी / स्रोताचे नाव",
            ["ChefNamePlaceholder"] = "उदा. आई, किंवा युट्यूब चॅनेलचे नाव",
            ["ChefUrlLabel"] = "आचारी / स्रोताची लिंक (ऐच्छिक)",
            ["PhotoLabel"] = "फोटो (ऐच्छिक)",
            ["FontLabel"] = "फॉन्ट",
            ["FontHint"] = "मंगल आणि कोहिनूर हे फॉन्ट संगणकावर आधीच असल्यास उत्तम दिसतात (Windows/Mac मध्ये आधीपासूनच असतात). नोटो सान्स देवनागरी हा फॉन्ट नेहमीच व्यवस्थित दिसतो.",
            ["IngredientsLabel"] = "साहित्य",
            ["AmountPlaceholder"] = "प्रमाण (उदा. २ कप)",
            ["IngredientNamePlaceholder"] = "साहित्याचे नाव",
            ["AddIngredient"] = "+ साहित्य जोडा",
            ["StepsLabel"] = "कृतीचे टप्पे",
            ["StepPlaceholder"] = "हा टप्पा लिहा",
            ["AddStep"] = "+ टप्पा जोडा",
            ["ClosingLineLabel"] = "शेवटचे वाक्य (ऐच्छिक, काहीतरी मजेदार!)",
            ["ClosingLinePlaceholder"] = "उदा. चिकन मसाला तयार आहे!",
            ["Save"] = "💾 पाककृती जतन करा",
            ["Cancel"] = "रद्द करा",
        },
    };
}
