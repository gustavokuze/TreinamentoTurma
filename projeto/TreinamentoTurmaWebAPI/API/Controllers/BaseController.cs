using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Retorno<T, Falha> FormataRetorno<T>(T objeto, string mensagemFalha = "") //bool valido substituido pela existencia da msg de falha
        {
            if (mensagemFalha == string.Empty || mensagemFalha == null)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new Retorno<T, Falha>(objeto, (HttpStatusCode)Response.StatusCode);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new Retorno<T, Falha>(new Falha(mensagemFalha), (HttpStatusCode)Response.StatusCode);
            }
        }
    }
}