using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Consulta : DTB_Consulta
    {
        public static bool Validar_Modelo(DTB_Consulta dtb_consulta)
        {
            if (!(dtb_consulta is null))
                return Fpr_Validar_Modelo(dtb_consulta);
            else
                throw new ArgumentNullException(nameof(dtb_consulta));
        }
        private static bool Fpr_Validar_Modelo(DTB_Consulta dtb_consulta)
        {
            if (string.IsNullOrWhiteSpace(dtb_consulta.str_Tabela))
                return false;
            else if (string.IsNullOrWhiteSpace(dtb_consulta.str_Parametros))
                return false;
            else
                return true;
        }
    }
}
