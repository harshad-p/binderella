using Binderella.Api.Contracts.Recipes;

namespace Binderella.Api.Features.Recipes;

public interface IRecipeStore
{
    RecipeResponse Create(CreateRecipeRequest request);
    RecipeResponse? GetById(Guid id);
}
