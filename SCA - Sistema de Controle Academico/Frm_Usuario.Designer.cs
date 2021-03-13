
namespace SCA___Sistema_de_Controle_Academico
{
    partial class Frm_Usuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Usuario));
            this.btn_novo_usuario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_usuario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_sair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuario)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_novo_usuario
            // 
            this.btn_novo_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.btn_novo_usuario.FlatAppearance.BorderSize = 0;
            this.btn_novo_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_novo_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_novo_usuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_novo_usuario.Image = ((System.Drawing.Image)(resources.GetObject("btn_novo_usuario.Image")));
            this.btn_novo_usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_novo_usuario.Location = new System.Drawing.Point(651, 405);
            this.btn_novo_usuario.Name = "btn_novo_usuario";
            this.btn_novo_usuario.Size = new System.Drawing.Size(144, 35);
            this.btn_novo_usuario.TabIndex = 35;
            this.btn_novo_usuario.Text = "Novo Usuário";
            this.btn_novo_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_novo_usuario.UseVisualStyleBackColor = false;
            this.btn_novo_usuario.Click += new System.EventHandler(this.btn_novo_usuario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(346, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 29);
            this.label2.TabIndex = 32;
            this.label2.Text = "Usuários";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_usuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_pesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(6, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 366);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // dgv_usuario
            // 
            this.dgv_usuario.AllowUserToAddRows = false;
            this.dgv_usuario.AllowUserToDeleteRows = false;
            this.dgv_usuario.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_usuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_usuario.Location = new System.Drawing.Point(6, 55);
            this.dgv_usuario.Name = "dgv_usuario";
            this.dgv_usuario.ReadOnly = true;
            this.dgv_usuario.Size = new System.Drawing.Size(777, 305);
            this.dgv_usuario.TabIndex = 4;
            this.dgv_usuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_usuarios_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome.";
            // 
            // txt_pesquisa
            // 
            this.txt_pesquisa.Location = new System.Drawing.Point(6, 27);
            this.txt_pesquisa.Name = "txt_pesquisa";
            this.txt_pesquisa.Size = new System.Drawing.Size(361, 22);
            this.txt_pesquisa.TabIndex = 0;
            this.txt_pesquisa.TextChanged += new System.EventHandler(this.txt_pesquisa_TextChanged);
            // 
            // btn_sair
            // 
            this.btn_sair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sair.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_sair.Image = ((System.Drawing.Image)(resources.GetObject("btn_sair.Image")));
            this.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sair.Location = new System.Drawing.Point(6, 405);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(74, 35);
            this.btn_sair.TabIndex = 37;
            this.btn_sair.TabStop = false;
            this.btn_sair.Text = "Sair";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // Frm_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.ControlBox = false;
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_novo_usuario);
            this.Controls.Add(this.label2);
            this.Name = "Frm_Usuario";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.Frm_Usuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_novo_usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pesquisa;
        private System.Windows.Forms.Button btn_sair;
    }
}