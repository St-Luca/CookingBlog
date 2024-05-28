namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredientMeasure
{
    public FoodApiResponseIngredientUs Us { get; set; } = null!;

    public FoodApiResponseIngredientMetric Metric { get; set; } = null!;
}