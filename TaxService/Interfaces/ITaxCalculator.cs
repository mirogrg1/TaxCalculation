using TaxCalculation.Models;

namespace TaxCalculation.Interfaces
{
    public interface ITaxCalculator
    {
        Task<Tax> GetTaxesForOder(Order order);
        Task<RateResult> GetRateForLocation(Location location, string zip);
    }
}
