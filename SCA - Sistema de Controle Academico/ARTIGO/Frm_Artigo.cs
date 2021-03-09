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
    public partial class Frm_Artigo : MetroForm
    {
        public Frm_Artigo() => InitializeComponent();
        // Load
        private void Frm_Artigo_Load(object sender, EventArgs e) => Prencher_DataGrid(dgv_artigos, Consulta_Artigo(""));
        // Modelo >> DTB/DTO
        private DTB_Consulta Consulta_Artigo(string pesquisa)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "ID, Titulo, Natureza, Autor_Principal, Email";
            dtb_consulta.str_Parametro_Ordenador = "Titulo";
            if (!string.IsNullOrWhiteSpace(pesquisa))
                dtb_consulta.str_Condicao = $"Titulo LIKE '%{pesquisa}%' OR Autor_Principal LIKE '%{pesquisa}%'";

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
                dgv_dataGrid.Columns[1].HeaderText = "Titulo";
                dgv_dataGrid.Columns[2].HeaderText = "Natureza";
                dgv_dataGrid.Columns[3].HeaderText = "Autor";
                dgv_dataGrid.Columns[4].HeaderText = "Email";
            }
        }
        private int Get_ID(DataGridView dgv_dataGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                return int.Parse(dgv_dataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            else
                return 0;
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_novo_artigo_Click(object sender, EventArgs e)
        {
            Frm_Novo_Artigo frm_Novo_Artigo = new Frm_Novo_Artigo();
            frm_Novo_Artigo.ShowDialog();

            Prencher_DataGrid(dgv_artigos, Consulta_Artigo(""));
        }
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrid(dgv_artigos, Consulta_Artigo(txt_pesquisa.Text));
        // DataGrid
        private void dgv_artigos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Get_ID(dgv_artigos, e);
            if (id > 0)
                new OPC_Artigo(id).ShowDialog();
            Prencher_DataGrid(dgv_artigos, Consulta_Artigo(""));
        }
    }
}
