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
    public partial class Frm_Alter_Projeto : MetroForm
    {
        public Frm_Alter_Projeto(int id)
        {
            InitializeComponent();
            this.id_projeto = id;
        }
        int id_projeto = 0;
        private DTB_Consulta Consulta_Projeto(int id_projeto)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "Situacao, Titulo, ID_Responsavel, Data_Inicio, Data_Final";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {id_projeto}";

            return dtb_consulta;
        }
        private DTB_Consulta Consulta_Responsavel()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Responsavel;
            dtb_consulta.str_Parametros = "ID, Nome";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        private DTO_Projeto Projeto()
        {
            DTO_Projeto dto_projeto = new DTO_Projeto();
            dto_projeto.int_ID = this.id_projeto;
            dto_projeto.str_Titulo = txt_titulo.Text;
            dto_projeto.int_ID_Responsavel = int.Parse(cbx_responsavel.SelectedValue.ToString());
            dto_projeto.dte_Data_Final = dtp_fim.Value;
            dto_projeto.dte_Data_Inicio = dtp_inicio.Value;
            dto_projeto.str_Situacao = cbx_situacao.Text;

            return dto_projeto;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Projeto(DTO_Projeto dto_projeto) => TST_Projeto.Validar_Modelo(dto_projeto);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Alterar_Projeto(DTO_Projeto dto_projeto)
        {
            if (Validar_Projeto(dto_projeto))
            {
                new Projeto().Fpu_Update(dto_projeto);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operacoes
        private void Prencher_ComboBox(ComboBox cbx_comboBox, DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                cbx_comboBox.DataSource = dt_table;
                cbx_comboBox.DisplayMember = "Nome";
                cbx_comboBox.ValueMember = "ID";
            }
        }
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_Campos(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                cbx_situacao.SelectedIndex = cbx_situacao.FindStringExact(Retornar_String(dt_table, "Situacao"));
                txt_titulo.Text = Retornar_String(dt_table, "Titulo");
                cbx_responsavel.SelectedValue = Retornar_String(dt_table, "ID_Responsavel");
                dtp_inicio.Text = Retornar_String(dt_table, "Data_Inicio");
                dtp_fim.Text = Retornar_String(dt_table, "Data_Final");
            }
            else
                this.Close();
        }
        // Load
        private void Frm_Alter_Projeto_Load(object sender, EventArgs e)
        {
            Prencher_ComboBox(cbx_responsavel, Consulta_Responsavel());
            Prencher_Campos(Consulta_Projeto(this.id_projeto));
        }

        // Button
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e) => Alterar_Projeto(Projeto());
    }
}
