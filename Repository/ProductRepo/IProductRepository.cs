using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.ProductRepo
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product CreateProduct(ProductDTOCreate product);
        public Product UpdateProduct(ProductDTOUpdate product);
        public void DeleteProduct(int id);
    }
}
