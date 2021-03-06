using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Coautor
    {
        public int int_ID { get; set; }
        public int int_ID_Artigo { get; set; } // chamar da outra class Artigo - obrigatório
        public string str_Nome { get; set; }
        public string str_Email { get; set; }
    }
}
