using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Context;
using LocadoraVeiculos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore; // Certifique-se que está presente
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Repositorio.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AppDbContext _context;

        public ClienteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? BuscarPorCpf(string cpf)
        {
            return _context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
        }
    }
}