using DBEntities.Entities.Drivers;
using DBEntities.Entities.Tours;
using DBSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Tours?> DeleteTour(string tourID)
        {
            var tour = await dbContext.Tours.FirstOrDefaultAsync(d => d.UID.ToString() == tourID);
            if (tour != null)
            {
                dbContext.Tours.Remove(tour);
                await dbContext.SaveChangesAsync();
                return tour;
            }

            return null;
        }

        public async Task<List<Tours>> GetAllTours()
        {
            var tours = await dbContext.Tours.ToListAsync();

            return tours;
        }

        public async Task<Tours?> GetTourByUID(string tourID)
        {
            var tour = await dbContext.Tours
               .FirstOrDefaultAsync(d => d.UID.ToString() == tourID);
           
            return tour;
        }

        public async Task<List<Tours>> GetToursByDate(DateTime startDate, DateTime endDate)
        {
            DateOnly start = DateOnly.FromDateTime(startDate);
            DateOnly end = DateOnly.FromDateTime(endDate);

            var tours = await dbContext.Tours.Where(t => t.TourDate >= start && t.TourDate <= end).ToListAsync();

            return tours;
        }

        public async Task<Tours?> UpdateTour(Tours tour)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Tours.Update(tour);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        // Return the updated driver
                        return tour;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Concurrency error: {ex.Message}");

                        // Handle the concurrency conflict...

                        return null;
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
    }
}
