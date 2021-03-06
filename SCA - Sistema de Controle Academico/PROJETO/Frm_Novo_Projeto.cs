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
    public partial class Frm_Novo_Projeto : MetroForm
    {
        public Frm_Novo_Projeto() => InitializeComponent();
        // Load
        private void Frm_Novo_Projeto_Load(object sender, EventArgs e)
        {
            Prencher_ComboBox(cbx_responsavel, Consulta_Responsavel());
            Consultar_Situacao(Consulta_Projeto(cbx_responsavel.SelectedValue.ToString()));
            txt_situacao.Text = DTC_Status_Projeto.Em_Andamento;
        }

        // Modelos >> DTO/DTB
        private DTO_Projeto Projeto()
        {
            DTO_Projeto dto_projeto = new DTO_Projeto();
            dto_projeto.int_ID_Responsavel = int.Parse(cbx_responsavel.SelectedValue.ToString());
            dto_projeto.str_Titulo = txt_titulo.Text;
            dto_projeto.str_Situacao = DTC_Status_Projeto.Em_Andamento;
            dto_projeto.dte_Data_Inicio = dtp_inicio.Value;
            dto_projeto.dte_Data_Final = dtp_fim.Value;

            return dto_projeto;
        }
        private DTB_Consulta Consulta_Projeto(string id_responsavel)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "Situacao";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID_Responsavel = {id_responsavel}";

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
        private void Cadastrar_Projeto(DTO_Projeto dto_projeto)
        {
            if (Validar_Projeto(dto_projeto))
            {
                new Projeto().Fpu_Insert(dto_projeto);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                Limpar();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operacoes
        private void Consultar_Situacao(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
                txt_situacao.Text = Retornar_String(dt_table, "Situacao");
            else
                txt_situacao.Text = string.Empty;
        }
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
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
        private void Limpar()
        {
            txt_situacao.Text = string.Empty;
            txt_titulo.Text = string.Empty;
        }
        // Button
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar_Projeto(Projeto());
            Consultar_Situacao(Consulta_Projeto(cbx_responsavel.SelectedValue.ToString()));
        }
    }
}
