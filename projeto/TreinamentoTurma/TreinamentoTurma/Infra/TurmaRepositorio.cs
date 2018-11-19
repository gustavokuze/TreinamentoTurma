using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class TurmaRepositorio : Repositorio 
    {
        public void Novo(Turma turma)
        {
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Query<bool>("select 1;");

            }
        }
    }
}