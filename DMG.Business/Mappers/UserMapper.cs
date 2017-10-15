using DMG.Business.Dtos;
using DMG.Model;

namespace DMG.Business.Mappers
{
    public class UserMapper : IMapper<User,UserDto>
    {
        public UserMapper()
        {
            
        }
        public UserDto Map(User user)
        {
            var userDto = new UserDto
            {
                Vat = user.Vat,
                Name = user.FirstName + " " + user.LastName
            };

            return userDto;
        }
    }
}