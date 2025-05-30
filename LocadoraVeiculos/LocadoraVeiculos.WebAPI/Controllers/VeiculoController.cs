using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraVeiculos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServico _servico;

        public VeiculoController(IVeiculoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IEnumerable<VeiculoDto> Listar()
        {
            return _servico.Listar();
        }

        [HttpGet("disponiveis")]
        public IEnumerable<VeiculoDto> ListarDisponiveis()
        {
            return _servico.ListarDisponiveis();
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] VeiculoDto veiculoDto)
        {
            _servico.Adicionar(veiculoDto);
            return Ok();
        }

        [HttpPost("alugar/{placa}")]
        public IActionResult Alugar(string placa)
        {
            _servico.Alugar(placa);
            return Ok();
        }

        [HttpPost("devolver/{placa}")]
        public IActionResult Devolver(string placa)
        {
            _servico.Devolver(placa);
            return Ok();
        }
    }
}