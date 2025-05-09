using System.Drawing;
using System.Windows.Forms;

namespace Policlinica_Proiect
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
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel = new Policlinica_Proiect.RoundedPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new Policlinica_Proiect.RoundedPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxAsigurat = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxVarsta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCNP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.roundedPanel.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(282, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 91);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bun venit! ";
            // 
            // roundedPanel
            // 
            this.roundedPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.roundedPanel.BorderColor = System.Drawing.Color.DarkBlue;
            this.roundedPanel.BorderRadius = 20;
            this.roundedPanel.BorderSize = 2;
            this.roundedPanel.Controls.Add(this.button4);
            this.roundedPanel.Controls.Add(this.button2);
            this.roundedPanel.Controls.Add(this.button1);
            this.roundedPanel.Controls.Add(this.passwordTextBox);
            this.roundedPanel.Controls.Add(this.textBoxUsername);
            this.roundedPanel.Controls.Add(this.label4);
            this.roundedPanel.Controls.Add(this.label3);
            this.roundedPanel.Controls.Add(this.label2);
            this.roundedPanel.Location = new System.Drawing.Point(214, 110);
            this.roundedPanel.Name = "roundedPanel";
            this.roundedPanel.ShadowColor = System.Drawing.Color.Gray;
            this.roundedPanel.ShadowOffset = 10;
            this.roundedPanel.Size = new System.Drawing.Size(568, 360);
            this.roundedPanel.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.Location = new System.Drawing.Point(388, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 45);
            this.button3.TabIndex = 6;
            this.button3.Text = "Sign In";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(408, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 72);
            this.button2.TabIndex = 5;
            this.button2.Text = "Pacient fara cont";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(37, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(186, 144);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(293, 22);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(186, 93);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(293, 22);
            this.textBoxUsername.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(204, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "LOG IN";
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Black;
            this.roundedPanel3.BorderRadius = 20;
            this.roundedPanel3.BorderSize = 2;
            this.roundedPanel3.Controls.Add(this.checkBoxAsigurat);
            this.roundedPanel3.Controls.Add(this.button3);
            this.roundedPanel3.Controls.Add(this.label13);
            this.roundedPanel3.Controls.Add(this.textBoxTelefon);
            this.roundedPanel3.Controls.Add(this.label12);
            this.roundedPanel3.Controls.Add(this.textBoxAdresa);
            this.roundedPanel3.Controls.Add(this.label11);
            this.roundedPanel3.Controls.Add(this.textBoxVarsta);
            this.roundedPanel3.Controls.Add(this.label10);
            this.roundedPanel3.Controls.Add(this.textBoxCNP);
            this.roundedPanel3.Controls.Add(this.label9);
            this.roundedPanel3.Controls.Add(this.textBoxPrenume);
            this.roundedPanel3.Controls.Add(this.label8);
            this.roundedPanel3.Controls.Add(this.textBoxNume);
            this.roundedPanel3.Controls.Add(this.label7);
            this.roundedPanel3.Location = new System.Drawing.Point(201, 12);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.ShadowColor = System.Drawing.Color.Black;
            this.roundedPanel3.ShadowOffset = 5;
            this.roundedPanel3.Size = new System.Drawing.Size(607, 374);
            this.roundedPanel3.TabIndex = 38;
            this.roundedPanel3.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SkyBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button4.Location = new System.Drawing.Point(169, 253);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 45);
            this.button4.TabIndex = 41;
            this.button4.Text = "Sign In";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxAsigurat
            // 
            this.checkBoxAsigurat.AutoSize = true;
            this.checkBoxAsigurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAsigurat.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkBoxAsigurat.Location = new System.Drawing.Point(36, 325);
            this.checkBoxAsigurat.Name = "checkBoxAsigurat";
            this.checkBoxAsigurat.Size = new System.Drawing.Size(122, 33);
            this.checkBoxAsigurat.TabIndex = 40;
            this.checkBoxAsigurat.Text = "Asigurat";
            this.checkBoxAsigurat.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkBlue;
            this.label13.Location = new System.Drawing.Point(31, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 29);
            this.label13.TabIndex = 38;
            this.label13.Text = "Telefon";
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(148, 279);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(434, 22);
            this.textBoxTelefon.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(31, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 29);
            this.label12.TabIndex = 36;
            this.label12.Text = "Adresa";
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(148, 235);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(434, 22);
            this.textBoxAdresa.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(31, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 29);
            this.label11.TabIndex = 34;
            this.label11.Text = "Varsta";
            // 
            // textBoxVarsta
            // 
            this.textBoxVarsta.Location = new System.Drawing.Point(148, 196);
            this.textBoxVarsta.Name = "textBoxVarsta";
            this.textBoxVarsta.Size = new System.Drawing.Size(434, 22);
            this.textBoxVarsta.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(31, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 29);
            this.label10.TabIndex = 32;
            this.label10.Text = "CNP";
            // 
            // textBoxCNP
            // 
            this.textBoxCNP.Location = new System.Drawing.Point(148, 158);
            this.textBoxCNP.Name = "textBoxCNP";
            this.textBoxCNP.Size = new System.Drawing.Size(434, 22);
            this.textBoxCNP.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(31, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 29);
            this.label9.TabIndex = 30;
            this.label9.Text = "Prenume";
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Location = new System.Drawing.Point(148, 115);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(434, 22);
            this.textBoxPrenume.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(31, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "Nume";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(148, 75);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(434, 22);
            this.textBoxNume.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(29, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 36);
            this.label7.TabIndex = 26;
            this.label7.Text = "Date pacient";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.medical_care;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(965, 535);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel);
            this.Name = "Form1";
            this.Text = "Policlinica Sanavita";
            this.roundedPanel.ResumeLayout(false);
            this.roundedPanel.PerformLayout();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedPanel roundedPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUsername;
        private TextBox passwordTextBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private RoundedPanel roundedPanel3;
        private CheckBox checkBoxAsigurat;
        private Label label13;
        private TextBox textBoxTelefon;
        private Label label12;
        private TextBox textBoxAdresa;
        private Label label11;
        private TextBox textBoxVarsta;
        private Label label10;
        private TextBox textBoxCNP;
        private Label label9;
        private TextBox textBoxPrenume;
        private Label label8;
        private TextBox textBoxNume;
        private Label label7;
        private Button button4;
    }
}

