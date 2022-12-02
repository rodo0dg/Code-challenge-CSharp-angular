using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGames.Test
{
    public class ProductControllerIntegrationTests
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceScopeFactory? _scopeFactory;

        public ProductControllerIntegrationTests() 
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder => { });
            _httpClient = appFactory.CreateClient();
            _scopeFactory = appFactory.Services.GetService<IServiceScopeFactory>();
        }

        [Fact]
        public async Task index_correct_returnsListOfProducts() 
        {
            // Arrange


            // Act
            var response = await _httpClient.GetAsync("https://localhost:7268/Product");
            string jsonString = await response.Content.ReadAsStringAsync();
            List<ProductDTO> objects = JsonConvert.DeserializeObject<List<ProductDTO>>(jsonString) ?? new List<ProductDTO>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(objects.Count > 0);
        }

        [Fact]
        public async Task GetProduct_CorrectId_ReturnsProduct()
        {
            // Arrange
            int? id = null;
            using (var scope = _scopeFactory?.CreateScope())
            {
                ApplicationDbContext? context = scope?.ServiceProvider.GetService<ApplicationDbContext>();
                if (context != null)
                    id = context.Products.FirstOrDefault()?.Id;
            }
            string url = $"https://localhost:7268/Product/GetProduct?id={id}";

            // Act
            var response = await _httpClient.GetAsync(url);
            string jsonString = await response.Content.ReadAsStringAsync();
            ProductDTO? productDTO = JsonConvert.DeserializeObject<ProductDTO>(jsonString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, productDTO?.id);
        }

        [Fact]
        public async Task CreateProduct_CorrectParams_ReturnsProduct() 
        {
            // Arrange
            ProductDTOCreate productDTO = new ProductDTOCreate();
            productDTO.name = "Zelda a link to the past";
            productDTO.description = "Videogame for supernintendo zelda a link to the past";
            productDTO.company = "GameStop";
            productDTO.price = 400;
            string url = "https://localhost:7268/Product";
            string jsonString = "";
            // Act
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(productDTO.name), "name");
                content.Add(new StringContent(productDTO.description), "description");
                content.Add(new StringContent(productDTO.company), "company");
                content.Add(new StringContent(productDTO.price.ToString()), "price");

                var response = await _httpClient.PostAsync(url, content);
                jsonString = await response.Content.ReadAsStringAsync();
            }

            ProductDTO? responseDTO = JsonConvert.DeserializeObject<ProductDTO>(jsonString);

            // Assert
            Assert.Equal(productDTO.name, responseDTO?.name);
            Assert.Equal(productDTO.description, responseDTO?.description);
            Assert.Equal(productDTO.price, responseDTO?.price);
            Assert.True(responseDTO?.id > 0);
            Assert.Equal(productDTO.company, responseDTO?.company);
        }
    }
}
