using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbook.Aplication.Models.ModelsRequest
{
    public class CadastroRequest
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string role { get; set; }
    }
}