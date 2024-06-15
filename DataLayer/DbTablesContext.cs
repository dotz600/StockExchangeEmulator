using GlobalEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DataLayer;

/// <summary>
/// hold the data base tables by inheriting from DbContext
/// </summary>
internal class DbTablesContext : DbContext
{
    public DbSet<Currency> CurrencyDB { get; set; }
    public DbSet<CurrencyPair> CurrencyPairDB { get; set; }

    private readonly string _connectionString;

    public DbTablesContext() 
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        //get connection string from appsettings.json
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new Exception("Failed to open the database.");
    }

    /// <summary>
    /// define the connection string to the data base
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(_connectionString);
    }


    /// <summary>
    /// define the data base tables for the first time
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>().HasData(
            new Currency { Id = 1, Country = "United States", Name = "Dollar", Abbreviation = "USD" },
            new Currency { Id = 2, Country = "Eurozone", Name = "Euro", Abbreviation = "EUR" },
            new Currency { Id = 3, Country = "Japan", Name = "Yen", Abbreviation = "JPY" },
            new Currency { Id = 4, Country = "Israel", Name = "Shekel", Abbreviation = "ILS" }
        );

        modelBuilder.Entity<CurrencyPair>().HasData(
            new CurrencyPair { Id = 1, Pair = "USD/EUR", MinVal = 0.90, MaxVal = 0.95 },
            new CurrencyPair { Id = 2, Pair = "USD/ILS", MinVal = 3.5, MaxVal = 3.8 },
            new CurrencyPair { Id = 3, Pair = "EUR/JPY", MinVal = 130.00, MaxVal = 135.00 }
        );
    }
}

