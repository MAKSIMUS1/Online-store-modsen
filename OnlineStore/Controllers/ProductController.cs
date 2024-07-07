using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO.Request.Product;
using BLL.DTO.Response;
using BLL.Service.Interface;
using Microsoft.AspNetCore.Authorization;


namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync(cancellationToken);
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
            return Ok(product);
        }

        // GET: api/product/category/{categoryId}
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId, cancellationToken);
            return Ok(products);
        }

        // POST: api/product
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] CreateProductDto productDto, CancellationToken cancellationToken)
        {
            await _productService.AddProductAsync(productDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            productDto.Id = id;
            await _productService.UpdateProductAsync(productDto, cancellationToken);
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
