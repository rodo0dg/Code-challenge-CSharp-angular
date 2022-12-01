using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace ToysAndGames.AutoMapper
{
    public class DbProfile : Profile
    {
        public DbProfile() 
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTOCreate, Product>();
            CreateMap<ProductDTOUpdate, Product>();
            CreateMap<Product, ProductDTOUpdate>();
        }
    }
}
