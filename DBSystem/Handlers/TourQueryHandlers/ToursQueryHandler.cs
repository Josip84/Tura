using DBEntities.Entities.Tours;
using DBSystem.Interfaces;

namespace DBSystem.Handlers.TourQueryHandlers
{
    public class ToursQueryHandler :
        IQueryHandlerTour<GetAllToursQuery, List<Tours>>,
        IQueryHandlerTour<GetTourByDateQuery, List<Tours>>,
        IQueryHandlerTour<GetTourByUIDQuery, Tours>
    {
        private readonly IToursRepository toursRepository;

        public ToursQueryHandler(IToursRepository toursRepository)
        {
            this.toursRepository = toursRepository;
        }

        public async Task<List<Tours>> Handle()
        {
            return (await toursRepository.GetAllTours()).ToList();
        }

        public async Task<List<Tours>> Handle(GetTourByDateQuery query)
        {
            return (await toursRepository.GetToursByDate(query.StartDate, query.EndDate)).ToList();
        }

        public async Task<Tours> Handle(GetTourByUIDQuery query)
        {
            return await toursRepository.GetTourByUID(query.IDTour);
        }

        public async Task<List<Tours>> Handle(GetAllToursQuery query)
        {
            throw new NotImplementedException();
        }

        Task<Tours> IQueryHandlerTour<GetTourByUIDQuery, Tours>.Handle()
        {
            throw new NotImplementedException();
        }
    }
}
