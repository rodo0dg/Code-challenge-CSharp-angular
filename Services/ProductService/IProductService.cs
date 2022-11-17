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
        public ProductDTO UpdateProduct(ProductDTOUpdate product);
        public void DeleteProduct(int id);
    }
}
