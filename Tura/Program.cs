
using DBEntities.Entities.Drivers;
using DBEntities.Entities.Planner;
using DBEntities.Entities.Tours;
using DBSystem;
using DBSystem.Handlers.DriverCommands;
using DBSystem.Handlers.DriverQueryHandlers;
using DBSystem.Handlers.PlannerCommandHandler;
using DBSystem.Handlers.PlannerQueryHandlers;
using DBSystem.Handlers.TourCommandHandlers;
using DBSystem.Handlers.TourQueryHandlers;
using DBSystem.Interfaces;
using DBSystem.Repositories;
using Microsoft.OpenApi.Models;
using ServiceStack;

namespace Tura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
#if PRODUCTION
                var env = "Production";
#elif DEBUG
                var env = "Debug";
#elif DEVELOP
                var env = "Develop";
#elif TESTSERVER
                var env = "TestServer";
#else
                var env = "Debug";

#endif

                config.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add repositories
            builder.Services.AddScoped<IDriverRepository, DriverRepository> ();
            builder.Services.AddScoped<IToursRepository, ToursRepository>();
            builder.Services.AddScoped<IPlannerRepository, PlannerRepository>();

            builder.Services.AddScoped<ICommandDriversHandler<CreateDriverCommand>, DriverCommandHandler>();
            builder.Services.AddScoped<ICommandDriversHandler<UpdateDriverCommand>, DriverCommandHandler>();
            builder.Services.AddScoped<ICommandDriversHandler<DeleteDriverCommand>, DriverCommandHandler>();

            builder.Services.AddScoped<ITourCommandHandler<CreateTourCommand>, TourCommandHandler>();
            builder.Services.AddScoped<ITourCommandHandler<UpdateTourCommand>, TourCommandHandler>();
            builder.Services.AddScoped<ITourCommandHandler<DeleteTourCommand>, TourCommandHandler>();

            builder.Services.AddScoped<IPlannerCommandHandler<CreatePlannerCommand>, PlannerCommandHandler>();
            builder.Services.AddScoped<IPlannerCommandHandler<UpdatePlannerCommand>, PlannerCommandHandler>();
            builder.Services.AddScoped<IPlannerCommandHandler<DeletePlannerCommand>, PlannerCommandHandler>();


            builder.Services.AddScoped<IQueryHandlerDrivers<GetDriverByPropertiesQuery, List<Drivers>>, DriverQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerDrivers<GetDriverByIdQuery, Drivers>, DriverQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerDrivers<GetDriverByCompanyIdQuery, Drivers>, DriverQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerDrivers<GetAllDriversQuery, List<Drivers>>, DriverQueryHandler>();

            builder.Services.AddScoped<IQueryHandlerTour<GetAllToursQuery, List<Tours>>, ToursQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerTour<GetTourByDateQuery, List<Tours>>, ToursQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerTour<GetTourByUIDQuery, Tours>, ToursQueryHandler>();


            builder.Services.AddScoped<IQueryHandlerPlanner<GetAllPlannerQuery, IEnumerable<Planner>>, PlannerQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerPlanner<GetPlannerByDateQuery, IEnumerable<Planner>>, PlannerQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerPlanner<GetPlannerByUIDQuery, Planner>, PlannerQueryHandler>();




            builder.Services.AddDbContext<TuraContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TURA API V1");
                });
            }

            app.UseCors("AllowLocalNetworkOrigins"); // Use the new policy name here 

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}