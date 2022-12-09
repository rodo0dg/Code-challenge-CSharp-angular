using AutoMapper;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.Entities;
using Moq;
using Repository.ProductRepo;
using Services.ProductService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToysAndGames.Test
{
    public class ProductServicesTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _productRepository;

        public ProductServicesTests() 
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DbProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object, mapper);
        }

        [Fact]
        public void CreateProduct_GivenCorrectParams_ReturnCorrectDTO()
        {
            // Arrange
            string name = "Killer instinct";
            string description = "Videogame killer instinct for super nintendo";
            int ageRestriction = 12;
            string company = "Game stop";
            decimal price = 400;
            string imageMimeType = "image/jpg";
            string imagePath = "c:/images/1/1.jpg";
            int id = 1;

            var fileMock = new Mock<IFormFile>();
            ProductDTOCreate dto = new ProductDTOCreate()
            {
                name = name,
                ageRestriction = ageRestriction,
                company = company,
                description = description,
                price = price,
                image = fileMock.Object
            };

            Product productReturned = new Product();
            productReturned.Name = name;
            productReturned.Description = description;
            productReturned.AgeRestriction = ageRestriction;
            productReturned.Company = company;
            productReturned.Price = price;
            productReturned.imageMimeType = imageMimeType;
            productReturned.imagePath = imagePath;
            

            _productRepository.Setup(_ => _.CreateProduct(dto)).Returns(new Product() { 
                Id=id,
                Name=name, 
                Description=description, 
                AgeRestriction=ageRestriction, 
                Company=company, 
                Price=price});
            _productRepository.Setup(_ => _.SavePicture(fileMock.Object, id)).Returns(("c:/images/1/1.jpg", "image/jpg"));
            _productRepository.Setup(_ => _.UpdateProduct(It.IsAny<ProductDTOUpdate>(), It.IsAny<int>())).Returns(productReturned);

            // Action
            ProductDTO responseDto = _productService.CreateProduct(dto);

            // Assert
            Assert.Equal(name, responseDto.name);
            Assert.Equal(description, responseDto.description);
            Assert.Equal(ageRestriction, responseDto.ageRestriction);
            Assert.Equal(company, responseDto.company);
            Assert.Equal(price, responseDto.price);
        }

        [Fact]
        public void UpdateProduct_GivenCorrectParams_ReturnCorrectDTO()
        {
            // Arrange
            string name = "Killer instinct";
            string description = "Videogame killer instinct for super nintendo";
            int ageRestriction = 12;
            string company = "Game stop";
            decimal price = 400;
            string imageMimeType = "image/jpg";
            string imagePath = "c:/images/1/1.jpg";
            int id = 1;

            var fileMock = new Mock<IFormFile>();
            ProductDTOUpdate dto = new ProductDTOUpdate()
            {
                name = name,
                agerestriction = ageRestriction,
                company = company,
                description = description,
                price = price,
                image = fileMock.Object
            };

            Product productReturned = new Product();
            productReturned.Name = name;
            productReturned.Description = description;
            productReturned.AgeRestriction = ageRestriction;
            productReturned.Company = company;
            productReturned.Price = price;
            productReturned.imageMimeType = imageMimeType;
            productReturned.imagePath = imagePath;


            _productRepository.Setup(_ => _.UpdateProduct(dto, id)).Returns(new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                AgeRestriction = ageRestriction,
                Company = company,
                Price = price
            });
            _productRepository.Setup(_ => _.SavePicture(fileMock.Object, id)).Returns(("c:/images/1/1.jpg", "image/jpg"));
            _productRepository.Setup(_ => _.UpdateProduct(It.IsAny<ProductDTOUpdate>(), It.IsAny<int>())).Returns(productReturned);

            // Action
            ProductDTO responseDto = _productService.UpdateProduct(dto, id);

            // Assert
            Assert.Equal(name, responseDto.name);
            Assert.Equal(description, responseDto.description);
            Assert.Equal(ageRestriction, responseDto.ageRestriction);
            Assert.Equal(company, responseDto.company);
            Assert.Equal(price, responseDto.price);
        }

        [Fact]
        public void UpdateProduct_GivenCorrectParamsNoImage_ReturnCorrectDTO()
        {
            // Arrange
            string name = "Killer instinct";
            string description = "Videogame killer instinct for super nintendo";
            int ageRestriction = 12;
            string company = "Game stop";
            decimal price = 400;
            int id = 1;

            var fileMock = new Mock<IFormFile>();
            ProductDTOUpdate dto = new ProductDTOUpdate()
            {
                name = name,
                agerestriction = ageRestriction,
                company = company,
                description = description,
                price = price,
            };

            Product productReturned = new Product();
            productReturned.Name = name;
            productReturned.Description = description;
            productReturned.AgeRestriction = ageRestriction;
            productReturned.Company = company;
            productReturned.Price = price;

            _productRepository.Setup(_ => _.UpdateProduct(dto, id)).Returns(new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                AgeRestriction = ageRestriction,
                Company = company,
                Price = price
            });
            _productRepository.Setup(_ => _.SavePicture(fileMock.Object, id)).Returns(("c:/images/1/1.jpg", "image/jpg"));
            _productRepository.Setup(_ => _.UpdateProduct(It.IsAny<ProductDTOUpdate>(), It.IsAny<int>())).Returns(productReturned);

            // Action
            ProductDTO responseDto = _productService.UpdateProduct(dto, id);

            // Assert
            Assert.Equal(name, responseDto.name);
            Assert.Equal(description, responseDto.description);
            Assert.Equal(ageRestriction, responseDto.ageRestriction);
            Assert.Equal(company, responseDto.company);
            Assert.Equal(price, responseDto.price);
        }
    }
}
