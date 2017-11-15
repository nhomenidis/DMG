using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Business.Dtos
{
    public class ErrorDto
    {
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public string StackTrace { get; set; }
    }
}
