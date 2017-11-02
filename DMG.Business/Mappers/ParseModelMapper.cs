using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class ParseModelMapper : IMapper<ParseModel,User>
    {
        
        public User Map(ParseModel billdto)
        {
            if (billdto == null)
            {
                return null;
            }
           
            var user = new User
            {
                Vat = billdto.VAT,
                FirstName = billdto.FIRST_NAME,
                LastName = billdto.LAST_NAME,
                Email = billdto.EMAIL,
                Phone = billdto.PHONE,
                Adress = new AddressInfo()
                { Address = billdto.ADRESS, County = billdto.COUNTY },
                Bills = new List<Bill>
                {
                  new Bill()
                  { BillId = billdto.BILL_ID,
                    Description = billdto.DESCRIPTION,
                    Amount  = billdto.AMOUNT,
                    DateDue = billdto.DATE_DUE,
                    UserVat = billdto.VAT
                  }
                },
   
            };

            return user;
        }

        public IEnumerable<User> Map(IEnumerable<ParseModel> parseModels)

        {
            var userList = new List<User>();

            foreach (var parsemodel in parseModels)
            {
                var userExists = userList.FirstOrDefault(x => x.Vat == parsemodel.VAT);
                if (userExists != null)
                {
                    var bill = new Bill()
                    {
                        BillId = parsemodel.BILL_ID,
                        Description = parsemodel.DESCRIPTION,
                        Amount = parsemodel.AMOUNT,
                        DateDue = parsemodel.DATE_DUE,
                        UserVat = parsemodel.VAT
                    };
                userExists.Bills.Add(bill);
                }
                else
                {
                    var user = Map(parsemodel);
                    userList.Add(user);
                }
                
            }
            return userList;

        }


    }
}