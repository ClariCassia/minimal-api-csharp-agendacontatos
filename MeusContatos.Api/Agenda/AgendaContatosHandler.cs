using AutoMapper;
using MeusContatos.Api.Data;
using MeusContatos.Api.Entidades;
using MeusContatos.Api.Enums;
using Microsoft.EntityFrameworkCore;

namespace MeusContatos.Api.Agenda;

public static class AgendaContatosHandler
{
    public static async Task<IResult> AdicionarContato(AddContatoRequest request, AppDbContext context)
    {
        var contatoExistente = await context.Contatos.AnyAsync(c => c.Nome == request.Nome);

        if (contatoExistente)
            return Results.Conflict(new { status = Utils.StatusCodes.Error, message = "O contato já está cadastrado." });

        var novoContato = new Contato(request.Nome, request.Email, request.Telefone, request.Rua, request.Numero, request.Bairro, request.Cidade, request.UF, request.Imagem, request.Categoria);

        context.Contatos.Add(novoContato);

        await context.SaveChangesAsync();

        return Results.Ok(novoContato);
    }

    public static async Task<IResult> RetornarTodosContatos(AppDbContext context)
    {
        var contatos = await context.Contatos.ToListAsync();

        return contatos is null ? Results.NotFound(new { message = "Não há contatos cadastrados." }) : Results.Ok(contatos);
    }

    public static async Task<IResult> RetornarContatoPorNome(string nome, AppDbContext context)
    {
        var contato = await context.Contatos.SingleOrDefaultAsync(c => c.Nome.Contains(nome));

        return contato is null ? Results.NotFound(new { message = "Contato não encontrado." }) : Results.Ok(contato);
    }

    public static async Task<IResult> AtualizarContato(int id, AddContatoRequest request, AppDbContext context, IMapper mapper)
    {
        var contato = await context.Contatos.SingleOrDefaultAsync(c => c.Id == id);

        if (contato is null)
            return Results.NotFound(new { message = "Contato não encontrado." });

        mapper.Map(request, contato);

        await context.SaveChangesAsync();

        return Results.Ok(contato);
    }

    public static async Task<IResult> DeletarContato(int id, AppDbContext context)
    {
        var contato = await context.Contatos.SingleOrDefaultAsync(c => c.Id == id);

        if (contato is null)
            return Results.NotFound(new { message = "Contato não encontrado." });

        context.Contatos.Remove(contato);

        await context.SaveChangesAsync();

        return Results.Ok(new { message = "Contato deletado com sucesso." });
    }

    public static IResult RetornarCategorias()
    {
        var categorias = CategoriaEnumHelper.ObterDescricoesDeTodosEnum();

        return Results.Ok(categorias);
    }
}