using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HalisElektronik.Repositories.Implementation.Mvc.Inteface;

namespace HalisElektronik.Repositories.Implementation.Mvc.Generic
{
    public class ImageApiRepository<T> : ImageApiInterface<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ImageApiRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        private string _Url { get { return "ApiSettings:BaseApi"; } }

        public async Task<T> AddImageClassAsync(string ApiAction, T item)
        {
            string Url = _configuration[_Url]!;
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{Url}/{ApiAction}", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };
            var items = JsonSerializer.Deserialize<T>(responseString, options);

            return items ?? null;
        }

        public async Task<string> AddImageAsync(string ApiAction, IFormFile item, string? name)
        {
            string Url = _configuration[_Url]!;
            using (var client = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                using (var stream = item.OpenReadStream())
                {
                    formData.Add(new StreamContent(stream), "model", item.FileName);
                    var response = await client.PostAsync($"{Url}/{ApiAction}?name={name}", formData);
                    if (!response.IsSuccessStatusCode)
                    {
                        return response.StatusCode.ToString();
                    }

                    return await response.Content.ReadAsStringAsync();

                }
            }
        }
        public async Task<bool> DeleteImageAsync(string ApiAction, int id)
        {
            string Url = _configuration[_Url]!;
            var response = await _httpClient.DeleteAsync($"{Url}/{ApiAction}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
