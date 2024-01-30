using System.Drawing;
using System.Windows.Forms;

namespace Usando_Datatable
{
    partial class Form1
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
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnCriarDataTable = new System.Windows.Forms.Button();
            this.btnSelecionarRota = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblSelecao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDados = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 29);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(645, 316);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            // 
            // btnCriarDataTable
            // 
            this.btnCriarDataTable.Location = new System.Drawing.Point(12, 357);
            this.btnCriarDataTable.Name = "btnCriarDataTable";
            this.btnCriarDataTable.Size = new System.Drawing.Size(114, 25);
            this.btnCriarDataTable.TabIndex = 1;
            this.btnCriarDataTable.Text = "Carregar Rotas";
            this.btnCriarDataTable.UseVisualStyleBackColor = true;
            this.btnCriarDataTable.Click += new System.EventHandler(this.btnCriarDataTable_Click);
            // 
            // btnSelecionarRota
            // 
            this.btnSelecionarRota.Enabled = false;
            this.btnSelecionarRota.Location = new System.Drawing.Point(12, 385);
            this.btnSelecionarRota.Name = "btnSelecionarRota";
            this.btnSelecionarRota.Size = new System.Drawing.Size(114, 24);
            this.btnSelecionarRota.TabIndex = 2;
            this.btnSelecionarRota.Text = "Calcular Caminho";
            this.btnSelecionarRota.UseVisualStyleBackColor = true;
            this.btnSelecionarRota.Click += new System.EventHandler(this.btnSelecionarRota_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(533, 358);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 21);
            this.textBox3.TabIndex = 4;
            // 
            // lblSelecao
            // 
            this.lblSelecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecao.ForeColor = System.Drawing.Color.Blue;
            this.lblSelecao.Location = new System.Drawing.Point(257, 388);
            this.lblSelecao.Name = "lblSelecao";
            this.lblSelecao.Size = new System.Drawing.Size(694, 23);
            this.lblSelecao.TabIndex = 5;
            this.lblSelecao.Text = "_________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Melhor Caminho:";
            // 
            // lbDados
            // 
            this.lbDados.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lbDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDados.FormattingEnabled = true;
            this.lbDados.Location = new System.Drawing.Point(663, 29);
            this.lbDados.Name = "lbDados";
            this.lbDados.Size = new System.Drawing.Size(368, 199);
            this.lbDados.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Posição Partida :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Posição Objeto :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(237, 358);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Posição Destino :";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(382, 359);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 21);
            this.textBox2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(663, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Últimas 10 Viagens:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rotas Disponíveis:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Location = new System.Drawing.Point(600, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 22);
            this.button1.TabIndex = 19;
            this.button1.Text = "Limpar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1039, 421);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelecao);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnSelecionarRota);
            this.Controls.Add(this.btnCriarDataTable);
            this.Controls.Add(this.dgvDados);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amazônia Faster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnCriarDataTable;
        private System.Windows.Forms.Button btnSelecionarRota;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblSelecao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDados;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}

