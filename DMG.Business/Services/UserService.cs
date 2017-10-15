using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Database;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Model;

namespace DMG.Business.Services
{
    public interface IUserService
    {
        UserDto GetUser(string vat);

    }

    public class UserService : IUserService
    {
       public UserDto GetUser(string vat)
       {
           var userRepository = new UserRepository();
           var user = userRepository.GetById(vat);

           var mapper = new UserMapper();
           var userdto = mapper.Map(user);

           return userdto;
       }
    }

}
