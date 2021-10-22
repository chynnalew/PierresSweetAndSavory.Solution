using Microsoft.EntityFrameworkCore;

namespace PierresSweetAndSavory.Models
{
  public class PierresSweetAndSavoryContext : DbContext
  {
    public DbSet<Flavor> Flavors {get; set;}
    public DbSet<Treat> Treats {get; set;}
    public DbSet<TreatFlavors> TreatFlavors {get; set;}

    public PierresSweetAndSavoryContext (DbContextOptions options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}