using System;
using System.Collections.Generic;
using System.Text;
using DMG.Model;

namespace DMG.Business.Database
{
    public interface IUserRepository
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
    }

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            var user = new User()
            {
                Vat = "12345",  
                FirstName = "Luca",
                LastName = "Melis"
            };
            var user2 = new User()
            {
                Vat = "54321",
                FirstName = "Nikaro",
                LastName = "Hosta"
            };

            var users = new List<User>
            {
                user,
                user2
            };

            return users;

        }

        public User GetById(string id)
        {
            var user = new User()
            {
                Vat = "12345",
                FirstName = "Luca",
                LastName = "Melis"
            };
            return user;
        }
    }
}
