using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLands.Models;

namespace SmartLands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogServices()
        {
            List<LandLog> logs = new List<LandLog>();
            FirebaseUtil firebaseUtil = new FirebaseUtil();
            logs = firebaseUtil.GetLogs();

            return Ok(logs);
        }
    }
}
