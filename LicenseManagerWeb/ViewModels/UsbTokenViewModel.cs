using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagerWeb.ViewModels
{
    public class UsbTokenViewModel
    {
        public UsbTokenLicense UsbToken { get; set; }

        public UsbTokenViewModel()
        {
            UsbToken = new UsbTokenLicense
            {
                IssueDate = DateTime.Now,
                UsbTokenApi = new UsbTokenApi(),
            };
        }
    }
}
