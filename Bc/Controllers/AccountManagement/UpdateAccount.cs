using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateAccount : ControllerBase
    {
        private readonly ILogger<UpdateAccount> _logger;

        public UpdateAccount(ILogger<UpdateAccount> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(UpdateAccount_input _input)
        {
            return Ok(Helpers.UpdateAccount(_input.UserID, _input.EMail, _input.DisplayUserName));
        }
    }

    public class UpdateAccount_input
    {
        public Int64 UserID { get; set; }
        public string EMail { get; set; }
        public string DisplayUserName { get; set; }
    }
}
