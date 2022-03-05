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

        public async Task<TaxForOrderResult> GetTaxesForOrder(Order order)
        {
            try
            {
                var taxesForOrder = await _taxCalculator.GetTaxesForOder(order);
                if (taxesForOrder != null)
                {
                    return new TaxForOrderResult
                    {
                        Success = true,
                        Result = taxesForOrder.tax?.amount_to_collect?.ToString()
                    };
                }
                else
                    return new TaxForOrderResult { Success = false, Message = "Tax for this order could not be found" };
            }
            catch (Exception ex)
            {
                return new TaxForOrderResult
                {
                    Success = false,
                    Error = ex.ToString(),
                    Message = ex.Message
                };
            }           
        }

        public async Task<RateResult> GetTaxRatesForLocation(Location location, string zipCode)
        {
            try
            {
                var rateForLocation = await _taxCalculator.GetRateForLocation(location, zipCode);
                if (rateForLocation != null)
                {
                    return new RateResult
                    {
                        Success = true,
                        Rate = rateForLocation.Rate
                    };
                }
                else
                    return new RateResult { Success = false, Message = "Rate could be not found" };
            }
            catch (Exception ex)
            {
                return new RateResult
                {
                    Success = false,
                    Error = ex.ToString(),
                    Message = ex.Message
                };
            }
        }      
    }
}