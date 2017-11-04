using DMG.Models;

namespace DMG.Business.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Vat { get; set; }
        public AddressInfo Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }

}
