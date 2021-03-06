using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Projeto
    {
        public int int_ID { get; set; }
        public int int_ID_Responsavel { get; set; } // chamar da outra class Resp_Cadastro
        public string str_Titulo { get; set; }
        public DateTime dte_Data_Inicio { get; set; }
        public DateTime dte_Data_Final { get; set; }
        public string str_Situacao { get; set; } // Em andamento, Cancelado ou Finalizado - padrão em Andamento 
    }
}
