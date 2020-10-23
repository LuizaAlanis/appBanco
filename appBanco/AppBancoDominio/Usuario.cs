using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Usuario
    {
        public int cd_usuario { get; set; }
        public string nm_usuario { get; set; }
        public string ds_cargo { get; set; }
        public DateTime dt_nascimento { get; set; }
    }
}

