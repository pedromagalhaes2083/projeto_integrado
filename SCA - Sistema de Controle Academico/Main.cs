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
        private void Fechar_Formularios_Filhos()
        {
            // percorre todos os formulários abertos
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                // se o formulário for filho
                if (Application.OpenForms[i].IsMdiChild)
                {
                    // fecha o formulário
                    Application.OpenForms[i].Close();
                }
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
            Frm_Responsavel frm_Responsavel = new Frm_Responsavel();
            frm_Responsavel.MdiParent = this.MdiParent;
            frm_Responsavel.Show();

            Recolher_Panels();
        }
        private void btn_tcc_tcc_Click(object sender, EventArgs e)
        {
            Frm_TCC frm_TCC = new Frm_TCC();
            frm_TCC.MdiParent = this;
            frm_TCC.Show();

            Recolher_Panels();
        }
        private void btn_art_artigos_Click(object sender, EventArgs e)
        {
            Frm_Artigo frm_Artigo = new Frm_Artigo();
            frm_Artigo.MdiParent = this;
            frm_Artigo.Show();

            Recolher_Panels();
        }
        private void btn_coa_coautores_Click(object sender, EventArgs e)
        {
            Frm_Coautor frm_Coautor = new Frm_Coautor();
            frm_Coautor.MdiParent = this;
            frm_Coautor.Show();

            Recolher_Panels();
        }
        private void btn_pro_projetos_Click(object sender, EventArgs e)
        {
            Frm_Projeto frm_Projeto = new Frm_Projeto();
            frm_Projeto.MdiParent = this;
            frm_Projeto.Show();

            Recolher_Panels();
        }
        

       

    }
}
