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
        optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=Quizer;integrated security=true");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
