using LocadoraVeiculos.Dominio.DTOs;
using System.Collections.Generic;

namespace LocadoraVeiculos.Servico.Interfaces
{
    public interface IReservaServico
    {
        void Adicionar(ReservaDto reservaDto);
        IEnumerable<ReservaDto> Listar();
        IEnumerable<ReservaDto> ListarPorCliente(string cpf);
    }
}