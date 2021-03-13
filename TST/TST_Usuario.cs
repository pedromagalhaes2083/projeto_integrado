using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Usuario
    {
        public static bool Validar_Modelo(DTO_Usuario dto_usuario)
        {
            if (!(dto_usuario is null))
                return Fpr_Validar_Modelo(dto_usuario);
            else
                throw new ArgumentNullException(nameof(dto_usuario));
        }
        private static bool Fpr_Validar_Modelo(DTO_Usuario dto_usuario)
        {
            if (string.IsNullOrWhiteSpace(dto_usuario.str_Nome))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_usuario.str_Login))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_usuario.str_Senha))
                return false;
            else
                return true;
        }
    }
}
