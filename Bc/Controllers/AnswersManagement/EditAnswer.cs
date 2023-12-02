using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditAnswer : ControllerBase
    {
        private readonly ILogger<EditAnswer> _logger;

        public EditAnswer(ILogger<EditAnswer> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(EditAnswer_input _input)
        {
            return Ok(Helpers.EditAnwser(_input.UserID, _input.ToQuestionId, _input.NewValue));
        }
    }

    public class EditAnswer_input
    {
        public Int64 UserID { get; set; }
        public Int64 ToQuestionId { get; set; }
        public string NewValue { get; set; }
    }
}
