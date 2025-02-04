using MeusContatos.Api.Enums;

namespace MeusContatos.Api.Agenda
{
    public record AddContatoRequest(string Nome, string Email, string Telefone, string Rua, string Numero, string Bairro, string Cidade, string UF, string Imagem, int Categoria);
}