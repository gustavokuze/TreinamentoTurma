﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Usuario = new Usuario();
        }

        public Usuario Usuario { get; set; }
        public bool SouProfessor { get; set; }

    }
}