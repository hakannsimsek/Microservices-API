using FirstService.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FirstService.SyncDataServices.Http
{
    public class HttpSecondDataClient : ISecondDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpSecondDataClient(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendFirstToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                 JsonSerializer.Serialize(platform),
                 Encoding.UTF8,
                 "application/json" );

            var response = await _httpClient.PostAsync($"{_configuration["SecondService"]}", httpContent);
            
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("-- Sync POST to second service Ok --");
            }
            else
            {
                Console.WriteLine("-- Sync POST to second service Fail --");
            }
        }
    }
}
