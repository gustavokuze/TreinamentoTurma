using System.Collections.Generic;
using System.Net;

namespace TreinamentoTurma.Helpers.Retornos.API
{
    public class Sucesso<T>
    {
        public Sucesso(T sucessoObj, HttpStatusCode codigoStatus = HttpStatusCode.OK)
        {
            Objeto = sucessoObj;
            CodigoStatus = codigoStatus;
        }

        //public Sucesso(IEnumerable<T> sucessoObjs, HttpStatusCode codigoStatus)
        //{
        //    Objetos = sucessoObjs;
        //    CodigoStatus = codigoStatus;
        //}

        public T Objeto{ get; set; }
        //public IEnumerable<T> Objetos { get; set; }
        public HttpStatusCode CodigoStatus { get; set; }
    }
}