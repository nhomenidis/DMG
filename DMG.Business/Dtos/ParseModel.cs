using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;
using Microsoft.EntityFrameworkCore.Storage;

namespace DMG.Business.Dtos
{
    [IgnoreFirst(1)]
    [DelimitedRecord(";")]
    public class ParseModel : IComparable<ParseModel>

    {
        public string VAT;
        public string FIRST_NAME;
        public string LAST_NAME;
        public string EMAIL;
        public string PHONE;
        public string ADRESS;
        public string COUNTY;

        [FieldConverter(ConverterKind.Guid, "D")] public Guid BILL_ID;

        public string DESCRIPTION;

        [FieldConverter(ConverterKind.Double, ",")] public double AMOUNT;

        [FieldConverter(ConverterKind.Date, "yyyyMMdd")] public DateTime DATE_DUE;

        public int CompareTo(ParseModel other)
        {
            return String.Compare(this.VAT, other.VAT, StringComparison.Ordinal);
        }
    }
}
