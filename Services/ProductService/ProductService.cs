using AutoMapper;
using Models.DTOs;
using Models.Entities;
using Repository.ProductRepo;

namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public List<ProductDTO> GetProducts()
        {
            return _repository.GetProducts().Select(x => _mapper.Map<ProductDTO>(x)).ToList();
        }

        public ProductDTO CreateProduct(ProductDTOCreate product) 
        {
            Product product_entity = _repository.CreateProduct(product);
            ProductDTO product_dto = new ProductDTO()
            {
                Id = product_entity.Id,
                Name = product_entity.Name,
                Description = product_entity.Description,
                AgeRestriction = product_entity.AgeRestriction,
                Company = product_entity.Company,
                Price = product_entity.Price
            };
            return product_dto;
        }

        public ProductDTO UpdateProduct(ProductDTOUpdate product)
        {
            Product product_entity = _repository.UpdateProduct(product);
            ProductDTO product_dto = new ProductDTO()
            {
                Id = product_entity.Id,
                Name = product_entity.Name,
                Description = product_entity.Description,
                AgeRestriction = product_entity.AgeRestriction,
                Company = product_entity.Company,
                Price = product_entity.Price
            };
            return product_dto;
        }

        public void DeleteProduct(int id) 
        {
            _repository.DeleteProduct(id);
        }
    }
}