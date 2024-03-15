using CookingBlog.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;


//string connection = config["Postgres:ConnectionString"];
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//string connection = settings.GetValue("Postgres:ConnectionString");

builder.Services.AddDbContext<CookingContext>(options => options.UseNpgsql(config["Postgres:ConnectionString"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
