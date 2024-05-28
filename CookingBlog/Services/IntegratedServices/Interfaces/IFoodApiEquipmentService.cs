using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiEquipmentService
{
    Task<FoodApiResponseEquipment?> GetEquipmentsByIdAsync(int id); 
}