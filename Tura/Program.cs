
using DBSystem;
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
            builder.Services.AddScoped<DBSystem.Handlers.Commands.DriverCommandHandler>();
            builder.Services.AddScoped<DriverQueryHandler>();
            builder.Services.AddScoped<TourCommandHandler>();
            builder.Services.AddScoped<ToursQueryHandler>();
            builder.Services.AddScoped<PlannerCommandHandler>();
            builder.Services.AddScoped<PlannerQueryHandler>();

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