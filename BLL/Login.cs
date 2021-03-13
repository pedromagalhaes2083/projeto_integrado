using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using BLL;
using TST;

namespace BLL
{
    public class Login
    {
        // Modelo >> DTB
        private DTB_Consulta Consulta_Usuario(DTO_Usuario dto_usuario)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Usuario;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"User_Login like '{dto_usuario.str_Login}' and Senha like '{dto_usuario.str_Senha}'";

            return dtb_consulta;
        }
        // Validacao
        private bool Validar_Login(DTO_Usuario dto_usuario) => TST_Login.Validar_Login(dto_usuario);
        private bool Validar_DataTable(DataTable dt_table) => dt_table.Rows.Count > 0 ? true : false;
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta) => new Consulta().Consultar(dtb_consulta);
        // Operacoes
        public bool Efetuar_Login(DTO_Usuario dto_usuario)
        {
            if (!(dto_usuario is null) && Validar_Login(dto_usuario))
                return Fpr_Efetuar_Login(dto_usuario);
            else
                throw new ArgumentNullException(nameof(dto_usuario));
        }
        private bool Fpr_Efetuar_Login(DTO_Usuario dto_usuario)
        {
            DataTable dt_table = Consultar_Banco(Consulta_Usuario(dto_usuario));
            return Validar_DataTable(dt_table);
        }
    }
}
