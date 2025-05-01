using System.Drawing;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelOraData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMeniu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRapoarte = new System.Windows.Forms.Button();
            this.buttonServicii = new System.Windows.Forms.Button();
            this.buttonProgram = new System.Windows.Forms.Button();
            this.buttonPacienti = new System.Windows.Forms.Button();
            this.buttonPersonal = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.main = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.labelOraData);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonMeniu);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2076, 86);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.ceas;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(1483, 15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(62, 57);
            this.panel6.TabIndex = 6;
            // 
            // labelOraData
            // 
            this.labelOraData.AutoSize = true;
            this.labelOraData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOraData.ForeColor = System.Drawing.Color.Navy;
            this.labelOraData.Location = new System.Drawing.Point(1551, 30);
            this.labelOraData.Name = "labelOraData";
            this.labelOraData.Size = new System.Drawing.Size(254, 32);
            this.labelOraData.TabIndex = 4;
            this.labelOraData.Text = "Ora si data curenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(824, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "Policlinica Sanavita";
            // 
            // buttonMeniu
            // 
            this.buttonMeniu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonMeniu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMeniu.Image = ((System.Drawing.Image)(resources.GetObject("buttonMeniu.Image")));
            this.buttonMeniu.Location = new System.Drawing.Point(24, 10);
            this.buttonMeniu.Name = "buttonMeniu";
            this.buttonMeniu.Size = new System.Drawing.Size(100, 68);
            this.buttonMeniu.TabIndex = 5;
            this.buttonMeniu.UseVisualStyleBackColor = false;
            this.buttonMeniu.Click += new System.EventHandler(this.buttonMeniu_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.inima;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(731, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(76, 62);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.poza_300x300;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(173, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(57, 54);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.buttonRapoarte);
            this.panel4.Controls.Add(this.buttonServicii);
            this.panel4.Controls.Add(this.buttonProgram);
            this.panel4.Controls.Add(this.buttonPacienti);
            this.panel4.Controls.Add(this.buttonPersonal);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(1, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(205, 575);
            this.panel4.TabIndex = 1;
            this.panel4.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cabinete";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonRapoarte
            // 
            this.buttonRapoarte.BackColor = System.Drawing.Color.LightBlue;
            this.buttonRapoarte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRapoarte.FlatAppearance.BorderSize = 0;
            this.buttonRapoarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRapoarte.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonRapoarte.Image = ((System.Drawing.Image)(resources.GetObject("buttonRapoarte.Image")));
            this.buttonRapoarte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRapoarte.Location = new System.Drawing.Point(-3, 491);
            this.buttonRapoarte.Name = "buttonRapoarte";
            this.buttonRapoarte.Size = new System.Drawing.Size(207, 69);
            this.buttonRapoarte.TabIndex = 6;
            this.buttonRapoarte.Text = "Rapoarte";
            this.buttonRapoarte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRapoarte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRapoarte.UseVisualStyleBackColor = false;
            // 
            // buttonServicii
            // 
            this.buttonServicii.BackColor = System.Drawing.Color.LightBlue;
            this.buttonServicii.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonServicii.FlatAppearance.BorderSize = 0;
            this.buttonServicii.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServicii.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonServicii.Image = ((System.Drawing.Image)(resources.GetObject("buttonServicii.Image")));
            this.buttonServicii.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonServicii.Location = new System.Drawing.Point(-3, 416);
            this.buttonServicii.Name = "buttonServicii";
            this.buttonServicii.Size = new System.Drawing.Size(207, 69);
            this.buttonServicii.TabIndex = 5;
            this.buttonServicii.Text = "Servicii";
            this.buttonServicii.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonServicii.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonServicii.UseVisualStyleBackColor = false;
            // 
            // buttonProgram
            // 
            this.buttonProgram.BackColor = System.Drawing.Color.LightBlue;
            this.buttonProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProgram.FlatAppearance.BorderSize = 0;
            this.buttonProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgram.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonProgram.Image = ((System.Drawing.Image)(resources.GetObject("buttonProgram.Image")));
            this.buttonProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProgram.Location = new System.Drawing.Point(-2, 341);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(207, 69);
            this.buttonProgram.TabIndex = 4;
            this.buttonProgram.Text = "Program";
            this.buttonProgram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProgram.UseVisualStyleBackColor = false;
            this.buttonProgram.Click += new System.EventHandler(this.buttonProgram_Click);
            // 
            // buttonPacienti
            // 
            this.buttonPacienti.BackColor = System.Drawing.Color.LightBlue;
            this.buttonPacienti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPacienti.FlatAppearance.BorderSize = 0;
            this.buttonPacienti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPacienti.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonPacienti.Image = ((System.Drawing.Image)(resources.GetObject("buttonPacienti.Image")));
            this.buttonPacienti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPacienti.Location = new System.Drawing.Point(0, 266);
            this.buttonPacienti.Name = "buttonPacienti";
            this.buttonPacienti.Size = new System.Drawing.Size(207, 69);
            this.buttonPacienti.TabIndex = 3;
            this.buttonPacienti.Text = "Pacienti";
            this.buttonPacienti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPacienti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPacienti.UseVisualStyleBackColor = false;
            this.buttonPacienti.Click += new System.EventHandler(this.buttonPacienti_Click);
            // 
            // buttonPersonal
            // 
            this.buttonPersonal.BackColor = System.Drawing.Color.LightBlue;
            this.buttonPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPersonal.FlatAppearance.BorderSize = 0;
            this.buttonPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPersonal.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonPersonal.Image = ((System.Drawing.Image)(resources.GetObject("buttonPersonal.Image")));
            this.buttonPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPersonal.Location = new System.Drawing.Point(0, 116);
            this.buttonPersonal.Name = "buttonPersonal";
            this.buttonPersonal.Size = new System.Drawing.Size(207, 69);
            this.buttonPersonal.TabIndex = 2;
            this.buttonPersonal.Text = "Personal";
            this.buttonPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPersonal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPersonal.UseVisualStyleBackColor = false;
            this.buttonPersonal.Click += new System.EventHandler(this.buttonPersonal_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.icon;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(56, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(80, 74);
            this.panel5.TabIndex = 0;
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.main.Controls.Add(this.label3);
            this.main.Location = new System.Drawing.Point(-2, 93);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(2500, 1047);
            this.main.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(834, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(489, 91);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bine ai venit!";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.main);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Sanavita";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Panel panel3;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private Timer timer1;
        private Label labelOraData;
        private Panel panel4;
        private Panel panel5;
        private Button buttonPersonal;
        private Button buttonRapoarte;
        private Button buttonServicii;
        private Button buttonProgram;
        private Button buttonPacienti;
        private Button buttonMeniu;
        private Button button2;
        private Panel panel6;
        private Panel main;
        private Label label3;
    }
}