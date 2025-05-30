using LocadoraVeiculos.Dominio.Models;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.Interfaces
{
    public interface IReservaRepositorio
    {
        void Salvar(Reserva reserva);
        IEnumerable<Reserva> Listar();
        IEnumerable<Reserva> ListarPorCliente(string cpf);
    }
}