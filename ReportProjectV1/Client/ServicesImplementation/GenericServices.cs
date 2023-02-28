using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ReportProjectV1.Client.Services;
using ReportProjectV1.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ReportProjectV1.Client.ServicesImplementation
{
    public class GenericServices<T> : IGenericServices<T> where T : BaseEntity
    {
    
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUri;
        public GenericServices(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _baseUri = _configuration.GetSection("ApiUrl:Url").Value;
            _httpClientFactory = httpClientFactory;
        }
       
      
        //getall methode
        public async Task<IEnumerable<T>> GetAll()
        {
            var httpClient = _httpClientFactory.CreateClient();
            /* // Retrieve the SessionId cookie from localStorage.
             var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");

             // Include the SessionId cookie in the request headers.
             httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);
             */
            return await httpClient.GetFromJsonAsync<IEnumerable<T>>($"{ _baseUri}/{typeof(T).Name}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            /*var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);*/
            var response = await httpClient.GetAsync($"{_baseUri}/{typeof(T).Name}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<T>
                    (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
        //Add Methode
        public async Task<T> CreateAsync(T entity)
        {
            var httpClient = _httpClientFactory.CreateClient(_baseUri);
           /* var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);*/
            var entityJson = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync ($"{_baseUri}/{typeof(T).Name}", entityJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }
        //update methode
        public async Task<bool> UpdateAsync(T entity)
        {
            var httpClient = _httpClientFactory.CreateClient(_baseUri);
           /* var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);*/
            var response = await httpClient.PutAsJsonAsync($"{_baseUri}/{typeof(T).Name}/{entity.Id}", entity);
            return response.IsSuccessStatusCode;
        }
        //delete methode
        public async Task<bool> DeleteAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient(_baseUri);
           /* var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);*/
            var response = await httpClient.DeleteAsync($"{_baseUri}/{typeof(T).Name}/{id}");
            return response.IsSuccessStatusCode;
        }

           
        }
}
