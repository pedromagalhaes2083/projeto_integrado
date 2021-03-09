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
    public partial class Frm_Novo_Coautor : MetroForm
    {
        public Frm_Novo_Coautor()
        {
            InitializeComponent();
        }
        private void Frm_Novo_Coautor_Load(object sender, EventArgs e) => Prencher_Artigos(Consulta_Artigo());
        // Modelos >> DTB/DTO
        private DTB_Consulta Consulta_Artigo()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "ID, Titulo";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        private DTO_Coautor Coautor()
        {
            DTO_Coautor dto_coautor = new DTO_Coautor();
            dto_coautor.int_ID_Artigo = int.Parse(cbx_artigo.SelectedValue.ToString());
            dto_coautor.str_Nome = txt_coautor.Text;
            dto_coautor.str_Email = txt_email.Text;

            return dto_coautor;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Coautor(DTO_Coautor dto_coautor) => TST_Coautor.Validar_Modelo(dto_coautor);
        // Operacoes >> BLL
        private void Prencher_Artigos(DTB_Consulta dtb_consulta)
        {
            cbx_artigo.DataSource = Consultar_Banco(dtb_consulta);
            cbx_artigo.DisplayMember = "Titulo";
            cbx_artigo.ValueMember = "ID";
        }
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Cadastrar_Coautor(DTO_Coautor dto_coautor)
        {
            if (Validar_Coautor(dto_coautor))
            {
                new Coautor().Fpu_Insert(dto_coautor);
                MessageBox.Show(USER_MESSAGE.Sucesso);
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        private void Cadastrar(DTB_Consulta dtb_consulta)
        {
            DataTable dt_table = Consultar_Banco(dtb_consulta);
            if (Validar_DataTable(dt_table))
                Cadastrar_Coautor(Coautor());
            else
                MessageBox.Show(USER_MESSAGE.Coautor_Existente);
        }
        // Buttons
        private void btn_cadastrar_Click(object sender, EventArgs e) => Cadastrar(Consulta_Artigo());
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
