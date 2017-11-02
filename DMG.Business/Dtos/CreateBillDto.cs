using System;

namespace DMG.Business.Dtos
{
    public class CreateBillDto
    {
        public Guid BillId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { set; get; }
        public DateTime DatePayed { get; set; }
        public bool IsPayed { set; get; }

        public Guid UserId { get; set; }
    }
}