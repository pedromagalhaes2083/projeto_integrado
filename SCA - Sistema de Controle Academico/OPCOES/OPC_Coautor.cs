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
    public partial class OPC_Coautor : MetroForm
    {
        public OPC_Coautor(int id)
        {
            InitializeComponent();
            this.id_coautor = id;
        }
        int id_coautor = 0;
        // Modelos >> DTO/DTB
        private DTO_Coautor Coautor()
        {
            DTO_Coautor dto_coautor = new DTO_Coautor();
            dto_coautor.int_ID = this.id_coautor;

            return dto_coautor;
        }
        // Validacoes >> TST
        private bool Validar_Identificador(int i) => i > 0 ? true : false;
        private void Deletar_Coautor(DTO_Coautor dto_coautor)
        {
            if (Validar_Identificador(dto_coautor.int_ID))
                new Coautor().Fpu_Delete(dto_coautor);
            this.Close();
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_editar_Click(object sender, EventArgs e)
        {
            Frm_Alter_Coautor frm_Alter_Coautor = new Frm_Alter_Coautor(this.id_coautor);
            frm_Alter_Coautor.ShowDialog();
            this.Close();
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo excluir esse coautor?", "Exclusão de coautor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Deletar_Coautor(Coautor());
            else
                this.Close();
        }
    }
}
