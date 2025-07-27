namespace HVAC_BacnetTCPIP.Views
{
    partial class Damper
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.radioMan = new System.Windows.Forms.RadioButton();
            this.radioAuto = new System.Windows.Forms.RadioButton();
            this.Control = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDamperPosition = new RJCodeAdvance.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDamperSP = new RJCodeAdvance.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picDamper = new System.Windows.Forms.PictureBox();
            this.Sampling_100ms = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDamper)).BeginInit();
            this.SuspendLayout();
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
            this.btnOpen.Location = new System.Drawing.Point(12, 64);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(150, 39);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseDown);
            this.btnOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseUp);
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
            this.btnReset.Location = new System.Drawing.Point(12, 186);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 39);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
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
            this.btnClose.Location = new System.Drawing.Point(12, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 39);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.Checked = true;
            this.radioMan.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.radioMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.radioMan.Location = new System.Drawing.Point(12, 18);
            this.radioMan.Name = "radioMan";
            this.radioMan.Size = new System.Drawing.Size(74, 27);
            this.radioMan.TabIndex = 15;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "Man";
            this.radioMan.UseVisualStyleBackColor = true;
            // 
            // radioAuto
            // 
            this.radioAuto.AutoSize = true;
            this.radioAuto.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.radioAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.radioAuto.Location = new System.Drawing.Point(94, 18);
            this.radioAuto.Name = "radioAuto";
            this.radioAuto.Size = new System.Drawing.Size(78, 27);
            this.radioAuto.TabIndex = 14;
            this.radioAuto.Text = "Auto";
            this.radioAuto.UseVisualStyleBackColor = true;
            // 
            // Control
            // 
            this.Control.AutoSize = true;
            this.Control.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold);
            this.Control.ForeColor = System.Drawing.Color.White;
            this.Control.Location = new System.Drawing.Point(117, 9);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(180, 30);
            this.Control.TabIndex = 13;
            this.Control.Text = "Control Panel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.panel1.Controls.Add(this.Control);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 50);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.radioAuto);
            this.panel2.Controls.Add(this.radioMan);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 294);
            this.panel2.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(58, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "Fault";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(30, 249);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 24;
            // 
            // txtDamperPosition
            // 
            this.txtDamperPosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtDamperPosition.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDamperPosition.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDamperPosition.BorderRadius = 0;
            this.txtDamperPosition.BorderSize = 2;
            this.txtDamperPosition.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamperPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDamperPosition.Location = new System.Drawing.Point(321, 278);
            this.txtDamperPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtDamperPosition.Multiline = false;
            this.txtDamperPosition.Name = "txtDamperPosition";
            this.txtDamperPosition.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDamperPosition.PasswordChar = false;
            this.txtDamperPosition.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDamperPosition.PlaceholderText = "";
            this.txtDamperPosition.Size = new System.Drawing.Size(90, 38);
            this.txtDamperPosition.TabIndex = 32;
            this.txtDamperPosition.Texts = "";
            this.txtDamperPosition.UnderlinedStyle = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(185, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Damper Pos";
            // 
            // txtDamperSP
            // 
            this.txtDamperSP.BackColor = System.Drawing.SystemColors.Window;
            this.txtDamperSP.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDamperSP.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDamperSP.BorderRadius = 0;
            this.txtDamperSP.BorderSize = 2;
            this.txtDamperSP.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamperSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDamperSP.Location = new System.Drawing.Point(321, 231);
            this.txtDamperSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtDamperSP.Multiline = false;
            this.txtDamperSP.Name = "txtDamperSP";
            this.txtDamperSP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDamperSP.PasswordChar = false;
            this.txtDamperSP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDamperSP.PlaceholderText = "";
            this.txtDamperSP.Size = new System.Drawing.Size(90, 38);
            this.txtDamperSP.TabIndex = 28;
            this.txtDamperSP.Texts = "50";
            this.txtDamperSP.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Damper SP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, -56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Monitoring";
            // 
            // picDamper
            // 
            this.picDamper.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Damper_Close_removebg;
            this.picDamper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDamper.Location = new System.Drawing.Point(236, 68);
            this.picDamper.Name = "picDamper";
            this.picDamper.Size = new System.Drawing.Size(125, 125);
            this.picDamper.TabIndex = 26;
            this.picDamper.TabStop = false;
            // 
            // Sampling_100ms
            // 
            this.Sampling_100ms.Enabled = true;
            this.Sampling_100ms.Tick += new System.EventHandler(this.Sampling_100ms_Tick);
            // 
            // Damper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 344);
            this.Controls.Add(this.txtDamperPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDamperSP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picDamper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Damper";
            this.ShowIcon = false;
            this.Text = "Damper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Damper_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDamper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radioMan;
        private System.Windows.Forms.RadioButton radioAuto;
        private System.Windows.Forms.Label Control;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private RJCodeAdvance.RJControls.RJTextBox txtDamperPosition;
        private System.Windows.Forms.Label label4;
        public RJCodeAdvance.RJControls.RJTextBox txtDamperSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picDamper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Sampling_100ms;
    }
}