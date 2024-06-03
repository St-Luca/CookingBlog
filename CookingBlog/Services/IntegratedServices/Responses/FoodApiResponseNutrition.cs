namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseNutrition
{
    public string Name { get; set; }
    public double Amount { get; set; }
    public string Unit { get; set; }
    public double PercentOfDailyNeeds { get; set; }
}