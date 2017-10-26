using System;

namespace DMG.Business.Dtos
{
    public class CreateBillDto
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { set; get; }
        public bool IsPayed { set; get; }

        public Guid UserId { get; set; }
    }
}