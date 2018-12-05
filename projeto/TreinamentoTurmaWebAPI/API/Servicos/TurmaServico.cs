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
            var resultado = _turmaRepositorio.ObterIncricao(alunoId, turmaId);
            if (resultado == null) return new Falha("Nenhuma inscrição encontrada"); return resultado;
        }

        public void CadastrarInscricao(Inscricao inscricao)
        {
            _turmaRepositorio.InserirInscricao(inscricao);
        }

        public void ExcluirInscricao(int id)
        {
            _turmaRepositorio.ExcluirInscricao(id);
        }

        public Resultado<Inscricao, Falha> ObterPeloAlunoId(int id)
        {
            var resultado = _turmaRepositorio.ObterIncricaoPeloAlunoId(id);
            if (resultado == null) return new Falha("Nenhuma inscrição encontrada"); return resultado;
        }

        public Resultado<Inscricao, Falha> ObterPeloTurmaId(int id)
        {
            var resultado = _turmaRepositorio.ObterIncricaoPeloTurmaId(id);
            if (resultado == null) return new Falha("Nenhuma inscrição encontrada"); return resultado;
        }
    }
}
