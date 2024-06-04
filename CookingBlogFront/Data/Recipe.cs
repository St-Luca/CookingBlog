namespace CookingBlogFront.Data
{
    public class Recipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public string instructions { get; set; }
        public string image { get; set; }
        public double pricePerServing {  get; set; }
        public List<Ingredient> extendedIngredients { get; set; }
    }
}
