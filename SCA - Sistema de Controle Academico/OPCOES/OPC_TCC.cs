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
    public partial class OPC_TCC : MetroForm
    {
        public OPC_TCC(int id)
        {
            InitializeComponent();
            this.id_tcc = id;
        }
        int id_tcc = 0;
        // Modelo >> DTO
        private DTO_TCC TCC()
        {
            DTO_TCC dto_tcc = new DTO_TCC();
            dto_tcc.int_ID = this.id_tcc;

            return dto_tcc;
        }
        // Operacoes >> BLL
        private void Deletar_TCC (DTO_TCC dto_tcc)
        {
            if (dto_tcc.int_ID > 0)
                new TCC().Fpu_Delete(dto_tcc);
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
            this.Close();
        }
        // Buttons
        private void btn_editar_Click(object sender, EventArgs e)
        {
            new Frm_Alter_TCC(this.id_tcc).ShowDialog();
            this.Close();
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo excluir esse TCC?", "Exclusão de TCC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Deletar_TCC(TCC());
            else
                this.Close();
        }

        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
