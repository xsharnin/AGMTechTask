using TechTask.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using WebMap;

namespace TechTask.Data
{
    public class TripsDbContext : DbContext
    {
        public TripsDbContext(
            DbContextOptions<TripsDbContext> options) : base(options)
        {
        }

        public DbSet<TlcGreenTrip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<TlcGreenTrip>().ToTable("TlcGreenTrips");
        }
    }

    public static class TripsDbInitializer
    {
        public static void Initialize(TripsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
