﻿using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Service.IEmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("Email"),Authorize(Roles = "Admin")]
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
            try
            {
                emailService.SendEmail(request);
                return Ok("Emailküldés sikeresen megtörtént");
            }
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }
            
        }
    }
}
