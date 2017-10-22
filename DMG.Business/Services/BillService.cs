using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Database;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface IBillService
        {
            BillDto GetBill(string billId);
            IEnumerable<BillDto> GetBillsbyUser(User user);
        }

    public class BillService : IBillService
    {
        public BillDto GetBill(string Id)
        {
            var billrepository = new BillRepository();
            var bill = billrepository.GetById(Id);

            var mapper = new BillMapper();
            var billdto = mapper.Map(bill);

            return billdto;

        }

        public IEnumerable<BillDto> GetBillsbyUser(User user)
        {
            var billrepository = new BillRepository();
            var bills = billrepository.GetAll(user);

            var mapper = new BillMapper();
            var billsdto = mapper.Map(bills);

            return billsdto;
        }





    }
}
