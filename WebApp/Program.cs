using DataStore.InMemory;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UseCases;
using UseCases.DataStore;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IView, View>();
builder.Services.AddTransient<IAddCategory, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategory, EditCategory>();
builder.Services.AddTransient<IGetCategoryById, GetCategoryById>();
builder.Services.AddTransient<IDeleteCategory, DeleteCategory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
