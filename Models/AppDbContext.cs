using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Autobus> Autobus { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
    }
}
