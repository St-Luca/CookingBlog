namespace CookingBlog.Services.IntegratedServices.Responses;

public class FoodApiResponseMissedIngredients
{
    public string Aisle { get; set; }
    public double Amount { get; set; }
    public int Id { get; set; }
    public string Image { get; set; }
    public IList<string> Meta { get; set; } = new List<string>();
    public string Name { get; set; }
    public string Original { get; set; }
    public string OriginalName { get; set; }
    public string Unit { get; set; }
    public string UnitLong { get; set; }
    public string UnitShort { get; set; }
}