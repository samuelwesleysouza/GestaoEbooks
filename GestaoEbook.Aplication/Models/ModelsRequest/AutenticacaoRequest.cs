﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbook.Aplication.Models.ModelsRequest
{
 
        public class AutenticacaoRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            
            public string Email { get; set; }   
        }
    }

