using AutoMapper;
using Project.FluentValidation.DTOs;
using Project.FluentValidation.Models;

namespace Project.FluentValidation.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Isım, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age));
            //CreateMap<Customer, CustomerDto>().ReverseMap();
          
        }
    }
}
