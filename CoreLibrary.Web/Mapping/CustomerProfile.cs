using AutoMapper;
using CoreLibrary.Web.DTOs;
using CoreLibrary.Web.Models;

namespace CoreLibrary.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()//.IncludeMembers(x => x.CreditCard)
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName2())) //Customerda da getfullname deseydik buna gerek kalmazdı

                .ReverseMap();
        }


    }
}
