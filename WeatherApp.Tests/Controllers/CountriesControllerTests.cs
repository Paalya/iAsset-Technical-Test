using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Controllers;
using WeatherApp.Models;

namespace WeatherApp.Tests.Controllers
{
    [TestClass]
    public class CountriesControllerTests
    {

        [TestMethod]
        public void GetCountries()
        {
            //Arrange

            var mockCountryService = new Mock<ICountryService>();
            var countries = new List<Country>();
            countries.Add(new Country() { code = "AU", id = 8, name = "Australia" });
            mockCountryService.Setup(x => x.GetCountries()).Returns(countries);

            var controller = new CountriesController(mockCountryService.Object);

            //Act
            var result = controller.Countries();

            //Assert
            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void GetCountriesResponseValidation()
        {
            //Arrange

            var mockCountryService = new Mock<ICountryService>();
            var countries = new List<Country>();
            countries.Add(new Country() { code = "AU", id = 8, name = "Australia" });
            mockCountryService.Setup(x => x.GetCountries()).Returns(countries);

            var controller = new CountriesController(mockCountryService.Object);

            //Act
            var result = controller.Countries();

            //Assert
            Assert.IsTrue(result[0].name == "Australia");
            Assert.IsTrue(result[0].code == "AU");
            Assert.IsTrue(result[0].id == 8);

        }

    }
}
