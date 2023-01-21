using BankTransferService.Core.DTOS.Response;
using BankTransferService.Core.Enums;
using BankTransferService.Core.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Core.Services
{
    public class BankTransferServices : IBankTransferService
    {
        private readonly IFlutterwaveService _flutterwaveService;

        public BankTransferServices(IFlutterwaveService flutterwaveService)
        {
            _flutterwaveService = flutterwaveService;
        }

        public async Task<BankResponse> GetBanks(string provider = "")
        {
            BankResponse result = new BankResponse();
            try
            {
                if (!string.IsNullOrEmpty(provider))
                {
                    provider = provider.ToUpper();

                    if (provider == IntegrationProvider.PAYSTACK.ToString())
                    {

                    }
                }
                else
                {
                    result = await _flutterwaveService.GetBankList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
