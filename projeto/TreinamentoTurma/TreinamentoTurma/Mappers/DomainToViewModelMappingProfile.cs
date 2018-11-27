using AutoMapper;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Mappers
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Turma, TurmaViewModel>();
        }
    }
}