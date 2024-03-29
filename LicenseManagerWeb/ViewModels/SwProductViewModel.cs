﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LicenseManagerWeb.DTOs;
using DAL.Repositories;

namespace LicenseManagerWeb.ViewModels
{
    public class SwProductViewModel
    {
        public SwProductViewDto SwProduct { get; set; }
        public List<UsbTokensListDto> UsbTokens { get; private set; }

        public IEnumerable<ProjectsListDto> Projects { get; set; }
        public ProjectsListDto Project { get; set; }

        public SwProductViewModel()
        {            
            SwProduct = new SwProductViewDto
            {
                EmergencyKey = new EmergencyKey(),
                ProductMetadata = new ProductMeta(),
                ViProtectionInfo = new List<ViProtection>(),
                ProductChanges = new List<ProductChange>(),
            };
            Projects = new List<ProjectsListDto>();
        }

        public async Task PopulateTokensList(ILicenseRepository<UsbTokenLicense> tokensRepo)
        {
            var tokens = await tokensRepo.GetList();
            UsbTokens = new List<UsbTokensListDto>();
            foreach (var token in tokens)
            {
                UsbTokens.Add(new UsbTokensListDto
                {
                    Id = token.Id,
                    Label = token.Name,
                });
            };
        }        
    }

}
