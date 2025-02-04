namespace MeusContatos.Api.Agenda;

public static class AgendaContatosRotas
{
    public static void AddContatos(this WebApplication app)
    {
        var rotasContato = app.MapGroup("contatos");

        rotasContato.MapPost("", AgendaContatosHandler.AdicionarContato).WithSummary("Adiciona um novo contato");

        rotasContato.MapGet("", AgendaContatosHandler.RetornarTodosContatos).WithSummary("Retorna todos os contatos");

        rotasContato.MapGet("nome/{nome}", AgendaContatosHandler.RetornarContatoPorNome).WithSummary("Retorna um contato pelo nome");

        rotasContato.MapPut("{id}", AgendaContatosHandler.AtualizarContato).WithSummary("Editar um contato");

        rotasContato.MapDelete("{id}", AgendaContatosHandler.DeletarContato).WithSummary("Deletar um contato");


        rotasContato.MapGet("categorias", AgendaContatosHandler.RetornarCategorias).WithSummary("Retorna todas as categorias");
    }
}