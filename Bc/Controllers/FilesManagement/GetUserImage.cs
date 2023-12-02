using Hackathon.Helper.OperationStatus;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace AuthServices.Controllers
{
    [ApiController]
    [Route("/GetUserImage")]
    public class GetUserImage : ControllerBase
    {
        private readonly ILogger<GetUserImage> _logger;

        public GetUserImage(ILogger<GetUserImage> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetUserImage")]
        public IActionResult POST_GetUserImage(GetFileInfo Input)
        {
            byte[] photoBytes = System.IO.File.ReadAllBytes(AuthFilesSaveLocation.SaveFileLocation + Input.FileID);

            return File(photoBytes, "image/png"); // Możesz dostosować typ MIME w zależności od formatu zdjęcia
        }
    }

    public class GetFileInfo
    {
        public Int64 FileID { get; set; }
    }
}