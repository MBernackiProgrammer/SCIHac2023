using Hackathon.dbContext;
using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NextMatch : ControllerBase
    {
        private readonly ILogger<NextMatch> _logger;

        public NextMatch(ILogger<NextMatch> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<Int64> POST_A_CreateAccount(NextMatch_input _input)
        {
            List<NextMachInfo> AnwsersInfo = new List<NextMachInfo>();
            using(var dbContext = new Data_context())
            {
                var allanwsers = dbContext.user_answer.Where(e=>e.user_id.Equals(_input.UserID)).ToList();

                foreach(var anwser in allanwsers)
                {
                    NextMachInfo x = new NextMachInfo();
                    x.AnwserValue = anwser.value;
                    x.AnwserValue = dbContext.questions.Where(e => e.id.Equals(anwser.to_question)).FirstOrDefault().question;
                    AnwsersInfo.Add(x);
                }
            }

            NextMatch_output x2 = new NextMatch_output(); 
            x2.Infos = AnwsersInfo;
            x2.GotPerson = Helpers.NextMatch(_input.UserID);
            return Ok(x2);
        }
    }

    public class NextMatch_output
    {
        
        public Int64 GotPerson { get; set; }
        public Int64 DisplayImageID { get; set; }
        public List<NextMachInfo> Infos { get; set; }

    }

    public class NextMatch_input
    {
        public Int64 UserID { get; set; }

    }

    public class NextMachInfo
    {
        public string QuestionValue { get; set; }
        public string AnwserValue { get; set; }
    }
}
