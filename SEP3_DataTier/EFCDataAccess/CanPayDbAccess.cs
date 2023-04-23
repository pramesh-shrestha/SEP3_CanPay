using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess; 

public class CanPayDbAccess : DbContext {
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DebitCardEntity> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Sep3Db");
        optionsBuilder.EnableSensitiveDataLogging();
    }
}