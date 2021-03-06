using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TCC
    {
        public int int_ID { get; set; }
        public int int_ID_Projeto { get; set; } // chamar da outra class Projeto
        public string str_Titulo { get; set; }
        public string str_Nome { get; set; }
        public string str_Situacao { get; set; } // desenvolvimento, Defendido ou Abandonado - padrão em desenvolvimento
    }
}
