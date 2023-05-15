using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbooks.Repository.Models.ModelsTableBancoDD
{
    public class TabUsuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string role { get; set; }
        
        public string email { get; set; }

    }

}
