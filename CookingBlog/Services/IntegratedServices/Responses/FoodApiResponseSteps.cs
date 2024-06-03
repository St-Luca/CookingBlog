namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseSteps
{
    public IList<FoodApiResponseEquipmentInformation> Equipment { get; set; } = new List<FoodApiResponseEquipmentInformation>();
    public IList<FoodApiResponseIngredient> Ingredients { get; set; } = new List<FoodApiResponseIngredient>();
    public int Number { get; set; }
    public string Step { get; set; }
}