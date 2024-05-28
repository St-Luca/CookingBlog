namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponsePriceIngredient
{
    public FoodApiResponseAmount Amount { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}