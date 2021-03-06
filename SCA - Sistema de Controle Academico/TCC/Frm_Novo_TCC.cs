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
using BLL;
using DTO;
using TST;

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Frm_Novo_TCC : MetroForm
    {
        public Frm_Novo_TCC()
        {
            InitializeComponent();
        }
        // Load
        private void Frm_Novo_TCC_Load(object sender, EventArgs e) => Prencher_ComboBox(Consulta_Projeto(), cbx_projeto);
        // Modelos >> DTB/DTO
        private DTB_Consulta Consulta_Projeto()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "ID, Titulo";
            dtb_consulta.str_Parametro_Ordenador = "ID";

            return dtb_consulta;
        }
        private DTO_TCC TCC()
        {
            DTO_TCC dto_tcc = new DTO_TCC();
            dto_tcc.int_ID_Projeto = int.Parse(cbx_projeto.SelectedValue.ToString());
            dto_tcc.str_Nome = txt_nome.Text;
            dto_tcc.str_Titulo = txt_titulo.Text;
            dto_tcc.str_Situacao = DTC_Status_TCC.Em_desenvolvimento;

            return dto_tcc;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_TCC(DTO_TCC dto_tcc) => TST_TCC.Validar_Modelo(dto_tcc);
        // Operacoes >> BLL
        private void Cadastrar_TCC(DTO_TCC dto_tcc) => new TCC().Fpu_Insert(dto_tcc);
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar_Left_Join(dtb_consulta);
            else
                return null;
        }
        // Operacoes 
        private void Prencher_ComboBox(DTB_Consulta dtb_consulta, ComboBox cbx_comboBox)
        {
            cbx_comboBox.DataSource = Consultar_Banco(dtb_consulta);
            cbx_comboBox.DisplayMember = "Titulo";
            cbx_comboBox.ValueMember = "ID";
        }
        private void Limpar()
        {
            txt_nome.Text = string.Empty;
            txt_titulo.Text = string.Empty;
        }
        private void Cadastrar(DTO_TCC dto_tcc)
        {
            if (Validar_TCC(dto_tcc))
            {
                Cadastrar_TCC(dto_tcc);
                MessageBox.Show(USER_MESSAGE.Sucesso);
                Limpar();
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Buttons
        private void btn_cadastrar_Click(object sender, EventArgs e) => Cadastrar(TCC());
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
