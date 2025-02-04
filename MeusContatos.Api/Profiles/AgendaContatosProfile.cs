using AutoMapper;
using MeusContatos.Api.Agenda;
using MeusContatos.Api.Entidades;

namespace MeusContatos.Api.Profiles;

public class AgendaContatosProfile : Profile
{
    public AgendaContatosProfile()
    {
        CreateMap<Contato, AddContatoRequest>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}