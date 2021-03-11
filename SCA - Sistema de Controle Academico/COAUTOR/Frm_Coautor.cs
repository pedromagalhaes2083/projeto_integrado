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
    public partial class Frm_Coautor : MetroForm
    {
        public Frm_Coautor() => InitializeComponent();
        // Load
        private void Frm_Coautor_Load(object sender, EventArgs e) => Prencher_DataGrid(dgv_coautor, Consulta_Coautor(""));
        // Modelos >> DTB
        private DTB_Consulta Consulta_Coautor(string pesquisar)
        {
            string coautor = DTB_Tabela.Coautor;
            string artigo = DTB_Tabela.Artigo;

            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Parametros = $"{coautor}.ID, {artigo}.Titulo, {coautor}.Nome, {coautor}.Email";
            dtb_consulta.str_Tabela = coautor;
            dtb_consulta.str_Tabela_Secundaria = artigo;
            dtb_consulta.str_On_Join = $"{coautor}.ID_Artigo = {artigo}.ID";
            if (!(string.IsNullOrWhiteSpace(pesquisar)))
                dtb_consulta.str_Condicao = $"{coautor}.Nome LIKE '%{pesquisar}%'";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consultar(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataGrid(DataGridView dgv_dataGrid) => TST_DataGrid.Validar_DataGrid_Columns(dgv_dataGrid);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consultar(dtb_consulta))
                return new Consulta().Consultar_Left_Join(dtb_consulta);
            else
                return null;
        }
        // Operacoes 
        private void Prencher_DataGrid(DataGridView dgv_dataGrid, DTB_Consulta dtb_consulta)
        {
            dgv_dataGrid.DataSource = Consultar_Banco(dtb_consulta);
            dgv_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Nomear_DataGrid(dgv_dataGrid);
        }
        private int Get_ID(DataGridView dgv_dataGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                return int.Parse(dgv_dataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            else
                return 0;
        }
        private void Nomear_DataGrid(DataGridView dgv_dataGrid)
        {
            if (Validar_DataGrid(dgv_dataGrid))
            {
                dgv_dataGrid.Columns[0].HeaderText = "Cod.";
                dgv_dataGrid.Columns[1].HeaderText = "Titulo";
                dgv_dataGrid.Columns[2].HeaderText = "Nome";
                dgv_dataGrid.Columns[3].HeaderText = "Email";
            }
        }
        // Buttons
        private void btn_novo_coautor_Click(object sender, EventArgs e)
        {
            Frm_Novo_Coautor frm_Novo_Coautor = new Frm_Novo_Coautor();
            frm_Novo_Coautor.ShowDialog();
            Prencher_DataGrid(dgv_coautor, Consulta_Coautor(""));
        }
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrid(dgv_coautor, Consulta_Coautor(txt_pesquisa.Text));
        // DataGrid
        private void dgv_coautor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Get_ID(dgv_coautor, e);
            if(id > 0)
                new OPC_Coautor(id).ShowDialog();
            Prencher_DataGrid(dgv_coautor, Consulta_Coautor(""));
        }
    }
}
