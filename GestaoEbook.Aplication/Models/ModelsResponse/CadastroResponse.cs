﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbook.Aplication.Models.ModelsResponse
{
    public class CadastroResponse
    {
        public string nome { get; set; }

        public string email { get; set; }

        public string mensagem { get; set; }


        public string? usuario { get; set; }

    }
}