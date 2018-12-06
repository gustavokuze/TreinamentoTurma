using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis;
using API.Uteis.Retornos.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private IAlunoRepositorio _alunoRepositorio { get; set; }
        private IUsuarioServico _usuarioService { get; set; }
        private ITurmaServico _turmaServico { get; set; }

        public AlunoServico(IAlunoRepositorio alunoRepositorio, IUsuarioServico usuarioService, ITurmaServico turmaServico)
        {
            _alunoRepositorio = alunoRepositorio;
            _usuarioService = usuarioService;
            _turmaServico = turmaServico;
        }
        
        public void Atualizar(Aluno aluno)
        {
            _alunoRepositorio.Atualizar(aluno);
        }

        public void Excluir(int id)
        {
            _turmaServico.ExcluirInscricoesPeloAlunoId(id);
            _alunoRepositorio.Excluir(id);
            _usuarioService.Excluir(id);
        }

        public void Cadastrar(Aluno aluno)
        {
            aluno.Id = _usuarioService.Inserir(aluno as Usuario);

            _alunoRepositorio.Inserir(aluno);
        }

        public Resultado<Aluno, Falha> ObterPeloEmail(string email)
        {
            var resultado = _alunoRepositorio.ObterPeloEmail(email);
            if (resultado == null) return new Falha("Nenhum aluno encontrado");
            return resultado;
        }

        public Resultado<Aluno, Falha> ObterPeloIdUsuario(int id)
        {
            var resultado = _alunoRepositorio.ObterPeloIdUsuario(id);
            if (resultado == null) return new Falha("Nenhum aluno encontrado");
            return resultado;
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            return _alunoRepositorio.ListarAlunos();
        }
    }
}
