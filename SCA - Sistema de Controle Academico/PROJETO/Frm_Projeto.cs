using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using TST;
using MetroFramework.Forms;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Frm_Projeto : MetroForm
    {
        public Frm_Projeto() => InitializeComponent();
        // Load
        private void Frm_Projeto_Load(object sender, EventArgs e) => Prencher_DataGrird(dgv_projetos, Consulta_Projeto(""));
        // DTO/DTB
        private DTB_Consulta Consulta_Projeto(string Nome)
        {
            string projeto = DTB_Tabela.Projeto;
            string responsavel = DTB_Tabela.Responsavel;

            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Parametros = $" {projeto}.ID, {projeto}.Data_Inicio, {projeto}.Data_Final, {projeto}.Situacao, {projeto}.Titulo, {responsavel}.Nome, {responsavel}.Email ";
            dtb_consulta.str_Tabela = projeto;
            dtb_consulta.str_Tabela_Secundaria = responsavel;
            dtb_consulta.str_On_Join = $"{projeto}.ID_Responsavel = {responsavel}.ID";
            if (!string.IsNullOrWhiteSpace(Nome))
                dtb_consulta.str_Condicao = $"{responsavel}.Nome LIKE '%{Nome}%' OR {projeto}.Titulo LIKE '%{Nome}%'";
            
            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_DataGrid(DataGridView dgv_dataGrid) => TST_DataGrid.Validar_DataGrid_Columns(dgv_dataGrid);
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar_Left_Join(dtb_consulta);
            else
                return null;
        }
        private void Prencher_DataGrird(DataGridView dgv_dataGrid, DTB_Consulta dtb_consulta)
        {
            dgv_dataGrid.DataSource = Consultar_Banco(dtb_consulta);
            dgv_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Nomear_DataGrid(dgv_dataGrid);
        }
        private void Nomear_DataGrid(DataGridView dgv_dataGrid)
        {
            if (Validar_DataGrid(dgv_dataGrid))
            {
                dgv_dataGrid.Columns[0].HeaderText = "Cod.";
                dgv_dataGrid.Columns[1].HeaderText = "Início";
                dgv_dataGrid.Columns[2].HeaderText = "Fim";
                dgv_dataGrid.Columns[3].HeaderText = "Situação";
                dgv_dataGrid.Columns[4].HeaderText = "Titulo";
                dgv_dataGrid.Columns[5].HeaderText = "Responsável";
                dgv_dataGrid.Columns[6].HeaderText = "Email";
            }
        }
        // Operacoes
        private int Get_ID(DataGridView dgv_dataGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                return int.Parse(dgv_dataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            else
                return 0;
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_novo_projeto_Click(object sender, EventArgs e)
        {
            Frm_Novo_Projeto frm_Novo_Projeto = new Frm_Novo_Projeto();
            frm_Novo_Projeto.ShowDialog();

            Prencher_DataGrird(dgv_projetos, Consulta_Projeto(""));
        }
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrird(dgv_projetos, Consulta_Projeto(txt_pesquisa.Text));
        // DataGrid
        private void dgv_projetos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Get_ID(dgv_projetos, e);
            if(id > 0)
                _ = new OPC_Projeto(id).ShowDialog();
            Prencher_DataGrird(dgv_projetos, Consulta_Projeto(""));
        }
    }
}
