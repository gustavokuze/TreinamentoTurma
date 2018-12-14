using API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface ILoginServico
    {
        Uteis.Retornos.Validacao.Resultado<AutenticacaoUsuario, Uteis.Retornos.Validacao.Falha> Autenticar(int codigo, string senha);
    }
}
