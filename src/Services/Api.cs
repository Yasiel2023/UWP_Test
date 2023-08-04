using Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services
{
    public static class Api
    {
        public static async Task<List<ProductDto>> GetProductsAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fakestoreapi.com/products");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Deserializa el JSON a la clase ProductDto
            List<ProductDto> products = JsonConvert.DeserializeObject<List<ProductDto>>(responseBody);
            return products;
        }
    }
}
