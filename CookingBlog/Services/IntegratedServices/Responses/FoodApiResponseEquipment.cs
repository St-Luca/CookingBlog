namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseEquipment
{
    public IList<FoodApiResponseEquipmentInformation> Equipment { get; set; } =
        new List<FoodApiResponseEquipmentInformation>();
}