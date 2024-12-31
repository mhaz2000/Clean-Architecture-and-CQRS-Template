using CleanArchAndCQRS.Infrastructure.EF.Config;
using CleanArchAndCQRS.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAndCQRS.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<PackingListReadModel> PackingLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        }
    }
}
