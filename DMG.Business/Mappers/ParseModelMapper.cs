using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class ParseModelMapper : IMapper<IEnumerable<ParseModel>, User>
    {

        public User Map(IEnumerable<ParseModel> parseUsers)
        {
            var parseUser = parseUsers.FirstOrDefault();
            if (parseUser == null) return null;

            var user = new User
            {
                Vat = parseUser.VAT,
                FirstName = parseUser.FIRST_NAME,
                LastName = parseUser.LAST_NAME,
                Email = parseUser.EMAIL,
                Phone = parseUser.PHONE,
                Adress = new AddressInfo()
                { Address = parseUser.ADRESS, County = parseUser.COUNTY },

                Bills = parseUsers.Select(parseBill => new Bill()
                {
                    BillId = parseBill.BILL_ID,
                    Description = parseBill.DESCRIPTION,
                    Amount = parseBill.AMOUNT,
                    DateDue = parseBill.DATE_DUE,
                    UserVat = parseBill.VAT
                }).ToList()
            };

            return user;
        }

        public IEnumerable<User> Map(IEnumerable<IEnumerable<ParseModel>> inputs)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<User> Map(IEnumerable<ParseModel> parseModels)

        //{
        //    var userList = new List<User>();

        //    foreach (var parsemodel in parseModels)
        //    {
        //        var userExists = userList.FirstOrDefault(x => x.Vat == parsemodel.VAT);
        //        if (userExists != null)
        //        {
        //            var bill = new Bill()
        //            {
        //                BillId = parsemodel.BILL_ID,
        //                Description = parsemodel.DESCRIPTION,
        //                Amount = parsemodel.AMOUNT,
        //                DateDue = parsemodel.DATE_DUE,
        //                UserVat = parsemodel.VAT
        //            };
        //        userExists.Bills.Add(bill);
        //        }
        //        else
        //        {
        //            var user = Map(parsemodel);
        //            userList.Add(user);
        //        }
        //    }
        //    return userList;
        //}
    }
}