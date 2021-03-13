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

namespace SCA___Sistema_de_Controle_Academico
{
    public partial class Frm_Informacao : MetroForm
    {
        public Frm_Informacao()
        {
            InitializeComponent();
        }

        private void Frm_Informacao_Load(object sender, EventArgs e)
        {

        }

        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
    }
}
