# Three-Week Angular + React/Next.js Crash Course

This is realistic **because you are not starting as a beginner**. Your Blazor and .NET experience already gives you components, dependency injection, routing, forms, HTTP, state, authentication, and application architecture. The main job is learning how Angular and React express those ideas.

Three weeks will not make you an expert in both ecosystems, but it should make you:

- Productive enough to build a real application.
- Comfortable reading existing Angular and React code.
- Able to explain the major architectural concepts in interviews.
- Able to compare Angular, React, Next.js, and Blazor intelligently.
- Able to run, test, build, debug, and deploy both applications.

We will target **Angular 22.x, React 19.3, and Next.js 16.x**. Angular 22 is currently active, React’s current documentation targets React 19.3, and Next.js 16 is the active LTS release. [Angular](https://angular.dev/reference/releases?utm_source=chatgpt.com)

## Course strategy

We will not spend days on basic JavaScript, HTML, or CSS.

Instead, we will:

1. Learn only the TypeScript features you need.
2. Build one application in Angular.
3. Rebuild the same application in React/Next.js.
4. Use the same ASP.NET Core API and database for both.
5. Compare the frameworks feature by feature.
6. Practice interview questions continuously rather than waiting until the end.

Modern Angular will be taught using standalone components, signals, typed reactive forms, and the current testing setup. Standalone components are now the default, and new Angular CLI applications use Vitest by default. We will only cover NgModules as legacy code you may encounter in interviews or existing applications. [Angular](https://angular.dev/guide/components?utm_source=chatgpt.com)

For React, we will use Next.js rather than Create React App. The React documentation recommends using a framework for new applications, and Create React App is deprecated. [react.dev](https://react.dev/learn/installation?utm_source=chatgpt.com)

---

# The project

## Job Application Tracker

You will build the same application twice:

```text
job-tracker/
|
+-- api/
|   +-- ASP.NET Core Web API
|   +-- EF Core
|   +-- SQLite initially
|
+-- angular-client/
|
+-- next-client/
```

The application will contain:

- Job list and job details.
- Create and edit forms.
- Delete and archive actions.
- Application statuses such as Saved, Applied, Interview, Rejected, and Offer.
- Search, filtering, sorting, and pagination.
- Loading, empty, success, and error states.
- Form validation.
- Dashboard counts.
- Optimistic status updates.
- A protected page or simple authentication flow.
- Unit, component, integration, and end-to-end tests.

This is large enough to cover real application development without becoming an enormous side project.

## How the database connection works

The Angular application and browser-side React components will **not connect directly to the database**.

```text
Angular browser application
            |
            | HTTP / JSON
            v
ASP.NET Core API
            |
            | EF Core
            v
        Database
```

The Next.js application will initially use the same architecture:

```text
Next.js application
        |
        | HTTP / JSON
        v
ASP.NET Core API
        |
        v
    Database
```

Later, you will also implement one small Next.js server-side feature that queries a database directly:

```text
Next.js Server Component or Route Handler
                    |
                    v
                Database
```

That is safe because the query and credentials execute on the server rather than being included in the browser bundle. Next.js Server Components can perform server-side I/O directly, while Route Handlers provide server-side HTTP endpoints. [nextjs.org](https://nextjs.org/docs/app/getting-started/fetching-data?utm_source=chatgpt.com)

---

# Weekly rhythm

The plan assumes:

- **Five core study days per week**
- Approximately **2½–3 hours per day**
- Optional weekend review or catch-up
- Approximately **40–45 focused hours total**

Each lesson will normally contain:

```text
Blazor comparison
        |
        v
Concept explanation
        |
        v
Guided implementation
        |
        v
Independent exercise
        |
        v
Interview questions
        |
        v
Review and refactoring
```

We will use the interview-practice format you already prefer:

```text
Question
   ↓
Your answer
   ↓
Critique
   ↓
Strong answer
   ↓
Deeper follow-up
```

That matches the existing interview curriculum structure rather than having you merely memorize prepared answers. plan

---

# Week 1 — Angular

## Day 1 — TypeScript sprint and Angular setup

### TypeScript

Only the useful parts:

- Type inference.
- Interfaces and type aliases.
- Union and literal types.
- Optional and readonly properties.
- Arrays and generic types.
- Functions and callback types.
- Type narrowing.
- Classes and access modifiers.
- `Promise<T>` and async functions.
- Utility types such as `Partial<T>`, `Pick<T>`, and `Omit<T>`.
- Modules, imports, and exports.
- Strict null checking.

### Angular setup

- Angular CLI.
- Workspace structure.
- `angular.json`.
- `package.json`.
- Application bootstrap.
- Standalone components.
- Development server.
- Building and testing.
- Angular DevTools.

### Blazor comparison

| Blazor | Angular |
|---|---|
| Razor component | Angular component |
| `.razor` markup | HTML template |
| `[Parameter]` | Input |
| `EventCallback` | Output event |
| Injected service | Angular service through DI |
| Component field | Signal or ordinary property |
| `@bind` | Form binding |
| `OnInitialized` | Angular lifecycle hook |

### Build output

- Create the Angular application.
- Create the shared job model.
- Display static job data.
- Create the initial page shell.

### Interview focus

- TypeScript versus JavaScript.
- Compile-time types versus runtime values.
- Angular framework versus Angular CLI.
- Standalone component versus NgModule.

---

## Day 2 — Components, templates, and communication

### Topics

- Component metadata.
- Component selectors.
- Templates and styles.
- Property binding.
- Event binding.
- Two-way binding.
- Conditional rendering.
- List rendering.
- `@if`, `@for`, and `@switch`.
- Inputs and outputs.
- Parent-child communication.
- Content projection.
- Pipes.
- Component lifecycle.
- Component composition.
- Tracking list items correctly.

### Build output

- `JobList` component.
- `JobCard` component.
- `StatusBadge` component.
- Reusable empty-state and loading components.
- Job selection and parent-child events.

### Interview focus

- Components versus directives.
- Inputs versus outputs.
- Pipes versus component methods.
- Lifecycle hooks.
- Why list tracking matters.
- Content projection versus passing input properties.

---

## Day 3 — Routing, services, and dependency injection

### Topics

- Angular Router.
- Route configuration.
- Router outlet.
- Navigation links.
- Route parameters.
- Query parameters.
- Nested routes.
- Lazy-loaded routes.
- Route guards.
- Services.
- `inject()`.
- Root, route, and component-level providers.
- Service lifetimes and injector hierarchy.
- Environment configuration.

Angular’s router is the official navigation library, while services and dependency injection provide reusable application logic and control the scope of service instances. [Angular](https://angular.dev/guide/routing?utm_source=chatgpt.com)

### Build output

- `/jobs`
- `/jobs/:id`
- `/jobs/new`
- `/jobs/:id/edit`
- Shared `JobService`.
- Lazy-loaded job-management routes.

### Interview focus

- Angular service versus component.
- How Angular dependency injection resolves a dependency.
- Root provider versus component provider.
- Route parameter versus query parameter.
- Lazy loading and why it matters.
- Route guard versus backend authorization.

---

## Day 4 — HTTP, APIs, and RxJS

### Topics

- `HttpClient`.
- REST requests.
- Typed HTTP responses.
- Observables.
- Observable versus Promise.
- Subscribing and unsubscribing.
- Async pipe.
- Signals and Observable interoperability.
- `map`.
- `filter`.
- `switchMap`.
- `debounceTime`.
- `distinctUntilChanged`.
- `catchError`.
- `finalize`.
- HTTP interceptors.
- Authentication headers.
- Development proxy configuration.
- CORS.
- Loading and error handling.

Angular provides `HttpClient` for HTTP communication, while its development server can proxy `/api` calls to a backend service. [Angular](https://angular.dev/guide/http/setup?utm_source=chatgpt.com)

### Build output

Connect Angular to the ASP.NET Core API:

```text
GET    /api/jobs
GET    /api/jobs/{id}
POST   /api/jobs
PUT    /api/jobs/{id}
DELETE /api/jobs/{id}
```

Implement:

- Job loading.
- Search with debounce.
- Error messages.
- Request cancellation through `switchMap`.
- HTTP interceptor.
- Loading indicator.

### Interview focus

- Observable versus Promise.
- Cold versus hot Observable.
- Why `switchMap` is useful for searches.
- Why nested subscriptions are problematic.
- HTTP interceptor use cases.
- Frontend validation versus backend validation.

---

## Day 5 — Forms, signals, state, and Angular testing

### Forms

- Reactive forms.
- Typed `FormControl`.
- `FormGroup`.
- `FormArray`.
- `FormBuilder`.
- Built-in validators.
- Custom validators.
- Cross-field validation.
- Form status.
- Dirty, touched, valid, and pending states.
- `setValue` versus `patchValue`.
- Submitting and resetting forms.

Reactive forms are the primary course approach because they provide an explicit model, synchronous access, better scalability, and a straightforward testing model. [Angular](https://angular.dev/guide/forms/reactive-forms?utm_source=chatgpt.com)

### State

- Local component signals.
- Writable signals.
- Computed signals.
- Effects.
- Shared state through an injectable service.
- Signal-based feature store.
- Signals versus RxJS.
- When NgRx is justified.
- NgRx Store concepts.
- NgRx SignalStore overview.

### Testing

- Vitest.
- Testing services.
- Testing components.
- Mocking `HttpClient`.
- Testing forms.
- Testing user-visible behavior.
- Avoiding implementation-detail tests.

### Build output

- Create and edit forms.
- Shared filter state.
- Dashboard counts.
- Angular unit tests.
- Production build.

### End-of-week checkpoint

You should be able to build a small Angular CRUD feature without copying the completed code.

---

# Week 2 — React and Next.js

## Day 6 — React mental model and component fundamentals

### Topics

- React as a UI library.
- Next.js as a React framework.
- JSX and TSX.
- Functional components.
- Props.
- Component composition.
- Children.
- Conditional rendering.
- Lists and keys.
- Events.
- Immutability.
- Controlled inputs.
- Declarative rendering.

### Blazor comparison

| Blazor | React |
|---|---|
| Razor component | Function component |
| `[Parameter]` | Props |
| `EventCallback` | Callback prop |
| `RenderFragment` | `children` |
| Component field | State or ordinary variable |
| Cascading value | Context |
| Service abstraction | Imported module, context, or external store |
| Component rerender | React render triggered by state/parent |

### Build output

- Create the Next.js application.
- Job list.
- Job card.
- Status badge.
- Reusable layout.
- Static data rendering.

### Interview focus

- React library versus Next.js framework.
- Props versus state.
- Why keys are required.
- Controlled versus uncontrolled inputs.
- Why React updates should be immutable.
- Composition versus inheritance.

---

## Day 7 — Hooks and React’s render model

### Topics

- `useState`.
- State snapshots.
- Functional state updates.
- Batching.
- `useReducer`.
- `useRef`.
- `useContext`.
- Custom hooks.
- Derived state.
- Lifting state.
- Render and commit phases.
- Closures.
- `useEffect`.
- Effect cleanup.
- Effect dependencies.
- Avoiding unnecessary Effects.
- `useMemo` and `useCallback`.
- When memoization is unnecessary.

React provides hooks for component state, reducers, context, refs, effects, and performance-related behavior. Its documentation also emphasizes that Effects should synchronize with external systems rather than orchestrate ordinary application data flow. [react.dev](https://react.dev/reference/react/hooks?utm_source=chatgpt.com)

### Build output

- Search and filter controls.
- Controlled job form.
- Reusable job-filter custom hook.
- Selected job state.
- Persistent UI preference.

### Interview focus

- What causes a React component to render?
- `useState` versus `useReducer`.
- State versus ref.
- Why stale closures occur.
- What belongs in `useEffect`?
- Why an Effect may run repeatedly.
- `useMemo` versus `useCallback`.

---

## Day 8 — Next.js App Router

### Topics

- App Router.
- File-system routing.
- Pages.
- Layouts.
- Nested layouts.
- Dynamic route segments.
- Loading UI.
- Error UI.
- Not-found pages.
- Navigation.
- Server Components.
- Client Components.
- The `"use client"` boundary.
- Hydration.
- Streaming.
- Server rendering versus client rendering.
- Static versus dynamic rendering.
- Environment variables.

In the App Router, pages and layouts are Server Components by default. Client Components are used where state, event handlers, effects, or browser APIs are required. [nextjs.org](https://nextjs.org/docs/app?utm_source=chatgpt.com)

### Build output

- `/jobs`
- `/jobs/[id]`
- `/jobs/new`
- `/jobs/[id]/edit`
- Loading and error boundaries.
- Server-rendered job details.
- Client-side interactive filtering.

### Interview focus

- React versus Next.js.
- Server Component versus Client Component.
- What `"use client"` actually does.
- What hydration means.
- Layout versus page.
- SSR versus CSR versus static generation.
- Why not mark the entire application `"use client"`?

---

## Day 9 — Data fetching, updates, and backend options

### Topics

- Fetching in Server Components.
- Fetching in Client Components.
- Route Handlers.
- Server Functions and Server Actions.
- Form mutations.
- Revalidation.
- Caching concepts.
- Error handling.
- API client abstraction.
- Environment secrets.
- Backend-for-frontend pattern.
- Calling the ASP.NET Core API.
- Direct server-side database access.
- Choosing between a separate API and Next.js backend features.

### Build output

- Load jobs from the ASP.NET Core API.
- Submit create and edit operations.
- Delete and update status.
- Revalidate affected pages.
- Create one Route Handler.
- Build one small server-side direct-database example.

### Interview focus

- Where does a Server Component execute?
- Can a Server Component use database credentials?
- Route Handler versus ASP.NET Core endpoint.
- Server Action versus browser API request.
- Public versus server-only environment variables.
- Why server state should not automatically be copied into global client state.

---

## Day 10 — React state management and testing

### State management

- Local `useState`.
- `useReducer`.
- Lifting state.
- Context.
- Reducer plus Context.
- Redux concepts.
- Redux Toolkit.
- Slices.
- Actions.
- Reducers.
- Selectors.
- Middleware.
- RTK Query overview.
- URL state.
- Server state versus client state.
- When global state is unnecessary.

Redux Toolkit is the official recommended way to write Redux logic; plain hand-written Redux will only be covered enough to understand existing code and interview terminology. [redux.js.org](https://redux.js.org/redux-toolkit/overview/?utm_source=chatgpt.com)

### Testing

- Vitest.
- React Testing Library.
- Testing user-visible behavior.
- Mocking APIs.
- Testing hooks sparingly.
- Playwright end-to-end tests.
- Testing Server Components through end-to-end behavior.

Next.js provides official guidance for Vitest, React Testing Library, and Playwright. Its documentation recommends end-to-end testing for async Server Components because unit-testing support remains limited. [nextjs.org](https://nextjs.org/docs/app/guides/testing?utm_source=chatgpt.com)

### Build output

- Shared client state.
- Redux Toolkit mini-feature.
- Component tests.
- End-to-end create-job test.
- Production build.

### End-of-week checkpoint

Implement the same new feature in Angular and Next.js without following an existing solution.

---

# Week 3 — Full-stack integration and interviews

## Day 11 — API and database integration

This is not a full EF Core course. You already have .NET experience, so we will focus on how frontend requirements affect API design.

### Topics

- Entities versus DTOs.
- API request and response models.
- Validation errors.
- Problem Details.
- Filtering.
- Sorting.
- Pagination.
- Search.
- Database migrations.
- Seed data.
- CORS.
- Authentication boundary.
- API versioning basics.
- Preventing over-fetching.
- Avoiding frontend-specific database models.
- Environment-based configuration.

### Build output

- Proper paginated jobs endpoint.
- Search and filtering.
- Consistent validation errors.
- Database-backed dashboard counts.
- Angular and Next.js clients using the same API contract.

---

## Day 12 — State-management comparison

You will implement the same stateful feature several ways and compare the trade-offs.

| State requirement | Angular | React/Next.js |
|---|---|---|
| Local UI state | Signal | `useState` |
| Derived state | `computed` | Derive during render |
| Complex local state | Signals with methods | `useReducer` |
| Shared feature state | Service with signals or SignalStore | Context plus reducer |
| Large global state | NgRx Store | Redux Toolkit |
| Server data | `HttpClient` and RxJS | Server Components, fetch, or RTK Query |
| Form state | Reactive Forms | Controlled form or form library |
| URL state | Router query parameters | `searchParams` |
| Authentication state | Service/store | Server session plus client context where needed |

Angular signals provide writable and computed reactive values. NgRx Store targets application-wide state, while SignalStore offers a signal-based injectable store. React supports local state, reducers, and context, with Redux Toolkit available when application-wide state becomes sufficiently complex. [Angular](https://angular.dev/guide/signals?utm_source=chatgpt.com)

### Central lesson

We will not treat “state management” as “install Redux or NgRx.”

We will first identify:

```text
What kind of state is this?
        |
        +-- Local UI state
        +-- Form state
        +-- URL state
        +-- Server/cache state
        +-- Authentication state
        +-- Application-wide client state
```

Only then will we choose a tool.

---

## Day 13 — Authentication, errors, and testing

### Topics

- Authentication versus authorization.
- Cookie versus bearer-token flow.
- Route guards and protected routes.
- Why client-side guards are not security boundaries.
- HTTP interceptors.
- Handling `401`, `403`, `404`, `409`, and `500`.
- Optimistic concurrency.
- Retry and cancellation.
- Global error handling.
- Unit versus integration versus E2E testing.
- Test pyramid and practical trade-offs.
- API integration tests.
- Browser network debugging.

### Build output

- Login or mock authentication flow.
- Protected dashboard.
- Angular route guard.
- Next.js server-side access check.
- Consistent error handling.
- End-to-end protected-route test.

---

## Day 14 — Performance, debugging, building, and deployment

### Angular

- Change detection.
- Signals and rendering.
- `OnPush`.
- List tracking.
- Lazy-loaded routes.
- Bundle analysis.
- Avoiding unnecessary subscriptions.
- Angular DevTools.

### React and Next.js

- Re-render causes.
- Component boundaries.
- Memoization.
- React Compiler awareness.
- Server and Client Component boundaries.
- Streaming.
- Caching and revalidation.
- Lazy loading.
- Bundle size.
- React DevTools.

### General

- Browser DevTools.
- Network tab.
- Source maps.
- Production versus development builds.
- Environment variables.
- Logging.
- Docker overview.
- Deployment architecture.
- Accessibility basics.
- Frontend security basics.

### Build output

- Production builds for all three applications.
- Deployable configuration.
- README containing setup and architecture.
- Performance review of both frontends.

---

## Day 15 — Interview bootcamp and capstone review

### Angular round

- Components, directives, and pipes.
- Standalone components versus NgModules.
- Dependency injection hierarchy.
- Signals versus RxJS.
- Observable versus Promise.
- Reactive versus template-driven forms.
- Change detection.
- Routing and lazy loading.
- Interceptors.
- NgRx and when not to use it.

### React round

- Props versus state.
- State snapshots.
- Keys and reconciliation.
- Controlled components.
- Render behavior.
- Closures.
- Effects and dependencies.
- Context versus Redux.
- `useState` versus `useReducer`.
- Memoization.

### Next.js round

- Server versus Client Components.
- Hydration.
- App Router.
- Route Handlers.
- Server Actions.
- Rendering strategies.
- Caching and revalidation.
- Secrets and environment variables.
- Next.js backend versus separate ASP.NET Core API.

### Practical round

- Build a small feature.
- Diagnose a broken Effect.
- Fix an Angular subscription problem.
- Explain a rendering-performance issue.
- Design state for a dashboard.
- Debug an HTTP request.
- Explain the full application architecture.

### Final exercise

You will explain:

```text
Browser
   |
   v
Angular or Next.js frontend
   |
   v
ASP.NET Core API
   |
   v
EF Core
   |
   v
Database
```

Then explain why you chose each state-management approach and how the same feature differs between Angular and React.

---

# Running the applications

Use a Node version supported by both frameworks. Angular’s current installation guide requires Node 22.22.3 or newer, while Next.js requires at least Node 20.9. [Angular](https://angular.dev/installation?utm_source=chatgpt.com)

## Angular

```bash
npm install -g @angular/cli

ng new job-tracker-angular \
  --routing \
  --style=scss \
  --strict

cd job-tracker-angular

ng serve --open
```

The Angular development server normally runs at:

```text
http://localhost:4200
```

Other commands:

```bash
ng test
ng build
ng generate component jobs/job-list
ng generate service jobs/job
```

## Next.js

```bash
npx create-next-app@latest job-tracker-next

cd job-tracker-next

npm run dev
```

During setup, choose:

```text
TypeScript: Yes
Linter: ESLint
Tailwind: No, unless you specifically want it
src directory: Yes
App Router: Yes
```

The Next.js development server normally runs at:

```text
http://localhost:3000
```

Other commands:

```bash
npm run lint
npm run build
npm run start
```

`npm run dev`, `npm run build`, and `npm run start` correspond to development, production build, and production server execution in Next.js. [nextjs.org](https://nextjs.org/docs/app/getting-started/installation?utm_source=chatgpt.com)

## ASP.NET Core API

```bash
dotnet new webapi -n JobTracker.Api

dotnet run --project JobTracker.Api
```

During development, you will normally have three terminals open:

```text
Terminal 1: ASP.NET Core API
Terminal 2: Angular
Terminal 3: Next.js
```

---

# What we will deliberately skip

To keep this within three weeks, we will not deeply study:

- Basic JavaScript syntax.
- HTML and CSS fundamentals.
- Legacy React class components.
- Create React App.
- Angular taught primarily through NgModules.
- Every RxJS operator.
- Raw Redux boilerplate.
- Advanced webpack or bundler configuration.
- Complex UI design systems.
- Micro-frontends.
- A complete identity-provider implementation.
- Deep EF Core or database fundamentals you already know.

We will still discuss legacy Angular modules, React class components, and older Next.js Pages Router conventions briefly so that older interview questions and existing codebases do not surprise you.

---

# Definition of completion

At the end of the three weeks, you should be able to:

1. Create and run Angular and Next.js applications from scratch.
2. Build reusable components with TypeScript.
3. Implement routing and forms.
4. Call an ASP.NET Core API.
5. Explain why frontends normally do not connect directly to databases.
6. Choose an appropriate state-management approach.
7. Explain signals, RxJS, hooks, context, NgRx, and Redux Toolkit.
8. Understand Server and Client Components.
9. Write practical component and end-to-end tests.
10. Build production versions of both applications.
11. Debug browser, rendering, and HTTP problems.
12. Answer senior-level comparison and architectural interview questions.