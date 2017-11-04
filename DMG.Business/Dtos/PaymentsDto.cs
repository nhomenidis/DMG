using System;

namespace DMG.Business.Dtos
{
    public class PaymentsDto
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public DateTime DatePayed { get; set; }
        public string PayMethod { get; set; }
        public string BillId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}