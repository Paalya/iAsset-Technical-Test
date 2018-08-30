using System.Web.Http;
using Newtonsoft.Json;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Models.DTO;

namespace WeatherApp.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public WeatherDTO WeatherDetails(string city, string country)
        {
            var request = new RequestDTO() { city = city, country = country };
            var response = _weatherService.GetWeatherDetails(request);
            return JsonConvert.DeserializeObject<WeatherDTO>(response);
        }
    }
}
