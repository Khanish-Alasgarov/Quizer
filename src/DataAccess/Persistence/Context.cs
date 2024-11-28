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
        optionsBuilder.UseSqlServer("data source=SEATTLE;initial catalog=Quizer;Trusted_Connection=True;TrustServerCertificate=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
