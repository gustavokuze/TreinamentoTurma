using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Uteis.Retornos.Validacao
{
    //Container
    public struct Resultado<TSucesso, TFalha>
    {
        //Construtor de sucesso
        internal Resultado(TSucesso sucesso)
        {
            Sucesso = sucesso;
            Falha = default(TFalha);
            EstaValido = true;
        }
         
        //Construtor de falha
        internal Resultado(TFalha falha)
        {
            Falha = falha; 
            Sucesso = default(TSucesso);
            EstaValido = false;
        }

        public TSucesso Sucesso { get; set; }
        public TFalha Falha { get; set; }
        public bool EstaValido { get; }

        public static implicit operator Resultado<TSucesso, TFalha>(TSucesso sucesso)
            => new Resultado<TSucesso, TFalha>(sucesso);

        public static implicit operator Resultado<TSucesso, TFalha>(TFalha falha)
            => new Resultado<TSucesso, TFalha>(falha);
    }
}