using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess; 

public class CanPayDbAccess : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<DebitCard> Cards { get; set; }

    protected CanPayDbAccess(DbContextOptions<CanPayDbAccess> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseSerialColumns();
    }
}