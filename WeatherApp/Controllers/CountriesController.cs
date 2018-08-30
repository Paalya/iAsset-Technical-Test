using System;
using System.Collections.Generic;
using System.Web.Http;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountryService _countryService;  

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public List<Country> Countries()
        {
            try
            {
                var response = _countryService.GetCountries();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
