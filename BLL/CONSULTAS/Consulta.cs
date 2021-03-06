using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Windows.Forms;

namespace BLL
{
    public class Consulta : Retorno_Consulta
    {
        public DataTable Consultar(DTB_Consulta dtb_consulta)
        {
            try
            {
                if (dtb_consulta.str_Condicao is null)
                    return Fpr_Retornar_Consulta(dtb_consulta);
                else
                    return Fpr_Retornar_Consulta_Condicao(dtb_consulta);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ERRO_MESSAGE.Erro_Consultar + ex.Message);
                return null;
            }
        }
        public DataTable Consultar_Left_Join(DTB_Consulta dtb_consulta)
        {
            try
            {
                if (dtb_consulta.str_Condicao is null)
                    return Fpr_Consulta_Left_Join(dtb_consulta);
                else
                    return Fpr_Consulta_Left_Joint_Condicao(dtb_consulta);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ERRO_MESSAGE.Erro_Consultar + ex.Message);
                return null;
            }
        }
        private static DataTable Fpr_Retornar_Consulta(DTB_Consulta consulta)
        {
            if (!(consulta is null))
            {
                string str_Command = $"Select {consulta.str_Parametros} from {consulta.str_Tabela} order by {consulta.str_Parametro_Ordenador} DESC";
                return Fpt_Retornar_DataTable(str_Command);
            }
            else
                throw new ArgumentNullException(nameof(consulta));
        }
        private static DataTable Fpr_Retornar_Consulta_Condicao(DTB_Consulta consulta)
        {
            if (!(consulta is null))
            {
                string str_Command = $"Select {consulta.str_Parametros} from {consulta.str_Tabela} where {consulta.str_Condicao} order by {consulta.str_Parametro_Ordenador} DESC";
                return Fpt_Retornar_DataTable(str_Command);
            }
            else
                throw new ArgumentNullException(nameof(consulta));
        }
        private static DataTable Fpr_Consulta_Left_Join(DTB_Consulta dtb_consulta)
        {
            if (!(dtb_consulta is null))
            {
                string str_Command = $"SELECT {dtb_consulta.str_Parametros}  FROM {dtb_consulta.str_Tabela} LEFT JOIN {dtb_consulta.str_Tabela_Secundaria} ON {dtb_consulta.str_On_Join}";
                return Fpt_Retornar_DataTable(str_Command);
            }
            else
                throw new ArgumentException(nameof(dtb_consulta));
        }
        private static DataTable Fpr_Consulta_Left_Joint_Condicao(DTB_Consulta dtb_consulta)
        {
            if (!(dtb_consulta is null))
            {
                string str_Command = $"SELECT {dtb_consulta.str_Parametros}  FROM {dtb_consulta.str_Tabela} LEFT JOIN {dtb_consulta.str_Tabela_Secundaria} ON {dtb_consulta.str_On_Join} WHERE {dtb_consulta.str_Condicao}";
                return Fpt_Retornar_DataTable(str_Command);
            }
            else
                throw new ArgumentException(nameof(dtb_consulta));
        }
    }
}
