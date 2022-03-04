using Newtonsoft.Json;
using TaxCalculation.Const;
using TaxCalculation.Extensions;
using TaxCalculation.Interfaces;
using TaxCalculation.Models;

namespace TaxCalculation.TaxCalculators
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private IHttpService _httpService;
        public TaxJarCalculator(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        public async Task<RateResult> GetRateForLocation(Location location, string zip)
        {          
           var result = await _httpService.GetForAPI(APIs.Rates + zip, ApiKeys.ApiKey, location.CreateParameters());

            return JsonConvert.DeserializeObject<RateResult>(result);
        }

        public async Task<Tax> GetTaxesForOder(Order order)
        {           
           var result = await _httpService.GetForAPI(APIs.Taxes, ApiKeys.ApiKey);

            return JsonConvert.DeserializeObject<Tax>(result);
        }
    }
}
