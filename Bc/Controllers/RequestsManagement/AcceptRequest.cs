using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcceptRequest : ControllerBase
    {
        private readonly ILogger<AcceptRequest> _logger;

        public AcceptRequest(ILogger<AcceptRequest> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(AcceptRequest_input _input)
        {
            return Ok(Helpers.AcceptRequest(_input.RequestID));
        }
    }

    public class AcceptRequest_input
    {
        public Int64 RequestID { get; set; }

    }
}
