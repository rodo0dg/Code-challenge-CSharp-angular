using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public interface IProductService
    {
        public List<ProductDTO> GetProducts();

        public ProductDTO CreateProduct(ProductDTOCreate product);
        public ProductDTO UpdateProduct(ProductDTOUpdate product, int id);
        public void DeleteProduct(int id);
        public ProductDTO GetProduct(int id);
        public (byte[] file, string fileName, string mimeType) GetPicture(int id);
    }
}
