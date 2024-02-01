using DBEntities.Entities.Tours;
using DBSystem.Interfaces;

namespace DBSystem.Handlers.TourCommandHandlers
{
    public class TourCommandHandler :
        ITourCommandHandler<CreateTourCommand>,
        ITourCommandHandler<UpdateTourCommand>,
        ITourCommandHandler<DeleteTourCommand>
    {
        public readonly IToursRepository? toursRepository;

        public TourCommandHandler(IToursRepository? toursRepository)
        {
            this.toursRepository = toursRepository;
        }

        public async Task<Tours> Handle(CreateTourCommand command)
        {
            return await toursRepository.CreateTour(command.Tours);
        }

        public async Task<Tours> Handle(UpdateTourCommand command)
        {
            return await toursRepository.UpdateTour(command.Tours);
        }

        public async Task<Tours> Handle(DeleteTourCommand command)
        {
            return await toursRepository.DeleteTour(command.UIDTour);
        }
    }
}
