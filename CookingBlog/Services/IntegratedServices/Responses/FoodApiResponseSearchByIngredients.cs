namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseSearchByIngredients
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string ImageType { get; set; }
    public int Likes { get; set; }
    public int MissedIngredientCount { get; set; } 
    public IList<FoodApiResponseMissedIngredients> MissedIngredients { get; set; }
}