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
                new ProductDTO(){ id = 1, name = "Puzzle sky at night", description = "Puzzle 500 pz van gogh", company = "Jugetelandia", ageRestriction = 12, price = 357 },
                new ProductDTO(){ id = 2, name = "Catan", description = "Boardgame Catan", company = "RavenFolk", ageRestriction = 12, price = 600 }
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
            product.name = "Auto lavado";
            product.description = "Pista HotWheels auto lavado";
            product.company = "Juguetelandia";
            product.ageRestriction = 8;
            product.price = 600;

            ProductDTO productReturned = new ProductDTO();
            productReturned.id = 1;
            productReturned.name = product.name;
            productReturned.description = product.description;
            productReturned.company = product.company;
            productReturned.ageRestriction = product.ageRestriction;
            productReturned.price = product.price;

            _productService.Setup(x => x.CreateProduct(product)).Returns(productReturned);
            
            // Action
            ObjectResult? result = _productController.Create(product) as ObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal(((ProductDTO)result.Value).name, product.name);
            Assert.Equal(((ProductDTO)result.Value).description, product.description);
            Assert.Equal(((ProductDTO)result.Value).company, product.company);
            Assert.Equal(((ProductDTO)result.Value).ageRestriction, product.ageRestriction);
            Assert.Equal(((ProductDTO)result.Value).price, product.price);
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
            productReturned.id = 1;
            productReturned.name = "Auto lavado";
            productReturned.description = "Pista HotWheels auto lavado";
            productReturned.company = "Juguetelandia";
            productReturned.ageRestriction = 8;
            productReturned.price = 600;

            _productService.Setup(x => x.UpdateProduct(product, 1)).Returns(productReturned);

            // Action
            ObjectResult? result = _productController.Update(1, product) as ObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
            Assert.Equal(product.name, ((ProductDTO)result.Value).name);
            Assert.Equal(product.description, ((ProductDTO)result.Value).description);
            Assert.Equal(product.company, ((ProductDTO)result.Value).company);
            Assert.Equal(product.agerestriction, ((ProductDTO)result.Value).ageRestriction);
            Assert.Equal(product.price, ((ProductDTO)result.Value).price);
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