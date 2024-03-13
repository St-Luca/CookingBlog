using CookingBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Recipe> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Recipe
            {
                Id = Random.Shared.Next(1, 55),
                Name = "Recipe" + Random.Shared.Next(1, 55)
            })
            .ToArray();
        }
    }
}