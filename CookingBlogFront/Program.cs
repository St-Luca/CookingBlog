using Blazored.LocalStorage;
using CookingBlogFront.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Blazored.FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation;
using CookingBlogFront.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<AuthenticationStateProvider, IdentutyAuthenticationStateProvider>();
builder.Services.AddScoped<AuthorizeApi>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IRecipeService, RecipeService>();
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
