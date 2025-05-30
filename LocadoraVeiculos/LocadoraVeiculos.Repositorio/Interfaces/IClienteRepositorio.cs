using LocadoraVeiculos.Dominio.Models;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        void Salvar(Cliente cliente);
        IEnumerable<Cliente> Listar();
        Cliente? BuscarPorCpf(string cpf);
    }
}