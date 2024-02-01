namespace DBSystem.Handlers.TourQueryHandlers
{
    public interface IQueryHandlerTour<TQuery, TResponse> where TQuery : IQueryTour<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
