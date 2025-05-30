using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Context;
using LocadoraVeiculos.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Repositorio.Repositories
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly AppDbContext _context;

        public VeiculoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public IEnumerable<Veiculo> Listar()
        {
            return _context.Veiculos.ToList();
        }

        public IEnumerable<Veiculo> ListarDisponiveis()
        {
            return _context.Veiculos.Where(v => v.Disponivel).ToList();
        }

        public void Alugar(string placa)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Placa == placa);
            if (veiculo != null)
            {
                veiculo.Disponivel = false;
                _context.SaveChanges();
            }
        }

        public void Devolver(string placa)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(v => v.Placa == placa);
            if (veiculo != null)
            {
                veiculo.Disponivel = true;
                _context.SaveChanges();
            }
        }
    }
}