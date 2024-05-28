namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseEquipment
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public FoodApiResponseTemperature Temperature { get; set; }
}