using LocadoraVeiculos.Dominio.DTOs;
using System.Collections.Generic;

namespace LocadoraVeiculos.Servico.Interfaces
{
    public interface IVeiculoServico
    {
        void Adicionar(VeiculoDto veiculoDto);
        IEnumerable<VeiculoDto> Listar();
        IEnumerable<VeiculoDto> ListarDisponiveis();
        void Alugar(string placa);
        void Devolver(string placa);
    }
}