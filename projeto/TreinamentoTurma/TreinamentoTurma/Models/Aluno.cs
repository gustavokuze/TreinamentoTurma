﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; 
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Aluno : Usuario
    {
        internal Aluno() 
            : this(
                  string.Empty,
                  string.Empty,
                  DateTime.Now,
                  string.Empty, 
                  string.Empty){ }

        public Aluno(
            string nome,
            string email, 
            DateTime dataNascimento, 
            string telefone, 
            string endereco
        )
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Endereco = endereco;
        }

        public int Id { get; set; }

        //[Required]
        public string Nome { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Entre com um email válido")]
        // ou
        // 
        //[DataType(DataType.EmailAddress)] 
        //[Required]
        public string Email { get; set; }

        //[Editable(true)]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[Display(Name = "Data de nascimento")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        //[Required]
        //[DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        //[Required]
        //[Display(Name = "Endereço")]
        public string Endereco { get; set; } 
    }
}