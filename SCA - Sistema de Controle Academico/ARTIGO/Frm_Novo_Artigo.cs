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
    public partial class Frm_Novo_Artigo : MetroForm
    {
        public Frm_Novo_Artigo() => InitializeComponent();
        // Modelos >> DTB/DTO
        private DTB_Consulta Consulta_Artigo(string titulo, int id_projeto)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"Titulo LIKE '{titulo}' AND ID_Projeto = {id_projeto}";

            return dtb_consulta;
        }
        private DTO_Artigo Artigo()
        {
            DTO_Artigo dto_artigo = new DTO_Artigo();
            dto_artigo.str_Titulo = txt_titulo.Text;
            dto_artigo.str_Autor = txt_autor.Text;
            dto_artigo.str_Email_Autor = txt_email.Text;
            dto_artigo.str_Natureza = txt_natureza.Text;
            dto_artigo.int_ID_Projeto = int.Parse(cbx_projeto.SelectedValue.ToString());

            return dto_artigo;
        }
        private DTB_Consulta Consultar_Projeto()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "ID, Titulo";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_Artigo(DTO_Artigo dto_artigo) => TST_Artigo.Validar_Modelo(dto_artigo);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);

        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Cadastrar_Artigo(DTO_Artigo dto_artigo)
        {
            if (Validar_Artigo(dto_artigo))
            {
                new Artigo().Fpu_Insert(dto_artigo);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                Limpar();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Operacoes
        private void Limpar()
        {
            txt_autor.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_natureza.Text = string.Empty;
            txt_titulo.Text = string.Empty;
        }
        private void Cadastrar(DTO_Artigo dto_artigo)
        {
            DataTable dt_table = Consultar_Banco(Consulta_Artigo(dto_artigo.str_Titulo, dto_artigo.int_ID_Projeto));
            if (!Validar_DataTable(dt_table))
                Cadastrar_Artigo(dto_artigo);
            else
                MessageBox.Show(USER_MESSAGE.Artigo_Existente);
        }
        private void Prencher_ComboBox(DTB_Consulta dtb_consulta, ComboBox cbx_comboBox)
        {
            cbx_comboBox.DataSource = Consultar_Banco(dtb_consulta);
            cbx_comboBox.DisplayMember = "Titulo";
            cbx_comboBox.ValueMember = "ID";
        }
        // Buttons
        private void btn_cadastrar_Click(object sender, EventArgs e) => Cadastrar(Artigo());
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        // Load
        private void Frm_Novo_Artigo_Load(object sender, EventArgs e) => Prencher_ComboBox(Consultar_Projeto(), cbx_projeto);
    }
}
