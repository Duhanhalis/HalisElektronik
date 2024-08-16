using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class GenericApiRepository<T> : ApiIRepository<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GenericApiRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    private string _Url { get { return "ApiSettings:BaseApi"; } }
    public async Task<T> GetItemByIdAsync(string ApiAction, int id)
    {
        string Url = _configuration[_Url]!;
        var response = await _httpClient.GetAsync($"{Url}/{ApiAction}/{id}");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
        return JsonSerializer.Deserialize<T>(responseString, options);
    }

    public async Task<IEnumerable<T>> GetAllItemsAsync(string ApiAction)
    {
        string Url = _configuration[_Url]!;
        var response = await _httpClient.GetAsync($"{Url}/{ApiAction}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            // 404 ise boş bir liste döndür
            return Enumerable.Empty<T>();
        }
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
        var items = JsonSerializer.Deserialize<IEnumerable<T>>(responseString, options);

        return items ?? Enumerable.Empty<T>();
    }
    public async Task<bool> AddItemAsync(string ApiAction, T item)
    {
        string Url = _configuration[_Url]!;
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{Url}/{ApiAction}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateItemAsync(string ApiAction, T item)
    {
        string Url = _configuration[_Url]!;
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{Url}/{ApiAction}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteItemAsync(string ApiAction, int id)
    {
        string Url = _configuration[_Url]!;
        var response = await _httpClient.DeleteAsync($"{Url}/{ApiAction}/{id}");
        return response.IsSuccessStatusCode;
    }
    
    public async Task<IEnumerable<T>> GetListById(string ApiAction, int id)
    {
        string Url = _configuration[_Url];
        var response = await _httpClient.GetAsync($"{Url}/{ApiAction}/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            // 404 ise boş bir liste döndür
            return Enumerable.Empty<T>();
        }
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
        var items = JsonSerializer.Deserialize<IEnumerable<T>>(responseString, options);

        return items ?? Enumerable.Empty<T>();

    }
}