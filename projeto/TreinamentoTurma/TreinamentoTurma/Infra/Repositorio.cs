using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Infra
{
    public class Repositorio
    {
        protected string ObterConnectionString { get { return ConfigurationManager.ConnectionStrings["treinamento"].ConnectionString; } }
    }
}