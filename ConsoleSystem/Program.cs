﻿using AutoMapper;
using DBEntities.Entities.Drivers;
using DBSystem;
using DBSystem.Commands.DriverCommands;
using DBSystem.Handlers.DriverCommandHandlers;
using DBSystem.Interfaces;
using DBSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ConsoleSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");
            
            DBSystem.DBSystem.CreateSchema();*/
            
            var serviceProvider = ConfigureServices();

            var driver = new Drivers
            {
                DriverCompanyID = "a23",
                DriverFirstName = "Josip",
                DriverLastName = "Pejaković",
                OIB = "123",
                IsActive = true
            };

            var createDriver = await CreateDriverAsync(driver, serviceProvider);

        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Add the necessary services  
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<CreateDriverHandler>();
            services.AddAutoMapper(typeof(Program));


            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            IConfiguration config = builder.Build();
            // Register the TuraContext  
            /*services.AddDbContext<TuraContext>(options =>
                options.UseNpgsql(config["ConnectionStrings"]));*/

            services.AddDbContext<TuraContext>();

            
            // Build the service provider             
            return services.BuildServiceProvider();
        }

        private static async Task<Drivers> CreateDriverAsync(Drivers driverDto, ServiceProvider serviceProvider)
        {
            // Instantiate the CreateDriverCommandHandler using the service provider  
            using var scope = serviceProvider.CreateScope();
            var createDriverCommandHandler = scope.ServiceProvider.GetRequiredService<CreateDriverHandler>();

            // Create a CreateDriverCommand object  
            var createDriverCommand = new CreateDriverCommand { Driver = driverDto };

            // Call the Handle method of the CreateDriverCommandHandler  
            var createdDriver = await createDriverCommandHandler.Handle(createDriverCommand, new TuraContext());

            // Map the created Drivers entity back to a DriversDto  
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            var createdDriverDto = mapper.Map<Drivers>(createdDriver);

            return createdDriverDto;
        }
    }
}