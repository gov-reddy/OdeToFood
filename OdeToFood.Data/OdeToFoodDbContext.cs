using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) 
            : base(options)
        {

        }
    }
}
