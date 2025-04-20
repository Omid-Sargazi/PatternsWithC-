using Microsoft.AspNetCore.Mvc;
using SendEmail.Model;
using SendEmail.Services;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService email)
        {
            _emailService = email;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel email)
        {
            if(email == null || string.IsNullOrEmpty(email.To)||string.IsNullOrEmpty(email.Subject)|| string.IsNullOrEmpty(email.Body))
            {
                return BadRequest("لطفاً تمام فیلدها را پر کنید.");
            }
            await _emailService.SendEmailAsync(email);
            return Ok("ایمیل با موفقیت ارسال شد!");
        }
    }
}