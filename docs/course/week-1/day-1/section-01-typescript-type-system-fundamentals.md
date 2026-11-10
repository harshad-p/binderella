# W1D1-S1 — TypeScript Type-System Fundamentals

## 1. Type inference

Because you come from C#, the easiest mental model is:

```csharp
var name = "Binderella";
```

C# knows that `name` is a `string`, even though you didn't explicitly write:

```csharp
string name = "Binderella";
```

TypeScript does essentially the same thing.

```typescript
let name = "Binderella";
```

TypeScript examines the assigned value and **infers**:

```typescript
name: string
```

So this is valid:

```typescript
let name = "Binderella";

name = "Recipe Studio";
```

But this is not:

```typescript
let name = "Binderella";

name = 42;
```

TypeScript reports an error because it already inferred `name` to be a `string`.

---

## `const` also uses inference

```typescript
const recipeCount = 10;
const isPublished = true;
const title = "Butter Chicken";
```

TypeScript understands their types without us writing:

```typescript
const recipeCount: number = 10;
const isPublished: boolean = true;
const title: string = "Butter Chicken";
```

This is one of the main ideas behind TypeScript:

> You get static typing without having to explicitly type everything.

In production TypeScript, you normally **let TypeScript infer obvious types**.

For example, this:

```typescript
const recipeName: string = "Butter Chicken";
```

is usually unnecessarily verbose.

Prefer:

```typescript
const recipeName = "Butter Chicken";
```

The type information is identical for our purposes.

---

## Important difference from JavaScript

This looks like ordinary JavaScript:

```typescript
let servings = 4;
```

But TypeScript's compiler now knows something JavaScript itself does not enforce:

```typescript
servings = "four";
```

produces a compile-time error.

The generated JavaScript does **not** contain the TypeScript type system. Types exist primarily while TypeScript analyzes/compiles your code.

We'll return to that distinction in **W1D1-S6**, because it becomes extremely important when consuming API data.

---

## C# mental mapping

You can roughly think of:

```typescript
let count = 5;
```

as:

```csharp
var count = 5;
```

and:

```typescript
let count: number = 5;
```

as:

```csharp
int count = 5;
```

There are important differences between C# and TypeScript's type systems, but this mapping is good enough for now.

---

## Quick check

What do you think TypeScript infers for each variable?

```typescript
const title = "Pasta";

let servings = 4;

let published = false;

const ingredients = ["Pasta", "Tomato", "Cheese"];
```

Try answering with the inferred types only.

## Answer
- string
- int
- boolean
- array or object

---

Good! 3 out of 4 correct. Two important TypeScript distinctions:

| Variable      | Your answer     | TypeScript type |
| ------------- | --------------- | --------------- |
| `title`       | string          | `string` ✅      |
| `servings`    | int             | `number`        |
| `published`   | boolean         | `boolean` ✅     |
| `ingredients` | array or object | `string[]`      |

Unlike C#, TypeScript doesn't distinguish between `int`, `float`, and `double`. All ordinary numeric values use `number`.

For arrays, TypeScript infers the element type too. So `["Pasta", "Tomato"]` becomes `string[]`, not just `array`.

## 2. Explicit type annotations

Sometimes we want to tell TypeScript what a variable's type should be rather than letting it infer one.

We use the `:` syntax:

```
let recipeName: string = "Butter Chicken";
let servings: number = 4;
let published: boolean = false;
```

This is especially useful when a variable doesn't have an initial value:

```
let recipeName: string;

recipeName = "Butter Chicken";
```

Or when we want to allow multiple possible types:

```
let recipeId: string | number;

recipeId = 123;
recipeId = "recipe-123";
```

We'll explore union types in detail shortly.

### Quick question

Consider:

```
let recipeId = 123;
recipeId = "recipe-123";
```

Question: Will TypeScript accept this? If not, how would you modify the declaration to allow both values?

### Answer
No, it won't accept. 
I would do this: let recipe : number | string

---

Correct! ✅

Just keep the variable name consistent:

```
let recipeId: number | string;

recipeId = 123;          // Valid
recipeId = "recipe-123"; // Valid
recipeId = true;         // Error
```

One important distinction: `number | string` is a union type, meaning the variable can hold either type.

We'll explore unions more deeply later in this section.

## 3. Primitive types

TypeScript has several primitive types:

| Type        | Example        | C# equivalent         |
| ----------- | -------------- | --------------------- |
| `string`    | `"Pasta"`      | `string`              |
| `number`    | `42`, `3.14`   | `int`, `double`, etc. |
| `boolean`   | `true`         | `bool`                |
| `bigint`    | `123n`         | Roughly `BigInteger`  |
| `symbol`    | `Symbol("id")` | No direct equivalent  |
| `undefined` | `undefined`    | No direct equivalent  |
| `null`      | `null`         | `null`                |

Two particularly important JavaScript/TypeScript values are `null` and `undefined`.

- `null` usually represents an intentionally absent value.
- `undefined` usually means a value hasn't been provided or assigned.

Unlike C#, TypeScript distinguishes between them.

### Quick question

What happens here?

```
let servings: number = 4;

servings = null;
```

Assume TypeScript's `strictNullChecks` option is enabled.

Will TypeScript accept this assignment? Why or why not?

### Answer
I am guessing no. Idk what strictNullChecks is.

Correct! ✅ TypeScript will reject the assignment.

```
let servings: number = 4;

servings = null; // Compile-time error
```

## What is `strictNullChecks`?

`strictNullChecks` is a TypeScript compiler option that controls whether `null` and `undefined` are treated as distinct types.

### When `strictNullChecks` is enabled

A variable declared as `number` can hold only numbers, not `null` or `undefined`.

```
let servings: number = 4;

servings = null;      // Error
servings = undefined; // Error
```

If you want to allow `null`, you must explicitly declare it:

```
let servings: number | null = 4;

servings = null; // Valid
```

This is similar to nullable value types in C#:

```
int? servings = 4;
servings = null;
```

### When `strictNullChecks` is disabled

TypeScript allows this:

```
let servings: number = 4;

servings = null;      // Allowed
servings = undefined; // Allowed
```

This is dangerous because you might later perform an operation assuming the variable contains a number.

Production recommendation: Keep `strictNullChecks` enabled. It's also enabled automatically when TypeScript's `strict` compiler option is enabled, unless explicitly overridden.

### Quick question

Consider the following code with `strictNullChecks` enabled:

```
let recipeName: string | null = null;

recipeName = "Butter Chicken";

recipeName = undefined;
```

Will TypeScript accept all three statements? If not, which one fails, and why?

### Answer
```
recipeName = undefined;
```

fails because strictNullChecks is enabled, and it can be fised by adding | undefined to recipeName.

Exactly right! ✅

```
let recipeName: string | null | undefined = null;

recipeName = "Butter Chicken"; // Valid
recipeName = null;             // Valid
recipeName = undefined;        // Valid
```

One subtle point: `strictNullChecks` doesn't prohibit `null` or `undefined`. It simply requires you to explicitly include them in the type when they are allowed.

## 4. Object types

In TypeScript, we can describe an object's structure directly.

```
let recipe: {
    id: number;
    title: string;
    servings: number;
    published: boolean;
};

recipe = {
    id: 1,
    title: "Butter Chicken",
    servings: 4,
    published: true
};
```

Unlike C#, TypeScript primarily uses structural typing.

This means TypeScript checks whether an object has the required properties with compatible types, rather than requiring it to be an instance of a particular named class.

For example:

```
let recipe: {
    title: string;
    servings: number;
};

const dinner = {
    title: "Pasta",
    servings: 2,
    category: "Italian"
};

recipe = dinner; // Valid
```

Even though `dinner` has an additional `category` property, it satisfies the required structure.

However, there's an interesting distinction when assigning an object literal directly.

### Quick question

Will TypeScript accept this?

```
let recipe: {
    title: string;
    servings: number;
};

recipe = {
    title: "Pasta",
    servings: 2,
    category: "Italian"
};
```

Notice that we're assigning an object literal directly rather than assigning an existing variable.

What do you think happens?

### Answer
It won't accept. This is creating an object using a structure which does not have the additional category property.

Correct! ✅ TypeScript rejects this assignment.

The error is:

```
Object literal may only specify known properties,
and 'category' does not exist in the declared type.
```

This behavior is called excess property checking.

### Why does TypeScript behave differently?

Compare these two examples.

Example 1 — Direct object literal

```
let recipe: {
    title: string;
    servings: number;
};

recipe = {
    title: "Pasta",
    servings: 2,
    category: "Italian" // Error
};
```

TypeScript applies excess property checking to the fresh object literal.

Example 2 — Existing variable

```
const dinner = {
    title: "Pasta",
    servings: 2,
    category: "Italian"
};

recipe = dinner; // Valid
```

Here, TypeScript uses structural compatibility. The `dinner` object contains everything required by `recipe`, so the assignment succeeds.

Important: Excess property checking is an additional safeguard, not a general rule that objects cannot contain extra properties.

## 5. Union types

We've already encountered unions:

```
let recipeId: number | string;
```

A union represents a value that can be one of several types.

Consider a function:

```
function printRecipeId(id: number | string) {
    console.log(id);
}
```

Both calls are valid:

```
printRecipeId(123);
printRecipeId("recipe-123");
```

However, there's something important about working with union types.

### Quick question

Consider:

```
function formatRecipeId(id: number | string) {
    return id.toUpperCase();
}
```

Will TypeScript accept this function?

If not, why? And how would you fix it?

### Answer
As far as I remember, it won't accept. It will check if the function definition is valid for both the types. 

Exactly right! ✅

TypeScript only allows operations that are valid for every possible type in the union.

```
function formatRecipeId(id: number | string) {
    return id.toUpperCase(); // Error
}
```

`toUpperCase()` exists on `string`, but not on `number`.

### How do we fix it?

We use type narrowing:

```
function formatRecipeId(id: number | string) {
    if (typeof id === "string") {
        return id.toUpperCase();
    }

    return id.toString();
}
```

Inside the `if` block, TypeScript knows `id` is a `string`. Outside that block, after the `return`, it knows `id` must be a `number`.

We'll cover type narrowing in greater detail in W1D1-S3.

## 6. Intersection types

A union (`|`) means a value can satisfy one type or another.

An intersection (`&`) means a value must satisfy both types simultaneously.

Consider:

```
type Recipe = {
    id: number;
    title: string;
};

type Auditable = {
    createdAt: Date;
    updatedAt: Date;
};

type AuditableRecipe = Recipe & Auditable;
```

An `AuditableRecipe` must contain all four properties:

```
const recipe: AuditableRecipe = {
    id: 1,
    title: "Butter Chicken",
    createdAt: new Date(),
    updatedAt: new Date()
};
```

This is particularly useful when combining reusable structures, such as API models that share audit information.

### Quick question

Will TypeScript accept the following?

```
type Recipe = {
    id: number;
    title: string;
};

type Published = {
    published: boolean;
};

type PublishedRecipe = Recipe & Published;

const recipe: PublishedRecipe = {
    id: 1,
    title: "Pasta"
};
```

If not, why?

### Answer
I think it will accept. The other "published" property is just not initialized, and is available.

Not quite! ❌ This is an important distinction in TypeScript.

An intersection (`&`) requires all properties from both types to be present.

```
type PublishedRecipe = Recipe & Published;
```

This means `PublishedRecipe` requires:

- `id: number`
- `title: string`
- `published: boolean`

Therefore, this fails:

```
const recipe: PublishedRecipe = {
    id: 1,
    title: "Pasta"
    // Error: Property 'published' is missing
};
```

The correct version is:

```
const recipe: PublishedRecipe = {
    id: 1,
    title: "Pasta",
    published: false
};
```

Notice that `false` is perfectly valid. TypeScript only requires the property to exist and contain a `boolean`.

## Quick follow-up

What if we change the `Published` type to:

```
type Published = {
    published?: boolean;
};
```

Would TypeScript now accept this?

```
const recipe: Recipe & Published = {
    id: 1,
    title: "Pasta"
};
```

And what do you think the `?` means?

### Answer
I think it will accept now. I don't know if it is the same as the null coalescing operator in C#, but here I think it should allow you not providing the value to that property.

Correct! ✅ TypeScript will accept it.

```
type Published = {
    published?: boolean;
};
```

The `?` makes the property optional. You can omit it entirely.

```
const recipe: Recipe & Published = {
    id: 1,
    title: "Pasta"
}; // Valid
```

### Is `?` the same as C#'s null-coalescing operator?

No. There are three different concepts worth distinguishing:

| Syntax                        | Meaning                                             |
| ----------------------------- | --------------------------------------------------- |
| `published?: boolean`         | Property is optional                                |
| `published: boolean \\| null` | Property is required but can contain `null`         |
| `published ?? false`          | Use `false` if `published` is `null` or `undefined` |

The last one, `??`, is equivalent to C#'s null-coalescing operator.

One important detail: with `strictNullChecks` enabled, reading an optional `boolean` property gives you `boolean | undefined`.

For example:

```
console.log(recipe.published); // undefined
```

We'll explore optional properties more deeply in W1D1-S2.

## 7. Literal types

Normally, a `string` variable can contain any string:

```
let status: string = "draft";

status = "published"; // Valid
status = "banana";    // Also valid
```

But what if Recipe Studio should only allow three statuses?

TypeScript lets us restrict values using literal types:

```
type RecipeStatus = "draft" | "published" | "archived";

let status: RecipeStatus = "draft";

status = "published"; // Valid
status = "banana";    // Error
```

This resembles a C# enum, although TypeScript literal unions work differently under the hood.

### Quick question

Consider:

```
type ServingSize = 1 | 2 | 4 | 6;

let servings: ServingSize = 4;

servings = 3;
```

Will TypeScript accept the final assignment? Why or why not?

### Answer
I don't think it will. 3 is not a value defined in the definiton of ServingSize.

Correct! ✅

```
type ServingSize = 1 | 2 | 4 | 6;

let servings: ServingSize = 4;

servings = 3; // Compile-time error
```

`ServingSize` is a union of numeric literal types, so only `1`, `2`, `4`, or `6` are allowed.

This is useful when your application has a fixed set of permitted values.

We've now covered all the topics in W1D1-S1, including strict null checking, which we encountered earlier.

## Final knowledge check

Consider this TypeScript code with `strictNullChecks` enabled:

```
type RecipeStatus = "draft" | "published";

type Recipe = {
    id: number;
    title: string;
    status: RecipeStatus;
    description?: string;
};

const recipe: Recipe = {
    id: 1,
    title: "Pasta",
    status: "draft"
};

recipe.status = "archived";
recipe.description = null;
```

Two questions:

1. Will TypeScript accept `recipe.status = "archived"`?
2. Will TypeScript accept `recipe.description = null`?

Explain why for each. After this check, we'll move to W1D1-S2 — TypeScript Object Modelling.

### Answer
1. No. Because "archived" is not among the literal string values in the definition.&#x20;
2. Yes. The "?" makes the property of type: string | null since strictNullChecks is enabled.

1\. Correct! ✅

`"archived"` is not part of the `RecipeStatus` literal union, so TypeScript rejects it.

2\. Almost! ❌

You're correct that `?` makes the property optional, but it does not make it nullable.

With `strictNullChecks` enabled:

```
type Recipe = {
    description?: string;
};
```

Reading `description` gives you the type:

```
string | undefined
```

Not:

```
string | null
```

Therefore:

```
recipe.description = "Delicious pasta"; // Valid
recipe.description = undefined;         // Valid by default
recipe.description = null;              // Error
```

To explicitly allow `null`, declare:

```
type Recipe = {
    description?: string | null;
};
```

Now the property can be omitted, contain a string, or contain `null`.

One additional detail: TypeScript has an `exactOptionalPropertyTypes` compiler option that, when enabled, distinguishes omitting an optional property from explicitly assigning `undefined`. We'll revisit this when studying optional properties.

W1D1-S1 — Completed! ✅

We've covered all eight topics in this section.