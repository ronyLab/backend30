using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Interfaces;
using LocadoraVeiculos.Servico.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Servico.Services
{
    public class ReservaServico : IReservaServico
    {
        private readonly IReservaRepositorio _repositorio;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ReservaServico(
            IReservaRepositorio repositorio,
            IVeiculoRepositorio veiculoRepositorio,
            IClienteRepositorio clienteRepositorio)
        {
            _repositorio = repositorio;
            _veiculoRepositorio = veiculoRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public void Adicionar(ReservaDto reservaDto)
        {
            var veiculo = _veiculoRepositorio.Listar().FirstOrDefault(v => v.Placa == reservaDto.PlacaVeiculo);
            var cliente = _clienteRepositorio.BuscarPorCpf(reservaDto.CpfCliente);

            if (veiculo == null || cliente == null)
                throw new Exception("Veículo ou cliente não encontrado.");

            if (!veiculo.EstaDisponivel())
                throw new Exception("Veículo já está alugado.");

            var reserva = new Reserva(
                reservaDto.PlacaVeiculo,
                reservaDto.CpfCliente,
                reservaDto.DataInicio,
                reservaDto.DataFim
            );

            _repositorio.Salvar(reserva);
            _veiculoRepositorio.Alugar(reservaDto.PlacaVeiculo);
        }

        public IEnumerable<ReservaDto> Listar()
        {
            return _repositorio.Listar().Select(r => new ReservaDto
            {   Id = r.Id,
                PlacaVeiculo = r.PlacaVeiculo,
                CpfCliente = r.CpfCliente,
                DataInicio = r.DataInicio,
                DataFim = r.DataFim
            });
        }

        public IEnumerable<ReservaDto> ListarPorCliente(string cpf)
        {
            return _repositorio.ListarPorCliente(cpf).Select(r => new ReservaDto
            {
                Id = r.Id,
                PlacaVeiculo = r.PlacaVeiculo,
                CpfCliente = r.CpfCliente,
                DataInicio = r.DataInicio,
                DataFim = r.DataFim
            });
        }
    }
}