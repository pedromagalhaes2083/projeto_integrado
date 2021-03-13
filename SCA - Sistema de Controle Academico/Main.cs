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
using BLL;
using DTO;
using TST;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }
        int permissao = 0;
        // Login
        private DTO_Usuario Usuario()
        {
            DTO_Usuario dto_usuario = new DTO_Usuario();
            dto_usuario.str_Login = txt_login.Text;
            dto_usuario.str_Senha = txt_senha.Text;

            return dto_usuario;
        }
        private bool Login(DTO_Usuario dto_usuario) => new Login().Efetuar_Login(dto_usuario);
        private void Efetuar_Login(DTO_Usuario dto_usuario)
        {
            if (Login(dto_usuario))
            {
                MessageBox.Show(USER_MESSAGE.Login_Efetuado);
                this.txt_login.ReadOnly = true;
                this.txt_senha.ReadOnly = true;
                btn_efetuar_login.Text = "Logoff";
                btn_efetuar_login.BackColor = Color.Crimson;
                this.permissao = 1;

                Recolher_Panels();
            }
            else
                MessageBox.Show(USER_MESSAGE.Credenciais_Invalidas);
        }
        private void Efetuar_Logoff()
        {
            txt_login.Text = "";
            txt_senha.Text = "";
            this.txt_login.ReadOnly = false;
            this.txt_senha.ReadOnly = false;
            btn_efetuar_login.Text = "Login";
            btn_efetuar_login.BackColor = Color.FromArgb(0, 137, 255);
            this.permissao = 0;

            btn_efetuar_login.BackColor = Color.White;
            Recolher_Panels();
        }
        // Login -> Buttons
        private void btn_efetuar_login_Click(object sender, EventArgs e)
        {
            if (btn_efetuar_login.Text.Equals("Login"))
            {
                if (!string.IsNullOrWhiteSpace(txt_login.Text) && !string.IsNullOrWhiteSpace(txt_senha.Text))
                    Efetuar_Login(Usuario());
                else
                    MessageBox.Show(USER_MESSAGE.Credenciais_Invalidas);
            }
            else
                Efetuar_Logoff();
        }
        private void btn_lat_login_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_login);
        // Validaces 
        private bool Validar_Identificador(int i) => i > 0 ? true : false;
        // Load
        private void Main_Load(object sender, EventArgs e) => Recolher_Panels();
        private void Atualiza_Menu(Panel panel)
        {
            foreach (var item in this.Controls)
            {
                if (item is Panel && item != panel && item != pnl_base_esquerda && item != pnl_base_superior)
                    ((Panel)item).Visible = false;
                else if (item == panel)
                    ((Panel)item).Visible = !((Panel)item).Visible;
            }
        }
        private void Recolher_Panels()
        {
            foreach (var item in this.Controls)
            {
                if (item is Panel && item != pnl_base_esquerda && item != pnl_base_superior && item != pnl_base_superior)
                    ((Panel)item).Visible = false;
            }
        }
        // Atualizacoes 
        private void btn_responsavel_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_responsavel);
        private void btn_tcc_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_tcc);
        private void btn_artigos_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_artigos);
        private void btn_coautores_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_coautores);
        private void btn_projetos_Click(object sender, EventArgs e) => Atualiza_Menu(pnl_projetos);
        // Windows/Close
        private void btn_close_Click(object sender, EventArgs e) => this.Close();
        private void btn_state_window_Click(object sender, EventArgs e)
        {
            if (this.WindowState is FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            Recolher_Panels();
        }
        // Menu
        private void btn_resp_responsavel_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Responsavel frm_Responsavel = new Frm_Responsavel();
                frm_Responsavel.MdiParent = this.MdiParent;
                frm_Responsavel.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
        private void btn_tcc_tcc_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_TCC frm_TCC = new Frm_TCC();
                frm_TCC.MdiParent = this;
                frm_TCC.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
        private void btn_art_artigos_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Artigo frm_Artigo = new Frm_Artigo();
                frm_Artigo.MdiParent = this;
                frm_Artigo.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
        private void btn_coa_coautores_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Coautor frm_Coautor = new Frm_Coautor();
                frm_Coautor.MdiParent = this;
                frm_Coautor.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
        private void btn_pro_projetos_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Projeto frm_Projeto = new Frm_Projeto();
                frm_Projeto.MdiParent = this;
                frm_Projeto.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
        // Action Bar
        private void btn_novo_artigo_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Novo_Artigo frm_Novo_Artigo = new Frm_Novo_Artigo();
                frm_Novo_Artigo.MdiParent = this;
                frm_Novo_Artigo.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }

        private void btn_novo_responsavel_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Novo_Responsavel frm_Novo_Responsavel = new Frm_Novo_Responsavel();
                frm_Novo_Responsavel.MdiParent = this;
                frm_Novo_Responsavel.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }

        private void btn_novo_projeto_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Novo_Projeto frm_Novo_Projeto = new Frm_Novo_Projeto();
                frm_Novo_Projeto.MdiParent = this;
                frm_Novo_Projeto.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }

        private void btn_novo_tcc_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Novo_TCC frm_Novo_TCC = new Frm_Novo_TCC();
                frm_Novo_TCC.MdiParent = this;
                frm_Novo_TCC.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }

        private void btn_informacoes_Click(object sender, EventArgs e)
        {
            Frm_Informacao frm_Informacao = new Frm_Informacao();
            frm_Informacao.MdiParent = this;
            frm_Informacao.Show();

            Recolher_Panels();
        }
        private void btn_lat_usuarios_Click(object sender, EventArgs e)
        {
            if (Validar_Identificador(this.permissao))
            {
                Frm_Usuario frm_usuario = new Frm_Usuario();
                frm_usuario.MdiParent = this;
                frm_usuario.Show();

                Recolher_Panels();
            }
            else
            {
                MessageBox.Show(USER_MESSAGE.Efetue_Login);
                Recolher_Panels();
            }
        }
    }
}
