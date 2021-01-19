﻿using System.Collections.Generic;
using System.Linq;
using DAL.EFRepositories;
using DAL.Repositories;
using Domain;
using LicenseManagerWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public abstract class CustomersControllerTest
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        protected CustomersControllerTest(DbContextOptions<ApplicationDbContext> context)
        {
            ContextOptions = context;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //var customerA = new Customer
                //{
                //    Name = "Customer A",
                //    Address = "Address A",
                //    Country = "Country A"
                //};
                //context.Add(customerA);
                //context.SaveChanges();
            }
        }

        [Fact]
        public async void SaveCustomers()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var repo = new EfCustomerRepository(context);
                var controller = new CustomersController(repo);

                var customer = new Customer
                {
                    Name = "CustomerA",
                    Address = "AddressA",
                    Country = "CountryA"
                };

                await controller.Edit(customer);
                var customers = await controller.Index();
                var allCustomers = customers as ViewResult;
                var castedCustomers = allCustomers.Model as IEnumerable<Customer>;

                Assert.Equal("CustomerA", castedCustomers.First().Name);
            }
        }
    }
}