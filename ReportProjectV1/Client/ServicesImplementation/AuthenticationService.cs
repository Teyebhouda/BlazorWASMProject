using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using ReportProjectV1.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ReportProjectV1.Client.ServicesImplementation
{
    public class AuthenticationService
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUri;
      
        public AuthenticationService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _baseUri = _configuration.GetSection("ApiUrl:Url").Value;
            _httpClientFactory = httpClientFactory;
           
        }


      

        // Login. This method is called when the user logs in.
        public async Task Login(string username, string password)
        {
            var httpClient = _httpClientFactory.CreateClient(_baseUri);
         
            // Make a request to the server to authenticate the user.
            var result = await httpClient.PostAsync($"{_baseUri}/user/authenticate", new StringContent(JsonSerializer.Serialize(new { username, password }), Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                // Retrieve the SessionId cookie from the response headers.
                var cookieHeader = result.Headers.GetValues("Set-Cookie").FirstOrDefault();
                var sessionId = cookieHeader?.Split(";")[0];

                // Store the SessionId cookie in localStorage.
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", "sessionId", sessionId);

                // Navigate to the home page
                NavigationManager.NavigateTo("/");
            }
            else
            {
                throw new Exception("Invalid username or password");
            }
        }

        // Get data. This method is called when the user requests data from the REST API.
       
        public async Task GetData()
        {

            var httpClient = _httpClientFactory.CreateClient();
            // Retrieve the SessionId cookie from localStorage.
            var sessionId = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "sessionId");

            // Include the SessionId cookie in the request headers.
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);

            // Make a request to the server to retrieve the user's data.
            var result = await httpClient.GetAsync($"{_baseUri}/User");
            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadFromJsonAsync<User>();

                // Do something with the data.
            }
            else
            {
                throw new Exception("Failed to retrieve data");
            }
        }
        public async Task Logout()
        {
            // remove the token from localStorage
            await jsRuntime.InvokeVoidAsync("localStorage.getItem", "sessionId");
            NavigationManager.NavigateTo("login");
        }
        public async Task request()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"{_baseUri}/User");
        }

    }
}
