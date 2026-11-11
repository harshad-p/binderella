## Progress Tracking and `next` Command

### Commands

The agent must recognize `next` (case-insensitive) as a special instruction.

When the user provides `next`, execute the following workflow automatically without asking for confirmation.

## Curriculum Section Identification

Only headings matching the following format represent trackable instructional sections:

`## W{week}D{day}-S{section} — {title}`

Examples:
- `## W1D1-S1 — TypeScript Type-System Fundamentals`
- `## W1D2-S1 — Component Fundamentals`
- `## W2D8-S1 — React Setup and Project Structure`

Use the regular expression:

```regex
^## W(\d+)D(\d+)-S(\d+) — (.+)$
```

Ignore all other headings, including:

- Course Foundation (`CF-S*`)
- Final Definition of Completion (`FC-S*`)
- Topics Covered but Not Deeply Implemented (`TA-S*`)
- Daily Progress Tracking (`PT-S*`)
- Week and day headings without section identifiers

These are curriculum metadata, not trackable instructional sections.

### Progress File Validation

When initializing or repairing `PROGRESS.md`:

1. Include only sections matching the instructional-section pattern.
2. Remove non-instructional entries such as `CF-S1` through `CF-S6`.
3. Preserve valid existing completion markers.
4. Never transfer completion markers from non-instructional entries to instructional sections.
5. If the current section is invalid or refers to curriculum metadata, reset it to the first incomplete instructional section.
6. Do not mark any instructional section complete unless the user explicitly advances past it using `next` or otherwise confirms its completion.

The first trackable section is:

`W1D1-S1 — TypeScript Type-System Fundamentals`

The `next` command must advance exclusively through the instructional sections in curriculum order.

### Progress File

Use `PROGRESS.md` in the Course directory to track completion.

- `CURRICULUM.md` defines the authoritative section order and titles.
- `PROGRESS.md` defines which sections have been completed and which section is currently active.
- Track every curriculum section using Markdown checkboxes.
- `[x]` means completed.
- `[ ]` means not completed.
- Use `**Current:**` to identify the active section.

Example:

```markdown
# Course Progress

**Current:** W1D1-S3

## Week 1

### Day 1

- [x] W1D1-S1 — TypeScript Type-System Fundamentals
- [x] W1D1-S2 — TypeScript Object Modelling
- [ ] W1D1-S3 — Functions, Narrowing, and Advanced Type Modelling
- [ ] W1D1-S4 — Classes and Object-Oriented TypeScript
```

### Initializing or Repairing Progress

If `PROGRESS.md` does not exist or is incomplete:

1. Read `CURRICULUM.md`.
2. Generate the complete progress checklist covering all 21 days and their sections.
3. Preserve existing completion markers wherever possible.
4. Add missing sections as unchecked (`[ ]`).
5. Correct section numbering and titles to match the curriculum.
6. Never mark a section completed solely because its note file exists.
7. If no progress information exists, initialize the first curriculum section as current.

## `next` Command — File-Based Progress

When the user says `next`, automatically synchronize progress with existing note files and prepare the next section.

### Source of Truth

- `CURRICULUM.md` determines the instructional section order, IDs, and titles.
- Existing section note files determine which sections have been reached.
- `PROGRESS.md` records completion status.
- Only curriculum headings matching `W{week}D{day}-S{section}` are instructional sections.

### `next` Workflow

1. Read `CURRICULUM.md` and identify all instructional sections in order.
2. Inspect existing `week-XX/day-XX/section-XX-*.md` files.
3. Identify the furthest section for which a valid note file exists.
4. Mark that section and all preceding instructional sections as completed (`[x]`) in `PROGRESS.md`.
5. Identify the immediately following instructional section.
6. Create its week/day directories if necessary.
7. Create its empty Markdown note file using the curriculum title.
8. Set `**Current:**` to the newly created section.
9. Preserve all existing note contents.
10. Report the sections marked complete and the new active section.

### Example

If these files exist:

```text
week-01/day-01/
  section-01-typescript-type-system-fundamentals.md
  section-02-typescript-object-modelling.md
  section-03-functions-narrowing-and-advanced-type-modelling.md
  section-04-classes-and-object-oriented-typescript.md
```

When the user says `next`:

- Mark `W1D1-S1` through `W1D1-S4` as complete.
- Create `week-01/day-01/section-05-async-typescript-and-utility-types.md`.
- Set `**Current:** W1D1-S5`.

### Restrictions

- Never overwrite existing note files.
- Never generate lesson content.
- Never skip missing sections in the curriculum sequence.
- Never include

### Safety and Consistency

- Advance exactly one section per `next` instruction.
- Never skip sections.
- Never overwrite existing notes.
- Never mark future sections complete.
- If `PROGRESS.md` references an invalid current section, stop and report the inconsistency rather than guessing.
- Do not modify application source code.
- Do not generate lesson content.

### Response Format

Keep responses concise.

Example:

**Completed:** W1D1-S2 — TypeScript Object Modelling

**Next:** W1D1-S3 — Functions, Narrowing, and Advanced Type Modelling

**File:** `week-01/day-01/section-03-functions-narrowing-and-advanced-type-modelling.md`