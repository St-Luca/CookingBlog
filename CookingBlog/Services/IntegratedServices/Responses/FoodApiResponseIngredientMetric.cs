namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredientMetric
{
    public double Amount { get; set; }	
    public string? UnitShort { get; set; }
    public string? UnitLong { get; set; }
    public string? Unit { get; set; }
    public double Value { get; set; } 
}