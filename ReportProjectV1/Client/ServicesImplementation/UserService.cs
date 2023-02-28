using ReportProjectV1.Client.Services;
using ReportProjectV1.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
namespace ReportProjectV1.Client.ServicesImplementation
{
    public class UserService : GenericServices<User>, IGenericServices<User>
    {
        public UserService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base( configuration,  httpClientFactory)
        {
        }

       
    }
}
