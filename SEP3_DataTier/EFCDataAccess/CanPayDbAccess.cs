using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess;

public class CanPayDbAccess : DbContext
{
    public DbSet<UserEntity?> Users { get; set; }
    public DbSet<DebitCardEntity> Cards { get; set; }
    public DbSet<TransactionEntity?> Transactions { get; set; }
    public DbSet<NotificationEntity?> Notifications { get; set; }
    
    public DbSet<RequestEntity> Requests { get; set; }
    public DbSet<BillTransactionEntity> BillTransactions { get; set; }


    /// <summary>
    /// Configures the database context options.
    /// </summary>
    /// <param name="optionsBuilder">The options builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=manny.db.elephantsql.com;Port=5432;Database=njqattew;Username=njqattew;Password=7GJwQ_Fu4cx5oQHutsdlMOwXUXhuSaFQ ",
            options => options.UseAdminDatabase("njqattew"));
        optionsBuilder.EnableSensitiveDataLogging();
    }

    /// <summary>
    /// Configures the model for the database context.
    /// </summary>
    /// <param name="modelBuilder">The model builder instance to use for configuration.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("CanPay");
    }
}