
namespace SCA___Sistema_de_Controle_Academico
{
    partial class Frm_Coautor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Coautor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_coautor = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pesquisa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_novo_coautor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coautor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_coautor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_pesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(6, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 366);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // dgv_coautor
            // 
            this.dgv_coautor.AllowUserToAddRows = false;
            this.dgv_coautor.AllowUserToDeleteRows = false;
            this.dgv_coautor.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_coautor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_coautor.Location = new System.Drawing.Point(6, 55);
            this.dgv_coautor.Name = "dgv_coautor";
            this.dgv_coautor.ReadOnly = true;
            this.dgv_coautor.Size = new System.Drawing.Size(777, 305);
            this.dgv_coautor.TabIndex = 4;
            this.dgv_coautor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_coautor_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome.";
            // 
            // txt_pesquisa
            // 
            this.txt_pesquisa.Location = new System.Drawing.Point(6, 27);
            this.txt_pesquisa.Name = "txt_pesquisa";
            this.txt_pesquisa.Size = new System.Drawing.Size(361, 22);
            this.txt_pesquisa.TabIndex = 0;
            this.txt_pesquisa.TextChanged += new System.EventHandler(this.txt_pesquisa_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label13.Location = new System.Drawing.Point(351, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 25);
            this.label13.TabIndex = 38;
            this.label13.Text = "Coautores";
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
            this.btn_sair.Location = new System.Drawing.Point(6, 408);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(74, 35);
            this.btn_sair.TabIndex = 37;
            this.btn_sair.TabStop = false;
            this.btn_sair.Text = "Sair";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_novo_coautor
            // 
            this.btn_novo_coautor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_novo_coautor.FlatAppearance.BorderSize = 0;
            this.btn_novo_coautor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_novo_coautor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_novo_coautor.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_novo_coautor.Image = ((System.Drawing.Image)(resources.GetObject("btn_novo_coautor.Image")));
            this.btn_novo_coautor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_novo_coautor.Location = new System.Drawing.Point(712, 408);
            this.btn_novo_coautor.Name = "btn_novo_coautor";
            this.btn_novo_coautor.Size = new System.Drawing.Size(83, 35);
            this.btn_novo_coautor.TabIndex = 36;
            this.btn_novo_coautor.TabStop = false;
            this.btn_novo_coautor.Text = "Novo";
            this.btn_novo_coautor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_novo_coautor.UseVisualStyleBackColor = false;
            this.btn_novo_coautor.Click += new System.EventHandler(this.btn_novo_coautor_Click);
            // 
            // Frm_Coautor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_novo_coautor);
            this.Name = "Frm_Coautor";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.Frm_Coautor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coautor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_coautor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pesquisa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_novo_coautor;
    }
}