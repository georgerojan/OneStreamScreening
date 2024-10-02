using Microsoft.AspNetCore.Mvc;

namespace OneStream.Api.BackendThree.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreeController : ControllerBase
    {
        private readonly ILogger<ThreeController> _logger;

        public ThreeController(ILogger<ThreeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string verb)
        {

            _logger.Log(LogLevel.Information, $"Api Three Get start method execution - {DateTime.Now}");
            var delayTime = new Random().Next(1, 10) * 1000;
            _logger.Log(LogLevel.Information, $"Api Three delay calculated - {delayTime / 1000} - {DateTime.Now}");
            await Task.Delay(delayTime); // Dynamic delay to mimic long-running operation
            _logger.Log(LogLevel.Information, $"Api Three Get finished method execution - {DateTime.Now}");
            return Ok($"Response from API - {verb} - Three - after {delayTime / 1000} second(s) delay");
        }
    }
}
