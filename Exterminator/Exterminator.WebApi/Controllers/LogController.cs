using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers
{
    [Route("api/logs")]
    public class LogController : Controller
    {
        private ILogService _logService;

        public LogController (ILogService serv) {
            _logService = serv;
        }
        
        [HttpGet("")]
        public IActionResult GetAllLogs() {
            return Ok(_logService.GetAllLogs());
        }
    }
}