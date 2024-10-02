using Microsoft.AspNetCore.Mvc;

namespace OneStream.Api.FrontendOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public OneController(IHttpClientFactory httpClientFactory, ILogger<OneController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("get-async")]
        public async Task<IActionResult> GetAsyncData()
        {
            var client = _httpClientFactory.CreateClient();

            var apiBackendTwo = client.GetStringAsync("https://localhost:7002/api/Two?verb=Get");
            var apiBackendThree = client.GetStringAsync("https://localhost:7023/api/Three?verb=Get");

            await Task.WhenAll(apiBackendTwo, apiBackendThree);

            var returnValue = new
            {
                APITwoResponse = await apiBackendTwo,
                APIThreeResponse = await apiBackendThree
            };

            return Ok(returnValue);
        }

        [HttpPost("post-async")]
        public async Task<IActionResult> PostAsyncData()
        {
            var client = _httpClientFactory.CreateClient();

            var apiBackendTwo = client.GetStringAsync("https://localhost:7002/api/Two?verb=Post");
            var apiBackendThree = client.GetStringAsync("https://localhost:7023/api/Three?verb=Post");

            await Task.WhenAll(apiBackendTwo, apiBackendThree);

            var returnValue = new
            {
                APITwoResponse = await apiBackendTwo,
                APIThreeResponse = await apiBackendThree
            };

            return Ok(returnValue);
        }
    }
}
