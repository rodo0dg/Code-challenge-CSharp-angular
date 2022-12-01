using Microsoft.AspNetCore.Http;
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
        public Product UpdateProduct(ProductDTOUpdate product, int id);
        public void DeleteProduct(int id);
        public Product GetProduct(int id);
        public (string path, string mime) SavePicture(IFormFile? image, int id);
        public (byte[] file, string fileName, string mimeType) GetPicture(int id);
    }
}
