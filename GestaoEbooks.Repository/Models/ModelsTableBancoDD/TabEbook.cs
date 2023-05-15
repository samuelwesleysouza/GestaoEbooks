using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbooks.Repository.Models.ModelsTableBancoDD
{
    public class TabEbook
    {
        public int id { get; set; }
        public string livros { get; set; }
        public int idUsuario { get; set; }
        public DateTime DATACAD { get; set; }

    }
}

