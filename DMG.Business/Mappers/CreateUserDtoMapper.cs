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
        public User Map(CreateUserDto userdto)
        {
            return new User
            {
                FirstName = userdto.FirstName,
                LastName = userdto.LastName,
                Email = userdto.Email,
                Vat = userdto.Vat,
                Password = PasswordHasher.HashPassword(userdto.Password)
            };
        }

        public IEnumerable<User> Map(IEnumerable<CreateUserDto> userDtos)
        {
            throw new NotImplementedException();
        }
    }
}
