using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Interfaces;
using LocadoraVeiculos.Servico.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Servico.Services
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(ClienteDto clienteDto)
        {
            var cliente = new Cliente(
                clienteDto.Nome,
                clienteDto.Cpf,
                clienteDto.Telefone,
                clienteDto.Email
            );
            _repositorio.Salvar(cliente);
        }

        public IEnumerable<ClienteDto> Listar()
        {
            return _repositorio.Listar().Select(c => new ClienteDto
            {
                Nome = c.Nome,
                Cpf = c.Cpf,
                Telefone = c.Telefone,
                Email = c.Email
            });
        }

        public ClienteDto? BuscarPorCpf(string cpf) // Adicione "?"
{
    var cliente = _repositorio.BuscarPorCpf(cpf);
    return cliente != null ? new ClienteDto
    {
        Nome = cliente.Nome,
        Cpf = cliente.Cpf,
        Telefone = cliente.Telefone,
        Email = cliente.Email
    } : null;
}
    }
}