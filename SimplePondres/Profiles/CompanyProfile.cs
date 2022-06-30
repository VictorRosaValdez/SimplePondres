using AutoMapper;
using SimplePondres.DTOs.CompanyDTOs;
using SimplePondres.Models;

namespace SimplePondres.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Company, CompanyReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<CompanyCreateDTO, Company>().ReverseMap();

        }
    }
}
