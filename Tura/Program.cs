
using DBSystem;
using DBSystem.Handlers.DriverCommandHandlers;
using DBSystem.Handlers.DriverQueryHandlers;
using DBSystem.Handlers.PlannerCommandHandler;
using DBSystem.Handlers.PlannerQueryHandlers;
using DBSystem.Handlers.TourCommandHandlers;
using DBSystem.Handlers.TourQueryHandlers;
using DBSystem.Interfaces;
using DBSystem.Repositories;

namespace Tura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add repositories
            builder.Services.AddScoped<IDriverRepository, DriverRepository> ();
            builder.Services.AddScoped<IToursRepository, ToursRepository>();
            builder.Services.AddScoped<IPlannerRepository, PlannerRepository>();
            builder.Services.AddScoped<DriverCommandHandler>();
            builder.Services.AddScoped<DriverQueryHandler>();
            builder.Services.AddScoped<TourCommandHandler>();
            builder.Services.AddScoped<ToursQueryHandler>();
            builder.Services.AddScoped<PlannercCommandHandler>();
            builder.Services.AddScoped<PlannerQueryHandler>();

            builder.Services.AddDbContext<TuraContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}