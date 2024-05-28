namespace CookingBlogFront.Data
{
    public class RecipeService
    {


        public async Task<Dictionary<string, List<Recipe>>> GetRecipe()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<Dictionary<string, List<Recipe>>>("http://host.docker.internal:8080/api/catalog?count=3");

        }
    }
}
