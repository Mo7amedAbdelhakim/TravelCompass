using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelCompassData.Models;
using TravelCompassLogic.Mapping;

namespace TravelCompassLogic.TravelCompassDbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
