using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Service.IEmailServices;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("Email")]
    public class EmailController : ControllerBase
    {
        public readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            emailService.SendEmail(request);
            return Ok("Emailküldés sikeresen megtörtént");
        }
    }
}
