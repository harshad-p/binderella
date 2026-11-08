using Binderella.Api.Contracts.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace Binderella.Api.Features.Recipes;

[ApiController]
[Route("api/recipes")]
public sealed class RecipesController(IRecipeStore store) : ControllerBase
{
    [HttpPost]
    public ActionResult<RecipeResponse> Create(CreateRecipeRequest request)
    {
        var recipe = store.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<RecipeResponse> GetById(Guid id)
    {
        var recipe = store.GetById(id);
        if (recipe is null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }
}
