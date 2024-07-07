using BLL.DTO.Request.Category;
using BLL.DTO.Response;
using BLL.Service.Interface;
using DAL.Model;
using DAL.Repositories.Interfaces;
using BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default )
        {
            var categories = await _categoryRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken = default )
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category is null)
                throw new EntityNotFoundException($"Category with Id {categoryId} not found.");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task AddCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken = default )
        {
            var existingCategory = await _categoryRepository.FindByNameAsync(categoryDto.Name, cancellationToken);
            if (existingCategory is not null)
            {
                throw new EntityAlreadyExistsException($"Category with name '{categoryDto.Name}' already exists.");
            }
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = Guid.NewGuid();

            await _categoryRepository.AddAsync(category, cancellationToken);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto, CancellationToken cancellationToken = default )
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(categoryDto.Id, cancellationToken);
            if (existingCategory is null)
                throw new EntityNotFoundException($"Category with Id {categoryDto.Id} not found.");

            _mapper.Map(categoryDto, existingCategory);

            await _categoryRepository.UpdateAsync(existingCategory, cancellationToken);
        }

        public async Task DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default )
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (existingCategory is null)
                throw new EntityNotFoundException($"Category with Id {categoryId} not found.");

            await _categoryRepository.DeleteAsync(categoryId, cancellationToken);
        }
    }
}
