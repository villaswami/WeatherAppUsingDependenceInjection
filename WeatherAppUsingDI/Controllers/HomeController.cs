using Microsoft.AspNetCore.Mvc;
using Model;
using ServiceContracts;

namespace WeatherAppUsingDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        //Create a constructor and inject IWeatherService
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
            [Route("/")]
        public IActionResult Index()
        {
            var city = _weatherService.GetWeatherDetails();
            return View(city);
        }
        [Route("weather/{cityCode?}")]
        public IActionResult City(string cityCode)
        {
            var city = _weatherService.GetWeatherByCityCode(cityCode);
            return View(city);
        }
    }
}
