namespace LocadoraVeiculos.Dominio.DTOs
{
    public class ClienteDto
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
    }
}