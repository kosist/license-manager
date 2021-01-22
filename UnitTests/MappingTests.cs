using System;
using AutoMapper;
using LicenseManagerWeb.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace UnitTests
{
    public class MappingTests
    {
        private static IMapper _mapper;
        private MapperConfiguration _mapperCfg;
        public MappingTests()
        {
            if (_mapper == null)
            {
                _mapperCfg = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EmergencyKeyMappingProfile());
                    mc.AddProfile(new ProjectMappingProfile());
                    mc.AddProfile(new SwProductMappingProfile());
                    mc.AddProfile(new ProjectsListMappingProfile());
                });
                IMapper mapper = _mapperCfg.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void TestLicenseManagerWebMapping()
        {
            _mapperCfg.AssertConfigurationIsValid();
        }
    }
}
