using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_TCC : DTO_TCC
    {
        public static bool Validar_Modelo(DTO_TCC dto_tcc)
        {
            if (!(dto_tcc is null))
                return Fpr_Validar_Modelo(dto_tcc);
            else
                throw new ArgumentNullException(nameof(dto_tcc));
        }
        private static bool Fpr_Validar_Modelo(DTO_TCC dto_tcc)
        {
            if (dto_tcc.int_ID_Projeto <= 0)
                return false;
            else if (string.IsNullOrWhiteSpace(dto_tcc.str_Titulo))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_tcc.str_Nome))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_tcc.str_Situacao))
                return false;
            else
                return true;
        }
    }
}
