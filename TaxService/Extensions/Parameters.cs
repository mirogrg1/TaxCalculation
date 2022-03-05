using TaxCalculation.Models;

namespace TaxCalculation.Extensions
{
    public static class Parameters
    {
        public static Dictionary<string, string> CreateParameters(this Location location)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "Country", location.Country}, { "City", location.City}
            };
            return parameters;
        }
    }
}
