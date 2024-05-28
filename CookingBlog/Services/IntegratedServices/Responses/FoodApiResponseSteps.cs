namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseSteps
{
    public IList<FoodApiResponseEquipment> equipment = new List<FoodApiResponseEquipment>();
    public IList<FoodApiResponseIngredient> ingredients = new List<FoodApiResponseIngredient>();
    public int Number { get; set; }
    public string Step { get; set; }
}