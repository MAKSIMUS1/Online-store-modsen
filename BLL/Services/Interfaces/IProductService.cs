using BLL.DTO.Request.Product;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
        Task AddProductAsync(CreateProductDto productDto, CancellationToken cancellationToken);
        Task UpdateProductAsync(UpdateProductDto productDto, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken);
    }
}
