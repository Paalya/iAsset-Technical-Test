using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace WeatherApp.Agents.Helper
{
    public class AgentHelper : IAgentHelper
    {
        public IRestResponse SendRequest(IRestRequest request, IRestClient restClient)
        {
            return restClient.Execute(request);
        }

        public string HandleResponseResult(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException("Not Found");
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new System.Exception(response.Content);
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new System.Exception(response.Content);

            }
            if (response.Content.Contains("blocked"))
            {
                throw new UnauthorizedAccessException(response.Content);
            }

            throw new InvalidOperationException(response.Content);
        }
    }
}
