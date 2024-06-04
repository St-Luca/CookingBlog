namespace CookingBlogFront.Data
{
    public interface IRecipeService
    {
        public Dictionary<string, List<Recipe>> Recipes { get; set; }

        public async Task GetRecipe() { }
    }
}
