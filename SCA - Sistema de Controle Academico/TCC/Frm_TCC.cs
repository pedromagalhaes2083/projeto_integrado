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
    public partial class Frm_TCC : MetroForm
    {
        public Frm_TCC() => InitializeComponent();
        // Load
        private void Frm_TCC_Load(object sender, EventArgs e)
        {

        }
        // Modelos >> DTB
        private DTB_Consulta Consulta_TCC(string pesquisa)
        {
            string responsavel = DTB_Tabela.Responsavel;
            string tcc = DTB_Tabela.TCC;

            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Parametros = $"{tcc}.ID, {tcc}.Situacao, {responsavel}.Nome, {tcc}.Titulo, {tcc}.Autor";
            dtb_consulta.str_Tabela = tcc;
            dtb_consulta.str_Tabela_Secundaria = responsavel;
            dtb_consulta.str_On_Join = $"{tcc}.ID_Projeto = {responsavel}.ID_Projeto";
            if (!string.IsNullOrWhiteSpace(pesquisa))
                dtb_consulta.str_Condicao = $"{tcc}.Autor LIKE '%{pesquisa}%'";

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
            dgv_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Nomear_DataGrid(dgv_dataGrid);
        }
        private void Nomear_DataGrid(DataGridView dgv_dataGrid)
        {
            if(Validar_DataGrid(dgv_dataGrid))
            {
                dgv_dataGrid.Columns[0].HeaderText = "Cod.";
                dgv_dataGrid.Columns[1].HeaderText = "Situação";
                dgv_dataGrid.Columns[2].HeaderText = "Responsável pelo Projeto";
                dgv_dataGrid.Columns[3].HeaderText = "Titulo";
                dgv_dataGrid.Columns[4].HeaderText = "Autor";
            }
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_novo_tcc_Click(object sender, EventArgs e)
        {
            Frm_Novo_TCC frm_Novo_TCC = new Frm_Novo_TCC();
            frm_Novo_TCC.ShowDialog();
            Prencher_DataGrid(dgv_tcc, Consulta_TCC(""));
        }
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrid(dgv_tcc, Consulta_TCC(txt_pesquisa.Text));
    }
}
