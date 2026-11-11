# W1D1-S5 — Async TypeScript and Utility Types

This section covers `Promise<T>`, `async`, `await`, then the utility types `Partial<T>`, `Required<T>`, `Pick<T>`, `Omit<T>`, and `Record<TKey, TValue>`. CURRICULUM

We'll take them one concept at a time.

## 1. `Promise<T>`

A `Promise<T>` represents:

> A value of type `T` that may become available later.

Coming from C#, the closest mental mapping is:

```text
C#                  TypeScript
Task<T>             Promise<T>
async                async
await                await
```

For example, suppose we eventually want to receive a recipe:

```ts
interface Recipe {
  id: number;
  title: string;
}
```

A normal synchronous function might return:

```ts
function getRecipe(): Recipe {
  return {
    id: 1,
    title: "Butter Chicken"
  };
}
```

Its return type is simply:

```ts
Recipe
```

But suppose obtaining the recipe requires an HTTP request. The result isn't available immediately.

So the return type becomes:

```ts
function getRecipe(): Promise<Recipe> {
  // ...
}
```

The important distinction is:

```ts
Recipe
```

means:

> I am returning a recipe now.

Whereas:

```ts
Promise<Recipe>
```

means:

> I am returning something that will eventually produce a recipe.

This is almost exactly the same distinction you're already familiar with:

```csharp
Recipe
```

versus:

```csharp
Task<Recipe>
```

### Creating a simple Promise

For example:

```ts
function getRecipe(): Promise<Recipe> {
  return Promise.resolve({
    id: 1,
    title: "Butter Chicken"
  });
}
```

The function itself immediately returns a `Promise`.

That promise eventually resolves to:

```ts
Recipe
```

So the generic parameter tells us the eventual result type:

```ts
Promise<string>
Promise<number>
Promise<Recipe>
Promise<Recipe[]>
```

You may also encounter:

```ts
Promise<void>
```

which means the asynchronous operation completes but doesn't produce a useful result.

Again, very similar to:

```csharp
Task
```

in C#.

### One subtle difference worth knowing

A JavaScript `Promise` can be in one of three conceptual states:

```text
pending
fulfilled
rejected
```

For example:

```ts
Promise<Recipe>
```

does **not** mean the promise is guaranteed to produce a `Recipe`.

It means:

```text
success → Recipe
failure → rejected Promise
```

The rejection isn't represented in the generic type.

So unlike something such as:

```ts
Result<Recipe, Error>
```

the TypeScript type:

```ts
Promise<Recipe>
```

only describes the successful value.

## Your next step

Before we move to `async`, make sure this distinction is clear:

```ts
Recipe
```

vs.

```ts
Promise<Recipe>
```

**Question:** What would the return type of an asynchronous function be if it eventually returns an array of `Recipe` objects?

### Answer
`Promise<Recipe[]>`

✅ Correct! `Promise<Recipe[]>` represents an asynchronous operation that will eventually return an array of recipes.

## 2. `async` in TypeScript

Just like C#, TypeScript uses the `async` keyword to declare asynchronous functions.

Consider:

```
interface Recipe {
  id: number;
  title: string;
}

async function getRecipe(): Promise<Recipe> {
  return {
    id: 1,
    title: "Butter Chicken"
  };
}
```

Notice something interesting: we're returning a `Recipe` object directly, even though the declared return type is `Promise<Recipe>`.

Why does this work?

Because an `async` function automatically wraps its returned value in a `Promise`.

These two functions are effectively equivalent in terms of their returned result:

```
async function getRecipe(): Promise<Recipe> {
  return { id: 1, title: "Butter Chicken" };
}
```

```
function getRecipe(): Promise<Recipe> {
  return Promise.resolve({
    id: 1,
    title: "Butter Chicken"
  });
}
```

### An important distinction from C\#

In C#, you can write:

```
async Task<Recipe> GetRecipeAsync()
{
    return new Recipe();
}
```

But the compiler warns you that the method has no `await` operator.

In TypeScript:

```
async function getRecipe(): Promise<Recipe> {
  return { id: 1, title: "Butter Chicken" };
}
```

This is perfectly valid, and TypeScript does not issue an equivalent compiler warning.

### Quick question

What happens when we execute this?

```
async function getNumber(): Promise<number> {
  return 42;
}

const result = getNumber();

console.log(result);
```

Does the console print `42`, or does it print a `Promise` object? And why?

### Answer
I think `Promise<number>`?

✅ Correct! More precisely, `console.log(result)` prints a Promise object, not `42`.

`Promise<number>` is the TypeScript type of `result`, while the actual runtime value is a `Promise` object.

```
async function getNumber(): Promise<number> {
  return 42;
}

const result = getNumber();

console.log(result); // Promise object
```

Even though the function returns `42`, the `async` keyword automatically wraps it in a Promise.

## 3. `await` in TypeScript

To retrieve the resolved value, we use `await`:

```
async function main(): Promise<void> {
  const result = await getNumber();

  console.log(result); // 42
}
```

Notice the difference:

```
const a = getNumber();       // Promise<number>
const b = await getNumber(); // number
```

Important: `await` suspends the execution of the surrounding async function until the Promise settles. It does not block the JavaScript thread.

### Quick question

Consider:

```
async function getNumber(): Promise<number> {
  return 42;
}

async function calculate(): Promise<number> {
  const a = getNumber();
  const b = await getNumber();

  return b * 2;
}
```

What are the TypeScript types of `a` and `b`, and what does `calculate()` return when called?

### Answer
```
a => Promise<number>
b => 42
calculate() returns 84.
```

✅ Almost perfect! Your understanding is correct, with one small distinction.

- `a` is `Promise<number>` ✅
- `b` is `number`, with the value `42` ✅
- `calculate()` returns `Promise<number>`, which resolves to `84`.

Remember, because `calculate()` is declared `async`, it always returns a Promise.

```
const result = calculate();       // Promise<number>
const value = await calculate();  // 84
```

## 4. Error handling with `async` / `await`

Just like C#, TypeScript supports `try/catch` for asynchronous operations.

```
async function getRecipe(): Promise<Recipe> {
  throw new Error("Recipe not found");
}

async function main(): Promise<void> {
  try {
    const recipe = await getRecipe();
    console.log(recipe.title);
  } catch (error) {
    console.log("Failed to load recipe");
  }
}
```

An exception thrown inside an `async` function causes its returned Promise to be rejected.

When we `await` that rejected Promise, the rejection becomes an exception that `catch` can handle.

### One important TypeScript difference

With strict TypeScript settings, the `error` variable in a `catch` block has type `unknown`, not necessarily `Error`.

Therefore, this isn't safe:

```
catch (error) {
  console.log(error.message); // TypeScript error
}
```

Instead, use type narrowing:

```
catch (error) {
  if (error instanceof Error) {
    console.log(error.message);
  }
}
```

This builds directly on the type narrowing we covered in W1D1-S3.

### Quick question

What happens here?

```
async function getNumber(): Promise<number> {
  throw new Error("Something went wrong");
}

async function main(): Promise<void> {
  try {
    const result = getNumber();
    console.log("A");
  } catch {
    console.log("B");
  }
}
```

Will it print `A`, `B`, or both? And why?

### Answer
It will print A, because the error is not caught, so it never gets resolved.

✅ Correct! It prints `A`.

One small correction: the Promise does settle, but it settles in the rejected state rather than the fulfilled state.

Here's what happens:

1. `getNumber()` returns a rejected `Promise<number>`.
2. Because there's no `await`, the `try/catch` doesn't catch the rejection.
3. `console.log("A")` executes.
4. The rejection remains unhandled, potentially triggering an unhandled Promise rejection warning or error.

To catch it, we need:

```
try {
  const result = await getNumber();
  console.log("A");
} catch {
  console.log("B");
}
```

Now it prints `B`, because `await` propagates the Promise rejection as an exception.

Before moving on, one final async question:

```
async function getValue(): Promise<number> {
  return 10;
}

async function calculate(): Promise<number> {
  const value = await getValue();
  return value * 3;
}

console.log(calculate());
```

What will `console.log()` print: `30` or a Promise object?

### Answer
Promise object

✅ Correct! `console.log(calculate())` prints a Promise object, which resolves to `30`.

To print `30`, we'd use `await calculate()`.

## 5. `Partial<T>` — TypeScript Utility Types

Now we're moving into utility types, which allow us to create new types from existing ones.

Consider our Recipe Studio model:

```
interface Recipe {
  id: number;
  title: string;
  description: string;
}
```

Suppose we want to update a recipe, but the user only changes its title.

We could define another interface:

```
interface UpdateRecipe {
  id?: number;
  title?: string;
  description?: string;
}
```

However, this duplicates our existing type definition.

Instead, TypeScript provides `Partial<T>`:

```
type UpdateRecipe = Partial<Recipe>;
```

This produces the equivalent of:

```
type UpdateRecipe = {
  id?: number;
  title?: string;
  description?: string;
};
```

`Partial<T>` makes every property of `T` optional.

For example, all of these are valid:

```
const a: Partial<Recipe> = {};

const b: Partial<Recipe> = {
  title: "Butter Chicken"
};

const c: Partial<Recipe> = {
  title: "Butter Chicken",
  description: "Delicious Indian dish"
};
```

One important detail: `Partial<T>` only makes properties optional at the top level. It does not recursively make nested properties optional.

### Quick question

Consider:

```
interface Recipe {
  id: number;
  title: string;
  author: {
    name: string;
    country: string;
  };
}

type UpdateRecipe = Partial<Recipe>;
```

Would the following compile?

```
const update: UpdateRecipe = {
  author: {
    name: "Sanjeev Kapoor"
  }
};
```

Why or why not?

### Answer
No, because even though author is now optional, once you do provide it, you need to provide all the properties of that object.

✅ Exactly correct!

`Partial<T>` is shallow. It makes `author` optional, but if you provide `author`, its required properties must still be present.

Now let's move to the next utility type.

## 6. `Required<T>`

`Required<T>` does the opposite of `Partial<T>`.

It makes all optional properties required.

Consider:

```
interface Recipe {
  id: number;
  title: string;
  description?: string;
  imageUrl?: string;
}
```

Now apply `Required<T>`:

```
type CompleteRecipe = Required<Recipe>;
```

This is equivalent to:

```
type CompleteRecipe = {
  id: number;
  title: string;
  description: string;
  imageUrl: string;
};
```

Notice that `description` and `imageUrl` are no longer optional.

This compiles:

```
const recipe: CompleteRecipe = {
  id: 1,
  title: "Butter Chicken",
  description: "Indian curry",
  imageUrl: "/images/butter-chicken.jpg"
};
```

But this doesn't:

```
const recipe: CompleteRecipe = {
  id: 1,
  title: "Butter Chicken"
};
```

Because `description` and `imageUrl` are now required.

### Quick question

Consider:

```
interface Recipe {
  id: number;
  title?: string;
  author?: {
    name: string;
    country?: string;
  };
}

type CompleteRecipe = Required<Recipe>;
```

Would this compile?

```
const recipe: CompleteRecipe = {
  id: 1,
  title: "Butter Chicken",
  author: {
    name: "Sanjeev Kapoor"
  }
};
```

Why or why not?

### Answer
Well, you did not tell me if Required is also shallow like Partial, but I am going to assume it is, so I think it will compile even though country in author is not provided. But if Required is not shallow, then I think it won't compile.

✅ Absolutely correct! And good reasoning.

Yes, `Required<T>` is also shallow, just like `Partial<T>`.

Your example compiles because:

- `title` becomes required.
- `author` becomes required.
- `author.country` remains optional.

```
type CompleteRecipe = Required<Recipe>;
```

This is equivalent to:

```
type CompleteRecipe = {
  id: number;
  title: string;
  author: {
    name: string;
    country?: string;
  };
};
```

## 7. `Pick<T, K>`

`Pick<T, K>` creates a new type containing only the properties you select from an existing type.

Consider:

```
interface Recipe {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
}
```

Suppose we want a lightweight recipe summary containing only its ID and title.

```
type RecipeSummary = Pick<Recipe, "id" | "title">;
```

This is equivalent to:

```
type RecipeSummary = {
  id: number;
  title: string;
};
```

Notice two things:

1. `Pick` takes two generic arguments: the original type and the property names.
2. It preserves the selected properties' original types and modifiers, including `?` and `readonly`.

For example:

```
type RecipeImage = Pick<Recipe, "title" | "imageUrl">;
```

Here, `imageUrl` remains optional.

### Quick question

What happens here?

```
type RecipePreview = Pick<Recipe, "title" | "author">;
```

Will TypeScript compile this? Why or why not?

### Answer
Well, according to the definition, `Pick<T, K>` creates a new type containing only the properties you select from an existing type.
So I would have assumed it would create new type with the author property not originally present in the Recipe type, but it won't do so. It won't compile.

✅ Correct! And your reasoning is right.

`Pick<T, K>` can only select properties that already exist in `T`. It cannot introduce new properties.

TypeScript enforces this through a generic constraint:

```
type Pick<T, K extends keyof T> = {
  [P in K]: T[P];
};
```

Here, `keyof T` represents the union of all property names in `T`.

For our `Recipe` interface:

```
keyof Recipe
// "id" | "title" | "description" | "imageUrl"
```

Since `"author"` isn't part of that union, TypeScript reports a compilation error.

## 8. `Omit<T, K>`

`Omit<T, K>` is essentially the opposite of `Pick<T, K>`.

- `Pick` selects properties to keep.
- `Omit` selects properties to exclude.

For example:

```
interface Recipe {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
}
```

Suppose we're creating a recipe. The server generates the ID, so the client shouldn't supply it.

```
type CreateRecipe = Omit<Recipe, "id">;
```

This produces:

```
type CreateRecipe = {
  title: string;
  description: string;
  imageUrl?: string;
};
```

We can also omit multiple properties:

```
type RecipeSummary = Omit<Recipe, "description" | "imageUrl">;
```

That leaves `id` and `title`.

### An interesting difference

Unlike `Pick<T, K>`, TypeScript's built-in `Omit<T, K>` does not require `K` to be a key of `T`.

Therefore, this is valid:

```
type CreateRecipe = Omit<Recipe, "id" | "author">;
```

Even though `author` doesn't exist, TypeScript simply excludes `id` and keeps the remaining properties.

### Quick question

What properties will this type contain?

```
type RecipeCard = Omit<
  Recipe,
  "description" | "imageUrl" | "author"
>;
```

And will TypeScript report a compilation error?

### Answer
`id, title`

✅ Correct! `RecipeCard` will contain only `id` and `title`.

And TypeScript will not report a compilation error, even though `author` doesn't exist in `Recipe`.

## 9. `Record<TKey, TValue>`

`Record<K, V>` creates an object type where:

- `K` defines the allowed property keys.
- `V` defines the type of each property's value.

For example:

```
type RecipeRatings = Record<string, number>;
```

This is equivalent to an object with string keys and numeric values:

```
const ratings: RecipeRatings = {
  "Butter Chicken": 5,
  "Biryani": 4,
  "Pasta": 3
};
```

### Restricting the keys

The interesting part is that keys don't have to be arbitrary strings.

```
type RecipeStatus = "draft" | "published" | "archived";

type StatusLabels = Record<RecipeStatus, string>;
```

Now TypeScript expects exactly those three properties:

```
const labels: StatusLabels = {
  draft: "Draft Recipe",
  published: "Published Recipe",
  archived: "Archived Recipe"
};
```

If we omit `archived`, TypeScript reports an error because `Record` requires all keys in the specified union.

### Comparison with C\#

Conceptually, `Record<string, number>` resembles:

```
Dictionary<string, int>
```

However, `Record` is a TypeScript type for JavaScript objects, not a runtime dictionary implementation. Unlike a C# `Dictionary`, it doesn't provide methods such as `Add()` or `Remove()`.

### Quick question

Consider:

```
type RecipeLanguage = "en" | "de" | "hi";

type RecipeTranslations = Record<RecipeLanguage, string>;
```

Will this compile?

```
const translations: RecipeTranslations = {
  en: "Butter Chicken",
  de: "Butterhähnchen"
};
```

Why or why not?

### Answer
I am not sure what will happen if we provide extra keys not in the union, but no, this won't compile because Record requires all keys in the specified union.

✅ Correct! The code won't compile because the `hi` property is missing.

And good question about extra keys!

Consider:

```
type RecipeLanguage = "en" | "de" | "hi";

type RecipeTranslations = Record<RecipeLanguage, string>;

const translations: RecipeTranslations = {
  en: "Butter Chicken",
  de: "Butterhähnchen",
  hi: "बटर चिकन",
  fr: "Poulet au beurre"
};
```

This also fails to compile, because `fr` isn't one of the allowed keys.

So, when assigning an object literal directly to `Record<RecipeLanguage, string>`, TypeScript enforces both:

1. All keys in the union must be present.
2. No unexpected keys are allowed.

One subtlety: TypeScript's excess-property checking is stricter for fresh object literals. An existing variable with additional properties can still be assignable to the `Record` type.

## W1D1-S5 — Final Check

We've now covered all seven topics:

- `Promise<T>`, `async`, `await`
- `Partial<T>`, `Required<T>`
- `Pick<T>`, `Omit<T>`
- `Record<TKey, TValue>`

Let's finish with one practical question combining utility types.

```
interface Recipe {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
}
```

Suppose we want to create a type for updating a recipe, where:

- `id` must not be included.
- All other properties should be optional.

How would you define `UpdateRecipe` using `Omit` and `Partial` together?

### Answer
```
interface Recipe {
  title?: string;
  description?: string;
  imageUrl?: string;
}

type Omitted = Omit<Recipe, "id">
type UpdateRecipe = Partial<Omitted, "title", "description">
```
I am guessing since imageUrl is already partial, it will stay partial, and no need to unnecessarily include it in partial.

You're very close! Your reasoning about `imageUrl` is correct, but there are two issues with your implementation.

### 1. `Partial<T>` accepts only one generic argument

This won't compile:

```
Partial<Omitted, "title", "description">
```

Unlike `Pick<T, K>` and `Omit<T, K>`, `Partial<T>` doesn't accept property names. It automatically makes all properties optional.

### 2. You unnecessarily redefined `Recipe`

You should retain the original interface, where `id`, `title`, and `description` are required.

### Correct solution

```
interface Recipe {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
}

type UpdateRecipe = Partial<Omit<Recipe, "id">>;
```

Here's what happens:

1. `Omit<Recipe, "id">` removes `id`.
2. `Partial<...>` makes all remaining properties optional.
3. `imageUrl` was already optional, so it simply remains optional.

The resulting type is:

```
type UpdateRecipe = {
  title?: string;
  description?: string;
  imageUrl?: string;
};
```

Your intuition about not needing to make `imageUrl` optional again was right. However, applying `Partial` to an already optional property doesn't cause any problems.

### Final question

Would reversing the order work?

```
type UpdateRecipe = Omit<Partial<Recipe>, "id">;
```

Would this produce the same type as our previous solution?

### Answer
Yes!

✅ Correct! Both produce exactly the same type.

```
type UpdateRecipe = Partial<Omit<Recipe, "id">>;
type UpdateRecipe = Omit<Partial<Recipe>, "id">;
```

In this case, the order doesn't matter.

- The first removes `id`, then makes everything optional.
- The second makes everything optional, then removes `id`.

## W1D1-S5 — Completed! ✅

You've covered all seven topics, including combining utility types to model API request contracts.

Next: W1D1-S6 — Modules and Runtime Reality

We'll cover `import`, `export`, ES modules, and why TypeScript types don't provide runtime validation.