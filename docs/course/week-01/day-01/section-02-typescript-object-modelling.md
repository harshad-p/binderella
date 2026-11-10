# W1D1-S2 — TypeScript Object Modelling

## 1. Interfaces vs Type Aliases

Both can describe the **shape of an object**.

### Interface

```ts
interface Recipe {
  id: number;
  title: string;
  description: string;
}
```

Then:

```ts
const recipe: Recipe = {
  id: 1,
  title: "Butter Chicken",
  description: "Creamy chicken curry"
};
```

Coming from C#, your first instinct may be:

> "`interface` must mean the same thing as a C# interface."

Not quite.

In C#, an interface usually describes **behavior/contracts**:

```csharp
public interface IRecipeService
{
    Recipe GetRecipe(int id);
}
```

In TypeScript, interfaces are very commonly used simply to describe **data shapes**:

```ts
interface Recipe {
  id: number;
  title: string;
}
```

So this is perfectly normal TypeScript.

---

### The Same Thing with `type`

You could write the exact same model using a type alias:

```ts
type Recipe = {
  id: number;
  title: string;
  description: string;
};
```

And use it identically:

```ts
const recipe: Recipe = {
  id: 1,
  title: "Butter Chicken",
  description: "Creamy chicken curry"
};
```

For simple object modelling, these two are extremely similar:

```ts
interface Recipe {
  id: number;
  title: string;
}
```

versus:

```ts
type Recipe = {
  id: number;
  title: string;
};
```

---

### So Why Do Both Exist?

The major difference is that **`type` can represent more kinds of types than `interface` can**.

For example:

```ts
type RecipeId = number;
```

An interface cannot do this.

Likewise:

```ts
type RecipeStatus = "draft" | "published" | "archived";
```

or:

```ts
type Id = string | number;
```

or:

```ts
type Coordinate = [number, number];
```

These are all valid type aliases.

An interface primarily describes **object-like structures**.

---

### Extending Interfaces

Interfaces can extend other interfaces:

```ts
interface Entity {
  id: number;
}

interface Recipe extends Entity {
  title: string;
}
```

Now:

```ts
const recipe: Recipe = {
  id: 1,
  title: "Butter Chicken"
};
```

This should feel familiar from C#:

```csharp
interface IEntity
{
    int Id { get; }
}

interface IRecipe : IEntity
{
    string Title { get; }
}
```

Although again, TypeScript interfaces are used much more heavily for plain data structures.

---

### Types Can Compose Too

With type aliases, you normally use intersections:

```ts
type Entity = {
  id: number;
};

type Recipe = Entity & {
  title: string;
};
```

The resulting shape is effectively:

```ts
{
  id: number;
  title: string;
}
```

You already encountered `&` in S1, so this is one place where intersection types become practical.

---

### One Important Difference: Declaration Merging

TypeScript allows interfaces with the same name to be merged.

```ts
interface Recipe {
  id: number;
}

interface Recipe {
  title: string;
}
```

TypeScript effectively sees:

```ts
interface Recipe {
  id: number;
  title: string;
}
```

So this works:

```ts
const recipe: Recipe = {
  id: 1,
  title: "Butter Chicken"
};
```

You **cannot** do the same thing with `type`:

```ts
type Recipe = {
  id: number;
};

type Recipe = {
  title: string;
};
```

That causes a duplicate identifier error.

This feature is called **declaration merging**.

You won't deliberately use it very often in ordinary application code, but it matters when working with TypeScript libraries and framework typings.

---

### What Should We Use in Recipe Studio?

A good practical convention is:

Use `interface` primarily for object contracts:

```ts
interface Recipe {
  id: string;
  title: string;
  description: string;
}
```

Use `type` when you're creating:

- unions
- intersections
- primitive aliases
- tuples
- more complex composed types

For example:

```ts
type RecipeStatus = "draft" | "published";

type RecipeId = string;
```

There are codebases that prefer `type` for almost everything, and that is also perfectly legitimate.

There isn't a universal rule that:

> interfaces are good, types are bad

or vice versa.

For this course, I want you to understand **why you'd choose each**, rather than blindly follow a style rule.

---

### Recipe Studio Example

Imagine our API eventually gives Angular this:

```json
{
  "id": "1",
  "title": "Butter Chicken",
  "source": "Chef Ranveer Brar",
  "status": "published"
}
```

A reasonable TypeScript model would be:

```ts
type RecipeStatus = "draft" | "published";

interface Recipe {
  id: string;
  title: string;
  source: string;
  status: RecipeStatus;
}
```

Notice that we're already combining both techniques:

```ts
type RecipeStatus = ...
```

because it's a union,

and:

```ts
interface Recipe
```

because we're describing an object shape.

That combination is extremely common in real TypeScript applications.

---

### Your exercise

Without running anything yet, model this object:

```ts
{
  id: "abc123",
  name: "Spaghetti Carbonara",
  difficulty: "medium",
  preparationMinutes: 30
}
```

Requirements:

- Use an `interface` for the recipe.
- `difficulty` may only be `"easy"`, `"medium"`, or `"hard"`.
- Define the difficulty separately with a `type`.

Write the TypeScript you think is correct.

Once you've done that, we'll continue to the **next part of W1D1-S2: optional properties**.

### Answer

```ts
type Difficulty = "easy" | "medium" | "hard"

interface Recipe
{
  id: string,
  name: string,
  difficulty: Difficulty,
  preparationMinutes: number
}
```
Correct! ✅ Your solution satisfies all three requirements.

- `Difficulty` is a union of three string literals.
- `Recipe` is defined using an interface.
- All properties have the appropriate types.

One small style note: TypeScript convention is to use semicolons rather than commas between interface properties, although both are valid.

## Optional Properties

In C#, you might define a nullable property:

```
public string? Description { get; set; }
```

In TypeScript, you can make a property optional using `?`:

```
interface Recipe {
  id: string;
  name: string;
  description?: string;
}
```

Now both objects are valid:

```
const recipe1: Recipe = {
  id: "1",
  name: "Butter Chicken"
};

const recipe2: Recipe = {
  id: "2",
  name: "Pasta",
  description: "Italian pasta dish"
};
```

### Important: Optional vs nullable

These are not equivalent:

```
interface Recipe {
  description?: string;
}
```

```
interface Recipe {
  description: string | null;
}
```

The first allows the property to be omitted entirely. When accessed, its type is `string | undefined`.

The second requires the property to exist, but its value can be `null`.

You can also combine them:

```
interface Recipe {
  description?: string | null;
}
```

### Your exercise

Consider this interface:

```
interface Recipe {
  id: string;
  name: string;
  description?: string;
}
```

Question: Will the following code compile with `strictNullChecks` enabled? Why or why not?

```
const recipe: Recipe = {
  id: "1",
  name: "Pasta"
};

console.log(recipe.description.toUpperCase());
```

Explain your reasoning before we move to `readonly` properties.

### Answer
I think the description becomes optional. But with strictNullChecks enabled, description becomes string | null. 
Will it compile? Umm... as far as C# is concerned, it gives a warning. Maybe TS does allow compiling.

You're very close! There are two important distinctions here.

### 1. Optional means `string | undefined`, not `string | null`

```
interface Recipe {
  description?: string;
}
```

TypeScript treats reading `description` as:

```
string | undefined
```

Why `undefined`? Because JavaScript returns `undefined` when you access a property that doesn't exist.

### 2. TypeScript reports a compilation error

```
console.log(recipe.description.toUpperCase());
```

With `strictNullChecks` enabled, TypeScript reports:

```
'recipe.description' is possibly 'undefined'.
```

Unlike C#'s nullable reference type warning, TypeScript reports a type-checking error.

However, there's an interesting detail: TypeScript can still emit JavaScript despite type errors, depending on the compiler configuration (`noEmitOnError`).

### 3. How would you fix it?

One approach is optional chaining:

```
console.log(recipe.description?.toUpperCase());
```

If `description` is `undefined`, the expression evaluates to `undefined` instead of throwing an exception.

Another approach is nullish coalescing:

```
console.log((recipe.description ?? "No description").toUpperCase());
```

Here, `??` supplies a fallback when `description` is `null` or `undefined`.

### Quick question before `readonly`

What's the difference between these two expressions?

```
const a = recipe.description || "No description";
const b = recipe.description ?? "No description";
```

Consider what happens when `description` is an empty string (`""`).

### Answer
umm... I can only guess. 
?? checks if the property is null or undefined. If it is, it returns the string after ??
Maybe || checks if the string is empty. If it is, it returns the string after ||.

You're correct about `??`, and very close with `||`! ✅

The important distinction is that `||` checks for any falsy value, not just an empty string.

JavaScript considers these values falsy:

- `false`
- `0`
- `""` (empty string)
- `null`
- `undefined`
- `NaN`

By contrast, `??` only checks for `null` and `undefined`.

### Let's compare

| `description` | `description \|\| "Default"` | `description ?? "Default"` |
| ------------- | ------------------------------ | -------------------------- |
| `"Pasta"`     | `"Pasta"`                      | `"Pasta"`                  |
| `""`          | `"Default"`                    | `""`                       |
| `null`        | `"Default"`                    | `"Default"`                |
| `undefined`   | `"Default"`                    | `"Default"`                |

This distinction becomes particularly important when working with numeric values:

```
const preparationMinutes = 0;

console.log(preparationMinutes || 30); // 30
console.log(preparationMinutes ?? 30); // 0
```

If `0` is a legitimate value, using `||` could introduce a bug.

Rule of thumb: Prefer `??` when you only want a fallback for missing (`null` or `undefined`) values.

## `readonly` Properties

In TypeScript, `readonly` prevents you from reassigning a property after initialization.

```
interface Recipe {
  readonly id: string;
  name: string;
}

const recipe: Recipe = {
  id: "abc123",
  name: "Butter Chicken"
};

recipe.name = "Chicken Curry"; // Allowed

recipe.id = "xyz789"; // TypeScript error
```

This resembles a C# property with an `init` accessor:

```
public string Id { get; init; }
```

However, there's an important difference: TypeScript's `readonly` is enforced by the type checker, not at runtime.

Also, `readonly` is shallow.

Consider:

```
interface Recipe {
  readonly id: string;
  readonly ingredients: string[];
}

const recipe: Recipe = {
  id: "123",
  ingredients: ["Chicken", "Butter"]
};

recipe.ingredients = ["Rice"]; // Error

recipe.ingredients.push("Salt"); // ???
```

### Your turn

Will `recipe.ingredients.push("Salt")` compile?

Think about what exactly `readonly` is protecting here.

### Answer
I think it will allow pushing, because pushing is not reinitializing.

Exactly right! ✅

`readonly` prevents reassigning the property, but it does not prevent modifying the object or array referenced by that property.

```
interface Recipe {
  readonly ingredients: string[];
}

const recipe: Recipe = {
  ingredients: ["Chicken", "Butter"]
};

recipe.ingredients.push("Salt"); // ✅ Allowed
recipe.ingredients[0] = "Rice";   // ✅ Allowed

recipe.ingredients = ["Flour"];  // ❌ Error
```

## What if we want an immutable array?

TypeScript provides `readonly T[]` and `ReadonlyArray<T>`.

```
interface Recipe {
  readonly ingredients: readonly string[];
}
```

Now:

```
recipe.ingredients.push("Salt"); // ❌ Error
recipe.ingredients[0] = "Rice";   // ❌ Error
recipe.ingredients = ["Flour"];  // ❌ Error
```

Notice the two separate uses of `readonly`:

- `readonly ingredients` prevents reassigning the property.
- `readonly string[]` prevents modifying the array through that reference.

This is still compile-time protection, not runtime immutability.

## Quick exercise

Consider:

```
interface Ingredient {
  name: string;
  quantity: number;
}

interface Recipe {
  readonly ingredients: readonly Ingredient[];
}

const recipe: Recipe = {
  ingredients: [
    { name: "Butter", quantity: 100 }
  ]
};
```

Which of these statements will compile?

```
// A
recipe.ingredients.push({ name: "Salt", quantity: 5 });

// B
recipe.ingredients[0].quantity = 200;

// C
recipe.ingredients[0] = { name: "Sugar", quantity: 50 };
```

Think carefully about the difference between making an array readonly and making the objects inside that array readonly.

### Answer
I think only B will compile.

Correct! ✅ Only B will compile.

Here's why:

- A: ❌ `push()` modifies the array, which is readonly.
- B: ✅ `quantity` belongs to an object inside the array. That object is still mutable.
- C: ❌ Replacing an array element modifies the readonly array.

This demonstrates an important concept: TypeScript's `readonly` is shallow, not deep.

If we wanted to prevent B as well, we could write:

```
interface Ingredient {
  readonly name: string;
  readonly quantity: number;
}

interface Recipe {
  readonly ingredients: readonly Ingredient[];
}
```

Now all three operations would fail type checking.

## Arrays in TypeScript

You've already encountered arrays, so let's build on that.

TypeScript provides two equivalent ways to declare an array:

```
const ingredients: string[] = ["Butter", "Salt"];

const quantities: Array<number> = [100, 5];
```

Both forms describe an array containing elements of a particular type.

Arrays can also contain objects:

```
interface Ingredient {
  name: string;
  quantity: number;
}

const ingredients: Ingredient[] = [
  { name: "Butter", quantity: 100 },
  { name: "Salt", quantity: 5 }
];
```

### An important distinction: Arrays vs tuples

An ordinary array does not enforce a fixed number of elements:

```
const quantities: number[] = [100, 200, 300];
```

A tuple, however, can enforce the number, order, and types of its elements:

```
const ingredient: [string, number] = ["Butter", 100];
```

Here, TypeScript expects the first element to be a `string` and the second to be a `number`.

## Your exercise

Which of these assignments will compile?

```
type IngredientTuple = [string, number];

// A
const a: IngredientTuple = ["Butter", 100];

// B
const b: IngredientTuple = [100, "Butter"];

// C
const c: IngredientTuple = ["Butter"];

// D
const d: IngredientTuple = ["Butter", 100, "grams"];
```

Once we've covered tuples, we'll move to generics, the final topic in W1D1-S2.

### Answer
I think only A will compile.

Correct! ✅ Only A will compile.

| Option | Result | Reason                                       |
| ------ | ------ | -------------------------------------------- |
| A      | ✅      | Correct types, order, and number of elements |
| B      | ❌      | Incorrect element types                      |
| C      | ❌      | Missing the second element                   |
| D      | ❌      | Too many elements                            |

One important detail: TypeScript tuples can also have optional elements and rest elements, but our example requires exactly two elements.

## Generics in TypeScript

Since you're familiar with C#, this should feel very natural.

In C#, you might define:

```
public class ApiResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
}
```

TypeScript supports the same concept:

```
interface ApiResponse<T> {
  data: T;
  success: boolean;
}
```

Here, `T` is a type parameter. It lets us define a reusable structure without committing to a specific data type.

### Example 1: A single recipe

```
interface Recipe {
  id: string;
  title: string;
}

const response: ApiResponse<Recipe> = {
  data: {
    id: "123",
    title: "Butter Chicken"
  },
  success: true
};
```

Here, TypeScript substitutes `Recipe` for `T`.

### Example 2: An array of recipes

We can reuse the same interface:

```
const response: ApiResponse<Recipe[]> = {
  data: [
    { id: "123", title: "Butter Chicken" },
    { id: "456", title: "Pasta" }
  ],
  success: true
};
```

Now `data` must be an array of `Recipe` objects.

### Example 3: Generic constraints

Just like C# supports `where T : ...`, TypeScript supports constraints using `extends`.

```
interface Entity {
  id: string;
}

function getId<T extends Entity>(entity: T): string {
  return entity.id;
}
```

This means `T` can be any type that satisfies the `Entity` structure.

For example:

```
const recipe = {
  id: "123",
  title: "Pasta"
};

console.log(getId(recipe)); // "123"
```

This works because `recipe` has an `id` property of type `string`.

However:

```
const ingredient = {
  name: "Butter",
  quantity: 100
};

getId(ingredient); // ❌ TypeScript error
```

The ingredient doesn't have the required `id` property.

Unlike C#, TypeScript uses structural typing here. The object doesn't need to explicitly implement `Entity`; it only needs to have the required shape.

## Your exercise

Consider:

```
interface Entity {
  id: string;
}

interface Recipe {
  id: string;
  title: string;
}

interface Ingredient {
  id: number;
  name: string;
}

function processEntity<T extends Entity>(entity: T): T {
  return entity;
}
```

Which of these calls will compile, and why?

```
// A
processEntity<Recipe>({
  id: "abc",
  title: "Pasta"
});

// B
processEntity<Ingredient>({
  id: 123,
  name: "Butter"
});

// C
processEntity({
  id: "xyz",
  name: "Salt"
});
```

Pay particular attention to C, where we haven't explicitly supplied a type argument.

This will also test your understanding of type inference from W1D1-S1.

### Answer
Only A and C will compile because they all have the id property, and satisfy the shape of Entity. Whereas B even though it has the id property, the data type is different.

Exactly right! ✅ All three explanations are correct.

- A: ✅ Compiles because `Recipe` satisfies the `Entity` constraint.
- B: ❌ Fails because `Ingredient.id` is `number`, whereas `Entity.id` requires `string`.
- C: ✅ Compiles because TypeScript infers the generic type from the argument. The object has the required `id: string` property, even though it doesn't explicitly implement `Entity`.

Your observation about C is particularly important: TypeScript uses structural typing rather than requiring explicit interface implementation.

## W1D1-S2 — Completed! ✅

We've now covered all six topics:

- Interfaces vs type aliases
- Optional properties
- Readonly properties
- Arrays
- Tuples
- Generics

You've also demonstrated an understanding of generic constraints and type inference.

The next section is W1D1-S3 — Functions, Narrowing, and Advanced Type Modelling, covering function types, callback types, type narrowing, and discriminated unions.