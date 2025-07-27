namespace HVAC_BacnetTCPIP.Faceplates
{
    partial class Valve
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
            this.Sampling_100ms = new System.Windows.Forms.Timer(this.components);
            this.txtSetPosition = new RJCodeAdvance.RJControls.RJTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioMan = new System.Windows.Forms.RadioButton();
            this.radioAuto = new System.Windows.Forms.RadioButton();
            this.Control = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtValvePosition = new RJCodeAdvance.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFlowRateSensor = new RJCodeAdvance.RJControls.RJTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFlowRate = new RJCodeAdvance.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picControlValve = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picControlValve)).BeginInit();
            this.SuspendLayout();
            // 
            // Sampling_100ms
            // 
            this.Sampling_100ms.Enabled = true;
            this.Sampling_100ms.Tick += new System.EventHandler(this.Sampling_1000ms_Tick);
            // 
            // txtSetPosition
            // 
            this.txtSetPosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtSetPosition.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtSetPosition.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtSetPosition.BorderRadius = 0;
            this.txtSetPosition.BorderSize = 2;
            this.txtSetPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSetPosition.Location = new System.Drawing.Point(21, 94);
            this.txtSetPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtSetPosition.Multiline = false;
            this.txtSetPosition.Name = "txtSetPosition";
            this.txtSetPosition.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSetPosition.PasswordChar = false;
            this.txtSetPosition.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSetPosition.PlaceholderText = "";
            this.txtSetPosition.Size = new System.Drawing.Size(150, 39);
            this.txtSetPosition.TabIndex = 0;
            this.txtSetPosition.Texts = "50";
            this.txtSetPosition.UnderlinedStyle = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Teal;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpen.Location = new System.Drawing.Point(21, 154);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(150, 39);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.Paint += new System.Windows.Forms.PaintEventHandler(this.btnOpen_Paint);
            this.btnOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseDown);
            this.btnOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Teal;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(21, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 39);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Paint += new System.Windows.Forms.PaintEventHandler(this.btnClose_Paint);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Teal;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(21, 278);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 39);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Paint += new System.Windows.Forms.PaintEventHandler(this.btnReset_Paint);
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.radioMan);
            this.panel1.Controls.Add(this.radioAuto);
            this.panel1.Controls.Add(this.Control);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.txtSetPosition);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 463);
            this.panel1.TabIndex = 10;
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.Checked = true;
            this.radioMan.ForeColor = System.Drawing.Color.White;
            this.radioMan.Location = new System.Drawing.Point(21, 48);
            this.radioMan.Name = "radioMan";
            this.radioMan.Size = new System.Drawing.Size(65, 24);
            this.radioMan.TabIndex = 12;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "Man";
            this.radioMan.UseVisualStyleBackColor = true;
            // 
            // radioAuto
            // 
            this.radioAuto.AutoSize = true;
            this.radioAuto.ForeColor = System.Drawing.Color.White;
            this.radioAuto.Location = new System.Drawing.Point(103, 48);
            this.radioAuto.Name = "radioAuto";
            this.radioAuto.Size = new System.Drawing.Size(68, 24);
            this.radioAuto.TabIndex = 11;
            this.radioAuto.Text = "Auto";
            this.radioAuto.UseVisualStyleBackColor = true;
            // 
            // Control
            // 
            this.Control.AutoSize = true;
            this.Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Control.ForeColor = System.Drawing.Color.White;
            this.Control.Location = new System.Drawing.Point(51, 9);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(82, 25);
            this.Control.TabIndex = 10;
            this.Control.Text = "Control";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtValvePosition);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFlowRateSensor);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtFlowRate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.picControlValve);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(193, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 463);
            this.panel2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Fault";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(27, 393);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 13;
            // 
            // txtValvePosition
            // 
            this.txtValvePosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtValvePosition.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtValvePosition.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtValvePosition.BorderRadius = 0;
            this.txtValvePosition.BorderSize = 2;
            this.txtValvePosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValvePosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValvePosition.Location = new System.Drawing.Point(27, 332);
            this.txtValvePosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtValvePosition.Multiline = false;
            this.txtValvePosition.Name = "txtValvePosition";
            this.txtValvePosition.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtValvePosition.PasswordChar = false;
            this.txtValvePosition.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtValvePosition.PlaceholderText = "";
            this.txtValvePosition.Size = new System.Drawing.Size(150, 40);
            this.txtValvePosition.TabIndex = 21;
            this.txtValvePosition.Texts = "";
            this.txtValvePosition.UnderlinedStyle = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Valve Position";
            // 
            // txtFlowRateSensor
            // 
            this.txtFlowRateSensor.BackColor = System.Drawing.SystemColors.Window;
            this.txtFlowRateSensor.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFlowRateSensor.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFlowRateSensor.BorderRadius = 0;
            this.txtFlowRateSensor.BorderSize = 2;
            this.txtFlowRateSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFlowRateSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFlowRateSensor.Location = new System.Drawing.Point(27, 262);
            this.txtFlowRateSensor.Margin = new System.Windows.Forms.Padding(4);
            this.txtFlowRateSensor.Multiline = false;
            this.txtFlowRateSensor.Name = "txtFlowRateSensor";
            this.txtFlowRateSensor.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFlowRateSensor.PasswordChar = false;
            this.txtFlowRateSensor.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFlowRateSensor.PlaceholderText = "";
            this.txtFlowRateSensor.Size = new System.Drawing.Size(150, 40);
            this.txtFlowRateSensor.TabIndex = 19;
            this.txtFlowRateSensor.Texts = "";
            this.txtFlowRateSensor.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Flow Rate Sensor";
            // 
            // txtFlowRate
            // 
            this.txtFlowRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtFlowRate.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFlowRate.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFlowRate.BorderRadius = 0;
            this.txtFlowRate.BorderSize = 2;
            this.txtFlowRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFlowRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFlowRate.Location = new System.Drawing.Point(27, 195);
            this.txtFlowRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtFlowRate.Multiline = false;
            this.txtFlowRate.Name = "txtFlowRate";
            this.txtFlowRate.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFlowRate.PasswordChar = false;
            this.txtFlowRate.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFlowRate.PlaceholderText = "";
            this.txtFlowRate.Size = new System.Drawing.Size(150, 40);
            this.txtFlowRate.TabIndex = 17;
            this.txtFlowRate.Texts = "";
            this.txtFlowRate.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Flow Rate";
            // 
            // picControlValve
            // 
            this.picControlValve.Location = new System.Drawing.Point(50, 48);
            this.picControlValve.Name = "picControlValve";
            this.picControlValve.Size = new System.Drawing.Size(100, 100);
            this.picControlValve.TabIndex = 15;
            this.picControlValve.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Monitoring";
            // 
            // Valve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Valve";
            this.ShowIcon = false;
            this.Text = "Valve";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Valve_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picControlValve)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Sampling_100ms;
        public RJCodeAdvance.RJControls.RJTextBox txtSetPosition;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioMan;
        private System.Windows.Forms.RadioButton radioAuto;
        private System.Windows.Forms.Label Control;
        private System.Windows.Forms.Panel panel2;
        private RJCodeAdvance.RJControls.RJTextBox txtFlowRateSensor;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJTextBox txtFlowRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picControlValve;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJTextBox txtValvePosition;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}