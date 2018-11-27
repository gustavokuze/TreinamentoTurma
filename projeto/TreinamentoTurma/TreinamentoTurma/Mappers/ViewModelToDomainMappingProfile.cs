using AutoMapper;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Mappers
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TurmaViewModel, Turma>();
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<ProfessorViewModel, Professor>();
        }
    }
}