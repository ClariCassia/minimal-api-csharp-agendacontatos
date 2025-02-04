using MeusContatos.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MeusContatos.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-CLARI;Database=MeusContatos;Integrated Security=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}