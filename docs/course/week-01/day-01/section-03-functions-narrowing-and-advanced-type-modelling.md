# W1D1-S3 — Functions, Narrowing, and Advanced Type Modelling

This section has four topics:

1. Function types
2. Callback types
3. Type narrowing
4. Discriminated unions CURRICULUM

We’ll take them one at a time.

## 3.1 — Function Types

You already know methods and delegates from C#, so the key TypeScript idea is:

> A function itself has a type.

Consider:

```ts
function add(a: number, b: number): number {
  return a + b;
}
```

The type of `add` is effectively:

```ts
(a: number, b: number) => number
```

That describes:

- two parameters
- both are `number`
- the function returns a `number`

### Storing a function in a variable

```ts
let operation: (a: number, b: number) => number;

operation = add;
```

This works because `add` satisfies the required function type.

But this does not:

```ts
function greet(name: string): string {
  return `Hello ${name}`;
}

operation = greet;
```

`greet` has the wrong signature.

---

## C# mental mapping

This:

```ts
let operation: (a: number, b: number) => number;
```

is conceptually similar to:

```csharp
Func<int, int, int> operation;
```

The big difference is that TypeScript writes the function signature directly rather than using something like `Func<T1, T2, TResult>`.

```ts
(a: number, b: number) => number
```

Read it as:

> "A function taking two numbers and returning a number."

---

## Return types

TypeScript can infer return types:

```ts
function multiply(a: number, b: number) {
  return a * b;
}
```

TypeScript knows the return type is `number`.

You can still explicitly specify it:

```ts
function multiply(a: number, b: number): number {
  return a * b;
}
```

For public APIs and important application functions, explicit return types can often make intent clearer.

---

## `void`

Functions that do not return a meaningful value use `void`:

```ts
function logRecipe(title: string): void {
  console.log(title);
}
```

Function type:

```ts
(title: string) => void
```

For example:

```ts
let logger: (message: string) => void;

logger = message => {
  console.log(message);
};
```

This pattern will become extremely common once we reach Angular events and React callback props.

---

## Type aliases for function types

If a function signature is reused, give it a name:

```ts
type MathOperation = (a: number, b: number) => number;

const add: MathOperation = (a, b) => {
  return a + b;
};

const subtract: MathOperation = (a, b) => {
  return a - b;
};
```

Notice something useful:

```ts
const add: MathOperation = (a, b) => ...
```

We didn't write:

```ts
a: number
b: number
```

again.

Because the function is contextually typed by `MathOperation`, TypeScript already knows that `a` and `b` are numbers.

This is called **contextual typing**.

---

## Recipe Studio example

Suppose we want different ways to format a recipe title:

```ts
type TitleFormatter = (title: string) => string;

const uppercaseTitle: TitleFormatter = title =>
  title.toUpperCase();

const prefixTitle: TitleFormatter = title =>
  `Recipe: ${title}`;
```

Now another function could accept any `TitleFormatter`:

```ts
function formatRecipeTitle(
  title: string,
  formatter: TitleFormatter
): string {
  return formatter(title);
}
```

Usage:

```ts
formatRecipeTitle("Butter Chicken", uppercaseTitle);
```

Result:

```text
BUTTER CHICKEN
```

That last example is already beginning to lead us into **callback types**, which is our next topic.

## Your exercise

Without running anything yet, determine which assignments TypeScript should accept:

```ts
type RecipeFormatter =
  (title: string, servings: number) => string;

const formatter1 = (
  title: string,
  servings: number
): string => `${title} serves ${servings}`;

const formatter2 = (
  title: string
): string => title.toUpperCase();

const formatter3 = (
  title: string,
  servings: string
): string => `${title}: ${servings}`;

const formatter4 = (
  title: string,
  servings: number
): number => servings;

let formatter: RecipeFormatter;

formatter = formatter1;
formatter = formatter2;
formatter = formatter3;
formatter = formatter4;
```

Tell me which of the four assignments you think compile and why. Then we'll move to **3.2 — Callback Types**.

### Answer
Only formatter1 will compile because it matches the function definition of parameters and return types, and the number of params.

Almost! Both `formatter1` and `formatter2` compile.

| Function     | Compiles? | Reason                                                                  |
| ------------ | --------- | ----------------------------------------------------------------------- |
| `formatter1` | Yes       | Parameters and return type match.                                       |
| `formatter2` | Yes       | A function can accept fewer parameters than its declared function type. |
| `formatter3` | No        | `servings` expects `number`, but receives `string`.                     |
| `formatter4` | No        | Returns `number` instead of `string`.                                   |

### Why does `formatter2` compile?

Consider:

```
type RecipeFormatter =
  (title: string, servings: number) => string;

const formatter2 = (title: string): string =>
  title.toUpperCase();

let formatter: RecipeFormatter = formatter2;

formatter("Butter Chicken", 4);
```

JavaScript allows functions to receive more arguments than they declare. The extra arguments are simply ignored.

In this case, `formatter2` only needs `title`, so it ignores `servings`.

The key rule: A function accepting fewer parameters can be assigned to a function type expecting more parameters, provided the types of the parameters it does accept are compatible and the return type is compatible.

This is particularly useful for callbacks, where frameworks often provide more arguments than your function needs.

For example:

```
const numbers = [1, 2, 3];

numbers.forEach(number => {
  console.log(number);
});
```

`forEach` provides three arguments to its callback (`value`, `index`, and `array`), but we're free to use only one.

### Quick follow-up question

Would the reverse compile?

```
type SimpleFormatter = (title: string) => string;

const formatter = (
  title: string,
  servings: number
): string => `${title} serves ${servings}`;

const simple: SimpleFormatter = formatter;
```

Yes or no? And why?

This distinction is worth understanding before we move to 3.2 — Callback Types.

### Answer
I think in this case it would not compile. I confused the previous scenario with something like this current one.

Correct! ✅

The code will not compile because `SimpleFormatter` promises that the function can be called with just one argument (`title`).

However, the assigned function requires two arguments (`title` and `servings`).

TypeScript cannot guarantee that `servings` will be provided.

The important distinction is:

- Fewer parameters: Allowed, because extra arguments can be ignored.
- More required parameters: Not allowed, because the function might receive insufficient arguments.

You've understood the distinction correctly.

## 3.2 Callback Types

A callback is simply a function passed as an argument to another function, which can invoke it.

In C#, you're already familiar with this through delegates and `Action<T>` or `Func<T>`.

For example, in Recipe Studio:

```
type RecipeCallback = (recipeId: number) => void;

function deleteRecipe(
  recipeId: number,
  onDeleted: RecipeCallback
): void {
  console.log(`Deleting recipe ${recipeId}`);

  onDeleted(recipeId);
}
```

Usage:

```
deleteRecipe(42, id => {
  console.log(`Recipe ${id} deleted`);
});
```

Here, `onDeleted` is a callback. Notice that its type describes the function signature, not the result of calling it.

### A callback with a return value

Callbacks can also return values:

```
type RecipePredicate = (title: string) => boolean;

function filterRecipes(
  titles: string[],
  predicate: RecipePredicate
): string[] {
  return titles.filter(predicate);
}
```

Usage:

```
const titles = ["Pasta", "Butter Chicken", "Pizza"];

const results = filterRecipes(
  titles,
  title => title.startsWith("P")
);
```

`results` contains `"Pasta"` and `"Pizza"`.

### Your turn

Consider:

```
type RecipeCallback = (id: number) => void;

function processRecipe(
  id: number,
  callback: RecipeCallback
): void {
  callback(id);
}

processRecipe(42, id => {
  return id * 2;
});
```

Will TypeScript compile this, even though the callback returns a `number` while `RecipeCallback` declares `void`?

Think about the difference between a function returning nothing and a caller ignoring its return value.

### Answer
I think it should compile, because for the caller, they think this callback is a void return type. So they won't bother grabbing the returned value. So I think TS will allow this.

Exactly right! ✅

TypeScript allows a function returning `number` to be assigned to a callback type returning `void`.

```
type RecipeCallback = (id: number) => void;
```

Here, `void` means the caller should not rely on the return value, not necessarily that the function returns nothing.

One subtle distinction:

```
const callback: RecipeCallback = id => id * 2; // ✅

const result = callback(42); // result is typed as void
```

Even though the implementation returns a number at runtime, TypeScript treats `result` as `void`.

This behavior is especially useful for event handlers in Angular and React.

## 3.3 Type Narrowing

Type narrowing is how TypeScript determines a more specific type based on runtime checks.

Consider:

```
function printRecipeId(id: string | number): void {
  console.log(id.toUpperCase()); // ❌
}
```

TypeScript rejects this because `number` doesn't have `toUpperCase()`.

We can narrow the type using `typeof`:

```
function printRecipeId(id: string | number): void {
  if (typeof id === "string") {
    console.log(id.toUpperCase());
  } else {
    console.log(id.toFixed(2));
  }
}
```

Inside the `if` block, TypeScript knows `id` is a `string`. Inside the `else` block, it knows `id` is a `number`.

Unlike C#, TypeScript uses control-flow analysis to track these refinements throughout the code.

### Common narrowing techniques

| Technique       | Example                     | Use case               |
| --------------- | --------------------------- | ---------------------- |
| `typeof`        | `typeof value === "string"` | Primitive types        |
| `instanceof`    | `value instanceof Date`     | Class instances        |
| `in`            | `"email" in user`           | Object properties      |
| Equality        | `value === null`            | Specific values        |
| Type predicates | `value is Recipe`           | Custom narrowing logic |

We'll examine type predicates after a quick exercise.

### Your turn

What happens here?

```
function formatValue(value: string | number | null): string {
  if (typeof value === "string") {
    return value.toUpperCase();
  }

  if (value === null) {
    return "No value";
  }

  return value.toFixed(2);
}
```

Question: What type does TypeScript infer for `value` at the final `return` statement, and why?

### Answer
number. Because string and null value checks were already performed, and according to the function signature, the only type remaining is number.

Correct! ✅

TypeScript's control-flow analysis recognizes that both `string` and `null` have already been handled by branches that return from the function.

Therefore, at the final statement:

```
return value.toFixed(2);
```

`value` is guaranteed to be a `number`.

An important detail: TypeScript doesn't just narrow types inside `if` blocks. It also tracks which types remain possible after branches that terminate execution.

## 3.3.1 — Custom Type Guards (Type Predicates)

Sometimes `typeof`, `instanceof`, and `in` aren't sufficient.

Suppose Recipe Studio has this model:

```
interface Recipe {
  id: number;
  title: string;
}
```

We receive a value whose type is `unknown`:

```
function processRecipe(value: unknown): void {
  console.log(value.title); // ❌ Compile error
}
```

Unlike `any`, `unknown` forces us to verify the value before accessing its properties.

We can write a custom type guard:

```
function isRecipe(value: unknown): value is Recipe {
  return (
    typeof value === "object" &&
    value !== null &&
    "id" in value &&
    typeof value.id === "number" &&
    "title" in value &&
    typeof value.title === "string"
  );
}
```

Notice the return type:

```
value is Recipe
```

This is a type predicate. It tells TypeScript:

> If this function returns `true`, treat `value` as a `Recipe`.

Now:

```
function processRecipe(value: unknown): void {
  if (isRecipe(value)) {
    console.log(value.title.toUpperCase()); // ✅
  }
}
```

Inside the `if`, TypeScript narrows `value` from `unknown` to `Recipe`.

### Important distinction

The type predicate doesn't automatically validate anything. Our implementation must actually perform the checks.

For example, this compiles but is dangerous:

```
function isRecipe(value: unknown): value is Recipe {
  return true;
}
```

TypeScript trusts the predicate even though the implementation is incorrect.

### Quick question

What's the difference between these two approaches?

```
// Approach A
const recipe = value as Recipe;

// Approach B
if (isRecipe(value)) {
  const recipe = value;
}
```

Specifically, which approach performs runtime checks, and which one merely tells TypeScript to trust us?

Once we've covered this, we'll move to 3.4 — Discriminated Unions.

### Answers
Approach A just says to trust the value as Recipe by maybe type-casting it like in C#? 
Approach B is a better approach for runtime.

Correct! ✅ Both observations are right.

Approach A — Type Assertion (`as Recipe`)

```
const recipe = value as Recipe;
```

This tells TypeScript to trust you. It performs no runtime validation.

One important difference from C#: Unlike a C# cast, TypeScript's `as` assertion does not perform a runtime cast or conversion. It disappears when TypeScript is compiled into JavaScript.

Approach B — Type Guard (`isRecipe`)

```
if (isRecipe(value)) {
  const recipe = value;
}
```

This actually executes runtime checks, assuming `isRecipe()` is implemented correctly.

For untrusted data, such as API responses, Approach B is safer.

## 3.4 Discriminated Unions

This is one of TypeScript's most useful features for modelling application state.

Imagine Recipe Studio has three possible states when loading a recipe:

- Loading
- Successfully loaded
- Failed

A naive model might look like this:

```
interface RecipeState {
  loading: boolean;
  recipe?: Recipe;
  error?: string;
}
```

The problem is that this allows contradictory states:

```
const state: RecipeState = {
  loading: true,
  recipe: { id: 1, title: "Pasta" },
  error: "Something went wrong"
};
```

All three conditions can coexist, even though that doesn't make sense for our application.

### Discriminated union solution

```
type RecipeState =
  | { status: "loading" }
  | { status: "success"; recipe: Recipe }
  | { status: "error"; message: string };
```

Here, `status` is called the discriminant.

Each possible value of `status` corresponds to a specific object structure.

```
function displayRecipe(state: RecipeState): void {
  switch (state.status) {
    case "loading":
      console.log("Loading...");
      break;

    case "success":
      console.log(state.recipe.title);
      break;

    case "error":
      console.log(state.message);
      break;
  }
}
```

TypeScript automatically narrows `state` based on `status`.

Inside `"success"`, it knows that `recipe` exists. Inside `"error"`, it knows that `message` exists.

Unlike the earlier interface, this model makes invalid combinations impossible to represent without bypassing the type system.

### Your exercise

Consider:

```
type SaveResult =
  | { status: "success"; recipeId: number }
  | { status: "validation-error"; errors: string[] }
  | { status: "server-error"; statusCode: number };

function handleResult(result: SaveResult): void {
  if (result.status === "success") {
    console.log(result.recipeId);
  } else {
    console.log(result.errors);
  }
}
```

Question: Will this compile? If not, why?

Think about what TypeScript knows about `result` inside the `else` block.

### Answer
No, it won't compile. There are still 2 states remaining, and there is ambiguity whether status is "validation-error" or "server-error".

Correct! ✅

Inside the `else` block, TypeScript narrows `result` to:

```
{ status: "validation-error"; errors: string[] }
  | { status: "server-error"; statusCode: number }
```

Since `server-error` doesn't have an `errors` property, accessing `result.errors` causes a compile-time error.

We can fix it with a `switch`:

```
function handleResult(result: SaveResult): void {
  switch (result.status) {
    case "success":
      console.log(result.recipeId);
      break;

    case "validation-error":
      console.log(result.errors);
      break;

    case "server-error":
      console.log(result.statusCode);
      break;
  }
}
```

### 3.4.1 — Exhaustiveness Checking with `never`

There's one more powerful technique worth learning.

Suppose we introduce a fourth status in the future:

```
type SaveResult =
  | { status: "success"; recipeId: number }
  | { status: "validation-error"; errors: string[] }
  | { status: "server-error"; statusCode: number }
  | { status: "unauthorized" };
```

Our existing `switch` would still compile, even though it doesn't handle `"unauthorized"`.

We can make TypeScript detect missing cases using `never`:

```
function handleResult(result: SaveResult): void {
  switch (result.status) {
    case "success":
      console.log(result.recipeId);
      break;

    case "validation-error":
      console.log(result.errors);
      break;

    case "server-error":
      console.log(result.statusCode);
      break;

    default:
      const exhaustiveCheck: never = result;
      throw new Error("Unhandled result");
  }
}
```

Because `"unauthorized"` hasn't been handled, TypeScript reports an error at:

```
const exhaustiveCheck: never = result;
```

Why?

`never` represents a value that should be impossible.

If we've handled every possible member of the union, TypeScript narrows `result` to `never` in the `default` branch.

If an unhandled member remains, assigning it to `never` fails.

This is particularly valuable in production applications because adding a new state can immediately reveal code that needs updating.

### Final S3 question

If we add:

```
case "unauthorized":
  console.log("Please log in");
  break;
```

Will the `never` assignment in the `default` branch compile now? And why?

This is our final concept check before completing W1D1-S3.

### Answer
Of course! It is just guarding in case there is any new values that are not handled.

Exactly! ✅

Once every possible status has been handled, TypeScript narrows `result` to `never` in the `default` branch, so the assignment compiles.

And if someone adds a new status later without updating the `switch`, TypeScript catches it at compile time.

## W1D1-S3 — Completed! ✅

You've covered all four topics:

- Function types: Signatures, parameter compatibility, and return types.
- Callback types: Passing functions as arguments and understanding `void` callbacks.
- Type narrowing: Control-flow analysis, type guards, and type predicates.
- Discriminated unions: Modelling mutually exclusive states and exhaustive checking with `never`.

You answered the exercises correctly after clarifying the function-parameter compatibility rule.

Next: W1D1-S4 — Classes and Object-Oriented TypeScript

We'll cover classes, access modifiers, abstract classes, and interfaces, comparing them with their C# equivalents.

One step at a time, following the curriculum.