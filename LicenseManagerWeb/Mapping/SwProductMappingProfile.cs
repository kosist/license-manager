using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using LicenseManagerWeb.DTOs;

namespace LicenseManagerWeb.Mapping
{
    public class SwProductMappingProfile : Profile
    {
        public SwProductMappingProfile()
        {
            CreateMap<SwProductViewDto, Product>()
                .ForMember(dest => dest.License, opt => opt.Ignore())
                .ForMember(dest => dest.EmergencyKey, opt => opt.MapFrom(src => src.EmergencyKey));
            CreateMap<Product, SwProductViewDto>()
                .ForMember(dest => dest.LicenseId, opt => opt.MapFrom(src => src.License.Id))
                .ForMember(dest => dest.EmergencyKey, opt => opt.MapFrom(src => src.EmergencyKey));
        }
    }
}
