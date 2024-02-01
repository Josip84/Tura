using DBEntities.Entities.Tours;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.TourCommandHandlers
{
    public class CommandTour
    {
        public CommandTour() { }
    }

    public class CreateTourCommand : ICommandTour
    {
        public Tours Tours { get; set; }

        public async Task<Tours> Execute(IToursRepository toursRepository)
        {
            return await toursRepository.CreateTour(Tours);
        }
    }

    public class UpdateTourCommand: ICommandTour
    {
        public Tours Tours { get; set; }

        public async Task<Tours> Execute(IToursRepository toursRepository)
        {
            return await toursRepository.UpdateTour(Tours);
        }
    }

    public class DeleteTourCommand : ICommandTour
    {
        public string UIDTour { get; set; }

        public async Task<Tours> Execute(IToursRepository toursRepository)
        {
            return await toursRepository.DeleteTour(UIDTour);
        }
    }
}
