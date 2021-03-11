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
    public partial class Frm_Alter_Coautor : MetroForm
    {
        public Frm_Alter_Coautor(int id)
        {
            InitializeComponent();
            this.id_coautor = id;
        }
        int id_coautor = 0;
        // Modelo >> DTB/DTO
        private DTB_Consulta Consulta_Coautor()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Coautor;
            dtb_consulta.str_Parametros = "ID_Artigo, Nome, Email";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {this.id_coautor}";

            return dtb_consulta;
        }
        private DTO_Coautor Coautor()
        {
            DTO_Coautor dto_coautor = new DTO_Coautor();
            dto_coautor.int_ID = this.id_coautor;
            dto_coautor.str_Nome = txt_coautor.Text;
            dto_coautor.str_Email = txt_email.Text;
            dto_coautor.int_ID_Artigo = int.Parse(cbx_artigo.SelectedValue.ToString());

            return dto_coautor;
        }
        private DTB_Consulta Consulta_Artigo()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "Titulo, ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Coautor(DTO_Coautor dto_coautor) => TST_Coautor.Validar_Modelo(dto_coautor);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Alterar(DTO_Coautor dto_coautor)
        {
            if (Validar_Coautor(dto_coautor))
            {
                new Coautor().Fpu_Update(dto_coautor);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operacoes
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_Campos(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                txt_coautor.Text = Retornar_String(dt_table, "Nome");
                txt_email.Text = Retornar_String(dt_table, "Email");
                cbx_artigo.SelectedItem = cbx_artigo.FindStringExact(Retornar_String(dt_table, "ID_Artigo"));
            }
            else
                this.Close();
        }
        private void Prencher_ComboBox(DTB_Consulta dtb_consulta, ComboBox cbx_comboBox)
        {
            cbx_comboBox.DataSource = Consultar_Banco(dtb_consulta);
            cbx_comboBox.DisplayMember = "Titulo";
            cbx_comboBox.ValueMember = "ID";
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e) => Alterar(Coautor());

        // Load
        private void Frm_Alter_Coautor_Load(object sender, EventArgs e)
        {
            Prencher_ComboBox(Consulta_Artigo(), cbx_artigo);
            Prencher_Campos(Consulta_Coautor());
        }
    }
}
