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
Console.ReadLine();