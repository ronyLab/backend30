namespace LocadoraVeiculos.Dominio.DTOs
{
    public class VeiculoDto
    {
        public required string Modelo { get; set; }
        public required string Marca { get; set; }
        public int Ano { get; set; }
        public required string Placa { get; set; }
        public decimal Diaria { get; set; }
    }
}