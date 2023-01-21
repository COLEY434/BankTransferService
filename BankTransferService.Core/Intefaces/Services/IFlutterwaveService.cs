using BankTransferService.Core.DTOS.Response;
using BankTransferService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Core.Intefaces.Services
{
    public interface IFlutterwaveService
    {
        Task<BankResponse> GetBankList();
        Task<List<Banks>> ValidateAccountNumber();
        Task<List<Banks>> BankTransfer();
    }
}
