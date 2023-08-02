using Microsoft.EntityFrameworkCore;

namespace DataAccess.Persistence;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options):base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("data source=DESKTOP-RI3B8A7;initial catalog=Quizer;user id=Khanish;password=15101995;TrustServerCertificate=True");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
