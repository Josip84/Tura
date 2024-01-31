using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Handlers.PlannerQueryHandlers
{
    public interface IQueryHandlerPlanner<TQuery, TResponse> where TQuery : IQueryPlanner<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
