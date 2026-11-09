# Recommended domain model

## Recipe

```text
Recipe
|
+-- Id
+-- Title
+-- ImageUrl
+-- RecipeLanguageCode
+-- Source
+-- Ingredients[]
+-- Steps[]
+-- CreatedAt
+-- UpdatedAt
```

## Source

```text
Source
|
+-- Type
|   +-- Chef
|   +-- YouTubeChannel
|   +-- WebPage
|   +-- Other
|
+-- Name
+-- Url
```

Examples:

```text
Type: Chef
Name: Sanjeev Kapoor
Url: optional
```

```text
Type: YouTubeChannel
Name: Your Food Lab
Url: https://...
```

## Ingredient

```text
Ingredient
|
+-- Id
+-- Position
+-- Name
+-- Quantity
+-- Unit
+-- Notes
```

I would initially make `Quantity` a string rather than a decimal:

```text
"1"
"1.5"
"½"
"1–2"
"to taste"
```

Recipes often contain quantities that do not fit neatly into a numeric field. We can introduce structured numeric quantities later if you want ingredient scaling.

Example:

```text
Name: Onion
Quantity: 2
Unit: medium
Notes: finely chopped
```

## Recipe step

```text
RecipeStep
|
+-- Id
+-- Position
+-- Instruction
```

The `Position` field lets users reorder ingredients and steps without relying on database insertion order.

## Recipe template

```text
RecipeTemplate
|
+-- Id
+-- Name
+-- IsBuiltIn
+-- ConfigurationJson
+-- SchemaVersion
+-- CreatedAt
+-- UpdatedAt
```

Storing the configurable portion as JSON gives us room to add layout options without continuously changing the relational schema.

# Language needs to be split into separate concepts

We should not treat “language” as one application property.

## 1. User-interface language

This controls application labels:

```text
Save
Delete
Ingredients
Steps
```

For example:

```text
Speichern
Löschen
Zutaten
Schritte
```

Start with English and German.

## 2. Recipe content language

This identifies the language in which the user wrote the recipe.

```text
RecipeLanguageCode: "en"
RecipeLanguageCode: "de"
RecipeLanguageCode: "hi"
```

It does not automatically translate the recipe.

## 3. Output language

This controls labels in the exported document:

```text
Ingredients
Instructions
Source
```

The output language could initially default to the recipe language or application language, while still allowing the user to override it.

Supporting the same recipe translated into multiple languages would be a later feature involving something like:

```text
Recipe
    |
    +-- RecipeTranslations[]
```

That should not be part of the first three-week version.

# Should the .NET API be pre-built?

I recommend a hybrid approach:

## Pre-build the stable backend foundation

Because your primary learning goal is Angular and React, we should begin with a functioning ASP.NET Core API containing:

- Solution and project structure.
- EF Core configuration.
- SQLite database.
- Initial migration.
- Recipe entities.
- Recipe request and response DTOs.
- Recipe CRUD endpoints.
- Nested ingredients and steps.
- Validation.
- Seed data.
- OpenAPI documentation.
- Consistent error responses.

That means you can immediately concentrate on frontend development rather than spending the first several days rebuilding familiar .NET infrastructure.

## Build evolving features incrementally

We should not completely pre-build:

- Template management.
- Template configuration validation.
- PDF generation.
- Image upload.
- Authentication.
- Recipe translations.
- Importing recipes from websites or videos.

The frontend experience will help us discover how those contracts should look.

The progression should be:

```text
Recipe editor
      |
      v
Understand the required data
      |
      v
Finalize request/response contract
      |
      v
Add template editor
      |
      v
Finalize template contract
      |
      v
Add PDF export
```

# Validation must exist independently of the UI

A mature UI does not replace API validation.

```text
Frontend validation
        |
        | Fast feedback and good user experience
        v
API validation
        |
        | Security and authoritative business rules
        v
Database constraints
        |
        | Final data-integrity boundary
        v
Database
```

For example, all three layers may enforce different parts of the same requirement:

```text
Title is required
Ingredient name is required
Step instruction is required
URL must be valid when supplied
Title cannot exceed a defined length
```

The frontend should prevent obvious mistakes, but the API must still assume that any caller can send invalid data. ASP.NET Core API controllers can automatically turn validation failures into structured HTTP 400 responses using `ValidationProblemDetails`; current Minimal API validation also supports nested objects and collection items when configured appropriately. [Microsoft Learn](https://learn.microsoft.com/aspnet/core/web-api?utm_source=chatgpt.com)

# Why this application is excellent for Angular

The recipe editor contains dynamic nested collections:

```text
Recipe form
|
+-- Title
+-- Source
+-- Ingredients[]
|   +-- Ingredient 1
|   +-- Ingredient 2
|   +-- Add ingredient
|   +-- Remove ingredient
|
+-- Steps[]
    +-- Step 1
    +-- Step 2
    +-- Add step
    +-- Remove step
```

That is an ideal use case for typed Angular Reactive Forms with `FormGroup` and `FormArray`.

Angular currently documents Signal Forms, Reactive Forms, and template-driven forms. For this course, I would use typed Reactive Forms as the primary approach because they are highly relevant to existing Angular codebases and interviews, and then compare them with Signal Forms later. Angular’s `FormArray` is specifically designed for dynamically adding and removing collections of controls. [Angular](https://angular.dev/guide/forms/reactive-forms?utm_source=chatgpt.com)

Angular state would be divided like this:

| State | Angular approach |
|---|---|
| Recipe editor | Typed Reactive Form |
| Add/remove ingredients | `FormArray` |
| Selected template | Signal |
| Live preview | Computed signal |
| Application language | Injectable service with signal |
| Recipes from API | API service |
| Loading/error state | Signal or feature store |
| Large shared state exercise | NgRx or Signal Store |

# Why this application is excellent for React

The recipe editor will involve many related actions:

```text
SET_TITLE
SET_SOURCE
ADD_INGREDIENT
UPDATE_INGREDIENT
REMOVE_INGREDIENT
MOVE_INGREDIENT
ADD_STEP
UPDATE_STEP
REMOVE_STEP
MOVE_STEP
SELECT_TEMPLATE
```

That gives us a natural reason to move from basic `useState` to `useReducer`.

React’s official learning material recommends structuring state to avoid redundant values, lifting shared state to the appropriate owner, and combining reducers with Context for complex screens when necessary. [react.dev](https://react.dev/learn/managing-state?utm_source=chatgpt.com)

React state would be divided like this:

| State | React approach |
|---|---|
| Simple local field state | `useState` |
| Complex recipe draft | `useReducer` |
| Application language | Context |
| Selected template | Local state or reducer |
| Live preview | Derived during rendering |
| Recipes fetched from API | Server or client data-fetching layer |
| Large shared state exercise | Redux Toolkit |

We will not install Redux merely to say that we used Redux. We will first identify whether the state is local, shared, derived, URL-based, form state, or server state.

# How Next.js fits when the backend is .NET

The ASP.NET Core API remains the main backend.

Next.js is still useful because we can learn its rendering model:

```text
Recipe list/detail page
        |
        +-- Server Component fetches recipe data
        |
        +-- Client Component handles editing and interaction
```

Next.js layouts and pages are Server Components by default. Interactive functionality involving state, event handlers, effects, or browser APIs belongs in Client Components. That gives this project a natural way to learn the server/client boundary rather than turning the entire application into one large Client Component. [nextjs.org](https://nextjs.org/docs/app/getting-started/server-and-client-components?utm_source=chatgpt.com)

We can implement the Next.js client in two passes:

1. Call the .NET API from ordinary Client Components, similar to Angular.
2. Refactor read-only pages to fetch through Server Components while keeping the recipe editor interactive.

# PDF generation should also be incremental

## Version 1: printable browser preview

Build a preview route such as:

```text
/recipes/{id}/print?templateId={templateId}
```

The page applies print-specific CSS and provides a Print button.

The browser already lets the user select:

```text
Save as PDF
```

Advantages:

- Fast to implement.
- The PDF closely matches the visible preview.
- No PDF library is needed initially.
- Immediately useful in your personal life.

## Version 2: API-generated PDF

Later add:

```http
GET /api/recipes/{recipeId}/pdf?templateId={templateId}&language=en
```

The API would:

```text
Load recipe
    |
Load template
    |
Validate template configuration
    |
Render document
    |
Return application/pdf
```

This teaches:

- Binary HTTP responses.
- Download handling.
- Content-Disposition headers.
- Server-side rendering.
- Template versioning.
- Failure handling.
- Potential background processing for expensive exports.

# Three-week revised curriculum

## Week 1 — ASP.NET Core foundation and Angular

### Day 1 — Domain model, API, and Angular setup

- Finalize the MVP recipe model.
- Run the prepared ASP.NET Core API.
- Explore Swagger/OpenAPI.
- Review the TypeScript needed for the project.
- Create the Angular application.
- Map Angular concepts to Blazor.
- Display seeded recipes.

### Day 2 — Components and routing

Build:

```text
/recipes
/recipes/:id
/recipes/new
/recipes/:id/edit
```

Learn:

- Standalone components.
- Inputs and outputs.
- Template syntax.
- Control flow.
- Pipes.
- Routing.
- Route parameters.
- Layout composition.

### Day 3 — Dynamic recipe form

Build:

- Title field.
- Image URL.
- Source fields.
- Dynamic ingredients.
- Dynamic steps.
- Add/remove controls.
- Reordering basics.
- Client-side validation.

Learn:

- Typed Reactive Forms.
- `FormGroup`.
- `FormArray`.
- Nested controls.
- Custom validators.
- Dirty, touched, valid, and pending state.

### Day 4 — API integration

Build:

- Load recipe.
- Create recipe.
- Update recipe.
- Delete recipe.
- Display backend validation errors.
- Loading and error states.

Learn:

- `HttpClient`.
- Observables.
- API services.
- Interceptors.
- Error handling.
- Observable versus Promise.
- DTO mapping.

### Day 5 — Angular state, localization, and tests

Build:

- English/German interface.
- Selected-language persistence.
- Recipe-list filtering.
- Unsaved-change warning.
- Component and service tests.

Learn:

- Signals.
- Computed signals.
- Effects.
- Local versus shared state.
- Signals versus RxJS.
- When NgRx is justified.

## Week 2 — React and Next.js

### Day 6 — React components and recipe pages

Build the same core pages using:

- Function components.
- Props.
- Children.
- Events.
- Conditional rendering.
- Lists and keys.
- Controlled inputs.

### Day 7 — Recipe editor with hooks

Build the recipe editor using:

- `useState`.
- `useReducer`.
- Immutable updates.
- Custom hooks.
- Form submission.
- Add/remove/reorder operations.

This is where you will understand React’s state model rather than merely memorizing hook syntax.

### Day 8 — Next.js App Router

Build:

```text
/recipes
/recipes/[id]
/recipes/new
/recipes/[id]/edit
```

Learn:

- Pages and layouts.
- Dynamic routes.
- Server Components.
- Client Components.
- Loading and error boundaries.
- Hydration.
- Server versus client data fetching.

### Day 9 — API integration and localization

Build:

- .NET API integration.
- API error display.
- English/German interface.
- Locale Context.
- Server-rendered recipe details.
- Client-side editor.

### Day 10 — React state management and testing

Learn and compare:

- `useState`.
- `useReducer`.
- Context.
- Reducer plus Context.
- Redux Toolkit.
- Client state versus server state.
- Derived state.
- URL state.

Build:

- Component tests.
- API interaction tests.
- One create-recipe end-to-end test.
- Production build.

## Week 3 — Templates, PDF, and interview preparation

### Day 11 — Template domain and built-in templates

Build:

- `Classic` template.
- `Compact` template.
- Template selector.
- Recipe preview.
- Section visibility options.

Learn:

- Dynamic rendering.
- Configuration-driven UI.
- Template strategy.
- Mapping configuration to components.

### Day 12 — Custom template editor

Build:

- Clone template.
- Rename template.
- Reorder sections.
- Show/hide sections.
- Select page size.
- Select density or typography preset.
- Save template configuration.

Learn:

- Complex editor state.
- Reducers and actions.
- Immutable nested updates.
- Angular signals versus React reducers.

### Day 13 — Persisted templates and live preview

Build:

- Template API endpoints.
- Template list.
- Create/update/delete custom template.
- Live preview while editing.
- Reset to built-in defaults.
- Validation of template configuration.

### Day 14 — PDF export and deployment

Build:

- Print-friendly preview.
- Browser Save as PDF.
- Download filename.
- Production configuration.
- Deployment-ready builds.
- Optional API-generated PDF if time permits.

Discuss:

- Client-generated versus server-generated PDF.
- Image URL versus upload.
- File storage.
- Security risks of arbitrary HTML/CSS templates.

### Day 15 — Refactoring and interviews

Review:

- Angular versus React component models.
- Reactive Forms versus React-controlled forms.
- Signals versus hooks.
- RxJS versus Promises.
- Context versus dependency-injected services.
- NgRx versus Redux.
- Server Components versus Angular SPA rendering.
- Client versus API validation.
- Template configuration versus hard-coded layouts.
- Browser versus server PDF generation.

Each day can end with the established interview format:

```text
Question
    |
Your answer
    |
Critique
    |
Strong answer
    |
Deeper follow-up
```

That matches the interview-practice structure already used in your broader curriculum. plan

# Three-week completion boundary

## Must complete

- Recipe list.
- Recipe details.
- Create/edit/delete.
- Structured source.
- Dynamic ingredients.
- Dynamic steps.
- Image URL.
- English/German UI.
- Angular core version.
- Next.js core version.
- Two built-in templates.
- Live preview.
- Browser Save as PDF.
- Basic tests.

## Complete if time permits

- Persisted custom templates.
- Reordering template sections.
- Server-generated PDFs.
- Image upload.
- Redux and NgRx implementation exercises.

## Explicitly defer

- Free-form drag-and-drop page builder.
- Arbitrary user-authored HTML or JavaScript.
- Full CSS editor.
- Authentication and multiple users.
- Automatic recipe extraction from websites.
- YouTube transcript extraction.
- Automatic translation.
- Shopping lists.
- Meal planning.
- Nutrition calculation.
- Recipe sharing and social features.

# My recommendation

Use **Recipe Studio** as the application for the course.

Start with a prepared, validated recipe CRUD API so that frontend learning begins immediately. Build the Angular client first, reproduce the core functionality in React/Next.js, and then add templates and PDF export as incremental vertical slices.

The most important constraint is this:

> Build complete recipe management in both frontends, but do not attempt to build a full visual page designer in both within three weeks.

A configuration-based template editor will still teach dynamic components, complex state, persistence, rendering, validation, and PDF output while leaving you with an application you can genuinely continue using.