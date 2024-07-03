using BLL.DTO.Request.Category;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken);
        Task AddCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken);
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto,CancellationToken cancellationToken);
        Task DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
    }
}
