using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO.Request.Category;
using BLL.DTO.Response;
using BLL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
                return Ok(category);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CreateCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            await _categoryService.AddCategoryAsync(categoryDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            try
            {
                categoryDto.Id = id;
                await _categoryService.UpdateCategoryAsync(categoryDto, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
