using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TST
{
    public class TST_Projeto : DTO_Projeto
    {
        public static bool Validar_Modelo(DTO_Projeto dto_projeto)
        {
            if (!(dto_projeto is null))
                return Fpr_Validar_Modelo(dto_projeto);
            else
                throw new ArgumentNullException(nameof(dto_projeto));
        }
        private static bool Fpr_Validar_Modelo(DTO_Projeto dto_projeto)
        {
            if (dto_projeto.int_ID_Responsavel <= 0)
                return false;
            else if (!(dto_projeto.dte_Data_Inicio != null))
                return false;
            else if (!(dto_projeto.dte_Data_Final != null))
                return false;
            else if (string.IsNullOrWhiteSpace(dto_projeto.str_Situacao))
                return false;
            else
                return true;
        }
    }
}
