using DBEntities.Entities.Drivers;
using DBEntities.Entities.Tours;
using DBSystem.Commands.DriverCommands;
using DBSystem.Commands.TourCommands;
using DBSystem.Interfaces;
using DBSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.TourCommandHandlers
{
    public class TourCommandHandler
    {
        public readonly IToursRepository? toursRepository;

        public TourCommandHandler(IToursRepository? toursRepository)
        {
            this.toursRepository = toursRepository;
        }

        public async Task<Tours> Handle(CreateTourCommand command) => await toursRepository.CreateTour(command.Tours);
        public async Task<Tours> Handle(UpdateTourCommand command) => await toursRepository.UpdateTour(command.Tours);
        /*public async Task Handle(string tourID)
        {
            await toursRepository.DeleteTour(tourID);
        }*/
        public async Task<Tours> Handle(DeleteTourCommand command) => await toursRepository.DeleteTour(command.TourID);
    }
}
