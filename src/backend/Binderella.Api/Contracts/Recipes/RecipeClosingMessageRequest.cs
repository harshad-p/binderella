using System.ComponentModel.DataAnnotations;

namespace Binderella.Api.Contracts.Recipes;

public sealed class RecipeClosingMessageRequest
{
    [EnumDataType(typeof(RecipeClosingMessageType))]
    public RecipeClosingMessageType Type { get; set; }

    [MaxLength(300)]
    public string? CustomText { get; set; }
}
