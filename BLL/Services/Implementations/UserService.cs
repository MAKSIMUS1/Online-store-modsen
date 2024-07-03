using AutoMapper;
using BLL.DTO.Request.User;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            if (user == null)
                throw new EntityNotFoundException($"User with Id {userId} not found.");

            return _mapper.Map<UserDto>(user);
        }

        public async Task AddUserAsync(CreateUserDto userDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();

            await _userRepository.AddAsync(user, cancellationToken);
        }

        public async Task UpdateUserAsync(UpdateUserDto userDto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDto.Id, cancellationToken);
            if (existingUser == null)
                throw new EntityNotFoundException($"User with Id {userDto.Id} not found.");

            _mapper.Map(userDto, existingUser);

            await _userRepository.UpdateAsync(existingUser, cancellationToken);
        }

        public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId, cancellationToken);
            if (existingUser == null)
                throw new EntityNotFoundException($"User with Id {userId} not found.");

            await _userRepository.DeleteAsync(userId, cancellationToken);
        }
    }
}
