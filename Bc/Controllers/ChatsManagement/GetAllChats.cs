using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllChats : ControllerBase
    {
        private readonly ILogger<GetAllChats> _logger;

        public GetAllChats(ILogger<GetAllChats> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(GetAllChats_input _input)
        {
            return Ok(Helpers.GetAllChats(_input.UserID));
        }
    }

    public class GetAllChats_input
    {
        public Int64 UserID { get; set; }

    }
}
