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
        private IAlunoRepositorio _alunoRepositorio { get; }
        private IUsuarioServico _usuarioServico { get; }
        private ITurmaServico _turmaServico { get; }

        public AlunoServico(IAlunoRepositorio alunoRepositorio, IUsuarioServico usuarioServico, ITurmaServico turmaServico)
        {
            _alunoRepositorio = alunoRepositorio;
            _usuarioServico = usuarioServico;
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
            _usuarioServico.Excluir(id);
        }

        public Resultado<Usuario, Falha> Cadastrar(Aluno aluno)
        {
            try
            {
                var usuario = _usuarioServico.Inserir(aluno as Usuario);
                aluno.Id = usuario.Sucesso.Id;

                _alunoRepositorio.Inserir(aluno);
                return usuario.Sucesso;
            }
            catch (Exception ex)
            {
                return new Falha(ex.Message);
            }
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
