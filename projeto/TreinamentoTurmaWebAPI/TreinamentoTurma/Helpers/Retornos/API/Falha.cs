using System.Net;

namespace TreinamentoTurma.Helpers.Retornos.API
{
    public class Falha
    {
        public Falha(string msg, HttpStatusCode codigoStatus = HttpStatusCode.BadRequest)
        {
            Mensagem = msg;
            CodigoStatus = codigoStatus;
        }

        public string Mensagem { get; set; }
        public HttpStatusCode CodigoStatus { get; set; }
    }
}