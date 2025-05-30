using LocadoraVeiculos.Dominio.Models;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.Interfaces
{
    public interface IVeiculoRepositorio
    {
        void Salvar(Veiculo veiculo);
        IEnumerable<Veiculo> Listar();
        IEnumerable<Veiculo> ListarDisponiveis();
        void Alugar(string placa);
        void Devolver(string placa);
    }
}