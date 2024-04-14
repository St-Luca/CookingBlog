namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseRecipe
{
    public string Title { get; set; } = null!;
    public string Instructions { get; set; } = null!;

    public IList<FoodApiResponseIngredient> ExtendedIngredients { get; set; } =
        new List<FoodApiResponseIngredient>();
}