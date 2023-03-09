using GraphQlDemo.DBSeedConfiguration;
using GraphQlDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlDemo.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
            modelBuilder.ApplyConfiguration(new OwnerDBSeedConfiguration(ids));
            modelBuilder.ApplyConfiguration(new AccountDBSeedConfiguration(ids));
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
