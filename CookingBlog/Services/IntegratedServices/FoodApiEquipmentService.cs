using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
namespace CookingBlog.Services.IntegratedServices;

public class FoodApiEquipmentService: IFoodApiEquipmentService
{
    private readonly HttpClient _httpClient;

    public FoodApiEquipmentService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseEquipment?> GetEquipmentsByIdAsync(int id)
    {
        var equipments = await _httpClient
            .GetFromJsonAsync<FoodApiResponseEquipment>(
                $"https://api.spoonacular.com/recipes/{id}/equipmentWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        var informationEquipment = equipments.Equipment;
        for (int i = 0; i < informationEquipment.Count; i++)
        {
            informationEquipment[i].Image =
                $"https://img.spoonacular.com/equipment_250x250/{informationEquipment[i].Image}";
        }
        return equipments;
    }
}