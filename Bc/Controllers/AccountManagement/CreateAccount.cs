using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateAccount : ControllerBase
    {
        private readonly ILogger<CreateAccount> _logger;

        public CreateAccount(ILogger<CreateAccount> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(CreateAccount_input _input)
        {
            return Ok(Helpers.CreateAccount(_input.Login, _input.Password, _input.EMail, _input.DisplayUserName));
        }
    }

    public class CreateAccount_input
    {
        public string Login { get; set; }
        public string Password { get; set; } 
        public string EMail { get; set; }
        public string DisplayUserName { get; set; }
    }
}
