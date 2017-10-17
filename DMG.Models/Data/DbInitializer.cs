using DMG.Models;
using System;
using System.Linq;

namespace DMG.Data
{
    public class DbInitializer
    {
        public static void Initialize(DimosDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            context.SaveChanges();
        }

    }
}

