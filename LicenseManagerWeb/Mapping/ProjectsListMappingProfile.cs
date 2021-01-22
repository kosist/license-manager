using AutoMapper;
using Domain;
using LicenseManagerWeb.DTOs;

namespace LicenseManagerWeb.Mapping
{
    public class ProjectsListMappingProfile : Profile
    {
        public ProjectsListMappingProfile()
        {
            CreateMap<ProjectsListDto, Project>()
                .ForMember(p => p.Customer, opt => opt.Ignore())
                .ForMember(p => p.CustomerId, opt => opt.Ignore())
                .ForMember(p => p.SwProducts, opt => opt.Ignore())
                .ForMember(p => p.UserProjects, opt => opt.Ignore());
            CreateMap<Project, ProjectsListDto>();
        }
    }
}