using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteAnswer : ControllerBase
    {
        private readonly ILogger<DeleteAnswer> _logger;

        public DeleteAnswer(ILogger<DeleteAnswer> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(DeleteAnswer_input _input)
        {
            return Ok(Helpers.DeleteAnwser(_input.UserID, _input.ToQuestionId));
        }
    }

    public class DeleteAnswer_input
    {
        public Int64 UserID { get; set; }
        public Int64 ToQuestionId { get; set; }
    }
}
