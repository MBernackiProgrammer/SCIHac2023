using Hackathon.Helper.OperationStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("/uploadfile")]
    public class C_UploadFile : ControllerBase
    {
        private readonly ILogger<C_UploadFile> _logger;

        public C_UploadFile(ILogger<C_UploadFile> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "C_UploadFile")]
        [RequestSizeLimit(100_000_000)]
        public async Task<ActionResult<OperationStatusx>> UploadFile(IFormFile file, [FromForm] string userid, [FromForm] string userPath, [FromForm] string packetToken)
        {
            using (var dbContext = new dbContext.Data_context())
            {

            }

            Console.Write(file.FileName);
            var filePath = AuthFilesSaveLocation.SaveFileLocation + ""; // Path.Combine(, "uploads", );

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }

            //Helper.SetRightsInFile(GeneratedToken, userToken, EUserRightsInFile.Creator);


            return Ok(new OperationStatusx(EReturnedInfo.Success));
        }
    }
}

