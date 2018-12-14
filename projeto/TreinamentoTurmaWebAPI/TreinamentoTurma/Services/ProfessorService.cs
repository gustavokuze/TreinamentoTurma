using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
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
            var usuarioAtual = HttpContext.Current.Session["TreinamentoTurmaUsuarioAtual"] as AutenticacaoUsuario;
            if (usuarioAtual == null)
            {
                TokenValido = "";
            }
            else
            {
                TokenValido = RequisitarToken(usuarioAtual.Usuario.Codigo, usuarioAtual.Usuario.Senha);
            }
        }

        public Resultado<Professor, Falha> Atualizar(Professor professor)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.PUT, professor).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<Usuario, Falha> Cadastrar(Professor professor)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Usuario, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.POST, professor).Content);
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
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}", RestSharp.Method.DELETE).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<int, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<int, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            List<Professor> professores = new List<Professor>();

            var response = JsonConvert.DeserializeObject<Retorno<List<Professor>, Falha> >( RequisitarAPI("professor").Content);
            if (response.Sucesso != null) professores = response.Sucesso.Objeto;
            return professores;
        }

        public Resultado<Professor, Falha> ObterPeloCpf(string cpf)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/obter/{cpf}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto == null || TokenValido == "")
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
            else
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
        }

        public Resultado<Professor, Falha> ObterPeloIdUsuario(int id)
        {
            //var authUsuario = new AutenticacaoUsuario() { Usuario = usuario };
            //var resultado = JsonConvert.DeserializeObject < Retorno < Professor, Helpers.Retornos.API.Falha >>( RequisitarAPI("login/autenticar", RestSharp.Method.POST, authUsuario).Content);
            //if (resultado.Sucesso.Objeto != null) return new Falha("Senha ou codigo incorretos");
            //var usuarioAutenticado = new UsuarioService().Autenticar(usuario );
            //if (!usuarioAutenticado.EstaValido) return new Falha("Codigo ou senha incorretos");

            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}", RestSharp.Method.GET, null, TokenValido).Content);
            if(response.Sucesso == null || TokenValido == "")
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }
        
    }
}