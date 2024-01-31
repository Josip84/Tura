using AutoMapper;
using DBEntities.Entities.Drivers;
using DBSystem;
using DBSystem.Handlers.Commands;
using DBSystem.Handlers.DriverQueryHandlers;
using DBSystem.Interfaces;
using DBSystem.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                DriverCompanyID = "a234",
                DriverFirstName = "Josip",
                DriverLastName = "Pejaković",
                OIB = "123",
                IsActive = true
            };

            var createDriver = await CreateDriverAsync(driver, serviceProvider);
            //var k = await GetDriversByLastNameAsync("Pejaković", serviceProvider);
            /*var d = await GetDriverById(1, serviceProvider);

            var all = await GetAllDrivers(serviceProvider);*/

        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Add the necessary services  
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<DriverCommandHandler>();
            services.AddScoped<DriverQueryHandler>();
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
            var createDriverCommandHandler = scope.ServiceProvider.GetRequiredService<DriverCommandHandler>();
            var deleteDriverCommandHandler = scope.ServiceProvider.GetRequiredService<DriverCommandHandler>();

            // Create a CreateDriverCommand object  
            var createDriverCommand = new CreateDriverCommand { Driver = driverDto };
            var deleteDriverCommand = new DeleteDriverCommand { DriverId = 5 };

            // Call the Handle method of the CreateDriverCommandHandler  
            var createdDriver = await createDriverCommandHandler.Handle(createDriverCommand);
            //var deleteDriver = await deleteDriverCommandHandler.Handle(deleteDriverCommand);

            // Map the created Drivers entity back to a DriversDto  
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            var createdDriverDto = mapper.Map<Drivers>(createdDriver);

            return createdDriverDto;
        }
        
        /*
        private static async Task<List<Drivers>> GetDriversByLastNameAsync(string lastName, ServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var getDriverByPropertiesQueryHandler = scope.ServiceProvider.GetRequiredService<DriverQueryHandler>();

            var properties = new Dictionary<string, object>
            {                
               
            };

            var getDriverByPropertiesQuery = new GetDriverByPropertiesQuery
            {
                Properties = properties
            };
                        

            var drivers = await getDriverByPropertiesQueryHandler.Handle(getDriverByPropertiesQuery);

            return drivers;
        }

        private static async Task<Drivers> GetDriverById(int id, ServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var getdriverbyid = scope.ServiceProvider.GetRequiredService<DriverQueryHandler>();

            var getriverbyidquery = new GetDriverByIdQuery
            {
                DriverId = 4
            };

            var drivers = await getdriverbyid.Handle(getriverbyidquery);

            return drivers;
        }

        private static async Task<List<Drivers>> GetAllDrivers(ServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var alldrivers = scope.ServiceProvider.GetRequiredService<DriverQueryHandler>();

            var getdriverall = new GetAllDrivers();

            var returnall = await alldrivers.Handle();

            return returnall;
        }*/
    }
}