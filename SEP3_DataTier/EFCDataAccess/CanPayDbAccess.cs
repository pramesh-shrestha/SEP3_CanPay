using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess; 

public class CanPayDbAccess : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<DebitCard> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Sep3Db");
        optionsBuilder.EnableSensitiveDataLogging();
    }
}