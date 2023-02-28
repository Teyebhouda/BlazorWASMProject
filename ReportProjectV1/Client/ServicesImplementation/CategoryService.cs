using ReportProjectV1.Client.Services;
using ReportProjectV1.Shared.Models;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReportProjectV1.Client.ServicesImplementation
{
    public class CategoryService : GenericServices<Category>, IGenericServices<Category>
    {
        public CategoryService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base(configuration, httpClientFactory)
        {
        }


    }
}

