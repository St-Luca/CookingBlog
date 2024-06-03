using System.Text.Json.Serialization;

namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public double Amount { get; set; }
    public string Image { get; set; } = null!;
    public double Price { get; set; }

    public FoodApiResponseIngredientMeasure Measures { get; set; } = null!;
}