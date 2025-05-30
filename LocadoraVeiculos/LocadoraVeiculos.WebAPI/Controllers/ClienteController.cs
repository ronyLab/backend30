using LocadoraVeiculos.Dominio.DTOs;
using LocadoraVeiculos.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraVeiculos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServico _servico;

        public ClienteController(IClienteServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IEnumerable<ClienteDto> Listar()
        {
            return _servico.Listar();
        }

        [HttpGet("{cpf}")]
        public ClienteDto? BuscarPorCpf(string cpf)
        {
            return _servico.BuscarPorCpf(cpf);
        }

        [HttpPost]
        public IActionResult? Adicionar([FromBody] ClienteDto clienteDto)
        {
            _servico.Adicionar(clienteDto);
            return Ok();
        }
    }
}