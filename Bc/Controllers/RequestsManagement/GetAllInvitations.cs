using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllInvitations : ControllerBase
    {
        private readonly ILogger<GetAllInvitations> _logger;

        public GetAllInvitations(ILogger<GetAllInvitations> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(GetAllInvitations_input _input)
        {
            return Ok(Helpers.GetAllInvitations(_input.UserID));
        }
    }

    public class GetAllInvitations_input
    {
        public Int64 UserID { get; set; }

    }
}
