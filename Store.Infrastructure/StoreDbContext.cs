using Store.Core.Access;
using System.Data.Entity;

namespace Store.Infrastructure
{
    public class StoreDbContext : EntityContext
    {
        public StoreDbContext(string nameOrConnectionString) : base("name=StoreEntities")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("database");
            base.OnModelCreating(modelBuilder);
        }
    }
}
