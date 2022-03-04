using TaxCalculation.Interfaces;
using TaxCalculation.Models;

namespace TaxCalculation.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxCalculator _taxCalculator;
        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        public async Task<Tax> GetTaxesForOrder(Order order)
        {
            return await _taxCalculator.GetTaxesForOder(order);
        }

        public async Task<RateResult> GetTaxRatesForLocation(Location location, string zipCode)
        {
           return await _taxCalculator.GetRateForLocation(location, zipCode);           
        }      
    }
}