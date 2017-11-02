using DMG.AuthProvider;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.DatabaseContext.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string vat);
        Task<User> GetUserNoDto(string vat);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> ChangeEmail(Guid id, string newEmail);
        Task<bool> ChangePassword(string vat, string oldPassword, string newPassword);
        Task<UserDto> CreateUser(CreateUserDto newUser);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDto> _userMapper;
        private readonly IMapper<CreateUserDto, User> _createUserDtoMapper;

        public UserService(
            IUserRepository userRepository,
            IMapper<User, UserDto> userMapper,
            IMapper<CreateUserDto, User> createUserDtoMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _createUserDtoMapper = createUserDtoMapper;
        }

        public async Task<UserDto> CreateUser(CreateUserDto newUser)
        {
            var user = _createUserDtoMapper.Map(newUser);

            user = await _userRepository.Insert(user);

            return _userMapper.Map(user);
        }

        public async Task<UserDto> GetUser(string vat)
        {
            var user = await _userRepository.GetByVat(vat);
            var userdto = _userMapper.Map(user);

            return userdto;
        }

        public async Task<User> GetUserNoDto(string vat) // returns the user without mapping him to Dto
        {
            var user = await _userRepository.GetByVat(vat);
            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var allusers = await _userRepository.GetAll();
            var usersdto = _userMapper.Map(allusers);

            return usersdto;
        }

        public async Task<UserDto> ChangeEmail(Guid id, string newEmail)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }
            user.Email = newEmail;
            user = await _userRepository.Update(user);

            return _userMapper.Map(user);
        }

        public async Task<bool> ChangePassword(string vat, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByVat(vat);
            var matcHashedPassword = PasswordHasher.VerifyHashedPassword(user.Password, oldPassword);

            
            if (user.Vat == null || !matcHashedPassword)
            {
                return false;
            }

            var hashedNewPassword = PasswordHasher.HashPassword(newPassword);
            user.Password = hashedNewPassword;
            await _userRepository.Update(user);

            return true;
        }
    }
}
