using ReportProjectV1.Client.Shared;
using ReportProjectV1.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
namespace ReportProjectV1.Client.Services
{
    public class UserService : IGenericServices<User>
    {
        private readonly HttpClient _httpClient;
     public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();

        public async Task AddObject(User obj)
        {
            var response = await _httpClient.PostAsJsonAsync("http://192.168.1.100/User", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<User>> GetAll()
        {

            var response = await _httpClient.GetAsync("http://192.168.1.100/User");
            response.EnsureSuccessStatusCode();
            var Users = await response.Content.ReadFromJsonAsync<List<User>>();
            return Users;
        }
        public async Task DeleteObject(User u)
        {
            await _httpClient.DeleteAsync($"http://192.168.1.100/User/" + u.IDUser);
        }

    }
}
