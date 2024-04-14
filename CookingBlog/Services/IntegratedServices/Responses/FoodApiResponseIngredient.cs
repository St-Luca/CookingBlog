namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredient
{
    public string Name { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public double Amount { get; set; }
}