using AutoMapper;
using SimplePondres.DTOs.OrderDTOs;
using SimplePondres.Models;

namespace SimplePondres.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Order, OrderReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<OrderCreateDTO, Order>().ReverseMap();

        }
    }
}
