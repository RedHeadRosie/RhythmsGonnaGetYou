using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RhythmsGonnaGetYou
{
    public class RhythmsGonnaGetYouContext : DbContext
    {
        //ties together c# and database
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou");

            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);


        }
        static RhythmsGonnaGetYouContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }

}