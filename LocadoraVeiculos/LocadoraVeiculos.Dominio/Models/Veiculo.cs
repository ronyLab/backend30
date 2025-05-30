namespace LocadoraVeiculos.Dominio.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public decimal Diaria { get; set; }
        public bool Disponivel { get; set; }

        public Veiculo(string modelo, string marca, int ano, string placa, decimal diaria, bool disponivel = true)
        {
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Placa = placa;
            Diaria = diaria;
            Disponivel = disponivel;
        }

        public bool EstaDisponivel() => Disponivel;
    }
}