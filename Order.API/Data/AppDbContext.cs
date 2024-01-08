using Microsoft.EntityFrameworkCore;

namespace Order.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() 
        {
        }

        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Models.Order> orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        { 
            foreach (var entry in ChangeTracker.Entries<Models.EntityBase>()) 
            {
                switch (entry.State)
                { 
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "user";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "user";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
