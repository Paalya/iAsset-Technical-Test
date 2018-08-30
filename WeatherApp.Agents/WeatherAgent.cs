using RestSharp;
using WeatherApp.Models.DTO;

namespace WeatherApp.Agents
{
    public class WeatherAgent : IWeatherAgent
    {
        private readonly IRestClient _restClient;
        private readonly IAgentHelper _agentHelper;
        public WeatherAgent(IRestClient restClient, IAgentHelper agentHelper)
        {
            _restClient = restClient;
            _agentHelper = agentHelper;
        }

        /// <summary>
        /// Gets the weather details by calling the openweather API
        /// </summary>
        /// <param name="requestDto">request dto containing city and country properties</param>
        /// <returns>returns a json response </returns>
        public string GetWeatherDetails(RequestDTO requestDto)
        {
            var request = new RestRequest("data/2.5/weather", Method.GET);
            request.AddParameter("q", requestDto.city + "," + requestDto.country);
            request.AddParameter("APPID", "6fbb70f2ca14d81af76ec5320de85b1c");
            request.AddParameter("units", "metric");
            _restClient.BaseUrl = new System.Uri("http://api.openweathermap.org/");

            var response = _agentHelper.SendRequest(request, _restClient);
            return _agentHelper.HandleResponseResult(response);
        }
    }
}
