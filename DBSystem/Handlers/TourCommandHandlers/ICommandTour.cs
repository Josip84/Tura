using DBEntities.Entities.Tours;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.TourCommandHandlers
{
    public interface ICommandTour
    {
        Task<Tours> Execute(IToursRepository toursRepository);
    }
}
