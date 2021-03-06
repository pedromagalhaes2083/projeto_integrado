using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DTO_Artigo
    {
            public int int_ID { get; set; }
            public int int_ID_Projeto { get; set; } // chamar da outra class Projeto - opcional
            public string str_Titulo { get; set; }
            public string str_Natureza { get; set; } // Resumo ou Completo - padrão em Resumo
            public string str_Autor { get; set; }
            public string str_Email_Autor { get; set; }
    }
}
