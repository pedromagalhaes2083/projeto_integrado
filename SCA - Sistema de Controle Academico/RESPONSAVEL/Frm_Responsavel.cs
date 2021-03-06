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
    public partial class Frm_Responsavel : MetroForm
    {
        public Frm_Responsavel() => InitializeComponent();
        // Load
        private void Frm_Responsavel_Load(object sender, EventArgs e) => Prencher_DataGrid(dgv_responsavel, Consulta_Responsavel(""));
        // Modelos >> DTB
        private DTB_Consulta Consulta_Responsavel(string Nome)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Responsavel;
            dtb_consulta.str_Parametros = "ID, Nome, Email";
            dtb_consulta.str_Parametro_Ordenador = "Nome";
            if (!string.IsNullOrWhiteSpace(Nome))
                dtb_consulta.str_Condicao = $"Nome LIKE '%{Nome}%'";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataGrid(DataGridView dgv_dataGrid) => TST_DataGrid.Validar_DataGrid_Columns(dgv_dataGrid);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
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
        private void Nomear_DataGrid(DataGridView dgv_dataGrid)
        {
            if (Validar_DataGrid(dgv_dataGrid))
            {
                dgv_dataGrid.Columns[0].HeaderText = "Cod.";
                dgv_dataGrid.Columns[1].HeaderText = "Nome";
                dgv_dataGrid.Columns[2].HeaderText = "Email";
            }
        }
        private int Get_ID(DataGridView dgv_dataGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                return int.Parse(dgv_dataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            else
                return 0;
        }
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrid(dgv_responsavel, Consulta_Responsavel(txt_pesquisa.Text));
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_novo_responsavel_Click(object sender, EventArgs e)
        {
            Frm_Novo_Responsavel frm_Novo_Responsavel = new Frm_Novo_Responsavel();
            frm_Novo_Responsavel.ShowDialog();

            Prencher_DataGrid(dgv_responsavel, Consulta_Responsavel(""));
        }
        // DataGrid
        private void dgv_responsavel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Get_ID(dgv_responsavel, e);
            if(id > 0)
                new OPC_Responsavel(id).ShowDialog();
            Prencher_DataGrid(dgv_responsavel, Consulta_Responsavel(""));
        }
    }
}
