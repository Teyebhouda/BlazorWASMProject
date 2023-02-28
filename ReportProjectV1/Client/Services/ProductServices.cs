using ReportProjectV1.Client.Shared;
using ReportProjectV1.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ReportProjectV1.Client.Services
{
    public class ProductServices : IGenericServices<Product>
    {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
           
            _httpClient = httpClient;
        }


        public IEnumerable<Product> products { get; set; } = Enumerable.Empty<Product>();

        public async Task AddObject(Product obj)
        {
            var response = await _httpClient.PostAsJsonAsync("http://192.168.1.100/Product", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Product>> GetAll (){
            
        var response = await _httpClient.GetAsync("http://192.168.1.100/Product");
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        return products;
        }
        public async Task DeleteObject(Product p)
        {
            await _httpClient.DeleteAsync($"http://192.168.1.100/Product/" + p.IDProduct);
        }

        /*

    public Product AddProduct(Product product)
        {
            

            if (product.IDProduct == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                product.IDProduct = key;
            }
            items[product.IDProduct] = product;
            return product;

        }
        public void DeleteProduct(int id) => items.Remove(id);



        public Product UpdateProduct(Product product) => AddProduct(product);

         */
    }
}

