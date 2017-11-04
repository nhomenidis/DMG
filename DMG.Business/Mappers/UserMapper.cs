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
        
        public UserDto Map(User billdto)
        {
            if (billdto == null)
            {
                return null;
            }
            var userDto = new UserDto
            {
                Vat = billdto.Vat,
                FirstName = billdto.FirstName,
                LastName = billdto.LastName,
                Email = billdto.Email,
                Phone = billdto.Phone,
                Address = billdto.Adress,
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