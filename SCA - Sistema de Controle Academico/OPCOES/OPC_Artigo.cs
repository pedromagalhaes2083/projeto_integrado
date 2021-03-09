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
    public partial class OPC_Artigo : MetroForm
    {
        public OPC_Artigo(int id)
        {
            InitializeComponent();
            this.id_artigo = id;
        }
        int id_artigo = 0;
        // Modelo >> DTB/DTO
        private DTB_Consulta Consulta_Coautor()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Coautor;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID_Artigo = {this.id_artigo}";

            return dtb_consulta;
        }
        private DTO_Artigo Artigo()
        {
            DTO_Artigo dto_artigo = new DTO_Artigo();
            dto_artigo.int_ID = this.id_artigo;

            return dto_artigo;
        }
        // Validacoes >> TST
        private bool Validar_DataTable(DataTable dt_table) => !TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Consulta(DTB_Consulta dtb_consulta) => TST_Consulta.Validar_Modelo(dtb_consulta);
        // Operacoes >> BLL
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Deletar_Artigo(DTO_Artigo dto_artigo)
        {
            DataTable dt_table = Consultar_Banco(Consulta_Coautor());
            if (Validar_DataTable(dt_table))
            {
                new Artigo().Fpu_Delete(dto_artigo);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Exclusao_Artigo);
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e)
        {
            Frm_Alter_Artigo frm_Alter_Artigo = new Frm_Alter_Artigo(this.id_artigo); ;
            frm_Alter_Artigo.ShowDialog();

            this.Close();
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo excluir esse artigo?", "Exclusão de artigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Deletar_Artigo(Artigo());

            else
                this.Close();
        }
    }
}
