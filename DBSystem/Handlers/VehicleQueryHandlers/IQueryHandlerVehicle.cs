using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.VehicleQueryHandlers
{
    public interface IQueryHandlerVehicle<TQuery, TResponse> where TQuery: IQueryVehicle<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
