namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseCollection
{
    public IList<FoodApiResponseRecipe> Recipes { get; set; } 
        = new List<FoodApiResponseRecipe>();
}