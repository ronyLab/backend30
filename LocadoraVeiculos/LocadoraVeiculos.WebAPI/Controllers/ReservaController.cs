using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraVeiculos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServico _servico;

        public ReservaController(IReservaServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IEnumerable<ReservaDto> Listar()
        {
            return _servico.Listar();
        }

        [HttpGet("cliente/{cpf}")]
        public IEnumerable<ReservaDto> ListarPorCliente(string cpf)
        {
            return _servico.ListarPorCliente(cpf);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ReservaDto reservaDto)
        {
            _servico.Adicionar(reservaDto);
            return Ok();
        }
    }
}