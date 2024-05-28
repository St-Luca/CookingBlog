namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseEquipmentInformation
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public FoodApiResponseTemperature Temperature { get; set; }
}