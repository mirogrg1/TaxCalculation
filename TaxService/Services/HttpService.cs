using System.Net.Http.Headers;
using TaxCalculation.Interfaces;

namespace TaxCalculation.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetForAPI(string api, string apiKey, Dictionary<string, string>? parameters = null)
        {
            using HttpClient client = new HttpClient();
            try
            {
                var uri = parameters != null ? "?" + string.Join("&", parameters.Select( p => p.Key + "=" + p.Value)) : string.Empty;
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(HttpMethod.Get.ToString(), $"Token token={apiKey}");   
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception)
            {
                // Do some logging
                throw;
            }
        }

        public async Task<string> PostForAPI(string api, string apiKey, Dictionary<string, string>? parameters = null, string body = "")
        {
            using HttpClient client = new HttpClient();
            try
            {
                var uri = parameters != null ? "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value)) : string.Empty;
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(HttpMethod.Post.ToString(), $"Token token={apiKey}");
                ByteArrayContent? content = null;
                if (!string.IsNullOrWhiteSpace(body))
                {
                    var buffer = System.Text.Encoding.UTF8.GetBytes(body);
                    content = new ByteArrayContent(buffer);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                  
                HttpResponseMessage response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception)
            {
                // Do some logging
                throw;
            }
        }
    }
}
