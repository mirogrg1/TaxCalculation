﻿namespace TaxCalculation.Interfaces
{
    public interface IHttpService
    {
        public Task<string> GetForAPI(string api, string apiKey, Dictionary<string, string>? parameters = null);
    }
}
