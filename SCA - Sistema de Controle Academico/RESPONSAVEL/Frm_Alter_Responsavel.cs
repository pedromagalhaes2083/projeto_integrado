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
    public partial class Frm_Alter_Responsavel : MetroForm
    {
        public Frm_Alter_Responsavel(int id)
        {
            InitializeComponent();
            this.id_responsavel = id;
        }
        int id_responsavel = 0;
        // Modelos >> DTO/DTB
        private DTB_Consulta Consulta_Responsavel(int id_responsavel)
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Responsavel;
            dtb_consulta.str_Parametros = "Nome, Email";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID = {id_responsavel}";

            return dtb_consulta;
        }
        private DTO_Responsavel Responsavel()
        {
            DTO_Responsavel dto_responsavel = new DTO_Responsavel();
            dto_responsavel.int_ID = this.id_responsavel;
            dto_responsavel.str_Nome = txt_nome.Text;
            dto_responsavel.str_Email = txt_email.Text;

            return dto_responsavel;
        }
        // Validacoes >> TST
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        private bool Validar_DataTable(DataTable dt_table) => TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Responsavel(DTO_Responsavel dto_responsavel) => TST_Responsavel.Validar_Modelo(dto_responsavel);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Alterar(DTO_Responsavel dto_responsavel)
        {
            if (Validar_Responsavel(dto_responsavel))
            {
                new Responsavel().Fpu_Update(dto_responsavel);
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
                txt_email.Text = Retornar_String(dt_table, "Email");
                txt_nome.Text = Retornar_String(dt_table, "Nome");
            }
            else
                this.Close();
        }
        // Load
        private void Frm_Alter_Responsavel_Load(object sender, EventArgs e) => Prencher_Campos(Consulta_Responsavel(this.id_responsavel));
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_cadastrar_Click(object sender, EventArgs e) => Alterar(Responsavel());
    }
}
