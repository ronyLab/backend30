using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Interfaces;
using LocadoraVeiculos.Servico.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Servico.Services
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly IVeiculoRepositorio _repositorio;

        public VeiculoServico(IVeiculoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(VeiculoDto veiculoDto)
        {
            var veiculo = new Veiculo(
                veiculoDto.Modelo,
                veiculoDto.Marca,
                veiculoDto.Ano,
                veiculoDto.Placa,
                veiculoDto.Diaria
            );
            _repositorio.Salvar(veiculo);
        }

        public IEnumerable<VeiculoDto> Listar()
        {
            return _repositorio.Listar().Select(v => new VeiculoDto
            {
                Modelo = v.Modelo,
                Marca = v.Marca,
                Ano = v.Ano,
                Placa = v.Placa,
                Diaria = v.Diaria
            });
        }

        public IEnumerable<VeiculoDto> ListarDisponiveis()
        {
            return _repositorio.ListarDisponiveis().Select(v => new VeiculoDto
            {
                Modelo = v.Modelo,
                Marca = v.Marca,
                Ano = v.Ano,
                Placa = v.Placa,
                Diaria = v.Diaria
            });
        }

        public void Alugar(string placa)
        {
            _repositorio.Alugar(placa);
        }

        public void Devolver(string placa)
        {
            _repositorio.Devolver(placa);
        }
    }
}