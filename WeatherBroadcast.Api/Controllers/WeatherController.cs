

namespace WeatherBroadcast.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDelayReport()
        {
            var serviceResult = await _weatherService.GetWeatherDetail();
            return Ok(serviceResult);
        }
    }
}
