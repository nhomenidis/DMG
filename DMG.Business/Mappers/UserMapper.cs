using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class UserMapper : IMapper<User,UserDto>
    {
        
        public UserDto Map(User user)
        {
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDto
            {
                Vat = user.Vat,
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Phone = user.Phone
                
            };

            return userDto;
        }

        public IEnumerable<UserDto> Map(IEnumerable<User> users)

        {
            var usersdtolist = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = Map(user);
                usersdtolist.Add(userDto);       
            }
            return usersdtolist;

        }


    }
}