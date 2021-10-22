using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresSweetAndSavory.Models
{
    public class PierresSweetAndSavoryContextFactory : IDesignTimeDbContextFactory<PierresSweetAndSavoryContext>
  {

    PierresSweetAndSavoryContext IDesignTimeDbContextFactory<PierresSweetAndSavoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PierresSweetAndSavoryContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PierresSweetAndSavoryContext(builder.Options);
    }
  }
}