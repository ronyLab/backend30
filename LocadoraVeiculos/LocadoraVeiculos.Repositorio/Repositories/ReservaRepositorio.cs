using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Context;
using LocadoraVeiculos.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Repositorio.Repositories
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly AppDbContext _context;

        public ReservaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> Listar()
        {
            return _context.Reservas.ToList();
        }

        public IEnumerable<Reserva> ListarPorCliente(string cpf)
        {
            return _context.Reservas.Where(r => r.CpfCliente == cpf).ToList();
        }
    }
}