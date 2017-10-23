using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.DatabaseContext
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
