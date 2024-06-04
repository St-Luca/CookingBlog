using CookingBlog.Models.Core;

namespace CookingBlogFront.Data
{
    public class RecipeService: IRecipeService
    {
        public Dictionary<string, List<Recipe>> Recipes { get; set; }

        public async Task GetRecipe()
        {
            HttpClient httpClient = new HttpClient();
            Recipes = await httpClient.GetFromJsonAsync<Dictionary<string, List<Recipe>>>("http://host.docker.internal:8080/api/catalog?count=3");

        }
    }
}
