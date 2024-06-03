namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseRecipe
{
    public string Title { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public string Image { get; set; } = null!;
    public double PricePerServing { get; set; }

    public IList<FoodApiResponseIngredient> ExtendedIngredients { get; set; } = new List<FoodApiResponseIngredient>();
}