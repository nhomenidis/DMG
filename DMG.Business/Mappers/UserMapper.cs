using System.Collections.Generic;
using System.Xml;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class UserMapper : IMapper<User,UserDto>
    {
        
        public UserDto Map(User user)
        {
            var userDto = new UserDto
            {
                Vat = user.Vat,
                Name = user.FirstName + " " + user.LastName
            };

            return userDto;
        }

        public IEnumerable<UserDto> Map(IEnumerable<User> users)

        {
            var usersdtolist = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Vat = user.Vat,
                    Name = user.FirstName + " " + user.LastName
                };
                usersdtolist.Add(userDto);
                    
                
            }
            return usersdtolist;

        }
    }
}