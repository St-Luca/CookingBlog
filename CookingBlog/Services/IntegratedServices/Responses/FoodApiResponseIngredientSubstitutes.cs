namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredientSubstitutes
{
    public string Ingredient { get; set; }
    public IList<string> substitutes = new List<string>();
    public string Message { get; set; }
}