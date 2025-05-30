using LocadoraVeiculos.Dominio.DTOs;
using System.Collections.Generic;

namespace LocadoraVeiculos.Servico.Interfaces
{
    public interface IClienteServico
    {
        void Adicionar(ClienteDto clienteDto);
        IEnumerable<ClienteDto> Listar();
        ClienteDto? BuscarPorCpf(string cpf);
    }
}