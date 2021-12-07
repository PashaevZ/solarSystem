using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using solarsystem.Models;

namespace solarsystem.Data
{
    public class SolarSystContext : DbContext
    {
        public SolarSystContext(DbContextOptions<SolarSystContext> options)
            : base(options)
        {
        }

        public DbSet<Star>? Stars { get; set; }
        public DbSet<Planet>? Planets { get; set; }
        public DbSet<Satellite>? Satellites { get; set; }
        public DbSet<DwarfPlanet>? DwarfPlanets { get; set; }
        public DbSet<Asteroid>? Asteroids { get; set; }
        public DbSet<Comet>? Comets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Star>().ToTable("Star");
            modelBuilder.Entity<Planet>().ToTable("Planet");
            modelBuilder.Entity<Satellite>().ToTable("Satellite");
            modelBuilder.Entity<DwarfPlanet>().ToTable("DwarfPlanet");
            modelBuilder.Entity<Asteroid>().ToTable("Asteroid");
            modelBuilder.Entity<Comet>().ToTable("Comet");
        }
    }
}
