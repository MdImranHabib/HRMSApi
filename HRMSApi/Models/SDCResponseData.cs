using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models
{
    public class SDCResponseData
    {
        public string TotalAmount { get; set; }
        public string Terminal { get; set; }
        public string TaxAmount { get; set; }       
        public string InvoiceNo { get; set; }                
        public string Msg { get; set; }
        public string Code { get; set; }
    }
}
