# W1D1-S4 — Classes and Object-Oriented TypeScript

This section covers **classes, access modifiers, abstract classes, and interfaces in object-oriented TypeScript**. 

Since you already know C#, I’ll teach this primarily by showing where TypeScript feels familiar and where its JavaScript runtime changes the rules.

## Step 1 — Classes

A basic TypeScript class looks very similar to C#:

```ts
class Recipe {
  id: number;
  title: string;
  isPublished: boolean;

  constructor(id: number, title: string) {
    this.id = id;
    this.title = title;
    this.isPublished = false;
  }

  publish(): void {
    this.isPublished = true;
  }

  get displayTitle(): string {
    return `${this.title} (${this.isPublished ? "Published" : "Draft"})`;
  }
}
```

You create an instance with `new`:

```ts
const recipe = new Recipe(1, "Butter Chicken");

console.log(recipe.displayTitle);

recipe.publish();

console.log(recipe.displayTitle);
```

Output:

```text
Butter Chicken (Draft)
Butter Chicken (Published)
```

### C# mental mapping

This:

```ts
class Recipe {
  id: number;
  title: string;

  constructor(id: number, title: string) {
    this.id = id;
    this.title = title;
  }

  publish(): void {
    // ...
  }
}
```

is conceptually close to:

```csharp
public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }

    public Recipe(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public void Publish()
    {
        // ...
    }
}
```

There is one important mental distinction already:

**The TypeScript class exists at runtime because JavaScript has classes.**

For example:

```ts
console.log(recipe instanceof Recipe);
```

works at runtime:

```text
true
```

That's different from a TypeScript `interface`, which we'll revisit later in this section. Interfaces disappear completely when TypeScript is compiled.

### Constructor parameters are not automatically fields

This is important:

```ts
class Recipe {
  constructor(id: number, title: string) {
  }
}
```

`id` and `title` are only constructor parameters. This does **not** create:

```ts
recipe.id
recipe.title
```

You must either declare and assign fields:

```ts
class Recipe {
  id: number;
  title: string;

  constructor(id: number, title: string) {
    this.id = id;
    this.title = title;
  }
}
```

or use TypeScript's constructor shorthand, which we'll encounter naturally when discussing access modifiers.

## Your one exercise

Without running it, tell me whether this compiles and what you expect it to print:

```ts
class Chef {
  name: string;

  constructor(name: string) {
    this.name = name;
  }

  introduce(): string {
    return `Hi, I'm ${this.name}`;
  }
}

const chef = new Chef("Sanjeev");
console.log(chef.introduce());
```

After your answer, we'll move to **access modifiers: `public`, `private`, and `protected`**, including the important differences from C#.

### Answer
Hi, I'm Sanjeev

Correct! ✅ The code compiles successfully and prints:

```
Hi, I'm Sanjeev
```

## Step 2 — Access Modifiers

TypeScript supports three familiar access modifiers:

| Modifier    | TypeScript                                 | C# equivalent |
| ----------- | ------------------------------------------ | ------------- |
| `public`    | Accessible everywhere (default)            | `public`      |
| `private`   | Accessible only within the class           | `private`     |
| `protected` | Accessible within the class and subclasses | `protected`   |

### Example

```
class Recipe {
  public title: string;
  private secretIngredient: string;
  protected preparationTime: number;

  constructor(title: string) {
    this.title = title;
    this.secretIngredient = "Love";
    this.preparationTime = 30;
  }
}

class SpecialRecipe extends Recipe {
  printPreparationTime(): void {
    console.log(this.preparationTime); // Allowed
  }
}

const recipe = new Recipe("Butter Chicken");

console.log(recipe.title);            // Allowed
console.log(recipe.secretIngredient); // Compilation error
console.log(recipe.preparationTime);  // Compilation error
```

### Important difference from C\#

TypeScript's `private` is primarily compile-time enforced, unlike C#'s runtime-enforced access restrictions.

After compilation, a TypeScript `private` property is still an ordinary JavaScript property.

JavaScript also supports genuinely private fields using `#`:

```
class Recipe {
  #secretIngredient = "Love";

  revealSecret(): string {
    return this.#secretIngredient;
  }
}
```

Here, `#secretIngredient` is enforced as private by JavaScript itself at runtime.

### Constructor parameter properties

TypeScript offers a shortcut:

```
class Recipe {
  constructor(
    public title: string,
    private secretIngredient: string,
    readonly id: number
  ) {}
}
```

This automatically declares and initializes all three properties.

Without the shortcut, you would need explicit field declarations and assignments.

Notice that `readonly` is also a valid parameter-property modifier. It prevents reassignment through TypeScript after construction, but doesn't make the object immutable at runtime.

## Quick exercise

Consider:

```
class Recipe {
  constructor(
    public title: string,
    private rating: number,
    readonly id: number
  ) {}
}

const recipe = new Recipe("Pasta", 5, 100);

recipe.title = "Pizza";
recipe.rating = 4;
recipe.id = 200;
```

Which of the three assignments compile successfully, and why?

After this, we'll cover abstract classes.

### Answer
These will fail: 
```
recipe.rating = 4; // no outside access to private fields
recipe.id = 200; // no reassignment to readonly field
```
Correct! ✅

- `recipe.title = "Pizza"` — Compiles. The property is `public` and mutable.
- `recipe.rating = 4` — Compilation error. The property is `private`.
- `recipe.id = 200` — Compilation error. The property is `readonly`.

## Step 3 — Abstract Classes

Just like C#, TypeScript supports abstract classes.

An abstract class cannot be instantiated directly. It can contain both implemented methods and abstract methods that subclasses must implement.

```
abstract class Recipe {
  constructor(public title: string) {}

  abstract calculateCalories(): number;

  displayTitle(): string {
    return `Recipe: ${this.title}`;
  }
}

class PastaRecipe extends Recipe {
  calculateCalories(): number {
    return 450;
  }
}

const pasta = new PastaRecipe("Carbonara");

console.log(pasta.displayTitle());       // Recipe: Carbonara
console.log(pasta.calculateCalories());  // 450
```

Attempting this produces a TypeScript compilation error:

```
const recipe = new Recipe("Pasta");
```

### Important difference from C\#

TypeScript's `abstract` keyword is enforced by the TypeScript compiler, not JavaScript.

After compilation, the abstract class becomes an ordinary JavaScript class. JavaScript itself doesn't enforce TypeScript's abstract-class restrictions.

## Quick exercise

Consider:

```
abstract class Ingredient {
  constructor(public name: string) {}

  abstract getQuantity(): string;

  describe(): string {
    return `${this.name}: ${this.getQuantity()}`;
  }
}

class MeasuredIngredient extends Ingredient {
  constructor(
    name: string,
    private amount: number,
    private unit: string
  ) {
    super(name);
  }

  getQuantity(): string {
    return `${this.amount} ${this.unit}`;
  }
}

const ingredient = new MeasuredIngredient("Flour", 200, "g");

console.log(ingredient.describe());
```

Two questions:

1. What does this print?
2. Why do we need `super(name)` in the subclass constructor?

Next, we'll cover interfaces in object-oriented TypeScript.

### Answer
Flour 200
I think super is similar to Java, which you use to call the base class constructor to initialize the variables appropriately in the base class.

You're almost correct! ✅

1\. Output

The actual output is:

```
Flour: 200 g
```

Notice the colon and unit. The `describe()` method combines `name` with the result of `getQuantity()`.

2\. `super(name)`

Exactly right! Just like Java and C#, `super(name)` calls the base class constructor.

In TypeScript, a subclass constructor must call `super()` before accessing `this`.

## Step 4 — Interfaces in Object-Oriented TypeScript

In C#, you're familiar with implementing interfaces:

```
public class Recipe : IPrintable
{
    public void Print() { }
}
```

TypeScript has an equivalent concept:

```
interface Printable {
  print(): void;
}

class Recipe implements Printable {
  constructor(public title: string) {}

  print(): void {
    console.log(this.title);
  }
}
```

### Important difference: Structural typing

Unlike C#, TypeScript uses structural typing.

Consider:

```
interface Printable {
  print(): void;
}

class Recipe {
  print(): void {
    console.log("Printing recipe");
  }
}

const printable: Printable = new Recipe();
```

This compiles successfully!

Even though `Recipe` never explicitly declares `implements Printable`, TypeScript accepts it because the class has the required structure.

The `implements` keyword provides an explicit compile-time contract check, but it doesn't determine whether a class is compatible with an interface.

### Quick exercise

```
interface Named {
  name: string;
}

class Chef {
  constructor(public name: string) {}
}

class Restaurant {
  constructor(public name: string) {}
}

function introduce(entity: Named): void {
  console.log(entity.name);
}

introduce(new Chef("Sanjeev"));
introduce(new Restaurant("Spice Garden"));
```

Will both calls compile successfully even though neither class implements `Named`? Why?

This is the final concept in W1D1-S4.

### Answer
Yes! Because of TS's structural typing.

Exactly! ✅

Both calls compile because TypeScript checks whether the objects satisfy the `Named` interface's structure, not whether their classes explicitly declare `implements Named`.

This is a key difference from C#.

## W1D1-S4 — Completed! ✅

You've covered all four topics:

- Classes and constructors
- Access modifiers (`public`, `private`, `protected`)
- Abstract classes and inheritance
- Interfaces and structural typing

One important takeaway: TypeScript's type system is largely structural and compile-time only, while JavaScript classes and `#private` fields have runtime behavior.

You're ready for W1D1-S5 — Async TypeScript and Utility Types.