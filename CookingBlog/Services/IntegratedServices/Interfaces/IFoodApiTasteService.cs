using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiTasteService
{
    Task<FoodApiResponseTaste?> GetTasteByIdAsync(int id); 
}