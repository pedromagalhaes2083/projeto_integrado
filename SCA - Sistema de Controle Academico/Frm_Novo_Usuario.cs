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
    public partial class Frm_Novo_Usuario : MetroForm
    {
        public Frm_Novo_Usuario()
        {
            InitializeComponent();
        }
        // Modelos
        private DTO_Usuario Usuario()
        {
            DTO_Usuario dto_usuario = new DTO_Usuario();
            dto_usuario.str_Nome = txt_nome.Text;
            dto_usuario.str_Login = txt_login.Text;
            dto_usuario.str_Senha = txt_senha.Text;

            return dto_usuario;
        }
        private DTB_Consulta Disponibilidade(string login)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Usuario;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"User_Login LIKE '{login}'";

            return dtb_consulta;
        }
        // Validacoes
        private bool Validar_Senha(string senha, string confirm) => senha.Equals(confirm);
        private bool Validar_Usuario(DTO_Usuario dto_usuario) => TST_Usuario.Validar_Modelo(dto_usuario);
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Cadastrar_Usaurio(DTO_Usuario dto_usuario) => new Usuario().Fpu_Insert(dto_usuario);
        // Operacoes
        private void Limpar()
        {
            txt_confirm_senha.Text = string.Empty;
            txt_login.Text = string.Empty;
            txt_nome.Text = string.Empty;
            txt_senha.Text = string.Empty;
        }
        private void Cadastrar(DTO_Usuario dto_usuario)
        {
            if (Validar_Usuario(dto_usuario))
            {
                Cadastrar_Usaurio(dto_usuario);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                Limpar();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        private bool Consultar_Disponibilidade(DTB_Consulta dtb_consulta) => !Validar_DataTable(Consultar_Banco(dtb_consulta));
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (Consultar_Disponibilidade(Disponibilidade(txt_login.Text)))
            {
                if (Validar_Senha(txt_senha.Text, txt_confirm_senha.Text))
                    Cadastrar(Usuario());
                else
                    MessageBox.Show(USER_MESSAGE.Senha_Nao_Coincedem);
            }
            else
                MessageBox.Show(USER_MESSAGE.Login_Indisponivel);
        }
    }
}
