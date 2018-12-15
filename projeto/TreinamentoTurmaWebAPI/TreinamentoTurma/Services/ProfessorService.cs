using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using Falha = TreinamentoTurma.Helpers.Retornos.Validacao.Falha;

namespace TreinamentoTurma.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        public ProfessorService()
        {
            UsuarioAtual = Login.ObterUsuarioAtual();
            if (UsuarioAtual == null)
            {
                TokenValido = "";
            }
            else
            {
                TokenValido = RequisitarToken(UsuarioAtual.Usuario.Codigo, UsuarioAtual.Usuario.Senha);
            }
        }

        public Resultado<Professor, Falha> Atualizar(Professor professor)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.PUT, professor, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Usuario, Falha> Cadastrar(Professor professor)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Retorno<Usuario, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.POST, professor, TokenValido).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<int, Falha> Excluir(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}", RestSharp.Method.DELETE, null, TokenValido).Content);
            if (response.Sucesso != null && response.Sucesso.Objeto > 0)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha("Erro ao excluir");
            }
        }

        public Resultado<IEnumerable<Professor>, Falha>  ListarProfessores()
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            List<Professor> professores = new List<Professor>();

            var response = JsonConvert.DeserializeObject<Retorno<List<Professor>, Falha> >( RequisitarAPI("professor", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso != null) professores = response.Sucesso.Objeto;
            return professores;
        }

        public Resultado<Professor, Falha> ObterPeloCpf(string cpf)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/obter/{cpf}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Professor, Falha> ObterPeloIdUsuario(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            //var authUsuario = new AutenticacaoUsuario() { Usuario = usuario };
            //var resultado = JsonConvert.DeserializeObject < Retorno < Professor, Helpers.Retornos.API.Falha >>( RequisitarAPI("login/autenticar", RestSharp.Method.POST, authUsuario).Content);
            //if (resultado.Sucesso.Objeto != null) return new Falha("Senha ou codigo incorretos");
            //var usuarioAutenticado = new UsuarioService().Autenticar(usuario );
            //if (!usuarioAutenticado.EstaValido) return new Falha("Codigo ou senha incorretos");

            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}", RestSharp.Method.GET, null, TokenValido).Content);
            if(response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }
        
    }
}