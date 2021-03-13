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
using TST;
using BLL;
using MetroFramework.Forms;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Frm_Usuario : MetroForm
    {
        public Frm_Usuario()
        {
            InitializeComponent();
        }
        // Load
        private void Frm_Usuario_Load(object sender, EventArgs e) => Prencher_DataGrid(dgv_usuario, Consulta_Usuario(""));
        // Modelos >> DTB
        private DTB_Consulta Consulta_Usuario(string pesquisa)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Usuario;
            dtb_consulta.str_Parametros = "ID, Nome, User_Login";
            dtb_consulta.str_Parametro_Ordenador = "Nome";
            if (!(string.IsNullOrWhiteSpace(pesquisa)))
                dtb_consulta.str_Condicao = $"Nome LIKE '%{pesquisa}%' OR User_Login LIKE '%{pesquisa}%'";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
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
        private int Get_ID(DataGridView dgv_dataGrid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                return int.Parse(dgv_dataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            else
                return 0;
        }
        private void Prencher_DataGrid(DataGridView dgv_dataGrid, DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            dgv_dataGrid.DataSource = dt_table;
            dgv_dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nomear_DataGrid(dgv_dataGrid);
        }
        private void Nomear_DataGrid(DataGridView dgv_dataGrid)
        {
            if (Validar_DataGrid(dgv_dataGrid))
            {
                dgv_dataGrid.Columns[0].HeaderText = "ID";
                dgv_dataGrid.Columns[1].HeaderText = "Nome";
                dgv_dataGrid.Columns[2].HeaderText = "Login";
            }
        }
        // Buttons
        private void btn_novo_usuario_Click(object sender, EventArgs e)
        {
            new Frm_Novo_Usuario().ShowDialog();
            Prencher_DataGrid(dgv_usuario, Consulta_Usuario(""));
        }
        private void btn_voltar_Click(object sender, EventArgs e) => this.Close();
        // DataGrid
        private void dgv_usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Get_ID(dgv_usuario, e);
            if (id > 0)
                new OPC_Usuario(id).ShowDialog();

            Prencher_DataGrid(dgv_usuario, Consulta_Usuario(""));
        }
        // TextBox
        private void txt_pesquisa_TextChanged(object sender, EventArgs e) => Prencher_DataGrid(dgv_usuario, Consulta_Usuario(txt_pesquisa.Text));
    }
}
