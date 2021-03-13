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
using TST;
using BLL;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Frm_Alter_Usuario : MetroForm
    {
        public Frm_Alter_Usuario(int id)
        {
            InitializeComponent();
            this.id_usuario = id;
        }
        int id_usuario = 0;
        // Modelos >> DTO
        private DTB_Consulta Consulta_Usuario(int id)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Usuario;
            dtb_consulta.str_Parametros = "Nome, User_Login";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {id}";

            return dtb_consulta;
        }
        private DTO_Usuario Usuario()
        {
            DTO_Usuario dto_usuario = new DTO_Usuario();
            dto_usuario.int_ID = this.id_usuario;
            dto_usuario.str_Nome = txt_nome.Text;
            dto_usuario.str_Login = txt_login.Text;
            dto_usuario.str_Senha = txt_senha.Text;

            return dto_usuario;
        }
        private DTO_Usuario Usuario_Login()
        {
            DTO_Usuario dto_usuario = new DTO_Usuario();
            dto_usuario.str_Login = txt_login.Text;
            dto_usuario.str_Senha = txt_CSI_Senha.Text;

            return dto_usuario;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_Usuario(DTO_Usuario dto_usuario) => TST_Usuario.Validar_Modelo(dto_usuario);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Senhas(string senha, string confirm) => senha.Equals(confirm);
        // Operacoes >> BLL
        private bool Efetuar_Login(DTO_Usuario dto_usuario) => new Login().Efetuar_Login(dto_usuario);
        private void Editar_Usuario(DTO_Usuario dto_usuario)
        {
            if (Validar_Usuario(dto_usuario))
            {
                new Usuario().Fpu_Udpate(dto_usuario);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        // Operacoes
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_Dados(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                txt_nome.Text = Retornar_String(dt_table, "Nome");
                txt_login.Text = Retornar_String(dt_table, "User_Login");
            }
            else
                this.Close();
        }
        
        private void Frm_Alter_Usuario_Load(object sender, EventArgs e) => Prencher_Dados(Consulta_Usuario(this.id_usuario));
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (Validar_Senhas(txt_senha.Text, txt_confirm_senha.Text))
            {
                if (Efetuar_Login(Usuario_Login()))
                    Editar_Usuario(Usuario());
                else
                    MessageBox.Show(USER_MESSAGE.Credenciais_Invalidas);
            }
            else
                MessageBox.Show(USER_MESSAGE.Senha_Nao_Coincedem);
        }
        // Load
        private void Frm_Alter_Usuario_Load_1(object sender, EventArgs e) => Prencher_Dados(Consulta_Usuario(this.id_usuario));
    }
}