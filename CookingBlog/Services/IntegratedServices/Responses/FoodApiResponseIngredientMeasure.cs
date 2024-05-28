namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseIngredientMeasure
{
    public FoodApiResponseIngredientMeasureUs Us { get; set; } = null!;

    public FoodApiResponseIngredientMeasureMetric Metric { get; set; } = null!;
}