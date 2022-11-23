using AutoMapper;
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

        public Product UpdateProduct(ProductDTOUpdate product, int id)
        {
            Product product_entity = _db.Products.Where(x => x.Id == id).FirstOrDefault();

            product_entity.Name = product.Name;
            product_entity.Description = product.Description;
            product_entity.Price = product.Price;
            product_entity.AgeRestriction = product.AgeRestriction;
            product_entity.Company = product.Company;

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
    }
}
