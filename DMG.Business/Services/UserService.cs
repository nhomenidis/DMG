using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Database;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Models;
using DMG.AuthProvider;

namespace DMG.Business.Services
{
    public interface IUserService
    {
        UserDto GetUser(string vat);
        IEnumerable<UserDto> GetAll();
        Boolean CheckPass(PasswordReset updatepass);

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

        public Boolean CheckPass(PasswordReset updatepass)
        {
            
            return true;

        }


    }

}
