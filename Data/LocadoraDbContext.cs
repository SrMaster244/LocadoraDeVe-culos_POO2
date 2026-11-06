using LocadoraDeVeículos.Model;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeículos.Data;

public sealed class LocadoraDbContext : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    public DbSet<Contrato> Contratos => Set<Contrato>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=locadora.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().UseTphMappingStrategy();
        modelBuilder.Entity<Veiculo>().UseTphMappingStrategy();
        modelBuilder.Entity<Contrato>().Property(c => c.ValorFinal).HasPrecision(18, 2);
    }
}
