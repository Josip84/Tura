using DBEntities.Entities.Drivers;
using DBEntities.Entities.Planner;
using DBEntities.Entities.Tours;
using DBSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem.Repositories
{
    public class PlannerRepository : IPlannerRepository
    {
        private readonly TuraContext dbContext;

        public PlannerRepository(TuraContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Planner?> CreatePlanner(Planner planner)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Planners.Add(planner);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        return planner;
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

        public async Task<Planner> DeletePlanner(Guid uid)
        {
            var planner = await dbContext.Planners.FirstOrDefaultAsync(d => d.UID == uid);
            if (planner != null)
            {
                dbContext.Planners.Remove(planner);
                await dbContext.SaveChangesAsync();
                return planner;
            }

            return null;
        }

        public async Task<IEnumerable<Planner>> GetAllPlanner()
        {
            var planners = await dbContext.Planners.ToListAsync();

            return planners;
        }

        public Task<IEnumerable<Planner>> GetPlannerByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Planner> GetPlannerByUID(Guid uid)
        {
            var planner = await dbContext.Planners
              .FirstOrDefaultAsync(d => d.UID == uid);

            return planner;
        }

        public async Task<Planner> UpdatePlanner(Planner planner)
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Planners.Update(planner);

                        // Save changes asynchronously  
                        await dbContext.SaveChangesAsync();

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        // Return the updated driver
                        return planner;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        transaction.Rollback();

                        Console.WriteLine($"Concurrency error: {ex.Message}");

                        // Handle the concurrency conflict...

                        //throw new Exception("Concurrency error occurred while updating the driver.", ex);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        //throw new Exception("Concurrency error occurred while updating the driver.", ex);
                        return null;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                //throw new Exception("Concurrency error occurred while updating the driver.", ex);
                return null;
            }
        }
    }
}
