using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteRequest : ControllerBase
    {
        private readonly ILogger<DeleteRequest> _logger;

        public DeleteRequest(ILogger<DeleteRequest> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(DeleteRequest_input _input)
        {
            return Ok(Helpers.DeleteRequest(_input.RequestID));
        }
    }

    public class DeleteRequest_input
    {
        public Int64 RequestID { get; set; }

    }
}
