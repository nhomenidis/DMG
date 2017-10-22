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
                Status = "Payed",
                DueDate = DateTime.Today


            };
            var bill2 = new Bill()
            {   
                Id = "2",
                Amount = 2000,
                Description = "Blues",
                Status = "Not Payed",
                DueDate = DateTime.Today
            };

            var bills = new List<Bill>
            {
                bill1,
                bill2
            };

            return bills;

        }

        public Bill GetById(string id)
        {
            var bill = new Bill()
            {
                Id = "3",
                Amount = 4000000,
                Description = "Pop",
                Status = "Not Payed",
                DueDate = DateTime.Today
            };
            return bill;
        }
    }
}
