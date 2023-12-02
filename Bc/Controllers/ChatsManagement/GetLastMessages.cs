using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLastMessages : ControllerBase
    {
        private readonly ILogger<GetLastMessages> _logger;

        public GetLastMessages(ILogger<GetLastMessages> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(GetLastMessages_input _input)
        {
            return Ok(Helpers.GetLastMesseges(_input.ChatID));
        }
    }

    public class GetLastMessages_input
    {
        public Int64 ChatID { get; set; }

    }
}
