using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendRequest : ControllerBase
    {
        private readonly ILogger<SendRequest> _logger;

        public SendRequest(ILogger<SendRequest> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(SendRequest_input _input)
        {
            return Ok(Helpers.SendRequest(_input.ByUserID, _input.ToUserID));
        }
    }

    public class SendRequest_input
    {
        public Int64 ByUserID { get; set; }
        public Int64 ToUserID { get; set; }

    }
}
