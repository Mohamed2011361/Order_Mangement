
using AutoMapper;
using Order.Core.Dto;
using Order.Core.Entites;
using Order.Infrastructure.Dto;

namespace Order.Api.MappingProfile
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<OrderCust, OrderCustDto>().ForMember(dest=>dest.OrderItems,opt=>opt.MapFrom(src=>src.OrderItems))
                .ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
