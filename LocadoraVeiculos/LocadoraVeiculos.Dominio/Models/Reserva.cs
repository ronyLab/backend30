using System.Diagnostics.CodeAnalysis;

public class Reserva
{
    public int Id { get; set; }

    [SetsRequiredMembers]
    public Reserva(string placaVeiculo, string cpfCliente, DateTime dataInicio, DateTime dataFim)
    {
        PlacaVeiculo = placaVeiculo;
        CpfCliente = cpfCliente;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    public required string PlacaVeiculo { get; set; }
    public required string CpfCliente { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}