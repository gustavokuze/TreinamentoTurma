using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Formata o retorno da controller filha para encaminhar o StatusCode de sucesso ou erro com o respectivo objeto
        /// </summary>
        /// <typeparam name="T">O tipo do objeto de retorno de sucesso.</typeparam>
        /// <param name="objeto">Objeto de sucesso. Pode ser um objeto vazio em caso de falha.</param>
        /// <param name="mensagemFalha">Mensagem que será retornada na propriedade Mensagem do objeto de Falha</param>
        /// <returns>Retorno<Sucesso> ou Retorno<Falha>. Sempre define o Response.StatusCode para a controller filha</returns>
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