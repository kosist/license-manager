using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using LicenseManagerWeb.DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LicenseManagerWeb.Mapping
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.SwProducts, opt => opt.Ignore());
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.SwProductIds,
                    opt => opt.MapFrom(dest => dest.SwProducts.Select(sw => sw.Id).ToList()));
        }
    }
}
