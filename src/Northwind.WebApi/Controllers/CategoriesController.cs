using Microsoft.AspNetCore.Mvc;

using Northwind.Application.Production.Categories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ICategoriesQueries _categoriesQueries;

        public CategoriesController(ICategoryAppService categoryAppService, ICategoriesQueries categoriesQueries)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _categoriesQueries = categoriesQueries ?? throw new ArgumentNullException(nameof(categoriesQueries));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto category)
        {
            var createdCategory = await _categoryAppService.Add(category);
            return CreatedAtRoute("GetCategory", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoriesQueries.GetCategories());
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryAppService.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto category)
        {
            if (await _categoryAppService.Get(id) == null)
            {
                return NotFound();
            }

            await _categoryAppService.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryAppService.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryAppService.Remove(id);
            return NoContent();
        }
    }
}