﻿using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Retornos.Validacao;
using System;
using System.Collections.Generic;

namespace API.Servicos
{
    public class ProfessorServico : IProfessorServico
    {
        private IProfessorRepositorio _professorRepositorio { get; }
        private IUsuarioServico _usuarioServico { get; }

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

        public Resultado<Usuario, Falha> Cadastrar(Professor professor)
        {
            try
            {
                var usuario = _usuarioServico.Inserir(professor as Usuario);

                if (usuario.EstaValido)
                {
                    professor.Id = usuario.Sucesso.Id;

                    _professorRepositorio.Inserir(professor);
                    return usuario.Sucesso;
                }
                else
                {
                    return usuario.Falha;
                }


            }
            catch (Exception ex)
            {
                return new Falha(ex.Message);
            }
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
