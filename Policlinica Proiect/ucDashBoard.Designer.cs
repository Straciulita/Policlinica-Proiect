namespace Policlinica_Proiect
{
    partial class ucDashBoard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashBoard));
            this.label21 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.labelDetalii = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelConsultatie = new System.Windows.Forms.Panel();
            this.lbNumePrenume = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxDiagnostic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTratament = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelConsultatie.SuspendLayout();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkBlue;
            this.label21.Location = new System.Drawing.Point(21, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(527, 42);
            this.label21.TabIndex = 39;
            this.label21.Text = "Pacientii de azi si Istoricul lor";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel7.Controls.Add(this.button3);
            this.panel7.Controls.Add(this.labelDetalii);
            this.panel7.Location = new System.Drawing.Point(833, 143);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1035, 734);
            this.panel7.TabIndex = 44;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkBlue;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(794, 660);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 54);
            this.button3.TabIndex = 15;
            this.button3.Text = "Consultatie";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelDetalii
            // 
            this.labelDetalii.AutoSize = true;
            this.labelDetalii.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalii.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelDetalii.Location = new System.Drawing.Point(46, 26);
            this.labelDetalii.Name = "labelDetalii";
            this.labelDetalii.Size = new System.Drawing.Size(198, 32);
            this.labelDetalii.TabIndex = 0;
            this.labelDetalii.Text = "detalii pacienti";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(716, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 58);
            this.button1.TabIndex = 43;
            this.button1.Text = "Afisare";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(584, 67);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(71, 58);
            this.buttonSearch.TabIndex = 42;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(56, 85);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(504, 34);
            this.textBoxSearch.TabIndex = 41;
            this.textBoxSearch.Text = "cautare....";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Beige;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(40, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(729, 207);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelConsultatie
            // 
            this.panelConsultatie.BackColor = System.Drawing.Color.LightYellow;
            this.panelConsultatie.Controls.Add(this.lbNumePrenume);
            this.panelConsultatie.Controls.Add(this.button2);
            this.panelConsultatie.Controls.Add(this.textBoxDiagnostic);
            this.panelConsultatie.Controls.Add(this.label1);
            this.panelConsultatie.Controls.Add(this.textBoxTratament);
            this.panelConsultatie.Controls.Add(this.label2);
            this.panelConsultatie.Enabled = false;
            this.panelConsultatie.Location = new System.Drawing.Point(40, 378);
            this.panelConsultatie.Name = "panelConsultatie";
            this.panelConsultatie.Size = new System.Drawing.Size(729, 499);
            this.panelConsultatie.TabIndex = 45;
            // 
            // lbNumePrenume
            // 
            this.lbNumePrenume.AutoSize = true;
            this.lbNumePrenume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumePrenume.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbNumePrenume.Location = new System.Drawing.Point(24, 50);
            this.lbNumePrenume.Name = "lbNumePrenume";
            this.lbNumePrenume.Size = new System.Drawing.Size(198, 32);
            this.lbNumePrenume.TabIndex = 17;
            this.lbNumePrenume.Text = "detalii pacienti";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(118, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(472, 54);
            this.button2.TabIndex = 16;
            this.button2.Text = "Adauga tratament si diagnostic";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDiagnostic
            // 
            this.textBoxDiagnostic.Location = new System.Drawing.Point(185, 129);
            this.textBoxDiagnostic.Name = "textBoxDiagnostic";
            this.textBoxDiagnostic.Size = new System.Drawing.Size(506, 22);
            this.textBoxDiagnostic.TabIndex = 11;
            this.textBoxDiagnostic.TextChanged += new System.EventHandler(this.textBoxDiagnostic_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(25, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Diagnostic";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxTratament
            // 
            this.textBoxTratament.Location = new System.Drawing.Point(185, 187);
            this.textBoxTratament.Multiline = true;
            this.textBoxTratament.Name = "textBoxTratament";
            this.textBoxTratament.Size = new System.Drawing.Size(506, 122);
            this.textBoxTratament.TabIndex = 9;
            this.textBoxTratament.TextChanged += new System.EventHandler(this.textBoxTratament_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(25, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tratament";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ucDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelConsultatie);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label21);
            this.Name = "ucDashBoard";
            this.Size = new System.Drawing.Size(2019, 929);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelConsultatie.ResumeLayout(false);
            this.panelConsultatie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelDetalii;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelConsultatie;
        private System.Windows.Forms.TextBox textBoxTratament;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxDiagnostic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNumePrenume;
    }
}
