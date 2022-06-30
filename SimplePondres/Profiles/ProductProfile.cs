using AutoMapper;
using SimplePondres.DTOs.ProductDTOs;
using SimplePondres.Models;

namespace SimplePondres.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Product, ProductReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ProductCreateDTO, Product>().ReverseMap();

        }
    }
}
