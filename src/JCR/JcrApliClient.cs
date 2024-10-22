using Newtonsoft.Json;
using ScientificReviews.JCR.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.JCR
{
    public class JcrApiClient
    {
        private static readonly Lazy<HttpClient> lazyHttpClient = new Lazy<HttpClient>(() => new HttpClient());
        private static HttpClient HttpClient => lazyHttpClient.Value;

        private readonly string baseUrl = "https://api.clarivate.com/apis/wos-journals/v1";
        private readonly string apiKey;

        private static DateTime lastRequest = DateTime.MinValue;

        public JcrApiClient(string apiKey)
        {            
            this.apiKey = apiKey;
        }


        public async Task<JournalsListDto> GetJournalsAsync(string q)
        {
            var parameters = new Dictionary<string, string>
            {
                { "q", q },
                { "limit", "50" }
            };
            string json = await GetAsync("journals", parameters);
            return JsonConvert.DeserializeObject<JournalsListDto>(json);
        }
        public async Task<JournalReportsDto> GetJournalReportsAsync(string id, int year)
        {
            string json = await GetAsync($"journals/{id}/reports/year/{year}");
            return JsonConvert.DeserializeObject<JournalReportsDto>(json);
        }

        public async Task<string> GetAsync(string route, Dictionary<string, string> parameters = null)
        {
            // At maximum 5 requests per second
            if ((DateTime.UtcNow - lastRequest).TotalMilliseconds < 200)
            {
                await Task.Delay(200); 
            }            
            lastRequest = DateTime.UtcNow;


            var uriBuilder = new UriBuilder($"{baseUrl}/{route}");

            if (parameters != null && parameters.Count > 0)
            {
                using (var query = new FormUrlEncodedContent(parameters))
                {
                    uriBuilder.Query = await query.ReadAsStringAsync();
                }
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri))
            {
                request.Headers.Add("X-ApiKey", apiKey);

                using (var response = await HttpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }            
        }
    }

}
