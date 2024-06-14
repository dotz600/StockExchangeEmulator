using DataLayer.DLEntity;
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

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    /// <summary>
    /// define the connection string to the data base
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=master;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False");
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
            new CurrencyPair { Id = 4, Pair = "USD/EUR", MinVal = 0.85, MaxVal = 0.95 },
            new CurrencyPair { Id = 5, Pair = "USD/ILS", MinVal = 3.2, MaxVal = 3.8 },
            new CurrencyPair { Id = 6, Pair = "EUR/JPY", MinVal = 125.00, MaxVal = 135.00 }
        );
    }
}

