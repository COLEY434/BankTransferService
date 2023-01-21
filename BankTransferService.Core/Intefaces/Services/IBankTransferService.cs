using BankTransferService.Core.DTOS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Core.Intefaces.Services
{
    public interface IBankTransferService
    {
        Task<BankResponse> GetBanks(string provider);
    }
}
