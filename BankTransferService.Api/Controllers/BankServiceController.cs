using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTransferService.Api.Controllers
{
    [Route("api/v1/core-banking")]
    [ApiController]
    public class BankServiceController : ControllerBase
    {
        public BankServiceController()
        {

        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetBanks([FromQuery] string provider)
        {
            return Ok();
        }
    }

}
