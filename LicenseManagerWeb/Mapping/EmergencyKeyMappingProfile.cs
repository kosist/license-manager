using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using LicenseManagerWeb.DTOs;

namespace LicenseManagerWeb.Mapping
{
    public class EmergencyKeyMappingProfile : Profile
    {
        public EmergencyKeyMappingProfile()
        {
            CreateMap<EmergencyKey, EmergencyKeyDto>();
            CreateMap<EmergencyKeyDto, EmergencyKey>();
        }
    }
}
