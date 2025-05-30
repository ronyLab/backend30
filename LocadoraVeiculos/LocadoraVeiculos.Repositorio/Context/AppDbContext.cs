using LocadoraVeiculos.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Repositorio.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}