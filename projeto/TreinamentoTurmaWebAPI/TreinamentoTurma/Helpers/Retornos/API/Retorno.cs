using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TreinamentoTurma.Helpers.Retornos.API
{
    public struct Retorno<TSucesso, TFalha>
    {
        internal Retorno(TSucesso sucesso, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Sucesso = new Sucesso<TSucesso>(sucesso, statusCode);
            Falha = default(TFalha);
        }
        
        internal Retorno(TFalha falha, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Falha = falha;
            Sucesso = new Sucesso<TSucesso>(default(TSucesso), statusCode);
        }

        public Sucesso<TSucesso> Sucesso { get; set; }
        public TFalha Falha { get; set; }

        public static implicit operator Retorno<TSucesso, TFalha>(TSucesso sucesso)
            => new Retorno<TSucesso, TFalha>(sucesso);

        public static implicit operator Retorno<TSucesso, TFalha>(TFalha falha)
            => new Retorno<TSucesso, TFalha>(falha);
    }
}
