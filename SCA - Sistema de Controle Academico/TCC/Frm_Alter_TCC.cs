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
    public partial class Frm_Alter_TCC : MetroForm
    {
        public Frm_Alter_TCC(int id)
        {
            InitializeComponent();
            this.id_tcc = id;
        }
        int id_tcc = 0;
        // Load
        private void Frm_Alter_TCC_Load(object sender, EventArgs e)
        {
            Prencher_ComboBox(Consulta_Projeto(), cbx_projeto);
            Prencher_Campos(Consultar_TCC());
        }
        // Modelo >> DTB/DTO
        private DTB_Consulta Consulta_Projeto()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "Titulo, ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        private DTB_Consulta Consultar_TCC()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.TCC;
            dtb_consulta.str_Parametros = "ID_Projeto, Titulo, Autor, Situacao";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {this.id_tcc}";

            return dtb_consulta;
        }
        private DTO_TCC TCC()
        {
            DTO_TCC dto_tcc = new DTO_TCC();
            dto_tcc.int_ID = this.id_tcc;
            dto_tcc.int_ID_Projeto = int.Parse(cbx_projeto.SelectedValue.ToString());
            dto_tcc.str_Autor = txt_nome.Text;
            dto_tcc.str_Titulo = txt_titulo.Text;
            dto_tcc.str_Situacao = cbx_status.Text;

            return dto_tcc;
        }
        // Validacoes >> TST
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_TCC(DTO_TCC dto_tcc) => TST_TCC.Validar_Modelo(dto_tcc);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Alterar(DTO_TCC dto_tcc)
        {
            if (Validar_TCC(dto_tcc))
            {
                new TCC().Fpu_Update(dto_tcc);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operecoes 
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_ComboBox(DTB_Consulta dtb_consulta, ComboBox cbx_comboBox)
        {
            cbx_comboBox.DataSource = Consultar_Banco(dtb_consulta);
            cbx_comboBox.DisplayMember = "Titulo";
            cbx_comboBox.ValueMember = "ID";
        }
        private void Prencher_Campos(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                txt_nome.Text = Retornar_String(dt_table, "Autor");
                txt_titulo.Text = Retornar_String(dt_table, "Titulo");
                cbx_projeto.SelectedItem = cbx_projeto.FindStringExact(Retornar_String(dt_table, "ID_Projeto"));
                cbx_status.SelectedIndex = cbx_status.FindStringExact(Retornar_String(dt_table, "Situacao"));
            }
            else
                this.Close();
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e) => Alterar(TCC());
    }
}
