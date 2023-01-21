using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Core.DTOS.Response
{
    public class FlutterwaveBankListRes
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Banks> data { get; set; }
    }

    public class Banks
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }
}
