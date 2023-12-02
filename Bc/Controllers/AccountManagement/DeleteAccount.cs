using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteAccount : ControllerBase
    {
        private readonly ILogger<DeleteAccount> _logger;

        public DeleteAccount(ILogger<DeleteAccount> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(DeleteAccount_input _input)
        {
            return Ok(Helpers.DeleteAccount(_input.UserID));
        }
    }

    public class DeleteAccount_input
    {
        public Int64 UserID { get; set; }

    }
}
