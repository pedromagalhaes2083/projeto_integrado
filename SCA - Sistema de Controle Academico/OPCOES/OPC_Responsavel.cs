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
    public partial class OPC_Responsavel : MetroForm
    {
        public OPC_Responsavel(int id)
        {
            InitializeComponent();
            this.id_responsavel = id;
        }
        int id_responsavel = 0;
        // Modelos >> DTO
        private DTO_Responsavel Responsavel()
        {
            DTO_Responsavel dto_responsavel = new DTO_Responsavel();
            dto_responsavel.int_ID = this.id_responsavel;

            return dto_responsavel;
        }
        private DTB_Consulta Consulta_Projeto()
        {
            DTB_Consulta dtb_consulta = new DTB_Consulta();
            dtb_consulta.str_Tabela = DTB_Tabela.Projeto;
            dtb_consulta.str_Parametros = "ID";
            dtb_consulta.str_Parametro_Ordenador = "ID";
            dtb_consulta.str_Condicao = $"ID_Responsavel = {id_responsavel}";

            return dtb_consulta;
        }
        // Validacoes >> TST
        private bool Validar_DataTable(DataTable dt_table) => !TST_DataTable.Validar_DataTable(dt_table);
        private bool Validar_Consulta(DTB_Consulta dtb_cosnulta) => TST_Consulta.Validar_Modelo(dtb_cosnulta);
        // Operacoes >> BLL 
        private DataTable Consultar_Banco(DTB_Consulta dtb_consulta)
        {
            if (Validar_Consulta(dtb_consulta))
                return new Consulta().Consultar(dtb_consulta);
            else
                return null;
        }
        private void Deletar_Responsavel(DTO_Responsavel dto_responsavel)
        {
            DataTable dt_table = Consultar_Banco(Consulta_Projeto());
            if (Validar_DataTable(dt_table))
            {
                new Responsavel().Fpu_Delete(dto_responsavel);
                this.Close();
            }
            else
                MessageBox.Show(USER_MESSAGE.Exclusao_Responsavel);
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo excluir esse responsável?", "Exclusão de responsável", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Deletar_Responsavel(Responsavel());
            else
                this.Close();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            new Frm_Alter_Responsavel(this.id_responsavel).ShowDialog();
            this.Close();
        }

        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
