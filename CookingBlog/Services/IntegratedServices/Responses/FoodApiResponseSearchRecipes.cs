namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseSearchRecipes
{
    public int Offset { get; set; }
    public int Number { get; set; }
    public IList<FoodApiResponseSearchResults> Results { get; set; } = new List<FoodApiResponseSearchResults>();
}