using CookingBlog.DataAccess;
using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.DataAccess.Repositories;
using CookingBlog.Infrastructure;
using CookingBlog.Services;
using CookingBlog.Services.IntegratedServices;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddDbContext<CookingContext>(options => options.UseNpgsql(config["Postgres:ConnectionString"]), ServiceLifetime.Scoped);

AddAllServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    AddBearerAuth(c);
    c.SchemaGeneratorOptions.SupportNonNullableReferenceTypes = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            //for signalr auth
            var token = context.Request.Query["access_token"];

            if (!string.IsNullOrEmpty(token))
            {
                context.Token = token;
            }

            return Task.CompletedTask;
        }
    };
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Auth:AccessTokenSecret"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddHealthChecks();

builder.Services.AddHttpClient<IFoodApiRecipeService, FoodApiRecipeService>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(config["FoodApi:Url"]);
});

builder.Services.AddHttpClient<IFoodApiPriceAndIngredientService, FoodApiPriceAndIngredientService>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(config["FoodApi:Url"]);
});

builder.Services.AddHttpClient<IFoodApiTasteService, FoodApiTasteService>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(config["FoodApi:Url"]);
});

builder.Services.AddHttpClient<IFoodApiEquipmentService, FoodApiEquipmentService>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri(config["FoodApi:Url"]);
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
})
.UseMiddleware<GlobalExceptionMiddleware>()
.UseAuthentication()
.UseRouting()
.UseAuthorization()
.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health42g3hd");
});

app.Run();



void AddBearerAuth(SwaggerGenOptions options)
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Description = "Enter the token with the `Bearer ` prefix, e.g. \"Bearer abcde12345\"."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
}

void AddAllServices(IServiceCollection services)
{
    services
        .AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
        })

        .AddTransient<IUserService, UserService>()
            //.AddTransient<IUserRolesService, UserRolesService>()
        .AddTransient<IRegistrationService, RegistrationService>()
            //.AddSingleton<IUserRolesRepository, UserRolesRepository>()
        .AddScoped<IUserRepository, UserRepository>()
        .AddSingleton<IPasswordHashService, PasswordHashService>()
        .AddTransient<IAuthService, AuthService>()
        .AddTransient<IUserTokensService, UserTokensService>()
        .AddScoped<IUserTokensRepository, UserTokensRepository>()
        .AddSingleton<ITokenGenService, TokenGenService>()
        .AddSingleton<IPasswordResetService, PasswordResetService>();
}
