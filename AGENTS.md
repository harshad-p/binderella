# Repository Purpose

Binderella is a guided learning project.

The application will eventually use one ASP.NET Core API with multiple
frontends:

- Blazor
- Angular
- React/Next.js

# Responsibilities

ChatGPT is responsible for:

- Teaching concepts
- Controlling curriculum order
- Explaining architecture and design decisions
- Creating exercises
- Reviewing implementation results
- Interview preparation
- Defining the next implementation task

Codex is responsible for:

- Performing explicitly requested repository tasks
- Creating and editing files
- Running commands, builds, and tests
- Reporting implementation results and problems

# Working Rules

Before making changes, read:

1. AGENTS.md
2. docs/course/CURRICULUM.md
3. docs/course/PROGRESS.md
4. Relevant source files

Only perform the task explicitly requested in the current prompt.

Do not:

- Jump ahead in the curriculum
- Implement unrequested features
- Redesign the architecture independently
- Add dependencies without explaining them
- Make unrelated refactors
- Generate the entire application in place of a learning exercise
- Modify files outside this repository

After an implementation task:

- Run the relevant build and tests
- Report every changed file
- Report commands run
- Report warnings, errors, and limitations
- Do not commit unless explicitly instructed
