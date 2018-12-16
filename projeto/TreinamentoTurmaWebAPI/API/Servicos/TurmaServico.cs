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
    public class TurmaServico : ITurmaServico
    {
        public ITurmaRepositorio _turmaRepositorio { get; }
        public TurmaServico(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        public void Atualizar(Turma turma)
        {
            _turmaRepositorio.Atualizar(turma);
        }

        public int Cadastrar(Turma turma)
        {
            return _turmaRepositorio.Inserir(turma);
        }

        public void Excluir(int id)
        {
            _turmaRepositorio.ExcluirInscricoesPeloTurmaId(id);
            _turmaRepositorio.Excluir(id);
        }

        public IEnumerable<Turma> ListarTurmas()
        {
            return _turmaRepositorio.ListarTurmas();
        }
        
        public Resultado<Turma, Falha> ObterPeloId(int id)
        {
            var resultado = _turmaRepositorio.ObterPeloId(id);
            if (resultado == null) return new Falha("Nenhuma turma encontrada"); return resultado;
        }

        public Resultado<Inscricao, Falha> ObterIncricao(int alunoId, int turmaId)
        {
            var resultado = _turmaRepositorio.ObterInscricao(alunoId, turmaId);
            if (resultado == null) return new Falha("Nenhuma inscrição encontrada"); return resultado;
        }

        public Resultado<Inscricao, Falha> CadastrarInscricao(Inscricao inscricao)
        {
            if(_turmaRepositorio.ObterInscricao(inscricao.AlunoId, inscricao.TurmaId) == null)
            {
                var inscricoes = _turmaRepositorio.ListarInscricoesPeloTurmaId(inscricao.TurmaId);
                var turma = _turmaRepositorio.ObterPeloId(inscricao.TurmaId);
                if (inscricoes.Count() < turma.LimiteAlunos)
                {
                    _turmaRepositorio.InserirInscricao(inscricao);
                    return inscricao;
                }
                return new Falha("A turma já atingiu o limite de alunos");
            }
            else
            {
                return new Falha("O aluno já está inscrito na turma");
            }
        }

        public void ExcluirInscricao(int id)
        {
            _turmaRepositorio.ExcluirInscricao(id);
        }

        public Resultado<Inscricao, Falha> ObterPeloAlunoId(int id)
        {
            var resultado = _turmaRepositorio.ObterInscricaoPeloAlunoId(id);
            if (resultado == null) return new Falha("Nenhuma inscrição encontrada"); return resultado;
        }

        public void ExcluirInscricoesPeloAlunoId(int alunoId)
        {
            _turmaRepositorio.ExcluirInscricoesPeloAlunoId(alunoId);
        }

        public IEnumerable<Inscricao> listarInscricoesPeloAlunoId(int id)
        {
            return _turmaRepositorio.ListarInscricoesPeloAlunoId(id);
        }
    }
}
