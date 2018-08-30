using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Controllers;
using WeatherApp.Models;

namespace WeatherApp.Tests.Controllers
{
    [TestClass]
    public class CitiesControllerTests
    {
        [TestMethod]
        public void GetCities()
        {
            //Arrange

            var mockCityService = new Mock<ICityService>();
            var cities = new List<City>();
            cities.Add(new City() { name = "City of Sydney", id = 6619279, country = "AU" });
            mockCityService.Setup(x => x.GetCities("AU")).Returns(cities);

            var controller = new CitiesController(mockCityService.Object);

            //Act
            var result = controller.CityDetails("AU");

            //Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetCitiesForInvalidParameter()
        {
            //Arrange

            var mockCityService = new Mock<ICityService>();
            var cities = new List<City>();
            cities.Add(new City() { name = "City of Sydney", id = 6619279, country = "AU" });
            mockCityService.Setup(x => x.GetCities("AU")).Returns(cities);

            var controller = new CitiesController(mockCityService.Object);

            //Act
            var result = controller.CityDetails("IN");

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCitiesForNullParameter()
        {
            //Arrange

            var mockCityService = new Mock<ICityService>();
            var cities = new List<City>();
            cities.Add(new City() { name = "City of Sydney", id = 6619279, country = "AU" });
            mockCityService.Setup(x => x.GetCities("AU")).Returns(cities);

            var controller = new CitiesController(mockCityService.Object);

            //Act
            var result = controller.CityDetails(null);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCitiesControllerInstallNull()
        {
            //Arrange

            var mockCityService = new Mock<ICityService>();
            var cities = new List<City>();
            cities.Add(new City() { name = "City of Sydney", id = 6619279, country = "AU" });
            mockCityService.Setup(x => x.GetCities("AU")).Returns(cities);
            try
            {
                var controller = new CitiesController(null);

                //Act
                var result = controller.CityDetails("AU");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("System.NullReferenceException", ex.GetType().ToString());
            }
        }
    }
}
