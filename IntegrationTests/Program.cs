using TaxCalculation.Const;
using TaxCalculation.Services;
using TaxCalculation.TaxCalculators;

var taxService = new TaxService(new TaxJarCalculator(new HttpService()));
var result = await taxService.GetTaxRatesForLocation(new TaxCalculation.Models.Location
{
    City = Cities.Chicago,
    Country = Countries.USA    
}, "60640");

Console.WriteLine(result.Rate.CombinedRate);

var orderResult = await taxService.GetTaxesForOrder(new TaxCalculation.Models.Order
{
    Amount = 2,
    FromCountry = Countries.USA,
    FromState = "IL",
    FromZip = "60640",
    ToCountry = Countries.USA,
    ToState = "CA",
    Shipping = 2.5M,
    ToZip = "92201",
    LineItems = new List<TaxCalculation.Models.LineItem> { new TaxCalculation.Models.LineItem { ProductTaxCode = "31000", Quantity = 1, UnitPrice = 245 } }
});

Console.WriteLine(orderResult.Result);
Console.ReadLine();