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
    public partial class Frm_Alter_Artigo : MetroForm
    {
        public Frm_Alter_Artigo(int id)
        {
            InitializeComponent();
            this.id_artigo = id;
        }
        int id_artigo = 0;
        // Load
        private void Frm_Alter_Artigo_Load(object sender, EventArgs e)
        {
            Prencher_ComboBox(cbx_projeto, Consulta_Projeto());
            Prencher_Campos(Consulta_Artigo(this.id_artigo));
        }
        // Modelo >> DTB/DTO
        private DTB_Consulta Consulta_Artigo(int id_artigo)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "Titulo, Natureza, Autor_Principal, Email";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {id_artigo}";

            return dtb_consulta;
        }
        private DTO_Artigo Artigo()
        {
            DTO_Artigo dto_artigo = new DTO_Artigo();
            dto_artigo.int_ID = this.id_artigo;
            dto_artigo.str_Titulo = txt_titulo.Text;
            dto_artigo.str_Autor = txt_autor.Text;
            dto_artigo.str_Email_Autor = txt_email.Text;
            dto_artigo.str_Natureza = txt_natureza.Text;
            dto_artigo.int_ID_Projeto = int.Parse(cbx_projeto.SelectedValue.ToString());

            return dto_artigo;
        }
        private DTB_Consulta Consulta_Projeto()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "Titulo, ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Artigo(DTO_Artigo dto_artigo) => TST_Artigo.Validar_Modelo(dto_artigo);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Alterar(DTO_Artigo dto_artigo)
        {
            if (Validar_Artigo(dto_artigo))
            {
                new Artigo().Fpu_Update(dto_artigo);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operacoes
        private void Prencher_ComboBox(ComboBox cbx_comboBox, DTB_Consulta dtb_consulta)
        {
            cbx_comboBox.DataSource = Consultar_Banco(dtb_consulta);
            cbx_comboBox.DisplayMember = "Titulo";
            cbx_comboBox.ValueMember = "ID";
        }
        private string Retornar_String(DataTable dt_table, string parametro) => dt_table.Rows[0][parametro].ToString();
        private void Prencher_Campos(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
            {
                txt_autor.Text = Retornar_String(dt_table, "Autor_Principal");
                txt_email.Text = Retornar_String(dt_table, "Email");
                txt_natureza.Text = Retornar_String(dt_table, "Natureza");
                txt_titulo.Text = Retornar_String(dt_table, "Titulo");
                cbx_projeto.SelectedIndex = cbx_projeto.FindStringExact(Retornar_String(dt_table, "ID_Projeto"));
            }
            else
                this.Close();
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e) => Alterar(Artigo());
    }
}
