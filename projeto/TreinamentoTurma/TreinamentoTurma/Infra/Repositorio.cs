using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Infra 
{
    public class Repositorio
    {
        protected string ObterConnectionString { get { return ConfigurationManager.ConnectionStrings["treinamento_rca"].ConnectionString; } } 
    }
}

/*
    


    ConnectionString da RCA:
    <connectionStrings>
        <add name="treinamento" connectionString="Database=treinamento; Data Source=RCA179;Integrated Security=True"/>
    </connectionStrings>

    Minha:
    <connectionStrings>
    <add name="treinamento" connectionString="Data Source=DESKTOP-DPFR0A0;Initial Catalog=treinamento;User ID=sa"/>
  </connectionStrings>
     
*/
