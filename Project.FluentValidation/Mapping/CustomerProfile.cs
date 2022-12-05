using AutoMapper;
using Project.FluentValidation.DTOs;
using Project.FluentValidation.Models;

namespace Project.FluentValidation.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
          
        }
    }
}
