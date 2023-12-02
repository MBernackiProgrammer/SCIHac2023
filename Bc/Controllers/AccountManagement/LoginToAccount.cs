using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginToAccount : ControllerBase
    {
        private readonly ILogger<LoginToAccount> _logger;

        public LoginToAccount(ILogger<LoginToAccount> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<LoginToAccount_Output> POST_LoginToAccount(LoginToAccount_input _input)
        {
            LoginToAccount_Output x = new LoginToAccount_Output();
            x.Id = Helpers.Login(_input.Login, _input.Password);
            return Ok(x);
        }
    }

    public class LoginToAccount_input
    {
        public string Login { get; set; }
        public string Password { get; set; } 
    }

    public class LoginToAccount_Output
    {
        public Int64 Id { get; set; }
    }
}
