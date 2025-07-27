namespace HVAC_BacnetTCPIP.Faceplates
{
    partial class Motor
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtRuntime = new System.Windows.Forms.TextBox();
            this.setSpeed = new System.Windows.Forms.TrackBar();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.timerRuntime = new System.Windows.Forms.Timer(this.components);
            this.FaultTimer = new System.Windows.Forms.Timer(this.components);
            this.Main_SCL = new System.Windows.Forms.Timer(this.components);
            this.picFault = new System.Windows.Forms.PictureBox();
            this.picSwitch = new System.Windows.Forms.PictureBox();
            this.picMotor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.setSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMotor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(30, 246);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Paint += new System.Windows.Forms.PaintEventHandler(this.btnStart_Paint);
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(30, 314);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 50);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseCompatibleTextRendering = true;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Paint += new System.Windows.Forms.PaintEventHandler(this.btnStop_Paint);
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(30, 382);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 50);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "RESET";
            this.btnReset.UseCompatibleTextRendering = true;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Paint += new System.Windows.Forms.PaintEventHandler(this.btnReset_Paint);
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // txtRuntime
            // 
            this.txtRuntime.BackColor = System.Drawing.Color.White;
            this.txtRuntime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuntime.ForeColor = System.Drawing.Color.Black;
            this.txtRuntime.Location = new System.Drawing.Point(30, 452);
            this.txtRuntime.Name = "txtRuntime";
            this.txtRuntime.Size = new System.Drawing.Size(150, 30);
            this.txtRuntime.TabIndex = 5;
            this.txtRuntime.Text = "00:00:00";
            this.txtRuntime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setSpeed
            // 
            this.setSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.setSpeed.LargeChange = 10;
            this.setSpeed.Location = new System.Drawing.Point(205, 10);
            this.setSpeed.Maximum = 1000;
            this.setSpeed.Name = "setSpeed";
            this.setSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.setSpeed.Size = new System.Drawing.Size(69, 477);
            this.setSpeed.SmallChange = 10;
            this.setSpeed.TabIndex = 6;
            this.setSpeed.TickFrequency = 10;
            this.setSpeed.Value = 500;
            this.setSpeed.Scroll += new System.EventHandler(this.setSpeed_Scroll);
            // 
            // txtSpeed
            // 
            this.txtSpeed.BackColor = System.Drawing.Color.White;
            this.txtSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed.ForeColor = System.Drawing.Color.Black;
            this.txtSpeed.Location = new System.Drawing.Point(30, 198);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(150, 30);
            this.txtSpeed.TabIndex = 7;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.White;
            this.lblValue.Location = new System.Drawing.Point(246, 457);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(23, 25);
            this.lblValue.TabIndex = 8;
            this.lblValue.Text = "0";
            // 
            // timerRuntime
            // 
            this.timerRuntime.Enabled = true;
            this.timerRuntime.Interval = 1000;
            this.timerRuntime.Tick += new System.EventHandler(this.timerRuntime_Tick);
            // 
            // FaultTimer
            // 
            this.FaultTimer.Enabled = true;
            this.FaultTimer.Interval = 1000;
            this.FaultTimer.Tick += new System.EventHandler(this.timer1s_Tick);
            // 
            // Main_SCL
            // 
            this.Main_SCL.Enabled = true;
            this.Main_SCL.Tick += new System.EventHandler(this.Main_SCL_Tick);
            // 
            // picFault
            // 
            this.picFault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.picFault.Location = new System.Drawing.Point(96, 132);
            this.picFault.Name = "picFault";
            this.picFault.Size = new System.Drawing.Size(40, 40);
            this.picFault.TabIndex = 9;
            this.picFault.TabStop = false;
            this.picFault.Visible = false;
            // 
            // picSwitch
            // 
            this.picSwitch.Location = new System.Drawing.Point(45, 12);
            this.picSwitch.Name = "picSwitch";
            this.picSwitch.Size = new System.Drawing.Size(100, 50);
            this.picSwitch.TabIndex = 2;
            this.picSwitch.TabStop = false;
            this.picSwitch.Click += new System.EventHandler(this.picSwitch_Click);
            // 
            // picMotor
            // 
            this.picMotor.BackColor = System.Drawing.Color.Transparent;
            this.picMotor.Location = new System.Drawing.Point(30, 80);
            this.picMotor.Name = "picMotor";
            this.picMotor.Size = new System.Drawing.Size(150, 100);
            this.picMotor.TabIndex = 3;
            this.picMotor.TabStop = false;
            this.picMotor.Click += new System.EventHandler(this.picMotor_Click);
            // 
            // Motor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(296, 515);
            this.Controls.Add(this.picFault);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.setSpeed);
            this.Controls.Add(this.txtRuntime);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.picSwitch);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picMotor);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Motor";
            this.ShowIcon = false;
            this.Text = "Motor";
            this.Load += new System.EventHandler(this.Motor_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMotor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox picSwitch;
        private System.Windows.Forms.PictureBox picMotor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtRuntime;
        private System.Windows.Forms.TrackBar setSpeed;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Timer timerRuntime;
        private System.Windows.Forms.PictureBox picFault;
        private System.Windows.Forms.Timer FaultTimer;
        private System.Windows.Forms.Timer Main_SCL;
    }
}