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
    public partial class Frm_Novo_Responsavel : MetroForm
    {
        public Frm_Novo_Responsavel() => InitializeComponent();

        // Modelo >> DTO
        private DTO_Responsavel Responsavel()
        {
            DTO_Responsavel dto_responsavel = new DTO_Responsavel();
            dto_responsavel.str_Nome = txt_nome.Text;
            dto_responsavel.str_Email = txt_email.Text;

            return dto_responsavel;
        }
        // Validacoes >> TST
        private bool Validar_Responsavel(DTO_Responsavel dto_responsavel) => TST_Responsavel.Validar_Modelo(dto_responsavel);
        // Operacoes >> BLL
        private void Cadastrar_Responsavel(DTO_Responsavel dto_responsavel) => new Responsavel().Fpu_Insert(dto_responsavel);
        // Operacoes
        private void Limpar()
        {
            txt_email.Text = string.Empty;
            txt_nome.Text = string.Empty;
        }
        private void Cadastrar(DTO_Responsavel dto_responsavel)
        {
            if (Validar_Responsavel(dto_responsavel))
            {
                Cadastrar_Responsavel(dto_responsavel);
                Limpar();
                MessageBox.Show(USER_MESSAGE.Sucesso);
            }
            else
                MessageBox.Show(USER_MESSAGE.Modelo_Invalido);
        }
        // Buttons
        private void btn_sair_Click(object sender, EventArgs e) => this.Close();
        private void btn_cadastrar_Click(object sender, EventArgs e) => Cadastrar(Responsavel());
    }
}
