# Binderella

A Blazor Server app for digitizing your mom's recipe binder. Built for a hackathon MVP.

## What it does
- Add a recipe with a title, photo, chef/source name (with optional link), ingredients, steps, and a fun closing line
- Every recipe is rendered through **one shared template** (`Shared/RecipeCard.razor`) — change the design once, every recipe (old and new) updates automatically
- Browse and search all recipes on the home page
- Print any recipe, sized for A5 paper (ready to laminate and put in a binder) — the recipe's own name shows in the print/save-as-PDF dialog, not just the app name
- Switch the app's UI language between **English and Marathi** using the dropdown in the top bar
- Pick a **font per recipe** — a couple of clean/fancy English fonts, plus Devanagari options (Mangal, Kohinoor Devanagari, and Noto Sans Devanagari as a universal fallback) so Marathi recipes render properly
- Data is stored locally in a SQLite file (`recipebook.db`) — no server setup needed

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run it
```bash
cd RecipeBook
dotnet restore
dotnet run
```
Then open the URL shown in the terminal (usually `https://localhost:5001` or similar).

The first time it runs, it will create `recipebook.db` automatically and seed one sample recipe (Chicken Masala) so the demo isn't empty.

## Project structure
```
RecipeBook/
├─ Models/            Recipe, RecipeIngredient, RecipeStep
├─ Data/              EF Core DbContext + seed data
├─ Services/          LocalizationService (English/Marathi UI strings)
├─ Shared/            MainLayout + RecipeCard (the reusable template)
├─ Pages/             Index (list), RecipeForm (add/edit), ViewRecipe, _Host
└─ wwwroot/css/       site.css (design + A5 print rules)
```

## Notes / known limitations (by design, for the 2hr scope)
- No authentication — this is meant for local/family use, not multi-user hosting
- Images are stored directly in the SQLite database as bytes (simplest for a single-file, portable database — easy to back up or copy to another machine)
- Marathi UI strings were machine-translated — have a fluent speaker review them before relying on this for real use
- Mangal and Kohinoor Devanagari are proprietary system fonts (bundled with Windows/macOS respectively). They aren't embedded in the app — they'll render correctly if already installed on the viewing computer, and fall back to Noto Sans Devanagari (a free web font) otherwise
- No AI auto-extraction from YouTube/text yet (cut for time) — could be a great v2 feature given how your mom finds recipes

## If something doesn't build
- Make sure you have the .NET 8 SDK specifically (`dotnet --version` should show `8.x`)
- If `dotnet restore` fails to find packages, check your internet connection — it needs to fetch the EF Core SQLite packages the first time
