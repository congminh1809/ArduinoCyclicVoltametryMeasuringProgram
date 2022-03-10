using System;

namespace CsharpInterface
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btRun = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBarMeasure = new System.Windows.Forms.ProgressBar();
            this.btCheck = new System.Windows.Forms.Button();
            this.comboBR = new System.Windows.Forms.ComboBox();
            this.txt_SVol = new System.Windows.Forms.TextBox();
            this.txt_EVol = new System.Windows.Forms.TextBox();
            this.txt_Step = new System.Windows.Forms.TextBox();
            this.txt_Freq = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txt_Frame = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(328, 2);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1184, 826);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // comboBoxName
            // 
            this.comboBoxName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(8, 2);
            this.comboBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(102, 21);
            this.comboBoxName.TabIndex = 1;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.Color.Red;
            this.btConnect.Location = new System.Drawing.Point(196, 59);
            this.btConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(61, 37);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Lime;
            this.btExit.Location = new System.Drawing.Point(262, 59);
            this.btExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(61, 37);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btSave.Location = new System.Drawing.Point(196, 151);
            this.btSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(61, 37);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btRun
            // 
            this.btRun.BackColor = System.Drawing.Color.Pink;
            this.btRun.Location = new System.Drawing.Point(262, 9);
            this.btRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(61, 37);
            this.btRun.TabIndex = 6;
            this.btRun.Text = "Check";
            this.btRun.UseVisualStyleBackColor = false;
            this.btRun.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // btPause
            // 
            this.btPause.BackColor = System.Drawing.Color.Crimson;
            this.btPause.Location = new System.Drawing.Point(262, 151);
            this.btPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(61, 37);
            this.btPause.TabIndex = 7;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = false;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.Fuchsia;
            this.btClear.Location = new System.Drawing.Point(262, 104);
            this.btClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(61, 38);
            this.btClear.TabIndex = 8;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 215);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(316, 613);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Potential (mV)";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current (uA)";
            this.columnHeader2.Width = 163;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Maroon;
            this.progressBar1.ForeColor = System.Drawing.Color.GreenYellow;
            this.progressBar1.Location = new System.Drawing.Point(113, 9);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 37);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // progressBarMeasure
            // 
            this.progressBarMeasure.Location = new System.Drawing.Point(8, 192);
            this.progressBarMeasure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarMeasure.Name = "progressBarMeasure";
            this.progressBarMeasure.Size = new System.Drawing.Size(319, 19);
            this.progressBarMeasure.Step = 1;
            this.progressBarMeasure.TabIndex = 12;
            // 
            // btCheck
            // 
            this.btCheck.BackColor = System.Drawing.Color.Gold;
            this.btCheck.Location = new System.Drawing.Point(196, 104);
            this.btCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(61, 38);
            this.btCheck.TabIndex = 11;
            this.btCheck.Text = "Start";
            this.btCheck.UseVisualStyleBackColor = false;
            this.btCheck.Click += new System.EventHandler(this.btRun_Click);
            // 
            // comboBR
            // 
            this.comboBR.ForeColor = System.Drawing.Color.Firebrick;
            this.comboBR.FormattingEnabled = true;
            this.comboBR.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.comboBR.Location = new System.Drawing.Point(8, 33);
            this.comboBR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBR.Name = "comboBR";
            this.comboBR.Size = new System.Drawing.Size(102, 21);
            this.comboBR.TabIndex = 12;
            this.comboBR.Text = "Baud Rate";
            this.comboBR.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txt_SVol
            // 
            this.txt_SVol.Location = new System.Drawing.Point(91, 65);
            this.txt_SVol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_SVol.Name = "txt_SVol";
            this.txt_SVol.Size = new System.Drawing.Size(103, 20);
            this.txt_SVol.TabIndex = 13;
            this.txt_SVol.Click += new System.EventHandler(this.txt_SVol_TextChanged);
            this.txt_SVol.TextChanged += new System.EventHandler(this.txt_SVol_TextChanged);
            // 
            // txt_EVol
            // 
            this.txt_EVol.Location = new System.Drawing.Point(91, 89);
            this.txt_EVol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_EVol.Name = "txt_EVol";
            this.txt_EVol.Size = new System.Drawing.Size(103, 20);
            this.txt_EVol.TabIndex = 14;
            this.txt_EVol.Click += new System.EventHandler(this.txt_EVol_TextChanged);
            this.txt_EVol.TextChanged += new System.EventHandler(this.txt_EVol_TextChanged);
            // 
            // txt_Step
            // 
            this.txt_Step.Location = new System.Drawing.Point(91, 114);
            this.txt_Step.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Step.Name = "txt_Step";
            this.txt_Step.Size = new System.Drawing.Size(103, 20);
            this.txt_Step.TabIndex = 15;
            this.txt_Step.Click += new System.EventHandler(this.txt_Step_TextChanged);
            this.txt_Step.TextChanged += new System.EventHandler(this.txt_Step_TextChanged);
            // 
            // txt_Freq
            // 
            this.txt_Freq.Location = new System.Drawing.Point(91, 138);
            this.txt_Freq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Freq.Name = "txt_Freq";
            this.txt_Freq.Size = new System.Drawing.Size(103, 20);
            this.txt_Freq.TabIndex = 16;
            this.txt_Freq.Click += new System.EventHandler(this.txt_Freq_TextChanged);
            this.txt_Freq.TextChanged += new System.EventHandler(this.txt_Freq_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 65);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Start Voltage";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 89);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "End Votage";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 114);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Step";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(8, 138);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 20);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "Frequency";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(8, 162);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 21;
            this.textBox5.Text = "Filter Frame";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Frame
            // 
            this.txt_Frame.Location = new System.Drawing.Point(91, 162);
            this.txt_Frame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Frame.Name = "txt_Frame";
            this.txt_Frame.Size = new System.Drawing.Size(103, 20);
            this.txt_Frame.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 845);
            this.Controls.Add(this.txt_Frame);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_Freq);
            this.Controls.Add(this.txt_Step);
            this.Controls.Add(this.txt_EVol);
            this.Controls.Add(this.txt_SVol);
            this.Controls.Add(this.comboBR);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressBarMeasure);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.zedGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Research and development of cyclic voltammetry measuring system for biomedical te" +
    "sting";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btClear;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBarMeasure;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.ComboBox comboBR;
        private System.Windows.Forms.TextBox txt_SVol;
        private System.Windows.Forms.TextBox txt_EVol;
        private System.Windows.Forms.TextBox txt_Step;
        private System.Windows.Forms.TextBox txt_Freq;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txt_Frame;
    }
}