namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseCollection
{
    public List<FoodApiResponseRecipe> Recipes { get; set; } 
        = new List<FoodApiResponseRecipe>();
}