using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Interfaces
{
    public interface IDriverRepository
    {
        Task<Drivers> CreateDriverAsync(Drivers driver);
        Task<Drivers> GetDriverByIdAsync(int driverId);
        Task<List<Drivers>> GetDriverByPredicateAsync(Expression<Func<Drivers, bool>> predicate);
        Task<List<Drivers>> GetDriversByPropertiesAsync(Dictionary<string, object> properties);
        Task<List<Drivers>> GetAllDriversAsync();
        Task<Drivers> UpdateDriverAsync(Drivers driver);
        Task<Drivers> DeleteDriverAsync(int driverId);
    }
}
