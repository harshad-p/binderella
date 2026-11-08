# Course Notes

Concept explanations, comparisons, examples, decisions, and lessons learned
will be recorded here as the course progresses.

## First API Vertical Slice

A vertical slice implements one behavior through all necessary layers. For
recipe creation and retrieval, the request flows through `RecipesController`,
`IRecipeStore`, and `InMemoryRecipeStore`.

The controller handles HTTP concerns: POST returns 201 Created with the recipe
and a Location header pointing to its GET route; GET returns 200 when the recipe
exists or 404 when it does not. Existing request annotations provide automatic
400 validation responses through `[ApiController]`.

The store handles temporary recipe persistence. Its singleton lifetime allows
the in-memory store to survive across requests in the same API process. Data
disappears when that process stops. Thread-safe storage holds private snapshots;
API DTOs are not used as the internal storage model. Each read maps a snapshot
to a fresh response, including fresh nested objects and collections.

EF Core will later replace the in-memory implementation without changing the
public HTTP contract.
