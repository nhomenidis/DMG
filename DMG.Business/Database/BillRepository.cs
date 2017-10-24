using System;
using System.Collections.Generic;
using System.Text;
using DMG.Models;

namespace DMG.Business.Database
{
    public interface IBillRepository
    {
        Bill GetById(string id);
        IEnumerable<Bill> GetAll(User user);
    }

    public class BillRepository : IBillRepository
    {
        public IEnumerable<Bill> GetAll(User user)
        {
            var bill1 = new Bill()
            {
                Id = "1",
                Amount = 1000,  
                Description = "Rock n Roll",
                IsPayed = true,
                DueDate = DateTime.Today


            };
            var bill2 = new Bill()
            {   
                Id = "2",
                Amount = 2000,
                Description = "Blues",
                IsPayed = false,
                DueDate = DateTime.Today
            };

            var bills = new List<Bill>
            {
                bill1,
                bill2
            };

            bill1.User = new User()
            {
                Vat = "12345",
                FirstName = "Luca",
                LastName = "Melis",
                Email = "papaki@gmail.com",
                Adress = new AddressInfo()
                {
                    Address = "papadias 25",
                    County = "Tsatrapatra",
                    Id = "1656",

                },
                Id = "12345",
                Phone = "3354345839945",
                Settlements = new List<Settlement>(),
            };
            bill2.User = bill1.User;

            return bills;

        }

        public Bill GetById(string id)
        {
            var bill = new Bill()
            {
                Id = "3",
                Amount = 4000000,
                Description = "Pop",
                IsPayed = false,
                DueDate = DateTime.Today,
                
                
            };
            bill.User = new User()
            {
                Vat = "12345",
                FirstName = "Luca",
                LastName = "Melis",
                Email = "papaki@gmail.com",
                Adress = new AddressInfo()
                {
                    Address = "papadias 25",
                    County = "Tsatrapatra",
                    Id = "1656",

                },
                Id = "12345",
                Phone = "3354345839945",
                Settlements = new List<Settlement>(),


            };

            return bill;
        }
    }
}
