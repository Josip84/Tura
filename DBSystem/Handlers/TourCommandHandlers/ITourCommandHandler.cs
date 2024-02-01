using DBEntities.Entities.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.TourCommandHandlers
{
    public interface ITourCommandHandler<TCommand> where TCommand : ICommandTour
    {
        Task<Tours> Handle(TCommand command);
    }
}
