using HRMSApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sdctool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SDCTestController : ControllerBase
    {
        sdcservice sdcservice = new sdcservice();
        private readonly HRMSDBContext _context;

        public SDCTestController(HRMSDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostItemData(ItemData model)
        {
            List<ItemData> list = new List<ItemData>();

            list.Add(model);
            var conStatus = sdcservice.SendConnection("192.168.2.141");
            var response = sdcservice.doInvoice(list, "05-25-01-616", "01682616727", "192.168.2.141");

            //var res = new SDCResponseData()
            //{
            //    TotalAmount = response.totalAmount,
            //    Terminal = response.terminal,
            //    TaxAmount = response.taxAmount,
            //    InvoiceNo = response.invoiceNo,
            //    Msg = response.msg,
            //    Code = response.code
            //};      

            return Ok(response.invoiceNo);        
        }

        
    }
}
