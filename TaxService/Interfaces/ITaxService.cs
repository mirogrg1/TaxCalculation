using TaxCalculation.Models;

namespace TaxCalculation.Interfaces
{
    public interface ITaxService
    {
        Task<TaxForOrderResult> GetTaxesForOrder(Order order);
        Task<RateResult> GetTaxRatesForLocation(Location location, string zipCode);
    }
}
