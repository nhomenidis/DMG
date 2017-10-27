using System;

namespace DMG.Business.Dtos
{
    public class BillDto

    {
        public string BillId { get; set; }
        public double Amount { get; set; }
        public DateTime DueDateTime { get; set; }
        public Boolean IsPayed { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public Guid UserId { get; set; }

    }

}
