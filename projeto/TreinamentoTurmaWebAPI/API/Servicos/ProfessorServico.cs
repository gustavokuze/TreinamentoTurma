using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos
{
    public class ProfessorServico : IProfessorServico
    {
        private IProfessorRepositorio _professorRepositorio { get; set; }
        private IUsuarioServico _usuarioServico { get; set; }

        public ProfessorServico(IProfessorRepositorio professorRepositorio, IUsuarioServico usuarioService)
        {
            _professorRepositorio = professorRepositorio;
            _usuarioServico = usuarioService;
        }
        
        public void Atualizar(Professor professor)
        {
            _professorRepositorio.Atualizar(professor);
        }

        public void Excluir(int id)
        {
            _professorRepositorio.Excluir(id);
            _usuarioServico.Excluir(id);
        }

        public void Cadastrar(Professor professor)
        {
            professor.Id = _usuarioServico.Inserir(professor as Usuario);

            _professorRepositorio.Inserir(professor);
        }

        public Resultado<Professor, Falha> ObterPeloCpf(string cpf)
        {
            var resultado = _professorRepositorio.ObterPeloCpf(cpf);
            if (resultado == null) return new Falha("Nenhum professor encontrado");
            return resultado;
        }

        public Resultado<Professor, Falha> ObterPeloIdUsuario(int id)
        {
            var resultado = _professorRepositorio.ObterPeloIdUsuario(id);
            if (resultado == null) return new Falha("Nenhum professor encontrado");
            return resultado;
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            return _professorRepositorio.ListarProfessores();
        }
    }
}
