using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.DriverQueryHandlers
{
    public interface IQueryHandlerDrivers<TQuery, TResponse> where TQuery : IQueryDrivers<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
