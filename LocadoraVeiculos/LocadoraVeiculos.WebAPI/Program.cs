using LocadoraVeiculos.Dominio.Models;
using LocadoraVeiculos.Repositorio.Context;
using LocadoraVeiculos.Repositorio.Interfaces;
using LocadoraVeiculos.Repositorio.Repositories;
using LocadoraVeiculos.Servico.Interfaces;
using LocadoraVeiculos.Servico.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("LocadoraDb"));

// Injeção de dependências
builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();
// Adicione estas linhas na seção de injeção de dependências:
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IClienteServico, ClienteServico>();
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<IReservaServico, ReservaServico>();

// Configuração do CORS (igual ao do professor)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowLocalhost4200"); // Posição idêntica à do professor
app.MapControllers();

// População inicial do banco (opcional)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Veiculos.AddRange(
        new Veiculo("Gol", "Volkswagen", 2022, "ABC1D23", 150),
        new Veiculo("Onix", "Chevrolet", 2023, "DEF4G56", 180),
        new Veiculo("HB20", "Hyundai", 2021, "GHI7J89", 160),
        new Veiculo("Corolla", "Toyota", 2023, "KLM1N23", 300)
    );
    context.SaveChanges();
    
    context.Clientes.AddRange(
    new Cliente("João Silva", "123.456.789-00", "(11) 9999-8888", "joao@email.com"),
    new Cliente("Maria Souza", "987.654.321-00", "(11) 7777-6666", "maria@email.com")
);
context.SaveChanges();
    context.Reservas.AddRange(
        new Reserva(
            placaVeiculo: "ABC1D23",
            cpfCliente: "123.456.789-00",
            dataInicio: DateTime.Now.AddDays(1),
            dataFim: DateTime.Now.AddDays(3)
        ),
        new Reserva(
            placaVeiculo: "DEF4G56",
            cpfCliente: "987.654.321-00",
            dataInicio: DateTime.Now.AddDays(2),
            dataFim: DateTime.Now.AddDays(5)
        )
    );

    context.SaveChanges();
}




app.Run();