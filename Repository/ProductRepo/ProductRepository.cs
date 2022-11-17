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
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Product> GetProducts()
        {
            var products = _db.Products.ToList();
            return products;
        }

        public Product CreateProduct(ProductDTOCreate product)
        {
            Product product_entity = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Company = product.Company,
                AgeRestriction = product.AgeRestriction,
                Price = product.Price
            };

            _db.Products.Add(product_entity);
            _db.SaveChanges();

            return product_entity;
        }

        public Product UpdateProduct(ProductDTOUpdate product)
        {
            Product product_entity = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Company = product.Company,
                AgeRestriction = product.AgeRestriction,
                Price = product.Price
            };
            _db.Products.Update(product_entity);
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
    }
}
