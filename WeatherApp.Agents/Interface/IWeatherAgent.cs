using WeatherApp.Models.DTO;

namespace WeatherApp.Agents
{
    public interface IWeatherAgent
    {
        string GetWeatherDetails(RequestDTO requestDto);
    }
}
