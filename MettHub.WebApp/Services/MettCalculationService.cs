using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MettHub.WebApp.Services {
    public class MettCalculationService : IMettCalculationService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MettCalculationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<int> CalculateAsync(int people)
        {
            var apiUrl = Environment.GetEnvironmentVariable("API_URL");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(apiUrl);
            var calculationPath = $"/api/mettcalculation?people={people}";

            string result = await client.GetStringAsync(calculationPath);
            return int.Parse(result);
        }
    }
}
