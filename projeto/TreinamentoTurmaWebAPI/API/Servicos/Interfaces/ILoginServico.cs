using API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface ILoginServico
    {
        AutenticacaoUsuario Autenticar(int codigo, string senha);
    }
}
