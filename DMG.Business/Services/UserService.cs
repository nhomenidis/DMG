using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Database;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface IUserService
    {
        UserDto GetUser(string vat);
        IEnumerable<UserDto> GetAll();

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

        public IEnumerable<UserDto> GetAll()
        {
            var userRepository = new UserRepository();
            var allusers = userRepository.GetAll();

            var mapper = new UserMapper();
            var usersdto = mapper.Map(allusers);

            return usersdto;
        }
    }

}
