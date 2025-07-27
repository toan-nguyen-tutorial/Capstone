namespace HVAC_BacnetTCPIP.Forms
{
    partial class Boiler
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
            this.lblValvePosition10 = new System.Windows.Forms.Label();
            this.lblValvePosition2 = new System.Windows.Forms.Label();
            this.lblMotor1Speed = new System.Windows.Forms.Label();
            this.lblMotor2Speed = new System.Windows.Forms.Label();
            this.lblBoilerTempOut = new System.Windows.Forms.Label();
            this.BoilerTimer = new System.Windows.Forms.Timer(this.components);
            this.lblFlowRateSensor = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTempBoilerSP = new System.Windows.Forms.TextBox();
            this.txtTempHeatExSP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelS5 = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelS4 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelS3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelS2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelS1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMotor1 = new System.Windows.Forms.Panel();
            this.panelMotor2 = new System.Windows.Forms.Panel();
            this.panelValve1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblHeatExTempOut = new System.Windows.Forms.Label();
            this.lblValvePosition11 = new System.Windows.Forms.Label();
            this.panelMotor10 = new System.Windows.Forms.Panel();
            this.panelValve11 = new System.Windows.Forms.Panel();
            this.panelValve10 = new System.Windows.Forms.Panel();
            this.panelValve2 = new System.Windows.Forms.Panel();
            this.lblValvePosition1 = new System.Windows.Forms.Label();
            this.lblMotor10Speed = new System.Windows.Forms.Label();
            this.panelValve12 = new System.Windows.Forms.Panel();
            this.lblValvePosition12 = new System.Windows.Forms.Label();
            this.lblValvePosition13 = new System.Windows.Forms.Label();
            this.panelValve13 = new System.Windows.Forms.Panel();
            this.PID1_Timer = new System.Windows.Forms.Timer(this.components);
            this.PID2_Timer = new System.Windows.Forms.Timer(this.components);
            this.Alarm_Timer = new System.Windows.Forms.Timer(this.components);
            this.txtTempAHUFeedback = new System.Windows.Forms.TextBox();
            this.cmbSel = new System.Windows.Forms.ComboBox();
            this.Random_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblValvePosition10
            // 
            this.lblValvePosition10.AutoSize = true;
            this.lblValvePosition10.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition10.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition10.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition10.Location = new System.Drawing.Point(697, 701);
            this.lblValvePosition10.Name = "lblValvePosition10";
            this.lblValvePosition10.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition10.TabIndex = 0;
            this.lblValvePosition10.Text = "0.00 %";
            // 
            // lblValvePosition2
            // 
            this.lblValvePosition2.AutoSize = true;
            this.lblValvePosition2.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition2.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition2.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition2.Location = new System.Drawing.Point(417, 965);
            this.lblValvePosition2.Name = "lblValvePosition2";
            this.lblValvePosition2.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition2.TabIndex = 1;
            this.lblValvePosition2.Text = "0.00 %";
            // 
            // lblMotor1Speed
            // 
            this.lblMotor1Speed.AutoSize = true;
            this.lblMotor1Speed.BackColor = System.Drawing.Color.Transparent;
            this.lblMotor1Speed.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotor1Speed.ForeColor = System.Drawing.Color.Blue;
            this.lblMotor1Speed.Location = new System.Drawing.Point(498, 712);
            this.lblMotor1Speed.Name = "lblMotor1Speed";
            this.lblMotor1Speed.Size = new System.Drawing.Size(92, 23);
            this.lblMotor1Speed.TabIndex = 2;
            this.lblMotor1Speed.Text = "0.0 rpm";
            // 
            // lblMotor2Speed
            // 
            this.lblMotor2Speed.AutoSize = true;
            this.lblMotor2Speed.BackColor = System.Drawing.Color.Transparent;
            this.lblMotor2Speed.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotor2Speed.ForeColor = System.Drawing.Color.Blue;
            this.lblMotor2Speed.Location = new System.Drawing.Point(526, 970);
            this.lblMotor2Speed.Name = "lblMotor2Speed";
            this.lblMotor2Speed.Size = new System.Drawing.Size(92, 23);
            this.lblMotor2Speed.TabIndex = 3;
            this.lblMotor2Speed.Text = "0.0 rpm";
            // 
            // lblBoilerTempOut
            // 
            this.lblBoilerTempOut.AutoSize = true;
            this.lblBoilerTempOut.BackColor = System.Drawing.Color.Transparent;
            this.lblBoilerTempOut.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoilerTempOut.ForeColor = System.Drawing.Color.Blue;
            this.lblBoilerTempOut.Location = new System.Drawing.Point(746, 566);
            this.lblBoilerTempOut.Name = "lblBoilerTempOut";
            this.lblBoilerTempOut.Size = new System.Drawing.Size(86, 23);
            this.lblBoilerTempOut.TabIndex = 4;
            this.lblBoilerTempOut.Text = "0.00 °C";
            // 
            // BoilerTimer
            // 
            this.BoilerTimer.Enabled = true;
            this.BoilerTimer.Tick += new System.EventHandler(this.BoilerTimer_Tick);
            // 
            // lblFlowRateSensor
            // 
            this.lblFlowRateSensor.AutoSize = true;
            this.lblFlowRateSensor.BackColor = System.Drawing.Color.Transparent;
            this.lblFlowRateSensor.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowRateSensor.ForeColor = System.Drawing.Color.Blue;
            this.lblFlowRateSensor.Location = new System.Drawing.Point(109, 1291);
            this.lblFlowRateSensor.Name = "lblFlowRateSensor";
            this.lblFlowRateSensor.Size = new System.Drawing.Size(178, 23);
            this.lblFlowRateSensor.TabIndex = 6;
            this.lblFlowRateSensor.Text = "0.00  cm³ /min";
            this.lblFlowRateSensor.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Teal;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.Location = new System.Drawing.Point(23, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 50);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTempBoilerSP);
            this.panel1.Controls.Add(this.txtTempHeatExSP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panelS5);
            this.panel1.Controls.Add(this.panelStatus);
            this.panel1.Controls.Add(this.panelS4);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panelS3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.panelS2);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panelS1);
            this.panel1.Location = new System.Drawing.Point(306, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 260);
            this.panel1.TabIndex = 8;
            // 
            // txtTempBoilerSP
            // 
            this.txtTempBoilerSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempBoilerSP.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.txtTempBoilerSP.Location = new System.Drawing.Point(409, 13);
            this.txtTempBoilerSP.Name = "txtTempBoilerSP";
            this.txtTempBoilerSP.Size = new System.Drawing.Size(83, 30);
            this.txtTempBoilerSP.TabIndex = 85;
            this.txtTempBoilerSP.Text = "60";
            this.txtTempBoilerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTempHeatExSP
            // 
            this.txtTempHeatExSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempHeatExSP.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.txtTempHeatExSP.Location = new System.Drawing.Point(409, 56);
            this.txtTempHeatExSP.Name = "txtTempHeatExSP";
            this.txtTempHeatExSP.Size = new System.Drawing.Size(83, 30);
            this.txtTempHeatExSP.TabIndex = 84;
            this.txtTempHeatExSP.Text = "35";
            this.txtTempHeatExSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(192, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 23);
            this.label8.TabIndex = 81;
            this.label8.Text = "Temp Heat Ex SP";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(43, 224);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 23);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "None";
            this.lblStatus.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(134, 227);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 24;
            this.panel3.Visible = false;
            // 
            // panelS5
            // 
            this.panelS5.BackColor = System.Drawing.Color.DarkGray;
            this.panelS5.Location = new System.Drawing.Point(447, 161);
            this.panelS5.Name = "panelS5";
            this.panelS5.Size = new System.Drawing.Size(20, 20);
            this.panelS5.TabIndex = 80;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Location = new System.Drawing.Point(23, 227);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(15, 15);
            this.panelStatus.TabIndex = 26;
            this.panelStatus.Visible = false;
            // 
            // panelS4
            // 
            this.panelS4.BackColor = System.Drawing.Color.DarkGray;
            this.panelS4.Location = new System.Drawing.Point(447, 121);
            this.panelS4.Name = "panelS4";
            this.panelS4.Size = new System.Drawing.Size(20, 20);
            this.panelS4.TabIndex = 79;
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
            this.btnReset.Location = new System.Drawing.Point(23, 161);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 50);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(155, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fault";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(192, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Temp Boiler SP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(344, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 23);
            this.label10.TabIndex = 74;
            this.label10.Text = "State 3";
            // 
            // panelS3
            // 
            this.panelS3.BackColor = System.Drawing.Color.DarkGray;
            this.panelS3.Location = new System.Drawing.Point(308, 201);
            this.panelS3.Name = "panelS3";
            this.panelS3.Size = new System.Drawing.Size(20, 20);
            this.panelS3.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(344, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 73;
            this.label1.Text = "State 2";
            // 
            // panelS2
            // 
            this.panelS2.BackColor = System.Drawing.Color.DarkGray;
            this.panelS2.Location = new System.Drawing.Point(308, 161);
            this.panelS2.Name = "panelS2";
            this.panelS2.Size = new System.Drawing.Size(20, 20);
            this.panelS2.TabIndex = 77;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Teal;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStop.Location = new System.Drawing.Point(23, 89);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 50);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(483, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 23);
            this.label9.TabIndex = 75;
            this.label9.Text = "State 4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(344, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 72;
            this.label4.Text = "State 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(483, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 23);
            this.label7.TabIndex = 71;
            this.label7.Text = "State 5";
            // 
            // panelS1
            // 
            this.panelS1.BackColor = System.Drawing.Color.DarkGray;
            this.panelS1.Location = new System.Drawing.Point(308, 121);
            this.panelS1.Name = "panelS1";
            this.panelS1.Size = new System.Drawing.Size(20, 20);
            this.panelS1.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(179, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "Process Simulation";
            // 
            // panelMotor1
            // 
            this.panelMotor1.BackColor = System.Drawing.Color.Transparent;
            this.panelMotor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMotor1.Location = new System.Drawing.Point(474, 506);
            this.panelMotor1.Name = "panelMotor1";
            this.panelMotor1.Size = new System.Drawing.Size(134, 195);
            this.panelMotor1.TabIndex = 13;
            this.panelMotor1.Click += new System.EventHandler(this.panelMotor1_Click);
            // 
            // panelMotor2
            // 
            this.panelMotor2.BackColor = System.Drawing.Color.Transparent;
            this.panelMotor2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMotor2.Location = new System.Drawing.Point(474, 768);
            this.panelMotor2.Name = "panelMotor2";
            this.panelMotor2.Size = new System.Drawing.Size(134, 195);
            this.panelMotor2.TabIndex = 14;
            this.panelMotor2.Click += new System.EventHandler(this.panelMotor2_Click);
            // 
            // panelValve1
            // 
            this.panelValve1.BackColor = System.Drawing.Color.Transparent;
            this.panelValve1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelValve1.Location = new System.Drawing.Point(424, 634);
            this.panelValve1.Name = "panelValve1";
            this.panelValve1.Size = new System.Drawing.Size(44, 45);
            this.panelValve1.TabIndex = 15;
            this.panelValve1.Click += new System.EventHandler(this.panelValve1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(306, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(582, 50);
            this.panel5.TabIndex = 16;
            // 
            // lblHeatExTempOut
            // 
            this.lblHeatExTempOut.AutoSize = true;
            this.lblHeatExTempOut.BackColor = System.Drawing.Color.Transparent;
            this.lblHeatExTempOut.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatExTempOut.ForeColor = System.Drawing.Color.Blue;
            this.lblHeatExTempOut.Location = new System.Drawing.Point(1181, 83);
            this.lblHeatExTempOut.Name = "lblHeatExTempOut";
            this.lblHeatExTempOut.Size = new System.Drawing.Size(86, 23);
            this.lblHeatExTempOut.TabIndex = 17;
            this.lblHeatExTempOut.Text = "0.00 °C";
            // 
            // lblValvePosition11
            // 
            this.lblValvePosition11.AutoSize = true;
            this.lblValvePosition11.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition11.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition11.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition11.Location = new System.Drawing.Point(1028, 217);
            this.lblValvePosition11.Name = "lblValvePosition11";
            this.lblValvePosition11.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition11.TabIndex = 18;
            this.lblValvePosition11.Text = "0.00 %";
            // 
            // panelMotor10
            // 
            this.panelMotor10.BackColor = System.Drawing.Color.Transparent;
            this.panelMotor10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMotor10.Location = new System.Drawing.Point(804, 356);
            this.panelMotor10.Name = "panelMotor10";
            this.panelMotor10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelMotor10.Size = new System.Drawing.Size(134, 195);
            this.panelMotor10.TabIndex = 19;
            this.panelMotor10.Click += new System.EventHandler(this.panelMotor10_Click);
            // 
            // panelValve11
            // 
            this.panelValve11.BackColor = System.Drawing.Color.Transparent;
            this.panelValve11.Location = new System.Drawing.Point(1019, 122);
            this.panelValve11.Name = "panelValve11";
            this.panelValve11.Size = new System.Drawing.Size(91, 77);
            this.panelValve11.TabIndex = 20;
            this.panelValve11.Click += new System.EventHandler(this.panelValve11_Click);
            // 
            // panelValve10
            // 
            this.panelValve10.BackColor = System.Drawing.Color.Transparent;
            this.panelValve10.Location = new System.Drawing.Point(694, 610);
            this.panelValve10.Name = "panelValve10";
            this.panelValve10.Size = new System.Drawing.Size(93, 69);
            this.panelValve10.TabIndex = 21;
            this.panelValve10.Click += new System.EventHandler(this.panelValve10_Click);
            // 
            // panelValve2
            // 
            this.panelValve2.BackColor = System.Drawing.Color.Transparent;
            this.panelValve2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelValve2.Location = new System.Drawing.Point(424, 904);
            this.panelValve2.Name = "panelValve2";
            this.panelValve2.Size = new System.Drawing.Size(44, 39);
            this.panelValve2.TabIndex = 22;
            this.panelValve2.Click += new System.EventHandler(this.panelValve2_Click);
            // 
            // lblValvePosition1
            // 
            this.lblValvePosition1.AutoSize = true;
            this.lblValvePosition1.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition1.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition1.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition1.Location = new System.Drawing.Point(420, 694);
            this.lblValvePosition1.Name = "lblValvePosition1";
            this.lblValvePosition1.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition1.TabIndex = 23;
            this.lblValvePosition1.Text = "0.00 %";
            // 
            // lblMotor10Speed
            // 
            this.lblMotor10Speed.AutoSize = true;
            this.lblMotor10Speed.BackColor = System.Drawing.Color.Transparent;
            this.lblMotor10Speed.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotor10Speed.ForeColor = System.Drawing.Color.Blue;
            this.lblMotor10Speed.Location = new System.Drawing.Point(937, 451);
            this.lblMotor10Speed.Name = "lblMotor10Speed";
            this.lblMotor10Speed.Size = new System.Drawing.Size(92, 23);
            this.lblMotor10Speed.TabIndex = 24;
            this.lblMotor10Speed.Text = "0.0 rpm";
            // 
            // panelValve12
            // 
            this.panelValve12.BackColor = System.Drawing.Color.Transparent;
            this.panelValve12.Location = new System.Drawing.Point(981, 293);
            this.panelValve12.Name = "panelValve12";
            this.panelValve12.Size = new System.Drawing.Size(74, 36);
            this.panelValve12.TabIndex = 25;
            this.panelValve12.Click += new System.EventHandler(this.panelValve12_Click);
            // 
            // lblValvePosition12
            // 
            this.lblValvePosition12.AutoSize = true;
            this.lblValvePosition12.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition12.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition12.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition12.Location = new System.Drawing.Point(984, 332);
            this.lblValvePosition12.Name = "lblValvePosition12";
            this.lblValvePosition12.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition12.TabIndex = 26;
            this.lblValvePosition12.Text = "0.00 %";
            // 
            // lblValvePosition13
            // 
            this.lblValvePosition13.AutoSize = true;
            this.lblValvePosition13.BackColor = System.Drawing.Color.Transparent;
            this.lblValvePosition13.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValvePosition13.ForeColor = System.Drawing.Color.Blue;
            this.lblValvePosition13.Location = new System.Drawing.Point(695, 973);
            this.lblValvePosition13.Name = "lblValvePosition13";
            this.lblValvePosition13.Size = new System.Drawing.Size(82, 23);
            this.lblValvePosition13.TabIndex = 28;
            this.lblValvePosition13.Text = "0.00 %";
            // 
            // panelValve13
            // 
            this.panelValve13.BackColor = System.Drawing.Color.Transparent;
            this.panelValve13.Location = new System.Drawing.Point(661, 939);
            this.panelValve13.Name = "panelValve13";
            this.panelValve13.Size = new System.Drawing.Size(30, 75);
            this.panelValve13.TabIndex = 27;
            this.panelValve13.Click += new System.EventHandler(this.panelValve13_Click);
            // 
            // PID1_Timer
            // 
            this.PID1_Timer.Interval = 10;
            this.PID1_Timer.Tick += new System.EventHandler(this.PID1_Timer_Tick);
            // 
            // PID2_Timer
            // 
            this.PID2_Timer.Interval = 10;
            this.PID2_Timer.Tick += new System.EventHandler(this.PID2_Timer_Tick);
            // 
            // Alarm_Timer
            // 
            this.Alarm_Timer.Enabled = true;
            this.Alarm_Timer.Tick += new System.EventHandler(this.Alarm_Timer_Tick);
            // 
            // txtTempAHUFeedback
            // 
            this.txtTempAHUFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempAHUFeedback.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold);
            this.txtTempAHUFeedback.Location = new System.Drawing.Point(1173, 451);
            this.txtTempAHUFeedback.Name = "txtTempAHUFeedback";
            this.txtTempAHUFeedback.Size = new System.Drawing.Size(49, 30);
            this.txtTempAHUFeedback.TabIndex = 85;
            this.txtTempAHUFeedback.Text = "30";
            this.txtTempAHUFeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbSel
            // 
            this.cmbSel.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSel.FormattingEnabled = true;
            this.cmbSel.Items.AddRange(new object[] {
            "Manual",
            "Random"});
            this.cmbSel.Location = new System.Drawing.Point(1228, 451);
            this.cmbSel.Name = "cmbSel";
            this.cmbSel.Size = new System.Drawing.Size(115, 31);
            this.cmbSel.TabIndex = 86;
            // 
            // Random_Timer
            // 
            this.Random_Timer.Enabled = true;
            this.Random_Timer.Interval = 5000;
            this.Random_Timer.Tick += new System.EventHandler(this.Random_Timer_Tick);
            // 
            // Boiler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.BoilerSystem2D;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1478, 1344);
            this.Controls.Add(this.cmbSel);
            this.Controls.Add(this.txtTempAHUFeedback);
            this.Controls.Add(this.lblValvePosition13);
            this.Controls.Add(this.panelValve13);
            this.Controls.Add(this.lblValvePosition12);
            this.Controls.Add(this.panelValve12);
            this.Controls.Add(this.lblMotor10Speed);
            this.Controls.Add(this.lblValvePosition1);
            this.Controls.Add(this.panelValve2);
            this.Controls.Add(this.panelValve10);
            this.Controls.Add(this.panelValve11);
            this.Controls.Add(this.panelMotor10);
            this.Controls.Add(this.lblValvePosition11);
            this.Controls.Add(this.lblHeatExTempOut);
            this.Controls.Add(this.lblMotor2Speed);
            this.Controls.Add(this.lblMotor1Speed);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panelValve1);
            this.Controls.Add(this.panelMotor2);
            this.Controls.Add(this.panelMotor1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFlowRateSensor);
            this.Controls.Add(this.lblBoilerTempOut);
            this.Controls.Add(this.lblValvePosition2);
            this.Controls.Add(this.lblValvePosition10);
            this.DoubleBuffered = true;
            this.Name = "Boiler";
            this.Text = "Boiler";
            this.Load += new System.EventHandler(this.Boiler_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValvePosition10;
        private System.Windows.Forms.Label lblValvePosition2;
        private System.Windows.Forms.Label lblMotor1Speed;
        private System.Windows.Forms.Label lblMotor2Speed;
        private System.Windows.Forms.Label lblBoilerTempOut;
        private System.Windows.Forms.Timer BoilerTimer;
        private System.Windows.Forms.Label lblFlowRateSensor;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelMotor1;
        private System.Windows.Forms.Panel panelMotor2;
        private System.Windows.Forms.Panel panelValve1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblHeatExTempOut;
        private System.Windows.Forms.Label lblValvePosition11;
        private System.Windows.Forms.Panel panelMotor10;
        private System.Windows.Forms.Panel panelValve11;
        private System.Windows.Forms.Panel panelValve10;
        private System.Windows.Forms.Panel panelValve2;
        private System.Windows.Forms.Label lblValvePosition1;
        private System.Windows.Forms.Label lblMotor10Speed;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelS5;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelS4;
        private System.Windows.Forms.Panel panelS3;
        private System.Windows.Forms.Panel panelS2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelS1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelValve12;
        private System.Windows.Forms.Label lblValvePosition12;
        private System.Windows.Forms.Label lblValvePosition13;
        private System.Windows.Forms.Panel panelValve13;
        private System.Windows.Forms.Timer PID1_Timer;
        private System.Windows.Forms.Timer PID2_Timer;
        public System.Windows.Forms.TextBox txtTempBoilerSP;
        public System.Windows.Forms.TextBox txtTempHeatExSP;
        private System.Windows.Forms.Timer Alarm_Timer;
        private System.Windows.Forms.TextBox txtTempAHUFeedback;
        private System.Windows.Forms.ComboBox cmbSel;
        private System.Windows.Forms.Timer Random_Timer;
        
    }
}