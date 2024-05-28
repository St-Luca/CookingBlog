namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponsePriceAndIngredients
{
    public IList<FoodApiResponsePriceIngredient> Ingredients { get; set; } = new List<FoodApiResponsePriceIngredient>();
    public double TotalCost { get; set; }
    public double TotalCostPerServing { get; set; }
}