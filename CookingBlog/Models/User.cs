﻿namespace CookingBlog.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Picture { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Raiting { get; set; }
    public List<Review> Reviews { get; set; } = new();
    public List<Recipe> Recipes { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
}
