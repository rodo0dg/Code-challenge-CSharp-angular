using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Moq;
using Repository.ProductRepo;
using Services.ProductService;
using System.Net;
using ToysAndGames.Controllers;

namespace ToysAndGames.Test
{
    public class ProductControllerTests
    {
        private readonly ProductController _productController;
        private readonly Mock<IProductService> _productService;

        public ProductControllerTests()
        {
            _productService = new Mock<IProductService>();
            _productController = new ProductController(_productService.Object);
        }

        [Fact]
        public void Index_GivenGetAll_ReturnAll() 
        {
            // Arrange
            List<ProductDTO> products = new List<ProductDTO>()
            {
                new ProductDTO(){ Id = 1, Name = "Puzzle sky at night", Description = "Puzzle 500 pz van gogh", Company = "Jugetelandia", AgeRestriction = 12, Price = 357 },
                new ProductDTO(){ Id = 2, Name = "Catan", Description = "Boardgame Catan", Company = "RavenFolk", AgeRestriction = 12, Price = 600 }
            };
            
            _productService.Setup(x=>x.GetProducts()).Returns(products);
            
            // Action
            ObjectResult? result = _productController.Index() as ObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal(((List<ProductDTO>)result.Value).Count, products.Count);
        }

        [Fact]
        public void Create_GivenCorrectParams_ReturnOK()
        {
            // Arrange
            ProductDTOCreate product = new ProductDTOCreate();
            product.Name = "Auto lavado";
            product.Description = "Pista HotWheels auto lavado";
            product.Company = "Juguetelandia";
            product.AgeRestriction = 8;
            product.Price = 600;

            ProductDTO productReturned = new ProductDTO();
            productReturned.Id = 1;
            productReturned.Name = product.Name;
            productReturned.Description = product.Description;
            productReturned.Company = product.Company;
            productReturned.AgeRestriction = product.AgeRestriction;
            productReturned.Price = product.Price;

            _productService.Setup(x => x.CreateProduct(product)).Returns(productReturned);
            
            // Action
            ObjectResult? result = _productController.Create(product) as ObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal(((ProductDTO)result.Value).Name, product.Name);
            Assert.Equal(((ProductDTO)result.Value).Description, product.Description);
            Assert.Equal(((ProductDTO)result.Value).Company, product.Company);
            Assert.Equal(((ProductDTO)result.Value).AgeRestriction, product.AgeRestriction);
            Assert.Equal(((ProductDTO)result.Value).Price, product.Price);
        }

        [Fact]
        public void Update_GivenCorrectParams_ReturnsOK() 
        {
            // Arrange
            ProductDTOUpdate product = new ProductDTOUpdate();
            product.name = "Auto lavado";
            product.description = "Pista HotWheels auto lavado";
            product.company = "Juguetelandia";
            product.agerestriction = 8;
            product.price = 600;

            ProductDTO productReturned = new ProductDTO();
            productReturned.Id = 1;
            productReturned.Name = "Auto lavado";
            productReturned.Description = "Pista HotWheels auto lavado";
            productReturned.Company = "Juguetelandia";
            productReturned.AgeRestriction = 8;
            productReturned.Price = 600;

            _productService.Setup(x => x.UpdateProduct(product)).Returns(productReturned);

            // Action
            ObjectResult? result = _productController.Update(product) as ObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal(product.name, ((ProductDTO)result.Value).Name);
            Assert.Equal(product.description, ((ProductDTO)result.Value).Description);
            Assert.Equal(product.company, ((ProductDTO)result.Value).Company);
            Assert.Equal(product.agerestriction, ((ProductDTO)result.Value).AgeRestriction);
            Assert.Equal(product.price, ((ProductDTO)result.Value).Price);
        }

        [Fact]
        public void Delete_GivenCorrectParams_ReturnsSucessfullyMessage() 
        {
            // Arrange
            int id = 1;

            // Action
            ObjectResult? result = _productController.Delete(id) as ObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal("Product id 1 successfully deleted", result?.Value);
            
        }
    }
}