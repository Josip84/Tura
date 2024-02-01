using DBEntities.Entities.Tours;

namespace DBSystem.Handlers.TourQueryHandlers
{
    public class TourQueries
    {
    }

    public class GetTourByUIDQuery : IQueryTour<Tours>
    {
        public string IDTour { get; set; }
    }

    public class GetAllToursQuery : IQueryTour<List<Tours>> 
    {
    }

    public class GetTourByDateQuery : IQueryTour<List<Tours>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
