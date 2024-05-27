namespace CookingBlogFront.Data
{
    public class Recipe
    {
        public string title { get; set; }
        public string instructions { get; set; }
        public List<Ingredient> extendedIngredients { get; set; }
    }
}
