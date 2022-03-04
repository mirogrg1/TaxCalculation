﻿using TaxCalculation.Models;

namespace TaxCalculation.Interfaces
{
    internal interface ITaxService
    {
        public Task<RateResult> GetTaxRatesForLocation(Location location, string zipCode);
        public Task<Tax> GetTaxesForOrder(Order order);
    }
}