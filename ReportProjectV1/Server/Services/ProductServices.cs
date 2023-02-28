using ReportProjectV1.Client.Shared;
using ReportProjectV1.Shared.Models;
using System.Net.Http;

namespace ReportProjectV1.Server.Services
{
    public class UserServices : IGenericServices<User>
    {
        private readonly HttpClient _httpClient;

        public UserServices(HttpClient httpClient)
        {
           
            _httpClient = httpClient;
        }



        public async Task<List<User>> getAll (){
            var response = await _httpClient.GetAsync("http://192.168.1.100/User");
        response.EnsureSuccessStatusCode();
        var Users = await response.Content.ReadFromJsonAsync<List<User>>();
        return Users;}

        /*

    public User AddUser(User User)
        {
            

            if (User.IDUser == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                User.IDUser = key;
            }
            items[User.IDUser] = User;
            return User;

        }
        public void DeleteUser(int id) => items.Remove(id);



        public User UpdateUser(User User) => AddUser(User);

         */   
    }
}

