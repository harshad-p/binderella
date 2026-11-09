# Angular, React, and Next.js: 21-Day Production Crash Course

## Course Foundation

### CF-S1 — Course Goal

Complete a comprehensive frontend crash course in exactly three weeks:

- Week 1: Angular — Days 1–7.
- Week 2: React — Days 8–14.
- Week 3: Next.js and production engineering — Days 15–21.

The course should prepare the learner to:

- Contribute to an existing production Angular, React, or Next.js codebase.
- Build complete frontend features independently.
- Read and review unfamiliar frontend code.
- Implement routing, forms, validation, authentication, state, and API integration.
- Distinguish local, form, URL, server, authentication, and global state.
- Write unit, component, integration, and end-to-end tests.
- Debug HTTP, rendering, state, routing, form, and performance problems.
- Build and deploy production applications.
- Answer framework-specific and frontend-architecture interview questions.
- Compare Angular, React, Next.js, and Blazor using practical examples.

### CF-S2 — Time Commitment

- 21 actual instructional days.
- No placeholder, catch-up, or rest days are counted as course days.
- Approximately 3–5 focused hours per day.
- Every day contains:
  - Concept learning.
  - Guided implementation.
  - Independent work.
  - Testing or debugging.
  - Interview preparation.

### CF-S3 — Assumed Knowledge

The learner already knows:

- JavaScript fundamentals.
- Some TypeScript.
- C# and ASP.NET Core.
- Blazor.
- General application architecture.
- REST APIs and SQL basics.

Therefore, the course will not spend significant time on:

- Basic programming.
- Basic HTML.
- Elementary CSS.

### CF-S4 — Application Strategy

Use one shared ASP.NET Core API and database with three frontend clients:

- Angular application.
- React application.
- Next.js application.

The project domain may be:

- Binderella.
- A job tracker.
- Another application chosen by the learner.

The curriculum must not depend on the project domain.

The chosen application must support enough behavior to practise:

- List and detail pages.
- Create, edit, and delete operations.
- Search, filtering, sorting, and pagination.
- A complex dynamic form.
- Loading, empty, success, and error states.
- Authentication and protected routes.
- Local and global state.
- Localization.
- Image or file handling.
- A live preview or derived view.
- Print or PDF output.
- Unit, integration, and end-to-end tests.

### CF-S5 — Backend Boundary

The ASP.NET Core API is supporting infrastructure, not the primary subject.

Frontend applications communicate with it through HTTP and JSON:

```text
Angular / React / Next.js
→ ASP.NET Core API
→ EF Core
→ Database
```

The frontend curriculum covers:

- DTO contracts.
- HTTP methods and status codes.
- Validation responses.
- Authentication flow.
- CORS.
- Pagination and filtering.
- Error handling.

Deep ASP.NET Core architecture and EF Core internals are outside the main course unless they directly affect frontend development.

### CF-S6 — Teaching Workflow

ChatGPT is responsible for:

- Teaching concepts.
- Explaining code.
- Controlling curriculum order.
- Giving exercises.
- Reviewing architectural choices.
- Conducting interview practice.
- Defining narrowly scoped implementation tasks.

Codex is responsible for:

- Creating and editing repository files.
- Running commands.
- Scaffolding projects.
- Implementing clearly defined tasks.
- Running builds and tests.
- Reporting failures and changed files.

Rule:

- Codex must not generate an entire lesson before the relevant concepts have been taught.

---

# Week 1 — Angular

# Day 1 — TypeScript Sprint and Angular Project Anatomy

## W1D1-S1 — TypeScript Type-System Fundamentals

- Type inference.
- Explicit annotations.
- Primitive types.
- Object types.
- Union types.
- Intersection types.
- Literal types.
- Strict null checking.

## W1D1-S2 — TypeScript Object Modelling

- Interfaces versus type aliases.
- Optional properties.
- Readonly properties.
- Arrays.
- Tuples.
- Generics.

## W1D1-S3 — Functions, Narrowing, and Advanced Type Modelling

- Function types.
- Callback types.
- Type narrowing.
- Discriminated unions.

## W1D1-S4 — Classes and Object-Oriented TypeScript

- Classes.
- Access modifiers.
- Abstract classes.
- Interfaces in object-oriented TypeScript.

## W1D1-S5 — Async TypeScript and Utility Types

- `Promise<T>`.
- `async`.
- `await`.
- `Partial<T>`.
- `Required<T>`.
- `Pick<T>`.
- `Omit<T>`.
- `Record<TKey, TValue>`.

## W1D1-S6 — Modules and Runtime Reality

- Modules.
- Imports.
- Exports.
- Why TypeScript types do not provide runtime validation.

## W1D1-S7 — Angular CLI and Workspace Anatomy

- Angular CLI.
- Workspace structure.
- `package.json`.
- Lockfiles.
- `angular.json`.
- TypeScript configuration.

## W1D1-S8 — Angular Bootstrap and Application Configuration

- Application bootstrap.
- Standalone components.
- Application configuration.
- Environment-specific configuration.

## W1D1-S9 — Running and Tooling

- Development server.
- Production build.
- Test command.
- Angular DevTools.
- Linting expectations.
- Formatting expectations.

## W1D1-S10 — Day 1 Build

- Scaffold the Angular application.
- Enable routing.
- Enable strict TypeScript.
- Use SCSS or CSS.
- Remove sample content.
- Create the application shell.
- Add a navigation header.
- Create placeholder pages:
  - Home.
  - List.
  - Details.
  - Create.
- Define TypeScript models for static sample data.
- Render a small static list.

## W1D1-S11 — Angular vs Blazor Mental Mapping

- Razor component versus Angular component.
- `[Parameter]` versus input.
- `EventCallback` versus output.
- Razor markup versus Angular template.
- Dependency injection in Blazor versus Angular.
- Component state versus signals and properties.
- Lifecycle methods in both frameworks.

## W1D1-S12 — Day 1 Interview Preparation

- TypeScript versus JavaScript.
- Compile-time type checking versus runtime validation.
- Interface versus type alias.
- Union type versus enum.
- Angular framework versus Angular CLI.
- Standalone component versus NgModule.
- Why strict TypeScript improves production code.

## W1D1-S13 — Day 1 Completion Check

The learner can:

- Run the Angular application.
- Explain the workspace.
- Create and import a standalone component.
- Explain where the application boots.
- Build the application successfully.

---

# Day 2 — Components, Templates, Directives, and Communication

## W1D2-S1 — Component Fundamentals

- Component metadata.
- Selectors.
- Inline versus external templates.
- Component styles.
- Style encapsulation.

## W1D2-S2 — Template Binding

- Interpolation.
- Property binding.
- Attribute binding.
- Class binding.
- Style binding.
- Event binding.
- Two-way binding.
- Template reference variables.

## W1D2-S3 — Modern Template Control Flow

- `@if`.
- `@for`.
- `@switch`.
- Tracking list items correctly.

## W1D2-S4 — Directives and Pipes

- Built-in directives.
- Custom attribute directives.
- Pipes.
- Pure pipes.
- Impure pipes.

## W1D2-S5 — Component Inputs and Outputs

- Inputs.
- Required inputs.
- Input transformation awareness.
- Outputs.
- Custom events.
- Parent-to-child communication.
- Child-to-parent communication.
- Sibling communication through a parent.

## W1D2-S6 — Content Projection and Composition

- Content projection.
- Single-slot projection.
- Multi-slot projection.
- Component composition.

## W1D2-S7 — Lifecycle and Component Responsibilities

- Component lifecycle hooks.
- Smart/feature components.
- Presentational components.
- Avoiding excessive logic in templates.

## W1D2-S8 — Day 2 Build

- List page.
- Card component.
- Details component.
- Status or category badge component.
- Empty-state component.
- Loading component.
- Error-message component.
- Reusable confirmation component.
- Parent-child selection.
- Child event emitted to parent.
- Content-projection example.
- Custom formatting pipe.
- Custom highlighting directive.

## W1D2-S9 — Day 2 Interview Preparation

- Component versus directive.
- Input versus output.
- Content projection versus passing inputs.
- Pipe versus component method.
- Pure versus impure pipe.
- Lifecycle hook use cases.
- Why stable list identity matters.
- Presentational versus feature components.
- Why business logic should not live in templates.

## W1D2-S10 — Day 2 Completion Check

The learner can:

- Break a screen into components.
- Pass data downward.
- Send events upward.
- Render lists safely.
- Explain Angular template syntax.

---

# Day 3 — Routing, Dependency Injection, and Frontend Architecture

## W1D3-S1 — Angular Routing Basics

- Router configuration.
- Router outlet.
- Navigation with router links.
- Active navigation state.
- Static routes.

## W1D3-S2 — Route State

- Route parameters.
- Query parameters.
- Fragments.
- Route data.

## W1D3-S3 — Nested and Programmatic Routing

- Nested routes.
- Child routes.
- Programmatic navigation.
- Not-found routes.

## W1D3-S4 — Lazy Loading and Guards

- Lazy-loaded routes.
- Route-level code splitting.
- Route guards.
- `CanActivate`.
- `CanDeactivate`.
- Route resolvers.
- When to avoid route resolvers.
- Why route guards are not a security boundary.

## W1D3-S5 — Angular Dependency Injection Fundamentals

- Angular services.
- `@Injectable`.
- Constructor injection.
- `inject()`.
- Injection tokens.

## W1D3-S6 — Provider Scope and Injector Hierarchy

- Root providers.
- Route-level providers.
- Component-level providers.
- Injector hierarchy.
- Service instance lifetime.
- Avoiding accidental multiple service instances.

## W1D3-S7 — Frontend Architecture

- Feature-based folder organization.
- Pages versus reusable components.
- Services.
- Models.
- API contracts.
- Shared UI components.
- Core application services.
- Keeping feature boundaries clear.
- Avoiding one giant shared module or shared folder.
- Container/presentational component separation.
- Environment configuration.

## W1D3-S8 — Day 3 Build

Create routes:

- `/`.
- `/items`.
- `/items/:id`.
- `/items/new`.
- `/items/:id/edit`.
- `/login`.
- `/protected`.
- `**` for not found.

Also:

- Read a route parameter.
- Read and update query parameters.
- Add active navigation.
- Lazy-load the primary feature.
- Create a feature service.
- Create an unsaved-changes guard.
- Create a placeholder protected-route guard.
- Add a not-found page.

## W1D3-S9 — Day 3 Interview Preparation

- Route parameter versus query parameter.
- Lazy loading and why it matters.
- Route guard versus backend authorization.
- Service versus component responsibility.
- Root provider versus component provider.
- How Angular resolves dependencies.
- Why component-level providers create separate instances.
- Feature folders versus technical-layer folders.

## W1D3-S10 — Day 3 Completion Check

The learner can:

- Add a routed feature.
- Lazy-load it.
- Inject a service.
- Explain provider scope.
- Read and change URL state.

---

# Day 4 — HTTP, RxJS, Server State, and Error Handling

## W1D4-S1 — Angular HTTP Fundamentals

- Configuring `HttpClient`.
- Typed request objects.
- Typed response objects.
- GET.
- POST.
- PUT.
- PATCH.
- DELETE.

## W1D4-S2 — HTTP Request Construction

- Query-string construction.
- Headers.
- Request options.
- JSON serialization.
- DTO mapping.

## W1D4-S3 — Backend Communication Concerns

- Development proxy configuration.
- CORS.
- HTTP status codes.
- ASP.NET Core `ProblemDetails`.
- Validation problem responses.

## W1D4-S4 — RxJS Foundations

- Observable versus Promise.
- Cold Observable.
- Hot Observable.
- Subscription lifecycle.
- Async pipe.
- Declarative subscription patterns.

## W1D4-S5 — Core RxJS Operators

- `map`.
- `filter`.
- `tap`.
- `debounceTime`.
- `distinctUntilChanged`.
- `catchError`.
- `finalize`.

## W1D4-S6 — RxJS Flattening Operators

- `switchMap`.
- `mergeMap`.
- `concatMap`.
- `exhaustMap`.

## W1D4-S7 — Combining and Cancelling Streams

- `combineLatest`.
- `forkJoin`.
- Request cancellation.
- Why nested subscriptions are problematic.
- `takeUntilDestroyed`.
- Signals and Observable interoperability.

## W1D4-S8 — HTTP Architecture and Server State

- API service responsibilities.
- Server state versus local UI state.
- Loading states.
- Empty states.
- Success states.
- Error states.
- Global versus feature-specific error handling.

## W1D4-S9 — Interceptors, Retry, and Optimistic Updates

- Functional HTTP interceptors.
- Correlation IDs.
- Authentication-header awareness.
- Retry only when safe.
- Optimistic updates.
- Rollback.

## W1D4-S10 — Day 4 Build

- API contract interfaces.
- API client service.
- Load a list.
- Load a detail.
- Create an item.
- Update an item.
- Delete an item.
- Search with debounce.
- Filter through query parameters.
- Sort through query parameters.
- Paginate server results.
- Cancel stale search requests.
- Display:
  - Initial loading.
  - Background loading.
  - Empty result.
  - Validation error.
  - Not found.
  - Server error.
- Map `ProblemDetails` into a frontend error model.
- Add a functional interceptor.
- Implement one optimistic update with rollback.

## W1D4-S11 — Day 4 Interview Preparation

- Observable versus Promise.
- Why Angular `HttpClient` uses Observables.
- `switchMap` versus `mergeMap`.
- Why `switchMap` suits searches.
- Why nested subscriptions are an anti-pattern.
- Interceptor use cases.
- Server state versus client state.
- Optimistic versus pessimistic updates.
- CORS versus authentication.
- `400`, `401`, `403`, `404`, `409`, and `500`.

## W1D4-S12 — Day 4 Completion Check

The learner can:

- Consume a typed API.
- Handle cancellation.
- Display every major request state.
- Explain core RxJS flattening operators.
- Debug an HTTP failure.

---

# Day 5 — Typed Reactive Forms and Complex Validation

## W1D5-S1 — Reactive Forms Mental Model

- Reactive Forms mental model.
- Typed forms.
- `FormControl`.
- `FormGroup`.
- `FormArray`.
- `FormBuilder`.
- Non-nullable controls.

## W1D5-S2 — Nested and Dynamic Forms

- Nested groups.
- Dynamic collections.

## W1D5-S3 — Validators

- Built-in validators.
- Custom validators.
- Cross-field validators.
- Async validators.
- Conditional validation.

## W1D5-S4 — Form State

- Pristine.
- Dirty.
- Touched.
- Untouched.
- Valid.
- Invalid.
- Pending.

## W1D5-S5 — Form Data Operations

- `setValue`.
- `patchValue`.
- Form submission.
- Reset behavior.
- Editing existing data.

## W1D5-S6 — DTO Mapping and Backend Errors

- Mapping DTOs to forms.
- Mapping forms to request DTOs.
- Mapping backend errors to fields.
- Validation summaries.
- Focusing the first invalid control.
- Unsaved-change detection.

## W1D5-S7 — Other Form Approaches

- Comparison with template-driven forms.
- Awareness of newer signal-based form approaches.

## W1D5-S8 — Day 5 Build

Create a production-style form with:

- Scalar fields.
- Select fields.
- Optional section.
- URL field.
- Nested object.
- Dynamic ingredient/task/item collection.
- Dynamic step/sub-item collection.
- Add operations.
- Remove operations.
- Edit operations.
- Reorder operations.
- Custom cross-field rule.
- Conditional field requirement.
- Async uniqueness-validation example.
- Create mode.
- Edit mode.
- Backend validation mapping.
- Validation summary.
- Unsaved-change warning.
- Accessible labels.
- Accessible error messages.

## W1D5-S9 — Day 5 Interview Preparation

- Reactive versus template-driven forms.
- `FormGroup` versus `FormArray`.
- `setValue` versus `patchValue`.
- Synchronous versus asynchronous validators.
- Client validation versus server validation.
- Why client validation is never authoritative.
- How to model dynamic collections.
- How to handle backend field errors.

## W1D5-S10 — Day 5 Completion Check

The learner can:

- Build a deeply nested typed form.
- Add and remove dynamic controls.
- Validate it correctly.
- Convert between form state and API DTOs.

---

# Day 6 — Signals, RxJS, NgRx, and State Management

## W1D6-S1 — State Classification

- Local UI state.
- Form state.
- Derived state.
- URL state.
- Server state.
- Authentication state.
- Shared feature state.
- Global application state.

## W1D6-S2 — Signals Fundamentals

- Writable signals.
- Reading signals.
- Setting signals.
- Updating signals.
- Computed signals.

## W1D6-S3 — Effects and Derived State

- Effects.
- When not to use effects.
- Derived state.
- Signal equality awareness.

## W1D6-S4 — Signals in Angular Architecture

- Signal inputs awareness.
- Model inputs awareness.
- Signals and change detection.
- Signals with RxJS.
- Injectable signal-based stores.

## W1D6-S5 — RxJS-Based State

- Subjects.
- BehaviorSubject.
- ReplaySubject.
- Observable state streams.
- Combining streams.
- Avoiding manual state synchronization.

## W1D6-S6 — NgRx Fundamentals

- When NgRx is justified.
- Store.
- Actions.
- Reducers.
- Selectors.
- Effects.
- Entity-style state.
- NgRx DevTools.

## W1D6-S7 — Signal Store and State-Tool Selection

- Signal Store.
- NgRx Store versus Signal Store.
- Avoiding global state for everything.

## W1D6-S8 — Day 6 Build

Implement the same small feature three ways:

1. Local component signal.
2. Injectable signal-based feature store.
3. Small NgRx or Signal Store exercise.

Feature state should include:

- Selected item.
- Search/filter state.
- Derived count.
- Loading state.
- Error state.
- Optimistic update state.

Also:

- Put shareable filters in the URL.
- Keep server data separate from temporary UI state.
- Inspect state changes with developer tools.

## W1D6-S9 — Day 6 Interview Preparation

- Signal versus Observable.
- Computed signal versus effect.
- Signal service versus NgRx.
- NgRx Store versus Signal Store.
- Local versus global state.
- Why derived state should not normally be stored.
- URL state versus in-memory state.
- When Redux-style architecture is excessive.

## W1D6-S10 — Day 6 Completion Check

The learner can:

- Classify state before choosing a tool.
- Implement shared state with signals.
- Explain NgRx architecture.
- Defend a state-management choice.

---

# Day 7 — Angular Authentication, Testing, Performance, and Production

## W1D7-S1 — Authentication and Authorization Fundamentals

- Authentication versus authorization.
- Cookie-based sessions.
- Bearer tokens.
- JWT structure awareness.
- Login flow.
- Logout flow.

## W1D7-S2 — Token and Session Lifecycle

- Access-token expiration.
- Refresh-token concepts.
- Safe token handling.
- Why local storage may be inappropriate for sensitive tokens.
- Session expiration.

## W1D7-S3 — Security Concerns

- CSRF implications.
- XSS implications.
- Why frontend guards do not secure the API.

## W1D7-S4 — Angular Authentication Implementation

- Authentication service.
- Authentication state.
- Functional auth interceptor.
- Route guards.
- Role checks.
- Permission checks.
- `401 Unauthorized`.
- `403 Forbidden`.

## W1D7-S5 — Angular Testing Fundamentals

- Test pyramid.
- Unit tests.
- Component tests.
- Integration tests.
- End-to-end tests.
- Vitest.
- Angular testing utilities.

## W1D7-S6 — Testing Angular Features

- Testing services.
- Testing components.
- Testing signals.
- Testing forms.
- Mocking HTTP.
- Router tests.
- Testing guards.
- Testing interceptors.
- Testing user-visible behavior.
- Avoiding tests coupled to implementation details.

## W1D7-S7 — Angular Performance

- Change detection.
- Default change detection.
- `OnPush`.
- Signals and rendering.
- Stable list tracking.
- Lazy loading.
- Deferrable views awareness.
- Avoiding unnecessary subscriptions.
- Bundle analysis.
- Angular DevTools.

## W1D7-S8 — Angular Production Concerns

- Production builds.
- Environment configuration.
- Source maps.
- Accessibility checks.
- XSS protection.
- Dependency auditing.

## W1D7-S9 — Day 7 Build

- Login page.
- Authentication service.
- Login/logout behavior.
- Protected route.
- Role-restricted UI example.
- Auth interceptor.
- `401` handling.
- Session-expiration handling.
- Component tests.
- Form tests.
- HTTP service tests.
- Guard tests.
- Interceptor tests.
- One protected-route E2E test.
- Production Angular build.
- Performance inspection with Angular DevTools.

## W1D7-S10 — Day 7 Interview Preparation

- Authentication versus authorization.
- Cookie versus bearer token.
- Route guard versus backend security.
- `401` versus `403`.
- Angular change detection.
- `OnPush`.
- Signals and rendering.
- Unit versus component versus E2E tests.
- How to test an HTTP service.
- How to diagnose a slow Angular page.

## W1D7-S11 — Week 1 Deliverable

A production-style Angular application containing:

- Routing.
- CRUD.
- Complex typed forms.
- API integration.
- Search.
- Filtering.
- Sorting.
- Pagination.
- State management.
- Authentication.
- Protected routes.
- Error handling.
- Accessibility.
- Tests.
- A successful production build.

---

# Week 2 — React

# Day 8 — React Setup, JSX, Components, and Composition

## W2D8-S1 — React Setup and Project Structure

- React as a UI library.
- Vite-based React setup.
- Project structure.
- React DevTools.

## W2D8-S2 — JSX and TSX

- JSX.
- TSX.
- JSX expressions.

## W2D8-S3 — Function Components and Props

- Function components.
- Props.
- Prop typing.
- `children`.

## W2D8-S4 — Rendering and Composition

- Component composition.
- Conditional rendering.
- Rendering lists.
- Keys.
- Events.
- Declarative rendering.
- Immutability.

## W2D8-S5 — Styling and Component Responsibilities

- CSS approaches.
- Component responsibility.
- Presentational components.
- Feature components.

## W2D8-S6 — Day 8 Build

- Scaffold a React application.
- Configure strict TypeScript.
- Create the application shell.
- Create:
  - List component.
  - Card component.
  - Details component.
  - Badge component.
  - Loading component.
  - Empty-state component.
  - Error component.
- Render static data.
- Pass props.
- Emit behavior through callback props.
- Use `children` for composition.

## W2D8-S7 — React vs Blazor Mental Mapping

- Razor component versus function component.
- `[Parameter]` versus props.
- `EventCallback` versus callback prop.
- `RenderFragment` versus `children`.
- Component field versus React state.
- Cascading values versus Context.

## W2D8-S8 — Day 8 Interview Preparation

- React library versus framework.
- Props versus state.
- Why keys matter.
- Why array index is often a poor key.
- Composition versus inheritance.
- Declarative versus imperative UI.
- Why React state should be treated as immutable.

## W2D8-S9 — Day 8 Completion Check

The learner can:

- Create typed function components.
- Compose components.
- Pass data and callbacks.
- Render lists safely.

---

# Day 9 — State, Events, Rendering, and Controlled Inputs

## W2D9-S1 — `useState` Fundamentals

- `useState`.
- Initial state.
- State as a snapshot.
- Functional state updates.
- Batching.

## W2D9-S2 — Events and Inputs

- Event handlers.
- Synthetic-event awareness.
- Controlled inputs.
- Uncontrolled-input awareness.

## W2D9-S3 — State Ownership

- Lifting state.
- Single source of truth.
- Derived state.
- Avoiding redundant state.

## W2D9-S4 — Immutable Updates

- Immutable array updates.
- Immutable object updates.

## W2D9-S5 — React Rendering Model

- Render phase.
- Commit phase.
- What causes a rerender.
- Parent rerenders.
- Child rerenders.
- Strict Mode development behavior.

## W2D9-S6 — Day 9 Build

- Search field.
- Filter controls.
- Sort controls.
- Selected item.
- Modal or drawer state.
- Controlled form fields.
- Derived filtered list.
- Immutable add operations.
- Immutable update operations.
- Immutable remove operations.
- State lifted to the correct owner.
- Remove one redundant state variable.

## W2D9-S7 — Day 9 Interview Preparation

- Props versus state.
- State snapshot.
- Why state updates appear asynchronous.
- Functional update versus direct update.
- Batching.
- Controlled versus uncontrolled input.
- Lifting state.
- Why derived values should usually be calculated during render.
- What causes a React component to rerender.

## W2D9-S8 — Day 9 Completion Check

The learner can:

- Model local React state.
- Update arrays and objects immutably.
- Explain state snapshots and batching.
- Avoid duplicated state.

---

# Day 10 — React Router, Component Architecture, and Custom Hooks

## W2D10-S1 — React Router Fundamentals

- React Router setup.
- Route configuration.
- Layout routes.
- Nested routes.
- Route parameters.
- Search parameters.
- Navigation.
- Not-found routes.
- Protected-route pattern.
- Lazy-loaded routes.
- URL state.

## W2D10-S2 — React Frontend Architecture

- Feature-based folders.
- Pages versus components.
- Hooks.
- API clients.
- Context providers.
- State stores.
- Shared UI.
- Avoiding oversized components.
- Colocation.
- Reusable component APIs.
- Error boundaries.

## W2D10-S3 — Custom Hooks

- What a custom hook is.
- Hook naming rules.
- Extracting reusable behavior.
- Hook composition.
- Separating logic from presentation.
- Avoiding overly generic hooks.

## W2D10-S4 — Day 10 Build

Create routes:

- `/`.
- `/items`.
- `/items/:id`.
- `/items/new`.
- `/items/:id/edit`.
- `/login`.
- `/protected`.
- `*` for not found.

Also:

- Use route parameters.
- Store filters in search parameters.
- Create a layout route.
- Lazy-load a route.
- Add an error boundary.
- Extract a reusable search/filter hook.
- Extract a browser-preference hook.

## W2D10-S5 — Day 10 Interview Preparation

- React Router versus Next.js routing.
- Route parameter versus search parameter.
- Why URL state is useful.
- Component versus custom hook.
- What an error boundary catches.
- Why hooks cannot be called conditionally.
- Colocation versus a global utilities folder.

## W2D10-S6 — Day 10 Completion Check

The learner can:

- Build a routed React SPA.
- Extract reusable logic into hooks.
- Organize a production feature.

---

# Day 11 — Effects, Refs, Closures, and External Synchronization

## W2D11-S1 — Closures and Stale Closures

- JavaScript closures.
- Stale closures.

## W2D11-S2 — `useEffect`

- `useEffect`.
- Effect dependencies.
- Dependency-array rules.
- Effect cleanup.
- Synchronizing with external systems.
- Why ordinary derived state does not need an effect.

## W2D11-S3 — Async Work and Race Conditions

- Fetching inside an effect.
- Race conditions.
- AbortController.

## W2D11-S4 — External Side Effects

- Event listeners.
- Timers.
- Subscriptions.

## W2D11-S5 — Refs

- `useRef`.
- DOM refs.
- Mutable values that do not trigger rendering.
- Previous-value patterns.
- `useLayoutEffect` awareness.

## W2D11-S6 — Memoization

- `useMemo`.
- `useCallback`.
- `memo`.
- When memoization is unnecessary.
- React Compiler awareness.

## W2D11-S7 — Day 11 Build

- Synchronize a preference with browser storage.
- Add and clean up a browser event listener.
- Add and clean up a timer.
- Cancel a stale request.
- Demonstrate a stale closure.
- Fix a stale closure.
- Replace an unnecessary effect with derived rendering.
- Use a ref to focus an invalid input.
- Profile before and after one memoization decision.

## W2D11-S8 — Day 11 Interview Preparation

- What belongs in an effect.
- Why effects run more than expected.
- Stale closure.
- Ref versus state.
- Cleanup function.
- `useEffect` versus `useLayoutEffect`.
- `useMemo` versus `useCallback`.
- Why memoization can make code worse.
- Why effects should not orchestrate all application state.

## W2D11-S9 — Day 11 Completion Check

The learner can:

- Write correct effects.
- Prevent leaks and stale updates.
- Explain closure-related bugs.
- Avoid effect abuse.

---

# Day 12 — Forms, Reducers, Dynamic Collections, and Validation

## W2D12-S1 — React Form Fundamentals

- Controlled forms.
- Form submission.
- Complex object state.

## W2D12-S2 — Reducers

- `useReducer`.
- Reducer actions.
- Reducer purity.

## W2D12-S3 — Dynamic Collections and Immutable Updates

- Dynamic arrays.
- Immutable nested updates.

## W2D12-S4 — Validation

- Field-level validation.
- Form-level validation.
- Cross-field validation.
- Touched state.
- Dirty state.
- Validation summaries.
- Server-validation mapping.
- Focus management.

## W2D12-S5 — Form Libraries

- React Hook Form awareness.
- Schema-validation awareness.
- Controlled form-library strategies.
- Uncontrolled form-library strategies.

## W2D12-S6 — Day 12 Build

Create a complex form containing:

- Scalar fields.
- Select fields.
- Nested source/contact object.
- Dynamic ingredient/task/item collection.
- Dynamic steps/sub-items.
- Add actions.
- Remove actions.
- Edit actions.
- Reorder actions.
- Conditional field.
- Cross-field rule.
- Create mode.
- Edit mode.
- Client validation.
- Backend validation.
- Validation summary.
- First-invalid-field focus.
- Unsaved-change warning.

Implement the form first with:

- `useReducer`.

Then recreate a small portion using:

- React Hook Form or an equivalent form-library exercise.

## W2D12-S7 — Day 12 Interview Preparation

- `useState` versus `useReducer`.
- Reducer purity.
- Controlled versus uncontrolled form.
- Form library versus handwritten state.
- Immutable nested updates.
- Client versus server validation.
- Dynamic-array field management.
- Why a reducer can make complex forms easier to reason about.

## W2D12-S8 — Day 12 Completion Check

The learner can:

- Build and validate a complex React form.
- Manage dynamic nested state.
- Explain reducer-based state.

---

# Day 13 — API Integration, Server State, Context, Redux, and Authentication

## W2D13-S1 — React API Integration

- `fetch`.
- Typed API clients.
- Request helpers.
- AbortController.
- Error normalization.
- `ProblemDetails`.

## W2D13-S2 — Server-State Patterns

- Loading state.
- Empty state.
- Success state.
- Error state.
- Pagination.
- Search.
- Filtering.
- Sorting.
- Optimistic updates.
- Retry policy.
- Cache invalidation.
- Server state versus client state.

## W2D13-S3 — Server-State Library Awareness

- RTK Query.
- Query-library concepts.

## W2D13-S4 — Context

- Context.
- Context provider.
- Context consumption.
- Context rerender considerations.
- Reducer plus Context.

## W2D13-S5 — Redux Toolkit

- Redux concepts.
- Redux Toolkit.
- Store configuration.
- Slices.
- Actions.
- Reducers.
- Selectors.
- Middleware.
- Async thunks.
- Redux DevTools.

## W2D13-S6 — RTK Query and State-Tool Selection

- RTK Query.
- When Redux is justified.
- When Context is enough.

## W2D13-S7 — React Authentication

- Login.
- Logout.
- Authentication context.
- Cookie versus bearer token.
- Protected routes.
- Permission-based UI.
- `401`.
- `403`.
- Token-expiration handling.
- Refresh concepts.
- CSRF implications.
- XSS implications.
- Why frontend authorization checks are not security.

## W2D13-S8 — Day 13 Build

- API client.
- List.
- Detail.
- Create.
- Update.
- Delete.
- Paginated search.
- Request cancellation.
- Error normalization.
- Optimistic update.
- Authentication provider.
- Login/logout.
- Protected React Router route.
- Permission-aware component.
- `401` handling.
- Small Redux Toolkit feature.
- Small RTK Query exercise.
- Compare Context and Redux implementations.

## W2D13-S9 — Day 13 Interview Preparation

- Context versus Redux.
- Redux Toolkit versus raw Redux.
- Server state versus global client state.
- RTK Query responsibilities.
- Why not place every API response in Redux.
- Cookie versus bearer token.
- Protected UI versus protected API.
- Optimistic-update rollback.
- Cache invalidation.

## W2D13-S10 — Day 13 Completion Check

The learner can:

- Consume an API robustly.
- Classify server versus client state.
- Implement shared state.
- Explain and use Redux Toolkit.
- Implement a frontend authentication flow.

---

# Day 14 — React Testing, Performance, Accessibility, Security, and Production

## W2D14-S1 — React Testing Foundations

- Unit tests.
- Component tests.
- Integration tests.
- E2E tests.
- Vitest.
- React Testing Library.
- User-event testing.

## W2D14-S2 — Testing React Features

- Mocking API requests.
- Testing Context.
- Testing reducers.
- Testing hooks only when necessary.
- React Router tests.
- Authentication tests.
- Playwright.
- Avoiding implementation-detail tests.

## W2D14-S3 — React Performance

- React Profiler.
- Rerender diagnosis.
- Component boundaries.
- State colocation.
- `memo`.
- `useMemo`.
- `useCallback`.
- Virtualization awareness.
- Lazy loading.
- Code splitting.
- Bundle analysis.
- Avoiding large client dependencies.

## W2D14-S4 — Accessibility

- Semantic HTML.
- Keyboard navigation.
- Focus order.
- Accessible names.
- Form labels.
- Error announcements.
- Modal accessibility.

## W2D14-S5 — Frontend Security

- XSS.
- Unsafe HTML.
- URL validation.
- Safe rendering.
- Environment variables.
- Dependency auditing.

## W2D14-S6 — React Production Concerns

- Vite production build.
- Environment files.
- Build-time configuration.
- Source maps.
- Logging.
- Error reporting.
- SPA hosting.
- Rewrite rules for client routing.

## W2D14-S7 — Day 14 Build

- Reducer tests.
- Component tests.
- API-state tests.
- Router tests.
- Authentication tests.
- One complete E2E workflow.
- Accessibility pass.
- React Profiler investigation.
- Fix one unnecessary rerender.
- Lazy-load one route.
- Analyse the production bundle.
- Create a production build.
- Document deployment requirements.

## W2D14-S8 — Day 14 Interview Preparation

- Unit versus integration versus E2E.
- React Testing Library philosophy.
- What causes unnecessary rerenders.
- `memo` trade-offs.
- State colocation.
- XSS in React.
- Frontend environment variables.
- How a React SPA is deployed.
- How to debug a production-only issue.

## W2D14-S9 — Week 2 Deliverable

A production-style React SPA containing:

- Routing.
- CRUD.
- Complex forms.
- API integration.
- Search.
- Filtering.
- Sorting.
- Pagination.
- Context.
- Redux Toolkit exercise.
- Authentication.
- Error boundaries.
- Accessibility.
- Tests.
- A successful production build.

---

# Week 3 — Next.js and Production Frontend Engineering

# Day 15 — Next.js App Router, Project Structure, and Routing

## W3D15-S1 — Next.js Purpose and Project Structure

- Why Next.js exists.
- React versus Next.js.
- App Router.
- Project structure.
- `app` directory.

## W3D15-S2 — Pages and Layouts

- Pages.
- Layouts.
- Nested layouts.
- Route groups.

## W3D15-S3 — Routing

- Dynamic segments.
- Catch-all segments.
- Search parameters.
- Navigation.

## W3D15-S4 — Route UI Boundaries

- Loading UI.
- Error UI.
- Not-found UI.

## W3D15-S5 — Metadata and Assets

- Metadata.
- Static assets.
- Fonts awareness.
- Image awareness.

## W3D15-S6 — Environment and Commands

- Environment variables.
- Server-only variables.
- Public variables.
- Development commands.
- Production commands.

## W3D15-S7 — Day 15 Build

- Scaffold a Next.js application.
- Create root layout.
- Create feature layout.
- Add routes:
  - `/`.
  - `/items`.
  - `/items/[id]`.
  - `/items/new`.
  - `/items/[id]/edit`.
  - `/login`.
  - `/protected`.
- Add loading UI.
- Add error UI.
- Add not-found handling.
- Add metadata.
- Add navigation.
- Read search parameters.

## W3D15-S8 — Day 15 Interview Preparation

- React versus Next.js.
- App Router versus React Router.
- Page versus layout.
- Dynamic route segment.
- Route group.
- Loading and error boundaries.
- Public versus server-only environment variable.
- Why Next.js requires deployment choices different from a static SPA.

## W3D15-S9 — Day 15 Completion Check

The learner can:

- Navigate the App Router.
- Create nested layouts and dynamic routes.
- Explain Next.js project structure.

---

# Day 16 — Server Components, Client Components, Rendering, and Hydration

## W3D16-S1 — Server and Client Components

- Server Components.
- Client Components.
- Default component type.
- `"use client"`.

## W3D16-S2 — Client Boundary Design

- Client-boundary placement.
- Serializable props.
- Server/client composition.

## W3D16-S3 — Hydration and Streaming

- Hydration.
- What is hydrated.
- What is not hydrated.
- Streaming.
- Suspense.

## W3D16-S4 — Rendering Modes

- Static rendering.
- Dynamic rendering.
- Request-time rendering.
- Prerendering.

## W3D16-S5 — Environment Boundaries

- Browser-only APIs.
- Server-only modules.
- Avoiding secrets in the client bundle.

## W3D16-S6 — Performance and SEO Implications

- Bundle-size implications.
- SEO implications.
- Metadata implications.

## W3D16-S7 — Day 16 Build

- Server-rendered list page.
- Server-rendered details page.
- Interactive client filter.
- Client-side form.
- Server component that renders a client component.
- Suspense boundary.
- Streaming loading state.
- Browser-only component.
- Narrow a client boundary that was initially too broad.
- Verify which code executes on the server.
- Verify which code executes in the browser.

## W3D16-S8 — Day 16 Interview Preparation

- Server Component versus Client Component.
- What `"use client"` actually marks.
- Hydration.
- Streaming.
- Why hooks do not work in Server Components.
- Why secrets can remain in server code.
- Why the whole application should not be a Client Component.
- SSR versus Server Components.
- Static versus dynamic rendering.

## W3D16-S9 — Day 16 Completion Check

The learner can:

- Decide where a component should run.
- Keep interactive boundaries narrow.
- Explain hydration and streaming.

---

# Day 17 — Next.js Data Fetching, Caching, Mutations, and Backend Patterns

## W3D17-S1 — Data Fetching

- Fetching in Server Components.
- Fetching in Client Components.
- Calling the ASP.NET Core API from server code.
- Request deduplication concepts.

## W3D17-S2 — Caching and Revalidation

- Caching.
- Dynamic data.
- Revalidation.
- Tag-based invalidation concepts.
- Path-based invalidation concepts.

## W3D17-S3 — Mutations

- Mutations.
- Server Actions.
- Client-side mutations.
- Redirects.
- Optimistic UI.

## W3D17-S4 — Route Handlers and Backend Patterns

- Route Handlers.
- Backend-for-frontend pattern.
- Proxying to an external API.
- Error propagation.
- `ProblemDetails`.

## W3D17-S5 — URL State and Data Operations

- Search parameters as state.
- Pagination.
- Filtering.
- Sorting.
- API contract reuse.

## W3D17-S6 — Database and Architecture Options

- Direct database access as an architectural option.
- Why this course keeps the shared ASP.NET Core API as the primary backend.

## W3D17-S7 — Day 17 Build

- Server-side list fetch.
- Server-side detail fetch.
- Client-side mutation.
- One Server Action exercise.
- One Route Handler exercise.
- Search through URL parameters.
- Pagination through URL parameters.
- Create flow.
- Update flow.
- Delete flow.
- Revalidation after mutation.
- Error translation.
- Optimistic UI example.

Compare:

- Browser → ASP.NET Core API.
- Next.js server → ASP.NET Core API.
- Browser → Route Handler → ASP.NET Core API.

## W3D17-S8 — Day 17 Interview Preparation

- Server Action versus Route Handler.
- Route Handler versus ASP.NET Core endpoint.
- Server fetch versus client fetch.
- Cache versus no-store behavior.
- Revalidation.
- URL state.
- Backend-for-frontend.
- Why server state should not automatically be copied into global client state.
- When direct database access from Next.js is appropriate.
- When direct database access from Next.js is inappropriate.

## W3D17-S9 — Day 17 Completion Check

The learner can:

- Fetch and mutate data from both server and client contexts.
- Explain caching and revalidation.
- Choose an appropriate backend interaction pattern.

---

# Day 18 — Authentication and Authorization Across Angular, React, and Next.js

## W3D18-S1 — Core Authentication Model

- Authentication versus authorization.
- Session-based authentication.
- Cookie-based authentication.
- Bearer tokens.
- JWT structure.
- JWT limitations.

## W3D18-S2 — Token and Session Lifecycle

- Access tokens.
- Refresh tokens.
- Token expiry.
- Session expiry.
- Logout.

## W3D18-S3 — Cookie Security

- Secure cookies.
- HttpOnly cookies.
- SameSite cookies.

## W3D18-S4 — Web Security Around Authentication

- CSRF.
- XSS.
- CORS.
- UI hiding versus real API enforcement.

## W3D18-S5 — Authorization Models

- Role-based authorization.
- Permission-based authorization.

## W3D18-S6 — Angular Authentication

- Authentication service.
- Auth signal/store.
- HTTP interceptor.
- Route guard.
- `401` handling.
- Refresh/session-renewal concepts.

## W3D18-S7 — React SPA Authentication

- Authentication provider.
- Protected React Router route.
- Authenticated API client.
- Permission-aware components.
- Session-expiration handling.

## W3D18-S8 — Next.js Authentication

- Server-side session access.
- Protected Server Component.
- Redirecting unauthenticated users.
- Middleware awareness.
- Route Handler protection.
- Server Action authorization.
- Client authentication state only where needed.
- Preventing server-only session data from leaking into client components.

## W3D18-S9 — Day 18 Build

Implement a coherent mock or real authentication flow:

- Login.
- Logout.
- Current-user endpoint.
- Protected Angular route.
- Protected React route.
- Protected Next.js server-rendered page.
- Role- or permission-restricted feature.
- `401` response handling.
- `403` response handling.
- Session-expiration behavior.
- One protected-route E2E test per frontend.
- Verify that direct API access is also protected.

## W3D18-S10 — Day 18 Interview Preparation

- Authentication versus authorization.
- Cookie versus bearer token.
- Local storage token risks.
- `401` versus `403`.
- CSRF versus XSS.
- Route guard versus backend security.
- Middleware versus Server Component authorization.
- Why authentication state should not blindly be duplicated everywhere.
- How logout should behave.
- How session expiration should behave.

## W3D18-S11 — Day 18 Completion Check

The learner can:

- Explain the complete authentication flow.
- Protect routes in all three frontend models.
- Identify common frontend authentication mistakes.

---

# Day 19 — Localization, Accessibility, Files, Images, Live Preview, and PDF

## W3D19-S1 — Localization Fundamentals

- UI language.
- Stored-content language.
- Output language.
- Translation-resource organization.
- Locale switching.
- Persisting locale.
- Date formatting.
- Number formatting.
- Right-to-left awareness.
- Localized validation.
- Avoiding hard-coded UI text.

## W3D19-S2 — Accessibility Fundamentals

- Semantic HTML.
- Keyboard navigation.
- Focus management.
- Skip links.
- Accessible names.
- ARIA only when necessary.
- Dynamic validation announcements.

## W3D19-S3 — Accessibility for Complex UI

- Accessible modals.
- Accessible drag/reordering alternatives.
- Color contrast.
- Reduced-motion awareness.

## W3D19-S4 — Files and Images

- File input.
- File metadata.
- Client-side preview.
- Object URLs.
- Object URL cleanup.
- Image URL versus file upload.
- Multipart form data.
- Upload progress.
- File-size validation.
- File-type validation.
- Backend storage options.
- Security limitations of client-side file checks.
- Image optimization awareness.

## W3D19-S5 — Live Preview

- Derived preview state.
- Configuration-driven rendering.

## W3D19-S6 — Print and PDF

- Print-specific CSS.
- Page size.
- Page breaks.
- Print routes.
- Browser Save as PDF.
- Client-generated versus server-generated PDF.
- Binary HTTP responses.
- `Content-Disposition`.
- Download handling.
- Object URLs for downloads.
- Template security.

## W3D19-S7 — Day 19 Build

- Language selector.
- At least two UI languages.
- Separate content/output-language concept.
- Localized built-in messages.
- Accessible form.
- Validation summary.
- Keyboard-operable dynamic collection.
- Image preview.
- File-validation feedback.
- Live derived preview.
- Two output templates.
- Print-friendly route.
- Browser Save as PDF.
- Binary-download exercise.
- Meaningful document title.
- Meaningful filename.

## W3D19-S8 — Day 19 Interview Preparation

- Localization versus translating stored content.
- Accessibility responsibilities of frontend developers.
- When ARIA is appropriate.
- Image URL versus upload.
- Why file validation must also occur on the server.
- Browser-generated versus server-generated PDF.
- Binary-response handling.
- Security risks of user-authored HTML and CSS.

## W3D19-S9 — Day 19 Completion Check

The learner can:

- Build localized and accessible UI.
- Handle a file or image.
- Build a live preview.
- Generate or download a printable document.

---

# Day 20 — Testing, Debugging, Performance, CI, and Deployment

## W3D20-S1 — Cross-Framework Testing

- Unit testing.
- Component testing.
- Integration testing.
- Contract testing awareness.
- End-to-end testing.
- Test pyramid trade-offs.
- Mocking versus real infrastructure.
- Authentication testing.
- Accessibility testing.
- Visual-regression awareness.
- Flaky-test prevention.

## W3D20-S2 — Browser Debugging

- Browser DevTools.
- Network tab.
- Console.
- Sources.
- Breakpoints.
- Source maps.
- Performance panel.
- Memory awareness.

## W3D20-S3 — Framework Debugging

- Angular DevTools.
- React DevTools.
- React Profiler.
- Server logs.
- Correlation IDs.
- Debugging server/client boundary issues.

## W3D20-S4 — Performance Fundamentals

- Measuring before optimizing.
- Angular change detection.
- `OnPush`.
- Stable list identity.
- React rerenders.
- State colocation.
- Memoization.
- Next.js client-boundary size.

## W3D20-S5 — Performance Techniques

- Lazy loading.
- Code splitting.
- Bundle analysis.
- Request waterfalls.
- Image loading.
- Web-performance metrics awareness.
- Virtualization awareness.

## W3D20-S6 — CI and Code Quality

- Type checking.
- Linting.
- Formatting.
- Unit tests.
- Integration tests.
- E2E tests.
- Production build.
- Dependency audit.
- Pull-request checks.
- Build artifacts.
- Environment configuration.

## W3D20-S7 — Deployment

- Angular static-SPA deployment.
- React static-SPA deployment.
- Next.js server deployment.
- Static export limitations.
- ASP.NET Core API deployment.
- Reverse proxy.
- Production CORS.
- Environment secrets.
- Docker overview.
- Logging and monitoring.
- Health checks.
- Rollback concepts.
- Release verification.

## W3D20-S8 — Day 20 Build

- Complete production builds for all frontends.
- Run type checking.
- Run linting.
- Run unit tests.
- Run component tests.
- Run E2E tests.
- Add CI workflow.
- Add accessibility check.
- Analyse bundles.
- Profile one Angular path.
- Profile one React path.
- Inspect Next.js server/client bundle boundaries.
- Fix one measurable performance problem.
- Document environment variables.
- Document startup commands.
- Document deployment architecture.
- Create a production-release checklist.

## W3D20-S9 — Day 20 Interview Preparation

- Unit versus integration versus E2E.
- Testing pyramid limitations.
- Diagnosing an HTTP failure.
- Diagnosing an unnecessary Angular update.
- Diagnosing a React rerender.
- Diagnosing a Next.js hydration problem.
- Source maps.
- Bundle size.
- CI quality gates.
- SPA versus Next.js deployment.
- Production CORS.
- Logging and monitoring strategy.

## W3D20-S10 — Day 20 Completion Check

The learner can:

- Build and test all applications.
- Diagnose common failures.
- Explain how each application is deployed.
- Describe a production CI/CD pipeline.

---

# Day 21 — Capstone, Code Review, Architecture, and Interview Bootcamp

## W3D21-S1 — Independent Capstone

Implement one unfamiliar feature in all relevant frontends without a prepared solution.

Possible features:

- Duplicate an item.
- Favorite an item.
- Archive and restore.
- Saved filter presets.
- New output-template option.
- Role-restricted operation.
- Bulk selection and action.
- URL-driven filtering.
- File attachment.
- Optimistic status update.

Requirements:

- Angular implementation.
- React implementation.
- Next.js implementation where appropriate.
- API integration.
- Authentication or permission handling where applicable.
- Loading states.
- Error states.
- Accessibility.
- Unit or component tests.
- E2E coverage for the main path.
- Production builds.
- Diff review.

## W3D21-S2 — Code Review Exercise

Review code containing intentional issues:

- Oversized component.
- Duplicated state.
- Missing effect cleanup.
- Nested subscription.
- Incorrect list key.
- Unsafe token handling.
- Missing authorization assumption.
- Inaccessible form.
- Unnecessary global state.
- Repeated API request.
- Missing loading state.
- Poor error handling.
- Unnecessary client component.
- Overuse of memoization.

Explain:

- What is wrong.
- Why it matters.
- How to fix it.
- How to test the correction.

## W3D21-S3 — Architecture Comparison

Explain the same feature in:

- Angular.
- React SPA.
- Next.js.

Compare:

- Component model.
- Routing.
- Dependency injection.
- State ownership.
- Forms.
- API integration.
- Authentication.
- Rendering model.
- Testing.
- Performance.
- Deployment.

## W3D21-S4 — Angular Interview Round

Cover:

- Components.
- Directives.
- Pipes.
- Standalone components.
- NgModules.
- Inputs and outputs.
- Content projection.
- Lifecycle hooks.
- Dependency injection.
- Provider scopes.
- Routing and lazy loading.
- Guards.
- Reactive Forms.
- RxJS.
- Signals.
- Change detection.
- `OnPush`.
- HTTP interceptors.
- NgRx.
- Authentication.
- Testing.
- Performance.

## W3D21-S5 — React Interview Round

Cover:

- Props and state.
- State snapshots.
- Batching.
- Keys.
- Immutability.
- Controlled inputs.
- Lifting state.
- Derived state.
- Render and commit.
- Closures.
- Effects.
- Refs.
- Custom hooks.
- Reducers.
- Context.
- Redux Toolkit.
- Server state.
- Authentication.
- Testing.
- Performance.

## W3D21-S6 — Next.js Interview Round

Cover:

- React versus Next.js.
- App Router.
- Pages and layouts.
- Server Components.
- Client Components.
- `"use client"`.
- Hydration.
- Streaming.
- Static rendering.
- Dynamic rendering.
- Data fetching.
- Caching.
- Revalidation.
- Server Actions.
- Route Handlers.
- Authentication.
- Middleware.
- Environment variables.
- Error boundaries.
- Loading boundaries.
- Deployment.

## W3D21-S7 — Practical Interview Exercises

- Build a small reusable component.
- Implement a dynamic form section.
- Debug an Angular subscription.
- Debug a React effect.
- Diagnose a stale closure.
- Design state ownership.
- Explain a failed HTTP request.
- Fix an accessibility issue.
- Explain `401` versus `403`.
- Design a protected frontend route.
- Explain a hydration error.
- Review a rendering-performance problem.
- Explain the complete system architecture.

## W3D21-S8 — Final Architecture Explanation

Be able to explain:

```text
Browser
→ Angular, React SPA, or Next.js
→ ASP.NET Core API
→ EF Core
→ Database
```

Also explain:

- Why frontends do not directly access the database.
- Why the same API contract supports multiple frontends.
- How authentication is enforced.
- How state is divided.
- How validation is split between frontend and API.
- How testing is divided across layers.
- How production builds are deployed.
- How logs and errors are investigated.

---

# Final Definition of Completion

## FC-S1 — Application Skills

The course is complete only when the learner can:

- Run Angular locally.
- Run React locally.
- Run Next.js locally.
- Run the API locally.
- Explain each frontend project structure.
- Create and route a new feature.
- Build reusable components.
- Build complex dynamic forms.
- Consume and debug an API.
- Implement loading states.
- Implement empty states.
- Implement success states.
- Implement error states.

## FC-S2 — Authentication and State Skills

The learner can:

- Implement login.
- Implement logout.
- Implement protected routes.
- Explain cookie authentication.
- Explain bearer-token authentication.
- Select an appropriate state-management strategy.
- Use Angular signals.
- Use RxJS.
- Use React hooks.
- Use React Context.
- Use reducers.
- Explain NgRx.
- Explain Redux Toolkit.
- Understand Server Components.
- Understand Client Components.

## FC-S3 — Quality and Production Skills

The learner can:

- Write meaningful unit tests.
- Write meaningful component tests.
- Write meaningful integration tests.
- Write meaningful E2E tests.
- Identify accessibility problems.
- Identify common frontend-security problems.
- Diagnose unnecessary renders.
- Diagnose unnecessary subscriptions.
- Build production versions of every frontend.
- Explain deployment differences.
- Pass framework-specific mock interviews.
- Implement a small feature with limited guidance.

---

# Topics Covered but Not Deeply Implemented

## TA-S1 — Legacy and Advanced Topics

These topics are included for production and interview awareness but do not require expert-level implementation during the three weeks:

- Legacy Angular NgModule-heavy architecture.
- Legacy React class components.
- Next.js Pages Router.
- Raw Redux without Redux Toolkit.
- Advanced webpack or bundler customization.
- Micro-frontends.
- Full identity-provider implementation.
- Advanced web-performance optimization.
- Full drag-and-drop visual page builders.
- Advanced visual-regression infrastructure.

---

# Daily Progress Tracking

## PT-S1 — PROGRESS.md

After every day, update `docs/course/PROGRESS.md` with:

- Current day.
- Topics completed.
- Code completed.
- Tests completed.
- Interview questions answered.
- Problems encountered.
- Topics requiring revision.
- Next implementation task.

## PT-S2 — NOTES.md

Record detailed explanations and personal notes in:

`docs/course/NOTES.md`