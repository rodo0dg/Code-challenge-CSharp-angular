using AutoMapper;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _db;
        IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<Product> GetProducts()
        {
            var products = _db.Products.ToList();
            return products;
        }

        public Product CreateProduct(ProductDTOCreate product)
        {
            Product product_entity = _mapper.Map<Product>(product);

            _db.Products.Add(product_entity);
            _db.SaveChanges();

            return product_entity;
        }

        public Product UpdateProduct(ProductDTOUpdate product, int id)
        {
            Product product_entity = _db.Products.Where(x => x.Id == id).First();
            _mapper.Map<ProductDTOUpdate, Product>(product,product_entity);
            
            _db.SaveChanges();
            return product_entity;
        }

        public void DeleteProduct(int id) 
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product is not null)
            {
                _db.Remove(product);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception($"No product found with id {id}");
            }
        }

        public Product? GetProduct(int id)
        {
            return _db.Products.FirstOrDefault(x => x.Id == id);
        }

        public (string? path, string? mime) SavePicture(IFormFile? file, int id)
        {
            string imgsDirectory = $"{Directory.GetCurrentDirectory()}\\images\\{id}";
            string fileName = id.ToString();

            string extension = "";

            if (file?.ContentType == @"image/jpeg")
                extension = ".jpg";
            else if (file?.ContentType == @"image/png")
                extension = ".png";

            string filePath = $"{imgsDirectory}\\{fileName}{extension}";

            if(Directory.Exists(imgsDirectory))
                Directory.Delete(imgsDirectory, true);

            Directory.CreateDirectory(imgsDirectory);

            if (!Directory.Exists(imgsDirectory))
                return (null,null);

            using(Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return (filePath, file.ContentType);
        }

        public (byte[] file, string fileName, string mimeType) GetPicture(int id)
        {
            var product = _db.Products.Find(id);
            string filePath = product?.imagePath ?? "";
            string fileName = filePath.Split("\\")[^1];

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return (file: ms.ToArray(), fileName: fileName, mimeType: product?.imageMimeType ?? "");
                }
            }
        }
    }
}
