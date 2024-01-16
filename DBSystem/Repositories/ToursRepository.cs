using DBEntities.Entities.Drivers;
using DBEntities.Entities.Tours;
using DBSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Repositories
{
    public class ToursRepository : IToursRepository
    {
        private readonly TuraContext dbContext;

        public ToursRepository(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Tours?> CreateTour(Tours tour)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Tours.Add(tour);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        return tour;
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

        public Task<Tours?> DeleteTour(string tourID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tours?>> GetAllTours()
        {
            throw new NotImplementedException();
        }

        public Task<Tours?> GetTour(string tourID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tours?>> GetToursByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Tours?> UpdateTour(Tours tour)
        {
            throw new NotImplementedException();
        }
    }
}
