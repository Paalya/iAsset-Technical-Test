using WeatherApp.Models.DTO;

namespace WeatherApp.BusinessLogic.Interface
{
    public interface IWeatherService
    {
        string GetWeatherDetails(RequestDTO request);
    }
}
