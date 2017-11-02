using System;

namespace DMG.Business.Dtos
{
    public class BillDto

    {
        public Guid BillId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DatePayed { get; set; }
        public bool IsPayed { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Vat { get; set; }

        public Guid UserId { get; set; }

    }

}
