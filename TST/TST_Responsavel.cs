using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Responsavel : DTO_Responsavel
    {
        public static bool Validar_Modelo(DTO_Responsavel dto_responsavel)
        {
            if (!(dto_responsavel is null))
                return Fpr_Validar_Modelo(dto_responsavel);
            else
                throw new ArgumentNullException(nameof(dto_responsavel));
        }
        private static bool Fpr_Validar_Modelo(DTO_Responsavel dto_responsavel)
        {
            if (string.IsNullOrWhiteSpace(dto_responsavel.str_Nome))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_responsavel.str_Email))
                return false;
            else
                return true;
        }
    }
}
