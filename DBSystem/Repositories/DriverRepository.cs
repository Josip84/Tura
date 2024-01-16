using DBEntities.Entities.Drivers;
using DBSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TuraContext dbContext;

        public DriverRepository(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Drivers?> CreateDriverAsync(Drivers driver)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Drivers.Add(driver);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        // Return the created driver (with the generated ID)  
                        return driver;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Error: {ex.Message}");

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                
                return null;
            }
        }

        public async Task<Drivers?> DeleteDriverAsync(int driverId)
        {
            var driver = await dbContext.Drivers.FirstOrDefaultAsync(d => d.DriverID == driverId);
            if (driver != null)
            {
                dbContext.Drivers.Remove(driver);
                await dbContext.SaveChangesAsync();
                return driver;
            }

            return null;
        }

        public async Task<List<Drivers>> GetAllDriversAsync()
        {
            var alldrivers = await dbContext.Drivers.ToListAsync();

            return alldrivers;
        }

        public async Task<Drivers> GetDriverByIdAsync(int driverId)
        {
            var driver = await dbContext.Drivers
                .FirstOrDefaultAsync(d => d.DriverID == driverId);

            // Return the driver, or null if not found  
            return driver;
        }

        public async Task<Drivers> GetDriverByCompanyIdAsync(String companyID)
        {
            var driver = await dbContext.Drivers
                .FirstOrDefaultAsync(d => d.DriverCompanyID == companyID);

            // Return the driver, or null if not found  
            return driver;
        }

        public async Task<List<Drivers>> GetDriverByPredicateAsync(Expression<Func<Drivers, bool>> predicate)
        {
            //var driver = await dbContext.Drivers.FirstOrDefaultAsync(predicate);
            var driver = await dbContext.Drivers.Where(predicate).ToListAsync();

            // Return the driver, or null if not found    
            return driver;
        }

        public async Task<List<Drivers>> GetDriversByPropertiesAsync(Dictionary<string, object> properties)
        {
            IQueryable<Drivers> driversQuery = dbContext.Drivers;

            foreach (var property in properties)
            {
                driversQuery = driversQuery.Where(GeneratePredicate(property.Key, property.Value));
            }

            var drivers = await driversQuery.ToListAsync();

            return drivers;
        }

        private Expression<Func<Drivers, bool>> GeneratePredicate(string propertyName, object propertyValue)
        {
            var parameter = Expression.Parameter(typeof(Drivers), "d");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(propertyValue);
            var equal = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<Drivers, bool>>(equal, parameter);

            return lambda;
        }

        public async Task<Drivers> UpdateDriverAsync(Drivers driver)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Drivers.Update(driver);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Return the created driver (with the generated ID)  
                        return driver;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }
    }
}
