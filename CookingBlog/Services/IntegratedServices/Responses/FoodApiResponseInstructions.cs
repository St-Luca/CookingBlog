namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseInstructions
{
    public string Name { get; set; }
    public IList<FoodApiResponseSteps> steps = new List<FoodApiResponseSteps>();
}