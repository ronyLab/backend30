namespace LocadoraVeiculos.Dominio.DTOs
{
    public class ReservaDto
    {
        public required int Id { get; set; }
        public required string PlacaVeiculo { get; set; }
        public required string CpfCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}