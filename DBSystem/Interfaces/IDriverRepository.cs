using DBEntities.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Interfaces
{
    public interface IDriverRepository
    {
        Task<Drivers> CreateDriverAsync(Drivers driver);
        Task<Drivers> GetDriverByIdAsync(int driverId);
        Task<List<Drivers>> GetAllDriversAsync();
        Task UpdateDriverAsync(Drivers driver);
        Task DeleteDriverAsync(int driverId);
    }
}
