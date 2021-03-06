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
    public partial class OPC_Projeto : MetroForm
    {
        public OPC_Projeto(int id)
        {
            InitializeComponent();
            this.id_projeto = id;
        }
        int id_projeto = 0;
        private DTB_Consulta Consulta_Artigos()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Artigo;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID_Projeto = {this.id_projeto}";

            return dtb_consulta;
        }
        private DTO_Projeto Projeto()
        {
            DTO_Projeto dto_projeto = new DTO_Projeto();
            dto_projeto.int_ID = this.id_projeto;
            dto_projeto.dte_Data_Final = DateTime.Now;
            dto_projeto.dte_Data_Inicio = DateTime.Now;

            return dto_projeto;
        }
        private DTB_Consulta Consulta_TCCS()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.TCC;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID_Projeto = {this.id_projeto}";

            return dtb_consulta;
        }
        // Validacoes
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
        private void Deletar_Projeto(DTO_Projeto dto_projeto)
        {
            DataTable dt_artigo = Consultar_Banco(Consulta_Artigos());
            DataTable dt_tccs = Consultar_Banco(Consulta_TCCS());
            if (Validar_DataTable(dt_tccs) && Validar_DataTable(dt_artigo) && this.id_projeto > 0)
            {
                new Projeto().Fpu_Delete(dto_projeto);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Projeto_Apagar);
        }
        // Buttons
        private void btn_editar_Click(object sender, EventArgs e)
        {
            Frm_Alter_Projeto frm_projeto = new Frm_Alter_Projeto(this.id_projeto);
            frm_projeto.ShowDialog();
            this.Close();
        }
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo excluir esse projeto?", "Exclusão de projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Deletar_Projeto(Projeto());
            else
                this.Close();
        }
    }
}
