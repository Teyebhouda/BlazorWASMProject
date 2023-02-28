using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using ReportProjectV1.Shared.Models;
using Microsoft.AspNetCore.Components;
using ReportProjectV1.Client.Services;
using ReportProjectV1.Client.ServicesImplementation;
using System;
 



namespace ReportProjectV1.Client.ServicesImplementation
{

    public class AuthService : IAuthService
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
         public IGenericServices<User> UserService;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUri;
        public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();
        public IEnumerable<User> LoggedUser { get; set; } = Enumerable.Empty<User>();
        public AuthService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {

            _configuration = configuration;
            _baseUri = _configuration.GetSection("ApiUrl:Url").Value;
            _httpClientFactory = httpClientFactory;

        }


        public async void login(User user)
        {

            var httpClient = _httpClientFactory.CreateClient(_baseUri);
          Users = await httpClient.GetFromJsonAsync<IEnumerable<User>>($"{_baseUri}/User");
            int LoggedUserID = Users.Where(u => u.Username == user.Username && u.Password == user.Password).Select(u => u.Id)
    .FirstOrDefault(); ;
            if (LoggedUserID !=null)
            {
                var loggeduser = await UserService.GetByIdAsync(LoggedUserID);
              
                    // Store the SessionId cookie in localStorage.
                    await jsRuntime.InvokeVoidAsync("localStorage.setItem", "sessionId", JsonSerializer.Serialize(loggeduser));
                NavigationManager.NavigateTo("/");
            }
            else
            {
                throw new Exception("Invalid username or password");
            }
    }
    public async Task Logout()
        {
            // Supprimez le cookie de session
            await jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "sessionId");
        }

       
    }
}
