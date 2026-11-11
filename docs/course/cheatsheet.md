# Cheatsheet

- You get static typing without having to explicitly type everything
- `strictNullChecks` is a TypeScript compiler option that controls whether `null` and `undefined` are treated as distinct types.
- Excess property checking
- type narrowing
- In TypeScript, interfaces are very commonly used simply to describe **data shapes**
- In TS, when dealing with objects, think in terms of **structure**
- `?` allows the property to be omitted entirely
- Declaration merging
- TypeScript convention is to use semicolons rather than commas between interface properties, although both are valid.
- TypeScript's `readonly` is enforced by the type checker, not at runtime.
- Contextual typing
- TypeScript doesn’t just narrow types inside if blocks. It also tracks which types remain possible after branches that terminate execution.
- Unlike any, unknown forces us to verify the value before accessing its properties.
- The type predicate doesn’t automatically validate anything. Our implementation must actually perform the checks.
- `never` represents a value that should be impossible.
- Interfaces disappear completely when TypeScript is compiled.
- A `Promise<T>` represents: A value of type `T` that may become available later.
- A JavaScript `Promise` can be in one of three conceptual states:
```text
pending
fulfilled
rejected
```
- An `async` function automatically wraps its returned value in a `Promise`.
- `await` suspends the execution of the surrounding async function until the Promise settles. It does not block the JavaScript thread.
- An exception thrown inside an `async` function causes its returned Promise to be rejected.
- When we `await` a rejected Promise, the rejection becomes an exception that `catch` can handle.
- Utility types allow us to create new types from existing ones
- `Partial<T>` makes every property of `T` optional.
- `Partial<T>` is shallow: `Partial<T>` only makes properties optional at the top level. It does not recursively make nested properties optional.
- `keyof T` represents the union of all property names in `T`.