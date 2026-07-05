# 📖 Binderella

Digitize your family's handwritten recipe binder. Binderella turns loose, yellowing recipe cards into a shareable, printable, permanent digital collection — without the "I have to go back and re-edit 20 old docs" problem.

Built as a hackathon project, in C# and Blazor.

## Why

Recipes scribbled from YouTube or TV onto scrap paper are easy to lose, hard to search, and only get more fragile with time. Old recipe binders turn yellow, pages come loose, paper wears out, and eventually tears or gets lost entirely.

Word documents seemed like a fix, but they come with their own problems: formatting one nicely needs real proficiency in Word, and the moment you come up with a better design, every single recipe you already wrote has to be manually re-edited to match.

Binderella gives recipes a permanent home — one you can search, share, and print onto a fresh A5 page for the binder, without ever manually reformatting a recipe again.

## Features

- **Add & edit recipes** — title, photo, chef/source name (with optional link back to the original video), ingredients, steps, and a fun closing line
- **One shared template** — every recipe renders through a single reusable component (`Shared/RecipeCard.razor`). Update the design once, and every recipe — old and new — updates automatically
- **Print-ready** — sized and styled for A5 paper, so you can print, laminate, and slot it straight into a physical binder
- **Bilingual UI** — switch the app between English and Marathi from a dropdown in the header
- **Custom fonts per recipe** — choose from clean/fancy English fonts or Devanagari fonts (Mangal, Kohinoor Devanagari, Noto Sans Devanagari) so Marathi recipes render correctly
- **Search** — quickly find a recipe by title
- **Local-first** — all data lives in a single SQLite file; no server, account, or internet connection required to use it day-to-day

## Tech stack

- **Blazor Server** (.NET 8)
- **Entity Framework Core** + **SQLite**
- Plain CSS (no component library) — custom "vintage cookbook" design system

## Getting started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run locally
```bash
git clone https://github.com/<your-username>/binderella.git
cd binderella
dotnet restore
dotnet run
```
Open the URL printed in the terminal (usually `https://localhost:5001`).

On first run, Binderella creates `recipebook.db` automatically and seeds one sample recipe (Chicken Masala) so it's not empty.

## Project structure
```
RecipeBook/
├─ Models/            Recipe, RecipeIngredient, RecipeStep
├─ Data/              EF Core DbContext + seed data
├─ Services/          LocalizationService (English/Marathi UI strings)
├─ Shared/            MainLayout + RecipeCard (the reusable template)
├─ Pages/             Index (list), RecipeForm (add/edit), ViewRecipe, _Host
└─ wwwroot/css/       site.css (design system + A5 print rules)
```

## Roadmap

- [ ] Auto-extract recipes from a pasted YouTube URL
- [ ] User-customizable card templates (not just fonts)
- [ ] Clean/hexagonal architecture split (Domain / Application / Infrastructure / UI)
- [ ] Ship as a native app via .NET MAUI Blazor Hybrid (no server, near-zero hosting cost)

## Known limitations

- No authentication — built for local/family use, not multi-user hosting
- Images are stored as bytes directly in SQLite, keeping the whole app in one portable file
- Marathi UI strings are machine-translated — a native speaker review is welcome
- Mangal and Kohinoor Devanagari are proprietary OS-bundled fonts (Windows/macOS) and aren't embedded in the app; they render correctly if already installed, and fall back to the free Noto Sans Devanagari otherwise

## License

MIT — see [LICENSE](LICENSE) for details.