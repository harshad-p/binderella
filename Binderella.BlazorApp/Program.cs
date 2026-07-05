using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<RecipeContext>(options =>
    options.UseSqlite("Data Source=recipebook.db"));
builder.Services.AddScoped<LocalizationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RecipeContext>();
    db.Database.EnsureCreated();
    SeedData.Initialize(db);
}

app.Run();
