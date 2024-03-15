using CookingBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        //private readonly ICatalogService catalogService;

        public CatalogController(ILogger<CatalogController> logger)//, ICatalogService catalogService)
        {
            _logger = logger;
           // this.catalogService = catalogService;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            //catalogService.GetCatalog();
            return Enumerable.Range(1, 5).Select(index => new Recipe
            {
                Id = Random.Shared.Next(1, 55),
                Name = "Recipe" + Random.Shared.Next(1, 55)
            })
            .ToArray();
        }
    }
}