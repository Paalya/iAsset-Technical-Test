using RestSharp;

namespace WeatherApp.Agents
{
    public interface IAgentHelper
    {
        IRestResponse SendRequest(IRestRequest request, IRestClient restClient);
        string HandleResponseResult(IRestResponse response);
    }
}
