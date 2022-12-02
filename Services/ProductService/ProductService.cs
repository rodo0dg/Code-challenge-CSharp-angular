using AutoMapper;
using Microsoft.AspNetCore.Http;
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
            Product product_saved = _repository.CreateProduct(product);
            (string? path, string? mime) path_mime = (null, null);

            if (product.image != null)
            {
                path_mime = _repository.SavePicture(product.image, product_saved.Id);
            }
            
            ProductDTOUpdate product_updt_dto = _mapper.Map<ProductDTOUpdate>(product_saved);

            product_updt_dto.imagePath = path_mime.path;
            product_updt_dto.imageMimeType = path_mime.mime;
            
            Product product_entity = _repository.UpdateProduct(product_updt_dto, product_saved.Id);
            
            ProductDTO product_dto = new ProductDTO()
            {
                id = product_entity.Id,
                name = product_entity.Name,
                description = product_entity.Description,
                ageRestriction = product_entity.AgeRestriction,
                company = product_entity.Company,
                price = product_entity.Price
            };
            return product_dto;
        }

        public ProductDTO UpdateProduct(ProductDTOUpdate product, int id)
        {
            Product product_entity = _repository.UpdateProduct(product, id);

            (string path, string mime) = _repository.SavePicture(product.image, product_entity.Id);
            ProductDTOUpdate dtoUpdate = _mapper.Map<ProductDTOUpdate>(product_entity);
            dtoUpdate.imagePath = path;
            dtoUpdate.imageMimeType = mime;

            product_entity = _repository.UpdateProduct(dtoUpdate, id);

            ProductDTO product_dto = new ProductDTO()
            {
                id = product_entity.Id,
                name = product_entity.Name,
                description = product_entity.Description,
                ageRestriction = product_entity.AgeRestriction,
                company = product_entity.Company,
                price = product_entity.Price
            };
            return product_dto;
        }

        public void DeleteProduct(int id) 
        {
            _repository.DeleteProduct(id);
        }

        public ProductDTO GetProduct(int id)
        {
            Product product_entity = _repository.GetProduct(id);
            ProductDTO product_dto = new ProductDTO();
            product_dto = _mapper.Map<ProductDTO>(product_entity);
            product_dto.hasPicture = !string.IsNullOrEmpty(product_entity.imagePath);
            return product_dto;
        }

        public (byte[] file, string fileName, string mimeType) GetPicture(int id)
        {
            return _repository.GetPicture(id);
        }
    }
}