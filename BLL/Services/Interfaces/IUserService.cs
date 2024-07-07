using BLL.DTO.Request.User;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task AddUserAsync(CreateUserDto userDto, CancellationToken cancellationToken);
        Task UpdateUserAsync(UpdateUserDto userDto, CancellationToken cancellationToken);
        Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);

        Task<UserDto> LoginAsync(LoginUserDto userDto , CancellationToken cancellation);
    }
}
