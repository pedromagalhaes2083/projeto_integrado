using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Artigo : DTO_Artigo
    {
        public static bool Validar_Modelo(DTO_Artigo dto_artigo)
        {
            if (!(dto_artigo is null))
                return Fpr_Validar_Modelo(dto_artigo);
            else
                throw new ArgumentNullException(nameof(dto_artigo));
        }
        private static bool Fpr_Validar_Modelo(DTO_Artigo dto_artigo)
        {
            if (dto_artigo.int_ID_Projeto <= 0)
                return false;
            else if (string.IsNullOrWhiteSpace(dto_artigo.str_Titulo))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_artigo.str_Natureza))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_artigo.str_Autor))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_artigo.str_Email_Autor))
                return false;
            else
                return true;

        }
    }
}
