using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbook.Aplication.Models.ModelsResponse
{

    public class AutenticacaoResponse
    {
        public string token { get; set; }

        public int UsuarioId { get; set; }
    }
}

