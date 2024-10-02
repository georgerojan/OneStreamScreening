using Microsoft.AspNetCore.Mvc;

namespace OneStream.Api.BackendTwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwoController : ControllerBase
    {
        private readonly ILogger<TwoController> _logger;

        public TwoController(ILogger<TwoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string verb)
        {
            _logger.Log(LogLevel.Information, $"Api Two Get start method execution - {DateTime.Now}");
            var delayTime = new Random().Next(1, 10) * 1000;
            _logger.Log(LogLevel.Information, $"Api Two delay calculated - {delayTime / 1000} - {DateTime.Now}");
            await Task.Delay(delayTime); // Dynamic delay to mimic long-running operation
            _logger.Log(LogLevel.Information, $"Api Two Get finished method execution - {DateTime.Now}");
            return Ok($"Response from API - {verb} - Two - after {delayTime / 1000} second(s) delay");
        }
    }
}
