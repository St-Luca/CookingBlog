namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiNutrition
{
    public string Name { get; set; }
    public double Amount { get; set; }
    public string Unit { get; set; }
    public double PercentOfDailyNeeds { get; set; }
}