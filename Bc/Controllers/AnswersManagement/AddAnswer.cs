using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddAnswer : ControllerBase
    {
        private readonly ILogger<AddAnswer> _logger;

        public AddAnswer(ILogger<AddAnswer> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<OperationStatusx> POST_A_CreateAccount(AddAnswer_input _input)
        {
            return Ok(Helpers.AddAnwser(_input.ToUserID, _input.QuestionId, _input.value));
        }
    }

    public class AddAnswer_input
    {
        public Int64 ToUserID { get; set; }
        public Int64 QuestionId { get; set; }
        public string value { get; set; }
    }
}
