using System;
using System.Collections.Generic;
using System.Text;
using DMG.AuthProvider;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class CreateUserDtoMapper : IMapper<CreateUserDto, User>
    {
        public User Map(CreateUserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Vat = userDto.Vat,
                Password = PasswordHasher.HashPassword(userDto.Password)
            };
        }

        public IEnumerable<User> Map(IEnumerable<CreateUserDto> userDtos)
        {
            throw new NotImplementedException();
        }
    }
}
