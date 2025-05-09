using System;
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
            this.button1 = new System.Windows.Forms.Button();
            this.labelOraData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.main = new System.Windows.Forms.Panel();
            this.MeniuPacient = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.meniuDoctor = new System.Windows.Forms.Panel();
            this.meniuAdmin = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.buttonCalendar = new System.Windows.Forms.Button();
            this.buttonPacientiDoc = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonProgramari = new System.Windows.Forms.Button();
            this.buttonRapoarte = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonServicii = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonProgram = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonPacienti = new System.Windows.Forms.Button();
            this.buttonPersonal = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonMeniu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.main.SuspendLayout();
            this.MeniuPacient.SuspendLayout();
            this.meniuDoctor.SuspendLayout();
            this.meniuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(389, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 40);
            this.button1.TabIndex = 17;
            this.button1.Text = "Log Out";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.main.Controls.Add(this.MeniuPacient);
            this.main.Controls.Add(this.meniuDoctor);
            this.main.Controls.Add(this.panel7);
            this.main.Controls.Add(this.meniuAdmin);
            this.main.Controls.Add(this.label13);
            this.main.Controls.Add(this.panel4);
            this.main.Controls.Add(this.label12);
            this.main.Controls.Add(this.label11);
            this.main.Controls.Add(this.label10);
            this.main.Controls.Add(this.label9);
            this.main.Controls.Add(this.label8);
            this.main.Controls.Add(this.label7);
            this.main.Controls.Add(this.label6);
            this.main.Controls.Add(this.label5);
            this.main.Controls.Add(this.label4);
            this.main.Controls.Add(this.label3);
            this.main.Location = new System.Drawing.Point(-2, 93);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(2363, 1047);
            this.main.TabIndex = 3;
            // 
            // MeniuPacient
            // 
            this.MeniuPacient.BackColor = System.Drawing.Color.LightSkyBlue;
            this.MeniuPacient.Controls.Add(this.button6);
            this.MeniuPacient.Controls.Add(this.label14);
            this.MeniuPacient.Controls.Add(this.button5);
            this.MeniuPacient.Controls.Add(this.panel10);
            this.MeniuPacient.Location = new System.Drawing.Point(3, 3);
            this.MeniuPacient.Name = "MeniuPacient";
            this.MeniuPacient.Size = new System.Drawing.Size(232, 754);
            this.MeniuPacient.TabIndex = 17;
            this.MeniuPacient.Visible = false;
            // 
            // label14
            // 
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkBlue;
            this.label14.Location = new System.Drawing.Point(6, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(226, 46);
            this.label14.TabIndex = 17;
            this.label14.Text = "Istoric";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            this.label14.MouseHover += new System.EventHandler(this.button6_MouseHover);
            // 
            // meniuDoctor
            // 
            this.meniuDoctor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.meniuDoctor.Controls.Add(this.buttonCalendar);
            this.meniuDoctor.Controls.Add(this.buttonPacientiDoc);
            this.meniuDoctor.Controls.Add(this.panel9);
            this.meniuDoctor.Controls.Add(this.button11);
            this.meniuDoctor.Location = new System.Drawing.Point(0, 6);
            this.meniuDoctor.Name = "meniuDoctor";
            this.meniuDoctor.Size = new System.Drawing.Size(211, 754);
            this.meniuDoctor.TabIndex = 16;
            // 
            // meniuAdmin
            // 
            this.meniuAdmin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.meniuAdmin.Controls.Add(this.buttonProgramari);
            this.meniuAdmin.Controls.Add(this.buttonRapoarte);
            this.meniuAdmin.Controls.Add(this.button2);
            this.meniuAdmin.Controls.Add(this.buttonServicii);
            this.meniuAdmin.Controls.Add(this.button4);
            this.meniuAdmin.Controls.Add(this.buttonProgram);
            this.meniuAdmin.Controls.Add(this.button3);
            this.meniuAdmin.Controls.Add(this.panel5);
            this.meniuAdmin.Controls.Add(this.buttonPacienti);
            this.meniuAdmin.Controls.Add(this.buttonPersonal);
            this.meniuAdmin.Location = new System.Drawing.Point(6, 3);
            this.meniuAdmin.Name = "meniuAdmin";
            this.meniuAdmin.Size = new System.Drawing.Size(211, 754);
            this.meniuAdmin.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkBlue;
            this.label13.Location = new System.Drawing.Point(167, 463);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(599, 46);
            this.label13.TabIndex = 11;
            this.label13.Text = "Unde ne gasiti?";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(880, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(949, 102);
            this.label12.TabIndex = 9;
            this.label12.Text = "Daca ai nevoie de o consultatie sau de o programare pentru analize, te invitam sa" +
    " accesezi sectiunea Programari. Noi suntem aici pentru a te ajuta sa mentii o sa" +
    "natate optima.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(838, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(599, 46);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ai nevoie de o programare?";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(838, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(267, 46);
            this.label10.TabIndex = 7;
            this.label10.Text = "Echipa noastra";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(880, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(949, 102);
            this.label9.TabIndex = 6;
            this.label9.Text = "Echipa noastra este formata din medici specialisti cu experienta, asistente si pe" +
    "rsonal administrativ care se ocupa de bunastarea pacientilor.";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(167, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 46);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ce Oferim?";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(204, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(501, 297);
            this.label7.TabIndex = 4;
            this.label7.Text = "Servicii de consultatii medicale\r\n\r\nAnalize si investigatii\r\n\r\nTratamente persona" +
    "lizate\r\n\r\nVaccinari si consultatii de preventie\r\n\r\nProgramari online pentru como" +
    "ditatea ta";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(223, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1580, 69);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ne bucuram sa te avem alaturi! La Policlinica Sanavita, oferim servicii de sanata" +
    "te de inalta calitate, cu o echipa de specialisti dedicati in scopul de a-ti ofe" +
    "ri cea mai buna ingrijire medicala.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(55, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 29);
            this.label5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(55, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(791, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 69);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bine ai venit!";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightBlue;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.DarkBlue;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-3, 261);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(239, 69);
            this.button6.TabIndex = 10;
            this.button6.Text = "Istoric";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseHover += new System.EventHandler(this.button6_MouseHover);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightBlue;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DarkBlue;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(-1, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(244, 69);
            this.button5.TabIndex = 16;
            this.button5.Text = "Programare";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel10
            // 
            this.panel10.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.icon;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(57, 22);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(80, 74);
            this.panel10.TabIndex = 8;
            // 
            // buttonCalendar
            // 
            this.buttonCalendar.BackColor = System.Drawing.Color.LightBlue;
            this.buttonCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalendar.FlatAppearance.BorderSize = 0;
            this.buttonCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalendar.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonCalendar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCalendar.Image")));
            this.buttonCalendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCalendar.Location = new System.Drawing.Point(-1, 186);
            this.buttonCalendar.Name = "buttonCalendar";
            this.buttonCalendar.Size = new System.Drawing.Size(224, 69);
            this.buttonCalendar.TabIndex = 16;
            this.buttonCalendar.Text = "Calendar";
            this.buttonCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCalendar.UseVisualStyleBackColor = false;
            this.buttonCalendar.Click += new System.EventHandler(this.buttonCalendar_Click);
            // 
            // buttonPacientiDoc
            // 
            this.buttonPacientiDoc.BackColor = System.Drawing.Color.LightBlue;
            this.buttonPacientiDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPacientiDoc.FlatAppearance.BorderSize = 0;
            this.buttonPacientiDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPacientiDoc.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonPacientiDoc.Image = ((System.Drawing.Image)(resources.GetObject("buttonPacientiDoc.Image")));
            this.buttonPacientiDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPacientiDoc.Location = new System.Drawing.Point(-4, 271);
            this.buttonPacientiDoc.Name = "buttonPacientiDoc";
            this.buttonPacientiDoc.Size = new System.Drawing.Size(239, 69);
            this.buttonPacientiDoc.TabIndex = 10;
            this.buttonPacientiDoc.Text = "DashBoard";
            this.buttonPacientiDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPacientiDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPacientiDoc.UseVisualStyleBackColor = false;
            this.buttonPacientiDoc.Click += new System.EventHandler(this.buttonPacientiDoc_Click);
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.icon;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(57, 22);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(80, 74);
            this.panel9.TabIndex = 8;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightBlue;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.DarkBlue;
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(0, 271);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(207, 69);
            this.button11.TabIndex = 10;
            this.button11.Text = "Pacienti";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.IMG_1568;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Location = new System.Drawing.Point(1171, 475);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(658, 443);
            this.panel7.TabIndex = 12;
            // 
            // buttonProgramari
            // 
            this.buttonProgramari.BackColor = System.Drawing.Color.LightBlue;
            this.buttonProgramari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProgramari.FlatAppearance.BorderSize = 0;
            this.buttonProgramari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgramari.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonProgramari.Image = ((System.Drawing.Image)(resources.GetObject("buttonProgramari.Image")));
            this.buttonProgramari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProgramari.Location = new System.Drawing.Point(-10, 497);
            this.buttonProgramari.Name = "buttonProgramari";
            this.buttonProgramari.Size = new System.Drawing.Size(237, 69);
            this.buttonProgramari.TabIndex = 15;
            this.buttonProgramari.Text = "Programari";
            this.buttonProgramari.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonProgramari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProgramari.UseVisualStyleBackColor = false;
            this.buttonProgramari.Click += new System.EventHandler(this.buttonProgramari_Click);
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
            this.buttonRapoarte.Location = new System.Drawing.Point(0, 572);
            this.buttonRapoarte.Name = "buttonRapoarte";
            this.buttonRapoarte.Size = new System.Drawing.Size(214, 69);
            this.buttonRapoarte.TabIndex = 13;
            this.buttonRapoarte.Text = "Rapoarte";
            this.buttonRapoarte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRapoarte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRapoarte.UseVisualStyleBackColor = false;
            this.buttonRapoarte.Click += new System.EventHandler(this.buttonRapoarte_Click);
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
            this.button2.Location = new System.Drawing.Point(0, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 69);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cabinete";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.buttonServicii.Location = new System.Drawing.Point(3, 421);
            this.buttonServicii.Name = "buttonServicii";
            this.buttonServicii.Size = new System.Drawing.Size(211, 69);
            this.buttonServicii.TabIndex = 12;
            this.buttonServicii.Text = "Servicii";
            this.buttonServicii.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonServicii.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonServicii.UseVisualStyleBackColor = false;
            this.buttonServicii.Click += new System.EventHandler(this.buttonServicii_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkBlue;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(3, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(211, 69);
            this.button4.TabIndex = 11;
            this.button4.Text = "Program";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.buttonProgram_Click);
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
            this.buttonProgram.Location = new System.Drawing.Point(0, 346);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(211, 69);
            this.buttonProgram.TabIndex = 11;
            this.buttonProgram.Text = "Program";
            this.buttonProgram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProgram.UseVisualStyleBackColor = false;
            this.buttonProgram.Click += new System.EventHandler(this.buttonProgram_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkBlue;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 271);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 69);
            this.button3.TabIndex = 10;
            this.button3.Text = "Pacienti";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.buttonPacienti_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.icon;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(57, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(80, 74);
            this.panel5.TabIndex = 8;
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
            this.buttonPacienti.Location = new System.Drawing.Point(0, 271);
            this.buttonPacienti.Name = "buttonPacienti";
            this.buttonPacienti.Size = new System.Drawing.Size(207, 69);
            this.buttonPacienti.TabIndex = 10;
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
            this.buttonPersonal.Location = new System.Drawing.Point(0, 121);
            this.buttonPersonal.Name = "buttonPersonal";
            this.buttonPersonal.Size = new System.Drawing.Size(214, 69);
            this.buttonPersonal.TabIndex = 9;
            this.buttonPersonal.Text = "Personal";
            this.buttonPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPersonal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPersonal.UseVisualStyleBackColor = false;
            this.buttonPersonal.Click += new System.EventHandler(this.buttonPersonal_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Policlinica_Proiect.Properties.Resources.location;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(223, 512);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(844, 406);
            this.panel4.TabIndex = 10;
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.main);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Sanavita";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            this.MeniuPacient.ResumeLayout(false);
            this.meniuDoctor.ResumeLayout(false);
            this.meniuAdmin.ResumeLayout(false);
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
        private Button buttonMeniu;
        private Panel panel6;
        private Panel main;
        private Label label3;
        private Panel meniuAdmin;
        private Button buttonRapoarte;
        private Button button2;
        private Button buttonServicii;
        private Button buttonProgram;
        private Panel panel5;
        private Button buttonPacienti;
        private Button buttonPersonal;
        private Button buttonProgramari;
        private Button button4;
        private Button button3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label10;
        private Label label9;
        private Label label12;
        private Label label11;
        private Panel panel4;
        private Label label13;
        private Panel panel7;
        private Panel meniuDoctor;
        private Button buttonPacientiDoc;
        private Panel panel9;
        private Button button11;
        private Button buttonCalendar;
        private Button button1;
        private Panel MeniuPacient;
        private Button button5;
        private Button button6;
        private Panel panel10;
        private ToolTip toolTip1;
        private Label label14;
    }
}