using Microsoft.EntityFrameworkCore;

namespace DBSystem
{
    public static class DBSystem
    {
        public static void CreateSchema()
        {
            using (var context = new TuraContext())
            {
                //creates db if not exists 
                //context.Database.Migrate();
                //context.Database.EnsureCreated();
                try
                {
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}