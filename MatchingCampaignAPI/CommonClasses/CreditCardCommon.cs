using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class CreditCardCommon
    {
        public string CreditNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime Validity { get; set; }
        public string Idnumber { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
