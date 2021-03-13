using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using DTO;
using BLL;
using TST;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class OPR_Exclusao_Usuario : MetroForm
    {
        public OPR_Exclusao_Usuario(int id)
        {
            InitializeComponent();
            this.id_usuario = id;
        }
        int id_usuario = 0;
        private DTO_Usuario Usuario(int id)
        {
            DTO_Usuario dto_usuario = new DTO_Usuario();
            dto_usuario.int_ID = id;
            dto_usuario.str_Login = txt_login.Text;
            dto_usuario.str_Senha = txt_senha.Text;

            return dto_usuario;
        }
        private DTB_Consulta Consulta_Usuario(int id_usuario)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Usuario;
            dtb_consulta.str_Parametros = "ID, User_Login";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {id_usuario}";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => dt_table.Rows.Count > 0 ? true : false;
        // Operaceos >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta) => new Consulta().Consultar(dtb_consulta);
        private void Prencher(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
                txt_login.Text = Table_String(dt_table, "User_Login");
            else
                this.Close();
        }
        private bool Verificar_Identidade(DTO_Usuario dto_usuario) => new Login().Efetuar_Login(dto_usuario);
        private void Excluir_Usuario(DTO_Usuario dto_usuario) => new Usuario().Fpu_Delete(dto_usuario);
        // Operacoes
        private string Table_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_Usuario(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                Prencher(dtb_consulta);
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        private void Excluir(DTO_Usuario dto_usuario)
        {
            if (Verificar_Identidade(dto_usuario))
            {
                Excluir_Usuario(dto_usuario);
                MessageBox.Show(USER_MESSAGE.Sucesso);
            }
            else
                MessageBox.Show(USER_MESSAGE.Credenciais_Invalidas);
        }
        // Button
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_senha.Text))
                Excluir(Usuario(this.id_usuario));
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
            this.Close();
        }
        private void btn_close_Click(object sender, EventArgs e) => this.Close();
        private void OPR_Exclusao_Usuario_Load(object sender, EventArgs e)
        {
            Prencher_Usuario(Consulta_Usuario(this.id_usuario));
        }
    }
}
