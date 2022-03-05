using TaxCalculation.Models;

namespace TaxCalculation.Interfaces
{
    public interface ITaxCalculator
    {
        Task<RateResult> GetRateForLocation(Location location, string zip);
        Task<dynamic> GetTaxesForOder(Order order);
    }
}
