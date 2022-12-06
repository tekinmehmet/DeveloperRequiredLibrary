using AutoMapper;
using Project.FluentValidation.DTOs;
using Project.FluentValidation.Models;

namespace Project.FluentValidation.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();
            CreateMap<Customer, CustomerDto>()
                .IncludeMembers(x=>x.CreditCard)
                .ForMember(dest => dest.Isım, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FerreAnkastre()));
                //.ForMember(dest=>dest.CCNumber,opt=>opt.MapFrom(x=>x.CreditCard.Number))
                //.ForMember(dest => dest.CCValidDate, opt => opt.MapFrom(x => x.CreditCard.ValidDate));
            //CreateMap<Customer, CustomerDto>().ReverseMap();

        }
    }
}
