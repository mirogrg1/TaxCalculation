using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculation.Const;
using TaxCalculation.Interfaces;
using TaxCalculation.Models;

namespace TaxCalculation.Services.Tests
{
    [TestClass()]
    public class TaxServiceTests
    {
        Mock<ITaxService> _taxServiceMock = new Mock<ITaxService>();

        [TestMethod()]
        public async Task GetTaxesForOrderTest()
        {
            _taxServiceMock.Setup(t => t.GetTaxesForOrder(It.IsAny<Order>())).Returns(Task.FromResult(new TaxForOrderResult {  Result = "0.05", Success = true }));
            var result = await _taxServiceMock.Object.GetTaxesForOrder(new Order
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
            });
            Assert.AreEqual(result.Result, "0.05");
        }

        [TestMethod()]
        public async Task GetTaxRatesForLocationTest()
        {
            _taxServiceMock.Setup(t => t.GetTaxRatesForLocation(It.IsAny<Location>(), It.IsAny<string>())).Returns(Task.FromResult(new RateResult { Result = "1.23", Success = true }));
            var result = await _taxServiceMock.Object.GetTaxRatesForLocation(new Location { City = "Chicago", Country = "US" }, "60640");
            Assert.AreEqual(result.Result, "1.23");
        }
    }
}