using Microsoft.AspNetCore.Mvc;
using TwilioSMS.Services;
using TwilioSMS.ViewModels.Dtos;

namespace TwilioSMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SMSController(ISMSService smsService) : ControllerBase
    {
        private readonly ISMSService _smsService= smsService;


        [HttpPost("send")]
        public IActionResult Send(SendSMSDto dto)
        {
            var result = _smsService.Send(dto.MobileNumber, dto.Body);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
    }
}
