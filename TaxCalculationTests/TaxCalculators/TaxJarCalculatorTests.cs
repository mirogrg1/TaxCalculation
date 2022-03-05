using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculation.Const;
using TaxCalculation.Extensions;
using TaxCalculation.Interfaces;
using TaxCalculation.Models;

namespace TaxCalculation.TaxCalculators.Tests
{

    [TestClass()]
    public class TaxJarCalculatorTests
    {
        Mock<IHttpService> _httpService = new Mock<IHttpService>();

        [TestMethod()]
        public async Task GetRateForLocationTest()
        {
            _httpService.Setup(h => h.GetForAPI(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).
           Returns(Task.FromResult("Rate"));

            var zipCode = "60640";
            var location = new Location
            {
                City = "Chicago",
                Country = "US"
            };
            var result = await _httpService.Object.GetForAPI(APIs.Rates + zipCode, ApiKeys.ApiKey, location.CreateParameters());
            Assert.AreEqual(result, "Rate");
        }

        [TestMethod()]
        public async Task GetTaxesForOderTest()
        {
            _httpService.Setup(h => h.PostForAPI(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<string>())).
           Returns(Task.FromResult("Tax"));

            var order = new Order
            {
                Amount = 2,
                FromCountry = Countries.USA,
                FromState = "IL",
                FromZip = "60640",
                ToCountry = Countries.USA,
                ToState = "CA",
                Shipping = 2.5M,
                ToZip = "92201",
                LineItems = new List<LineItem> { new LineItem { ProductTaxCode = "31000", Quantity = 1, UnitPrice = 245 } }
            };
            var result = await _httpService.Object.PostForAPI(APIs.Taxes, ApiKeys.ApiKey, body: JsonConvert.SerializeObject(order));
            Assert.AreEqual(result, "Tax");
        }
    }
}