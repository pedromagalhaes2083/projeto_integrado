using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Coautor : DTO_Coautor
    {
        public static bool Validar_Modelo(DTO_Coautor dto_coautor)
        {
            if (!(dto_coautor is null))
                return Fpr_Validar_Modelo(dto_coautor);
            else
                throw new ArgumentNullException(nameof(dto_coautor));
        }
        private static bool Fpr_Validar_Modelo(DTO_Coautor dto_coautor)
        {
            if (dto_coautor.int_ID_Artigo <= 0)
                return false;
            else if (string.IsNullOrWhiteSpace(dto_coautor.str_Nome))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_coautor.str_Email))
                return false;
            else
                return true;
        }
    }
}
