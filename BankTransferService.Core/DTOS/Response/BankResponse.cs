using BankTransferService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Core.DTOS.Response
{
    public class BankResponse
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public List<Banks>? BankList { get; set; }
    }
}
