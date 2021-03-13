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
    public partial class OPC_Usuario : MetroForm
    {
        public OPC_Usuario(int id)
        {
            InitializeComponent();
            this.id_usuario = id;
        }
        int id_usuario = 0;
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            new OPR_Exclusao_Usuario(id_usuario).ShowDialog();
            this.Dispose();
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            Frm_Alter_Usuario frm_Alter_Usuario = new Frm_Alter_Usuario(this.id_usuario);
            frm_Alter_Usuario.ShowDialog();

            this.Close();
        }
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
