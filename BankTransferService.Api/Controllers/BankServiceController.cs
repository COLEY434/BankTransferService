using BankTransferService.Core.Intefaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTransferService.Api.Controllers
{
    [Route("api/v1/core-banking")]
    [ApiController]
    public class BankServiceController : ControllerBase
    {
        private readonly IBankTransferService _bankTransferService;

        public BankServiceController(IBankTransferService bankTransferService)
        {
            _bankTransferService = bankTransferService;
        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetBanks([FromQuery] string? provider)
        {
            var result = await _bankTransferService.GetBanks(provider);

            if(result.Code != StatusCodes.Status200OK)
            {
                return StatusCode(result.Code, result);
            }

            return Ok(result);
        }
    }

}
