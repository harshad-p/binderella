# Angular, React, and Next.js: 21-Day Production Crash Course

## Course Goal

Complete a comprehensive frontend crash course in exactly three weeks:

- Week 1: Angular — Days 1–7
- Week 2: React — Days 8–14
- Week 3: Next.js and production engineering — Days 15–21

This course should prepare the learner to:

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

## Time Commitment

- 21 actual instructional days.
- No placeholder, catch-up, or rest days are counted as course days.
- Approximately 3–5 focused hours per day.
- Every day contains:
  - Concept learning.
  - Guided implementation.
  - Independent work.
  - Testing or debugging.
  - Interview preparation.

## Assumed Knowledge

The learner already knows:

- JavaScript fundamentals.
- Some TypeScript.
- C# and ASP.NET Core.
- Blazor.
- General application architecture.
- REST APIs and SQL basics.

Therefore, the course will not spend significant time on basic programming,
basic HTML, or elementary CSS.

## Application Strategy

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

## Backend Boundary

The ASP.NET Core API is supporting infrastructure, not the primary subject.

Frontend applications communicate with it through HTTP and JSON:

Angular / React / Next.js
→ ASP.NET Core API
→ EF Core
→ Database

The frontend curriculum covers:

- DTO contracts.
- HTTP methods and status codes.
- Validation responses.
- Authentication flow.
- CORS.
- Pagination and filtering.
- Error handling.

Deep ASP.NET Core architecture and EF Core internals are outside the main
course unless they directly affect frontend development.

## Teaching Workflow

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

Codex must not generate an entire lesson before the relevant concepts have
been taught.

---

# Week 1 — Angular

## Day 1 — TypeScript Sprint and Angular Project Anatomy

### Learn

#### TypeScript

- Type inference.
- Explicit annotations.
- Primitive and object types.
- Interfaces versus type aliases.
- Union and intersection types.
- Literal types.
- Optional and readonly properties.
- Arrays, tuples, and generics.
- Function and callback types.
- Type narrowing.
- Discriminated unions.
- Classes and access modifiers.
- Abstract classes and interfaces.
- `Promise<T>` and `async`/`await`.
- Utility types:
  - `Partial<T>`.
  - `Required<T>`.
  - `Pick<T>`.
  - `Omit<T>`.
  - `Record<TKey, TValue>`.
- Modules, imports, and exports.
- Strict null checking.
- Why TypeScript types do not provide runtime validation.

#### Angular project anatomy

- Angular CLI.
- Workspace structure.
- `package.json`.
- Lockfiles.
- `angular.json`.
- TypeScript configuration.
- Application bootstrap.
- Standalone components.
- Application configuration.
- Development server.
- Production build.
- Test command.
- Angular DevTools.
- Linting and formatting expectations.
- Environment-specific configuration.

### Build

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

### Blazor comparison

- Razor component versus Angular component.
- `[Parameter]` versus input.
- `EventCallback` versus output.
- Razor markup versus Angular template.
- Dependency injection in Blazor versus Angular.
- Component state versus signals and properties.
- Lifecycle methods in both frameworks.

### Interview preparation

- TypeScript versus JavaScript.
- Compile-time type checking versus runtime validation.
- Interface versus type alias.
- Union type versus enum.
- Angular framework versus Angular CLI.
- Standalone component versus NgModule.
- Why strict TypeScript improves production code.

### Completion check

The learner can:

- Run the Angular application.
- Explain the workspace.
- Create and import a standalone component.
- Explain where the application boots.
- Build the application successfully.

---

## Day 2 — Components, Templates, Directives, and Communication

### Learn

- Component metadata.
- Selectors.
- Inline versus external templates.
- Component styles and style encapsulation.
- Interpolation.
- Property binding.
- Attribute binding.
- Class and style binding.
- Event binding.
- Two-way binding.
- Template reference variables.
- Modern control flow:
  - `@if`.
  - `@for`.
  - `@switch`.
- Tracking list items correctly.
- Built-in directives.
- Custom attribute directives.
- Pipes.
- Pure versus impure pipes.
- Inputs.
- Required inputs.
- Input transformation awareness.
- Outputs and custom events.
- Parent-to-child communication.
- Child-to-parent communication.
- Sibling communication through a parent.
- Content projection.
- Single-slot and multi-slot projection.
- Component lifecycle hooks.
- Component composition.
- Smart/feature components versus presentational components.
- Avoiding excessive logic in templates.

### Build

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

### Interview preparation

- Component versus directive.
- Input versus output.
- Content projection versus passing inputs.
- Pipe versus component method.
- Pure versus impure pipe.
- Lifecycle hook use cases.
- Why stable list identity matters.
- Presentational versus feature components.
- Why business logic should not live in templates.

### Completion check

The learner can:

- Break a screen into components.
- Pass data downward.
- Send events upward.
- Render lists safely.
- Explain Angular template syntax.

---

## Day 3 — Routing, Dependency Injection, and Frontend Architecture

### Learn

#### Routing

- Router configuration.
- Router outlet.
- Navigation with router links.
- Active navigation state.
- Static routes.
- Route parameters.
- Query parameters.
- Fragments.
- Nested routes.
- Child routes.
- Route data.
- Programmatic navigation.
- Not-found routes.
- Lazy-loaded routes.
- Route-level code splitting.
- Route guards.
- `CanActivate`.
- `CanDeactivate`.
- Route resolvers and when to avoid them.
- Why route guards are not a security boundary.

#### Dependency injection

- Angular services.
- `@Injectable`.
- Constructor injection.
- `inject()`.
- Injection tokens.
- Root providers.
- Route-level providers.
- Component-level providers.
- Injector hierarchy.
- Service instance lifetime.
- Avoiding accidental multiple service instances.

#### Architecture

- Feature-based folder organization.
- Pages versus reusable components.
- Services.
- Models and API contracts.
- Shared UI components.
- Core application services.
- Keeping feature boundaries clear.
- Avoiding one giant shared module or shared folder.
- Container/presentational component separation.
- Environment configuration.

### Build

Create routes:

- `/`
- `/items`
- `/items/:id`
- `/items/new`
- `/items/:id/edit`
- `/login`
- `/protected`
- `**` for not found

Also:

- Read a route parameter.
- Read and update query parameters.
- Add active navigation.
- Lazy-load the primary feature.
- Create a feature service.
- Create an unsaved-changes guard.
- Create a placeholder protected-route guard.
- Add a not-found page.

### Interview preparation

- Route parameter versus query parameter.
- Lazy loading and why it matters.
- Route guard versus backend authorization.
- Service versus component responsibility.
- Root provider versus component provider.
- How Angular resolves dependencies.
- Why component-level providers create separate instances.
- Feature folders versus technical-layer folders.

### Completion check

The learner can:

- Add a routed feature.
- Lazy-load it.
- Inject a service.
- Explain provider scope.
- Read and change URL state.

---

## Day 4 — HTTP, RxJS, Server State, and Error Handling

### Learn

#### HTTP

- Configuring `HttpClient`.
- Typed request and response objects.
- GET, POST, PUT, PATCH, and DELETE.
- Query-string construction.
- Headers.
- Request options.
- JSON serialization.
- DTO mapping.
- Development proxy configuration.
- CORS.
- HTTP status codes.
- ASP.NET Core `ProblemDetails`.
- Validation problem responses.

#### RxJS

- Observable versus Promise.
- Cold versus hot Observable.
- Subscription lifecycle.
- Async pipe.
- Declarative subscription patterns.
- `map`.
- `filter`.
- `tap`.
- `switchMap`.
- `mergeMap`.
- `concatMap`.
- `exhaustMap`.
- `debounceTime`.
- `distinctUntilChanged`.
- `catchError`.
- `finalize`.
- `combineLatest`.
- `forkJoin`.
- Request cancellation.
- Why nested subscriptions are problematic.
- `takeUntilDestroyed`.
- Signals and Observable interoperability.

#### HTTP architecture

- API service responsibilities.
- Server state versus local UI state.
- Loading, empty, success, and error states.
- Global versus feature-specific error handling.
- Functional HTTP interceptors.
- Correlation IDs.
- Authentication-header awareness.
- Retry only when safe.
- Optimistic updates and rollback.

### Build

- API contract interfaces.
- API client service.
- Load a list.
- Load a detail.
- Create an item.
- Update an item.
- Delete an item.
- Search with debounce.
- Filter and sort through query parameters.
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

### Interview preparation

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

### Completion check

The learner can:

- Consume a typed API.
- Handle cancellation.
- Display every major request state.
- Explain core RxJS flattening operators.
- Debug an HTTP failure.

---

## Day 5 — Typed Reactive Forms and Complex Validation

### Learn

- Reactive Forms mental model.
- Typed forms.
- `FormControl`.
- `FormGroup`.
- `FormArray`.
- `FormBuilder`.
- Non-nullable controls.
- Nested groups.
- Dynamic collections.
- Built-in validators.
- Custom validators.
- Cross-field validators.
- Async validators.
- Conditional validation.
- Form status:
  - Pristine and dirty.
  - Touched and untouched.
  - Valid and invalid.
  - Pending.
- `setValue` versus `patchValue`.
- Form submission.
- Reset behavior.
- Editing existing data.
- Mapping DTOs to forms.
- Mapping forms to request DTOs.
- Mapping backend errors to fields.
- Validation summaries.
- Focusing the first invalid control.
- Unsaved-change detection.
- Comparison with template-driven forms.
- Awareness of newer signal-based form approaches.

### Build

Create a production-style form with:

- Scalar fields.
- Select fields.
- Optional section.
- URL field.
- Nested object.
- Dynamic ingredient/task/item collection.
- Dynamic step/sub-item collection.
- Add, remove, edit, and reorder operations.
- Custom cross-field rule.
- Conditional field requirement.
- Async uniqueness-validation example.
- Create mode.
- Edit mode.
- Backend validation mapping.
- Validation summary.
- Unsaved-change warning.
- Accessible labels and error messages.

### Interview preparation

- Reactive versus template-driven forms.
- `FormGroup` versus `FormArray`.
- `setValue` versus `patchValue`.
- Synchronous versus asynchronous validators.
- Client validation versus server validation.
- Why client validation is never authoritative.
- How to model dynamic collections.
- How to handle backend field errors.

### Completion check

The learner can:

- Build a deeply nested typed form.
- Add and remove dynamic controls.
- Validate it correctly.
- Convert between form state and API DTOs.

---

## Day 6 — Signals, RxJS, NgRx, and State Management

### Learn

#### State classification

- Local UI state.
- Form state.
- Derived state.
- URL state.
- Server state.
- Authentication state.
- Shared feature state.
- Global application state.

#### Signals

- Writable signals.
- Reading and setting signals.
- Updating signals.
- Computed signals.
- Effects.
- When not to use effects.
- Derived state.
- Signal equality awareness.
- Signal inputs and model inputs awareness.
- Signals and change detection.
- Signals with RxJS.
- Injectable signal-based stores.

#### RxJS-based state

- Subjects.
- BehaviorSubject.
- ReplaySubject.
- Observable state streams.
- Combining streams.
- Avoiding manual state synchronization.

#### NgRx

- When NgRx is justified.
- Store.
- Actions.
- Reducers.
- Selectors.
- Effects.
- Entity-style state.
- NgRx DevTools.
- Signal Store.
- NgRx Store versus Signal Store.
- Avoiding global state for everything.

### Build

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

### Interview preparation

- Signal versus Observable.
- Computed signal versus effect.
- Signal service versus NgRx.
- NgRx Store versus Signal Store.
- Local versus global state.
- Why derived state should not normally be stored.
- URL state versus in-memory state.
- When Redux-style architecture is excessive.

### Completion check

The learner can:

- Classify state before choosing a tool.
- Implement shared state with signals.
- Explain NgRx architecture.
- Defend a state-management choice.

---

## Day 7 — Angular Authentication, Testing, Performance, and Production

### Learn

#### Authentication and authorization

- Authentication versus authorization.
- Cookie-based sessions.
- Bearer tokens.
- JWT structure awareness.
- Login and logout flow.
- Access-token expiration.
- Refresh-token concepts.
- Safe token handling.
- Why local storage may be inappropriate for sensitive tokens.
- CSRF and XSS implications.
- Authentication service.
- Authentication state.
- Functional auth interceptor.
- Route guards.
- Role and permission checks.
- `401 Unauthorized`.
- `403 Forbidden`.
- Session expiration.
- Why frontend guards do not secure the API.

#### Testing

- Test pyramid.
- Unit tests.
- Component tests.
- Integration tests.
- End-to-end tests.
- Vitest.
- Angular testing utilities.
- Testing services.
- Testing components.
- Testing signals.
- Testing forms.
- Mocking HTTP.
- Router tests.
- Testing guards and interceptors.
- Testing user-visible behavior.
- Avoiding tests coupled to implementation details.

#### Performance and production

- Change detection.
- Default versus `OnPush`.
- Signals and rendering.
- Stable list tracking.
- Lazy loading.
- Deferrable views awareness.
- Avoiding unnecessary subscriptions.
- Bundle analysis.
- Angular DevTools.
- Production builds.
- Environment configuration.
- Source maps.
- Accessibility checks.
- XSS protection.
- Dependency auditing.

### Build

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
- Guard and interceptor tests.
- One protected-route E2E test.
- Production Angular build.
- Performance inspection with Angular DevTools.

### Interview preparation

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

### Week 1 deliverable

A production-style Angular application containing:

- Routing.
- CRUD.
- Complex typed forms.
- API integration.
- Search, filtering, sorting, and pagination.
- State management.
- Authentication.
- Protected routes.
- Error handling.
- Accessibility.
- Tests.
- A successful production build.

---

# Week 2 — React

## Day 8 — React Setup, JSX, Components, and Composition

### Learn

- React as a UI library.
- Vite-based React setup.
- Project structure.
- JSX and TSX.
- JSX expressions.
- Function components.
- Props.
- Prop typing.
- `children`.
- Component composition.
- Conditional rendering.
- Rendering lists.
- Keys.
- Events.
- Declarative rendering.
- Immutability.
- CSS approaches.
- Component responsibility.
- Presentational versus feature components.
- React DevTools.

### Build

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

### Blazor comparison

- Razor component versus function component.
- `[Parameter]` versus props.
- `EventCallback` versus callback prop.
- `RenderFragment` versus `children`.
- Component field versus React state.
- Cascading values versus Context.

### Interview preparation

- React library versus framework.
- Props versus state.
- Why keys matter.
- Why array index is often a poor key.
- Composition versus inheritance.
- Declarative versus imperative UI.
- Why React state should be treated as immutable.

### Completion check

The learner can:

- Create typed function components.
- Compose components.
- Pass data and callbacks.
- Render lists safely.

---

## Day 9 — State, Events, Rendering, and Controlled Inputs

### Learn

- `useState`.
- Initial state.
- State as a snapshot.
- Functional state updates.
- Batching.
- Event handlers.
- Synthetic-event awareness.
- Controlled inputs.
- Uncontrolled-input awareness.
- Lifting state.
- Single source of truth.
- Derived state.
- Avoiding redundant state.
- Immutable array updates.
- Immutable object updates.
- Render phase.
- Commit phase.
- What causes a rerender.
- Parent rerenders and child rerenders.
- Strict Mode development behavior.

### Build

- Search field.
- Filter controls.
- Sort controls.
- Selected item.
- Modal or drawer state.
- Controlled form fields.
- Derived filtered list.
- Immutable add, update, and remove operations.
- State lifted to the correct owner.
- Remove one redundant state variable.

### Interview preparation

- Props versus state.
- State snapshot.
- Why state updates appear asynchronous.
- Functional update versus direct update.
- Batching.
- Controlled versus uncontrolled input.
- Lifting state.
- Why derived values should usually be calculated during render.
- What causes a React component to rerender.

### Completion check

The learner can:

- Model local React state.
- Update arrays and objects immutably.
- Explain state snapshots and batching.
- Avoid duplicated state.

---

## Day 10 — React Router, Component Architecture, and Custom Hooks

### Learn

#### Routing

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

#### Architecture

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

#### Custom hooks

- What a custom hook is.
- Hook naming rules.
- Extracting reusable behavior.
- Hook composition.
- Separating logic from presentation.
- Avoiding overly generic hooks.

### Build

Create routes:

- `/`
- `/items`
- `/items/:id`
- `/items/new`
- `/items/:id/edit`
- `/login`
- `/protected`
- `*` for not found

Also:

- Use route parameters.
- Store filters in search parameters.
- Create a layout route.
- Lazy-load a route.
- Add an error boundary.
- Extract a reusable search/filter hook.
- Extract a browser-preference hook.

### Interview preparation

- React Router versus Next.js routing.
- Route parameter versus search parameter.
- Why URL state is useful.
- Component versus custom hook.
- What an error boundary catches.
- Why hooks cannot be called conditionally.
- Colocation versus a global utilities folder.

### Completion check

The learner can:

- Build a routed React SPA.
- Extract reusable logic into hooks.
- Organize a production feature.

---

## Day 11 — Effects, Refs, Closures, and External Synchronization

### Learn

- JavaScript closures.
- Stale closures.
- `useEffect`.
- Effect dependencies.
- Dependency-array rules.
- Effect cleanup.
- Synchronizing with external systems.
- Why ordinary derived state does not need an effect.
- Fetching inside an effect.
- Race conditions.
- AbortController.
- Event listeners.
- Timers.
- Subscriptions.
- `useRef`.
- DOM refs.
- Mutable values that do not trigger rendering.
- Previous-value patterns.
- `useLayoutEffect` awareness.
- `useMemo`.
- `useCallback`.
- `memo`.
- When memoization is unnecessary.
- React Compiler awareness.

### Build

- Synchronize a preference with browser storage.
- Add and clean up a browser event listener.
- Add and clean up a timer.
- Cancel a stale request.
- Demonstrate and fix a stale closure.
- Replace an unnecessary effect with derived rendering.
- Use a ref to focus an invalid input.
- Profile before and after one memoization decision.

### Interview preparation

- What belongs in an effect.
- Why effects run more than expected.
- Stale closure.
- Ref versus state.
- Cleanup function.
- `useEffect` versus `useLayoutEffect`.
- `useMemo` versus `useCallback`.
- Why memoization can make code worse.
- Why effects should not orchestrate all application state.

### Completion check

The learner can:

- Write correct effects.
- Prevent leaks and stale updates.
- Explain closure-related bugs.
- Avoid effect abuse.

---

## Day 12 — Forms, Reducers, Dynamic Collections, and Validation

### Learn

- Controlled forms.
- Form submission.
- Complex object state.
- `useReducer`.
- Reducer actions.
- Reducer purity.
- Dynamic arrays.
- Immutable nested updates.
- Field-level validation.
- Form-level validation.
- Cross-field validation.
- Touched and dirty state.
- Validation summaries.
- Server-validation mapping.
- Focus management.
- React Hook Form awareness.
- Schema-validation awareness.
- Controlled versus uncontrolled form-library strategies.

### Build

Create a complex form containing:

- Scalar fields.
- Select fields.
- Nested source/contact object.
- Dynamic ingredient/task/item collection.
- Dynamic steps/sub-items.
- Add, remove, edit, and reorder actions.
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

### Interview preparation

- `useState` versus `useReducer`.
- Reducer purity.
- Controlled versus uncontrolled form.
- Form library versus handwritten state.
- Immutable nested updates.
- Client versus server validation.
- Dynamic-array field management.
- Why a reducer can make complex forms easier to reason about.

### Completion check

The learner can:

- Build and validate a complex React form.
- Manage dynamic nested state.
- Explain reducer-based state.

---

## Day 13 — API Integration, Server State, Context, Redux, and Authentication

### Learn

#### API integration

- `fetch`.
- Typed API clients.
- Request helpers.
- AbortController.
- Error normalization.
- `ProblemDetails`.
- Loading, empty, success, and error states.
- Pagination.
- Search.
- Filtering.
- Sorting.
- Optimistic updates.
- Retry policy.
- Cache invalidation.
- Server state versus client state.
- Server-state-library awareness:
  - RTK Query.
  - Query-library concepts.

#### Shared state

- Context.
- Context provider.
- Context consumption.
- Context rerender considerations.
- Reducer plus Context.
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
- RTK Query.
- When Redux is justified.
- When Context is enough.

#### Authentication

- Login and logout.
- Authentication context.
- Cookie versus bearer token.
- Protected routes.
- Permission-based UI.
- `401` and `403`.
- Token-expiration handling.
- Refresh concepts.
- CSRF and XSS implications.
- Why frontend authorization checks are not security.

### Build

- API client.
- List/detail/create/update/delete.
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

### Interview preparation

- Context versus Redux.
- Redux Toolkit versus raw Redux.
- Server state versus global client state.
- RTK Query responsibilities.
- Why not place every API response in Redux.
- Cookie versus bearer token.
- Protected UI versus protected API.
- Optimistic-update rollback.
- Cache invalidation.

### Completion check

The learner can:

- Consume an API robustly.
- Classify server versus client state.
- Implement shared state.
- Explain and use Redux Toolkit.
- Implement a frontend authentication flow.

---

## Day 14 — React Testing, Performance, Accessibility, Security, and Production

### Learn

#### Testing

- Unit tests.
- Component tests.
- Integration tests.
- E2E tests.
- Vitest.
- React Testing Library.
- User-event testing.
- Mocking API requests.
- Testing Context.
- Testing reducers.
- Testing hooks only when necessary.
- React Router tests.
- Authentication tests.
- Playwright.
- Avoiding implementation-detail tests.

#### Performance

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

#### Accessibility and security

- Semantic HTML.
- Keyboard navigation.
- Focus order.
- Accessible names.
- Form labels.
- Error announcements.
- Modal accessibility.
- XSS.
- Unsafe HTML.
- URL validation.
- Safe rendering.
- Environment variables.
- Dependency auditing.

#### Production

- Vite production build.
- Environment files.
- Build-time configuration.
- Source maps.
- Logging.
- Error reporting.
- SPA hosting.
- Rewrite rules for client routing.

### Build

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

### Interview preparation

- Unit versus integration versus E2E.
- React Testing Library philosophy.
- What causes unnecessary rerenders.
- `memo` trade-offs.
- State colocation.
- XSS in React.
- Frontend environment variables.
- How a React SPA is deployed.
- How to debug a production-only issue.

### Week 2 deliverable

A production-style React SPA containing:

- Routing.
- CRUD.
- Complex forms.
- API integration.
- Search, filtering, sorting, and pagination.
- Context.
- Redux Toolkit exercise.
- Authentication.
- Error boundaries.
- Accessibility.
- Tests.
- A successful production build.

---

# Week 3 — Next.js and Production Frontend Engineering

## Day 15 — Next.js App Router, Project Structure, and Routing

### Learn

- Why Next.js exists.
- React versus Next.js.
- App Router.
- Project structure.
- `app` directory.
- Pages.
- Layouts.
- Nested layouts.
- Route groups.
- Dynamic segments.
- Catch-all segments.
- Search parameters.
- Navigation.
- Loading UI.
- Error UI.
- Not-found UI.
- Metadata.
- Static assets.
- Fonts and image awareness.
- Environment variables.
- Server-only versus public variables.
- Development and production commands.

### Build

- Scaffold a Next.js application.
- Create root layout.
- Create feature layout.
- Add routes:
  - `/`
  - `/items`
  - `/items/[id]`
  - `/items/new`
  - `/items/[id]/edit`
  - `/login`
  - `/protected`
- Add loading UI.
- Add error UI.
- Add not-found handling.
- Add metadata.
- Add navigation.
- Read search parameters.

### Interview preparation

- React versus Next.js.
- App Router versus React Router.
- Page versus layout.
- Dynamic route segment.
- Route group.
- Loading and error boundaries.
- Public versus server-only environment variable.
- Why Next.js requires deployment choices different from a static SPA.

### Completion check

The learner can:

- Navigate the App Router.
- Create nested layouts and dynamic routes.
- Explain Next.js project structure.

---

## Day 16 — Server Components, Client Components, Rendering, and Hydration

### Learn

- Server Components.
- Client Components.
- Default component type.
- `"use client"`.
- Client-boundary placement.
- Serializable props.
- Server/client composition.
- Hydration.
- What is and is not hydrated.
- Streaming.
- Suspense.
- Static rendering.
- Dynamic rendering.
- Request-time rendering.
- Prerendering.
- Browser-only APIs.
- Server-only modules.
- Avoiding secrets in the client bundle.
- Bundle-size implications.
- SEO and metadata implications.

### Build

- Server-rendered list page.
- Server-rendered details page.
- Interactive client filter.
- Client-side form.
- Server component that renders a client component.
- Suspense boundary.
- Streaming loading state.
- Browser-only component.
- Narrow a client boundary that was initially too broad.
- Verify which code executes on the server and which executes in the browser.

### Interview preparation

- Server Component versus Client Component.
- What `"use client"` actually marks.
- Hydration.
- Streaming.
- Why hooks do not work in Server Components.
- Why secrets can remain in server code.
- Why the whole application should not be a Client Component.
- SSR versus Server Components.
- Static versus dynamic rendering.

### Completion check

The learner can:

- Decide where a component should run.
- Keep interactive boundaries narrow.
- Explain hydration and streaming.

---

## Day 17 — Next.js Data Fetching, Caching, Mutations, and Backend Patterns

### Learn

- Fetching in Server Components.
- Fetching in Client Components.
- Calling the ASP.NET Core API from server code.
- Request deduplication concepts.
- Caching.
- Dynamic data.
- Revalidation.
- Tag- and path-based invalidation concepts.
- Mutations.
- Server Actions.
- Client-side mutations.
- Route Handlers.
- Backend-for-frontend pattern.
- Proxying to an external API.
- Error propagation.
- `ProblemDetails`.
- Redirects.
- Optimistic UI.
- Search parameters as state.
- Pagination.
- Filtering.
- Sorting.
- API contract reuse.
- Direct database access as an architectural option.
- Why this course keeps the shared ASP.NET Core API as the primary backend.

### Build

- Server-side list fetch.
- Server-side detail fetch.
- Client-side mutation.
- One Server Action exercise.
- One Route Handler exercise.
- Search and pagination through URL parameters.
- Create/update/delete flow.
- Revalidation after mutation.
- Error translation.
- Optimistic UI example.
- Compare:
  - Browser → ASP.NET Core API.
  - Next.js server → ASP.NET Core API.
  - Browser → Route Handler → ASP.NET Core API.

### Interview preparation

- Server Action versus Route Handler.
- Route Handler versus ASP.NET Core endpoint.
- Server fetch versus client fetch.
- Cache versus no-store behavior.
- Revalidation.
- URL state.
- Backend-for-frontend.
- Why server state should not automatically be copied into global client state.
- When direct database access from Next.js is appropriate or inappropriate.

### Completion check

The learner can:

- Fetch and mutate data from both server and client contexts.
- Explain caching and revalidation.
- Choose an appropriate backend interaction pattern.

---

## Day 18 — Authentication and Authorization Across Angular, React, and Next.js

### Learn

#### Core security model

- Authentication versus authorization.
- Session-based authentication.
- Cookie-based authentication.
- Bearer tokens.
- JWT structure and limitations.
- Access and refresh tokens.
- Token expiry.
- Session expiry.
- Secure, HttpOnly, SameSite cookies.
- CSRF.
- XSS.
- CORS.
- Logout.
- Role-based authorization.
- Permission-based authorization.
- UI hiding versus real API enforcement.

#### Angular

- Authentication service.
- Auth signal/store.
- HTTP interceptor.
- Route guard.
- `401` handling.
- Refresh/session-renewal concepts.

#### React SPA

- Authentication provider.
- Protected React Router route.
- Authenticated API client.
- Permission-aware components.
- Session-expiration handling.

#### Next.js

- Server-side session access.
- Protected Server Component.
- Redirecting unauthenticated users.
- Middleware awareness.
- Route Handler protection.
- Server Action authorization.
- Client authentication state only where needed.
- Preventing server-only session data from leaking into client components.

### Build

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

### Interview preparation

- Authentication versus authorization.
- Cookie versus bearer token.
- Local storage token risks.
- `401` versus `403`.
- CSRF versus XSS.
- Route guard versus backend security.
- Middleware versus Server Component authorization.
- Why authentication state should not blindly be duplicated everywhere.
- How logout and session expiration should behave.

### Completion check

The learner can:

- Explain the complete authentication flow.
- Protect routes in all three frontend models.
- Identify common frontend authentication mistakes.

---

## Day 19 — Localization, Accessibility, Files, Images, Live Preview, and PDF

### Learn

#### Localization

- UI language.
- Stored-content language.
- Output language.
- Translation-resource organization.
- Locale switching.
- Persisting locale.
- Date and number formatting.
- Right-to-left awareness.
- Localized validation.
- Avoiding hard-coded UI text.

#### Accessibility

- Semantic HTML.
- Keyboard navigation.
- Focus management.
- Skip links.
- Accessible names.
- ARIA only when necessary.
- Dynamic validation announcements.
- Accessible modals.
- Accessible drag/reordering alternatives.
- Color contrast.
- Reduced-motion awareness.

#### Files and images

- File input.
- File metadata.
- Client-side preview.
- Object URLs and cleanup.
- Image URL versus file upload.
- Multipart form data.
- Upload progress.
- File-size and type validation.
- Backend storage options.
- Security limitations of client-side file checks.
- Image optimization awareness.

#### Live preview and PDF

- Derived preview state.
- Configuration-driven rendering.
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

### Build

- Language selector.
- At least two UI languages.
- Separate content/output-language concept.
- Localized built-in messages.
- Accessible form and validation summary.
- Keyboard-operable dynamic collection.
- Image preview.
- File-validation feedback.
- Live derived preview.
- Two output templates.
- Print-friendly route.
- Browser Save as PDF.
- Binary-download exercise.
- Meaningful document title and filename.

### Interview preparation

- Localization versus translating stored content.
- Accessibility responsibilities of frontend developers.
- When ARIA is appropriate.
- Image URL versus upload.
- Why file validation must also occur on the server.
- Browser-generated versus server-generated PDF.
- Binary-response handling.
- Security risks of user-authored HTML and CSS.

### Completion check

The learner can:

- Build localized and accessible UI.
- Handle a file or image.
- Build a live preview.
- Generate or download a printable document.

---

## Day 20 — Testing, Debugging, Performance, CI, and Deployment

### Learn

#### Cross-framework testing

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

#### Debugging

- Browser DevTools.
- Network tab.
- Console.
- Sources and breakpoints.
- Source maps.
- Performance panel.
- Memory awareness.
- Angular DevTools.
- React DevTools.
- React Profiler.
- Server logs.
- Correlation IDs.
- Debugging server/client boundary issues.

#### Performance

- Measuring before optimizing.
- Angular change detection.
- `OnPush`.
- Stable list identity.
- React rerenders.
- State colocation.
- Memoization.
- Next.js client-boundary size.
- Lazy loading.
- Code splitting.
- Bundle analysis.
- Request waterfalls.
- Image loading.
- Web-performance metrics awareness.
- Virtualization awareness.

#### CI and code quality

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

#### Deployment

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

### Build

- Complete production builds for all frontends.
- Run type checking.
- Run linting.
- Run unit and component tests.
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

### Interview preparation

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

### Completion check

The learner can:

- Build and test all applications.
- Diagnose common failures.
- Explain how each application is deployed.
- Describe a production CI/CD pipeline.

---

## Day 21 — Capstone, Code Review, Architecture, and Interview Bootcamp

### Part 1 — Independent capstone

Implement one unfamiliar feature in all relevant frontends without a prepared
solution.

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
- Loading and error states.
- Accessibility.
- Unit or component tests.
- E2E coverage for the main path.
- Production builds.
- Diff review.

### Part 2 — Code-review exercise

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

### Part 3 — Architecture comparison

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

### Part 4 — Angular interview round

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

### Part 5 — React interview round

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

### Part 6 — Next.js interview round

Cover:

- React versus Next.js.
- App Router.
- Pages and layouts.
- Server Components.
- Client Components.
- `"use client"`.
- Hydration.
- Streaming.
- Static and dynamic rendering.
- Data fetching.
- Caching.
- Revalidation.
- Server Actions.
- Route Handlers.
- Authentication.
- Middleware.
- Environment variables.
- Error and loading boundaries.
- Deployment.

### Part 7 — Practical interview exercises

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

### Final architecture explanation

Be able to explain:

Browser
→ Angular, React SPA, or Next.js
→ ASP.NET Core API
→ EF Core
→ Database

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

# Definition of Completion

The course is complete only when the learner can:

- Run Angular, React, Next.js, and the API locally.
- Explain each frontend project structure.
- Create and route a new feature.
- Build reusable components.
- Build complex dynamic forms.
- Consume and debug an API.
- Implement loading, empty, success, and error states.
- Implement login, logout, and protected routes.
- Explain cookie and bearer-token authentication.
- Select an appropriate state-management strategy.
- Use Angular signals and RxJS.
- Use React hooks, Context, and reducers.
- Explain NgRx and Redux Toolkit.
- Understand Server and Client Components.
- Write meaningful unit, component, integration, and E2E tests.
- Identify accessibility problems.
- Identify common frontend-security problems.
- Diagnose unnecessary renders and subscriptions.
- Build production versions of every frontend.
- Explain deployment differences.
- Pass framework-specific mock interviews.
- Implement a small feature with limited guidance.

# Topics Covered but Not Deeply Implemented

These topics are included for production and interview awareness but do not
require expert-level implementation during the three weeks:

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

# Daily Progress Tracking

After every day, update `docs/course/PROGRESS.md` with:

- Current day.
- Topics completed.
- Code completed.
- Tests completed.
- Interview questions answered.
- Problems encountered.
- Topics requiring revision.
- Next implementation task.

Record detailed explanations and personal notes in:

`docs/course/NOTES.md`