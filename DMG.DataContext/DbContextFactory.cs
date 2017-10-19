﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DMG.DatabaseContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory().Replace("DMG.DataContext", "DMG.Api");
            var builder = new DbContextOptionsBuilder<DataContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(@path)
              .AddJsonFile("appsettings.json")
              .Build();

            var connection = configuration["ConnectionStrings:DefaultConnection"];

            builder.UseSqlServer(connection);

            return new DataContext(builder.Options);
        }
    }
}
