using DBEntities.Entities.Tours;
using DBSystem.Commands.TourCommands;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.TourQueryHandlers
{
    public class ToursQueryHandler
    {
        private readonly IToursRepository toursRepository;
        public ToursQueryHandler(IToursRepository toursRepository)
        {
            this.toursRepository = toursRepository;
        }

        public async Task<List<Tours>> Handle()
        {
            var getalltours = await toursRepository.GetAllTours();

            return getalltours.ToList();
        }

        public async Task<Tours> Handle(GetTourByIDQuery tour)
        {
            var gettour = await toursRepository.GetTour(tour.TourID);

            return gettour;
        }

        public async Task<List<Tours>> Handle(GetTourByDateQuery tour)
        {
            var getalltours = await toursRepository.GetToursByDate(tour.StartDate, tour.EndDate);

            return getalltours.ToList();
        }

    }
}
