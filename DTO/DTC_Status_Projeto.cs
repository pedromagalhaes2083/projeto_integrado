using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTC_Status_Projeto
    {
        // Em andamento, Cancelado ou Finalizado
        public static string Em_Andamento => "EM ANDAMENTO";
        public static string Cancelado => "CANCELADO";
        public static string Finalizado => "FINALIZADO";
    }
}
