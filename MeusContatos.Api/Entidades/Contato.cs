using MeusContatos.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeusContatos.Api.Entidades;

public class Contato
{
    [Key]
    public int Id { get; init; }

    [Required, MaxLength(60)]
    public string Nome { get; private set; }

    [EmailAddress]
    public string? Email { get; private set; }

    [Phone]
    public string? Telefone { get; set; }

    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }

    [MaxLength(2)]
    public string UF { get; set; }

    public string? Imagem { get; set; }
    public int Categoria { get; set; }

    public Contato()
    { }

    public Contato(string nome, string email, string telefone, string rua, string numero, string bairro, string cidade, string uf, string imagem, int categoria)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Rua = rua;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        UF = uf;
        Imagem = imagem;
        Categoria = categoria;
    }

    public void AtualizaNome(string nome)
    {
        Nome = nome;
    }

    public void AtualizaEmail(string email)
    {
        Email = email;
    }
}