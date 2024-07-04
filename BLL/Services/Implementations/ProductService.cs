using AutoMapper;
using BLL.DTO.Request.Product;
using BLL.DTO.Response;
using BLL.Exceptions;
using BLL.Service.Interface;
using DAL.Model;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken = default = default)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken = default = default)
        {
            var product = await _productRepository.GetByIdAsync(productId, cancellationToken);
            if (product is null)
                throw new EntityNotFoundException($"Product with Id {productId} not found.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default = default)
        {
            var products = await _productRepository.GetByCategoryAsync(categoryId, cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task AddProductAsync(CreateProductDto productDto, CancellationToken cancellationToken = default = default)
        {
            var existingProduct = await _productRepository.FindByNameAsync(productDto.Name, cancellationToken);
            if (existingProduct is not null)
            {
                throw new EntityAlreadyExistsException($"Product with name '{productDto.Name}' already exists.");
            }
            var product = _mapper.Map<Product>(productDto);
            product.Id = Guid.NewGuid();

            await _productRepository.AddAsync(product, cancellationToken);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto, CancellationToken cancellationToken = default = default)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id, cancellationToken);
            if (existingProduct is null)
                throw new EntityNotFoundException($"Product with Id {productDto.Id} not found.");

            _mapper.Map(productDto, existingProduct);

            await _productRepository.UpdateAsync(existingProduct, cancellationToken);
        }

        public async Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken = default = default)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId, cancellationToken);
            if (existingProduct is null)
                throw new EntityNotFoundException($"Product with Id {productId} not found.");

            await _productRepository.DeleteAsync(productId, cancellationToken);
        }
    }
}
