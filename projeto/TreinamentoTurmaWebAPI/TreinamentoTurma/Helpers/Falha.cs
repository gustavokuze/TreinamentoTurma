﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Helpers
{
    public class Falha
    {
        public Falha(string erro)
        {
            Erro = erro;
        }

        public string Erro { get; set; }
    }
}