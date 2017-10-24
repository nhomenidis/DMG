using System;

namespace DMG.Business.Dtos
{
    public class BillDto

    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public DateTime DueDateTime { get; set; }
        public Boolean IsPayed { get; set; }
        public string Name { get; set; }

    }

}
