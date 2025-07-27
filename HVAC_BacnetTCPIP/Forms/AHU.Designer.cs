namespace HVAC_BacnetTCPIP.Forms
{
    partial class AHU
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelS2 = new System.Windows.Forms.Panel();
            this.panelS1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblChillerTempOut = new System.Windows.Forms.Label();
            this.AHUTimer = new System.Windows.Forms.Timer(this.components);
            this.panelMotor8 = new System.Windows.Forms.Panel();
            this.lblDamper4Pos = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panelMotor9 = new System.Windows.Forms.PictureBox();
            this.lblDamper5Pos = new System.Windows.Forms.Label();
            this.lblDamper2Pos = new System.Windows.Forms.Label();
            this.lblDamper1Pos = new System.Windows.Forms.Label();
            this.lblDamper3Pos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ReturnFan_Simulate = new System.Windows.Forms.Timer(this.components);
            this.panelDamper1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panelDamper2 = new System.Windows.Forms.Panel();
            this.panelDamper3 = new System.Windows.Forms.Panel();
            this.panelDamper4 = new System.Windows.Forms.Panel();
            this.panelDamper5 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblMotor9Speed = new System.Windows.Forms.Label();
            this.lblMotor8Speed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Alarm_Timer = new System.Windows.Forms.Timer(this.components);
            this.txtTempRoom = new System.Windows.Forms.TextBox();
            this.SupplyFan_Simulate = new System.Windows.Forms.Timer(this.components);
            this.lblBoilerSystemTempOut = new System.Windows.Forms.Label();
            this.cmbSel = new System.Windows.Forms.ComboBox();
            this.Random_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMotor9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(17, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 50);
            this.panel1.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(93, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(249, 30);
            this.label11.TabIndex = 71;
            this.label11.Text = "Process Simulation";
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.White;
            this.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControl.Controls.Add(this.panelS2);
            this.panelControl.Controls.Add(this.panelS1);
            this.panelControl.Controls.Add(this.label6);
            this.panelControl.Controls.Add(this.label5);
            this.panelControl.Controls.Add(this.btnStop);
            this.panelControl.Controls.Add(this.btnStart);
            this.panelControl.Location = new System.Drawing.Point(17, 97);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(400, 150);
            this.panelControl.TabIndex = 46;
            // 
            // panelS2
            // 
            this.panelS2.BackColor = System.Drawing.Color.DarkGray;
            this.panelS2.Location = new System.Drawing.Point(285, 57);
            this.panelS2.Name = "panelS2";
            this.panelS2.Size = new System.Drawing.Size(20, 20);
            this.panelS2.TabIndex = 67;
            // 
            // panelS1
            // 
            this.panelS1.BackColor = System.Drawing.Color.DarkGray;
            this.panelS1.Location = new System.Drawing.Point(285, 17);
            this.panelS1.Name = "panelS1";
            this.panelS1.Size = new System.Drawing.Size(20, 20);
            this.panelS1.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("RomanD", 8F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(321, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 63;
            this.label6.Text = "State 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("RomanD", 8F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(321, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 62;
            this.label5.Text = "State 1";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Teal;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStop.Location = new System.Drawing.Point(18, 73);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 50);
            this.btnStop.TabIndex = 48;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Teal;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.Location = new System.Drawing.Point(18, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 50);
            this.btnStart.TabIndex = 44;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Humidity_sensor;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(529, 709);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 127);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Humidity_sensor;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1298, 539);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 127);
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // lblChillerTempOut
            // 
            this.lblChillerTempOut.AutoSize = true;
            this.lblChillerTempOut.BackColor = System.Drawing.Color.Transparent;
            this.lblChillerTempOut.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblChillerTempOut.ForeColor = System.Drawing.Color.Blue;
            this.lblChillerTempOut.Location = new System.Drawing.Point(830, 992);
            this.lblChillerTempOut.Name = "lblChillerTempOut";
            this.lblChillerTempOut.Size = new System.Drawing.Size(79, 23);
            this.lblChillerTempOut.TabIndex = 56;
            this.lblChillerTempOut.Text = "0.00 °C";
            // 
            // AHUTimer
            // 
            this.AHUTimer.Enabled = true;
            this.AHUTimer.Tick += new System.EventHandler(this.AHUTimer_Tick);
            // 
            // panelMotor8
            // 
            this.panelMotor8.BackColor = System.Drawing.Color.Transparent;
            this.panelMotor8.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Fan_Rotate_1;
            this.panelMotor8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMotor8.Location = new System.Drawing.Point(1005, 810);
            this.panelMotor8.Name = "panelMotor8";
            this.panelMotor8.Size = new System.Drawing.Size(150, 150);
            this.panelMotor8.TabIndex = 57;
            this.panelMotor8.Click += new System.EventHandler(this.panelMotor8_Click);
            // 
            // lblDamper4Pos
            // 
            this.lblDamper4Pos.AutoSize = true;
            this.lblDamper4Pos.BackColor = System.Drawing.Color.Transparent;
            this.lblDamper4Pos.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblDamper4Pos.ForeColor = System.Drawing.Color.Blue;
            this.lblDamper4Pos.Location = new System.Drawing.Point(1183, 539);
            this.lblDamper4Pos.Name = "lblDamper4Pos";
            this.lblDamper4Pos.Size = new System.Drawing.Size(76, 23);
            this.lblDamper4Pos.TabIndex = 63;
            this.lblDamper4Pos.Text = "0.00 %";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("RomanD", 8F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label16.Location = new System.Drawing.Point(1342, 544);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 23);
            this.label16.TabIndex = 64;
            this.label16.Text = "0.00 °C";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label17.Location = new System.Drawing.Point(1294, 511);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 23);
            this.label17.TabIndex = 65;
            this.label17.Text = "Temp Return";
            // 
            // panelMotor9
            // 
            this.panelMotor9.BackColor = System.Drawing.Color.Transparent;
            this.panelMotor9.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Fan_Rotate_1;
            this.panelMotor9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMotor9.Location = new System.Drawing.Point(1005, 404);
            this.panelMotor9.Name = "panelMotor9";
            this.panelMotor9.Size = new System.Drawing.Size(150, 150);
            this.panelMotor9.TabIndex = 66;
            this.panelMotor9.TabStop = false;
            this.panelMotor9.Click += new System.EventHandler(this.panelMotor9_Click);
            // 
            // lblDamper5Pos
            // 
            this.lblDamper5Pos.AutoSize = true;
            this.lblDamper5Pos.BackColor = System.Drawing.Color.Transparent;
            this.lblDamper5Pos.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblDamper5Pos.ForeColor = System.Drawing.Color.Blue;
            this.lblDamper5Pos.Location = new System.Drawing.Point(1183, 937);
            this.lblDamper5Pos.Name = "lblDamper5Pos";
            this.lblDamper5Pos.Size = new System.Drawing.Size(76, 23);
            this.lblDamper5Pos.TabIndex = 67;
            this.lblDamper5Pos.Text = "0.00 %";
            // 
            // lblDamper2Pos
            // 
            this.lblDamper2Pos.AutoSize = true;
            this.lblDamper2Pos.BackColor = System.Drawing.Color.Transparent;
            this.lblDamper2Pos.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblDamper2Pos.ForeColor = System.Drawing.Color.Blue;
            this.lblDamper2Pos.Location = new System.Drawing.Point(233, 937);
            this.lblDamper2Pos.Name = "lblDamper2Pos";
            this.lblDamper2Pos.Size = new System.Drawing.Size(76, 23);
            this.lblDamper2Pos.TabIndex = 68;
            this.lblDamper2Pos.Text = "0.00 %";
            // 
            // lblDamper1Pos
            // 
            this.lblDamper1Pos.AutoSize = true;
            this.lblDamper1Pos.BackColor = System.Drawing.Color.Transparent;
            this.lblDamper1Pos.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblDamper1Pos.ForeColor = System.Drawing.Color.Blue;
            this.lblDamper1Pos.Location = new System.Drawing.Point(233, 539);
            this.lblDamper1Pos.Name = "lblDamper1Pos";
            this.lblDamper1Pos.Size = new System.Drawing.Size(76, 23);
            this.lblDamper1Pos.TabIndex = 69;
            this.lblDamper1Pos.Text = "0.00 %";
            // 
            // lblDamper3Pos
            // 
            this.lblDamper3Pos.AutoSize = true;
            this.lblDamper3Pos.BackColor = System.Drawing.Color.Transparent;
            this.lblDamper3Pos.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblDamper3Pos.ForeColor = System.Drawing.Color.Blue;
            this.lblDamper3Pos.Location = new System.Drawing.Point(674, 668);
            this.lblDamper3Pos.Name = "lblDamper3Pos";
            this.lblDamper3Pos.Size = new System.Drawing.Size(76, 23);
            this.lblDamper3Pos.TabIndex = 70;
            this.lblDamper3Pos.Text = "0.00 %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label7.Location = new System.Drawing.Point(1014, 580);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 30);
            this.label7.TabIndex = 71;
            this.label7.Text = "Return Fan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label8.Location = new System.Drawing.Point(1014, 992);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 30);
            this.label8.TabIndex = 72;
            this.label8.Text = "Supply Fan";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label12.Location = new System.Drawing.Point(1294, 852);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 23);
            this.label12.TabIndex = 75;
            this.label12.Text = "Temp Supply";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("RomanD", 8F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label13.Location = new System.Drawing.Point(1342, 890);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 23);
            this.label13.TabIndex = 74;
            this.label13.Text = "0.00 °C";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.Humidity_sensor;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(1298, 880);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 127);
            this.pictureBox3.TabIndex = 73;
            this.pictureBox3.TabStop = false;
            // 
            // ReturnFan_Simulate
            // 
            this.ReturnFan_Simulate.Interval = 200;
            this.ReturnFan_Simulate.Tick += new System.EventHandler(this.ReturnFan_Simulate_Tick);
            // 
            // panelDamper1
            // 
            this.panelDamper1.BackColor = System.Drawing.Color.Transparent;
            this.panelDamper1.Location = new System.Drawing.Point(250, 421);
            this.panelDamper1.Name = "panelDamper1";
            this.panelDamper1.Size = new System.Drawing.Size(59, 115);
            this.panelDamper1.TabIndex = 76;
            this.panelDamper1.Click += new System.EventHandler(this.panelDamper1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("RomanD", 8F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label14.Location = new System.Drawing.Point(315, 467);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 23);
            this.label14.TabIndex = 77;
            this.label14.Text = "Damper 1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("RomanD", 8F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label15.Location = new System.Drawing.Point(315, 869);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Damper 2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("RomanD", 8F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label20.Location = new System.Drawing.Point(569, 628);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 23);
            this.label20.TabIndex = 79;
            this.label20.Text = "Damper 3";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("RomanD", 8F);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label22.Location = new System.Drawing.Point(1193, 796);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 23);
            this.label22.TabIndex = 81;
            this.label22.Text = "Damper 5";
            // 
            // panelDamper2
            // 
            this.panelDamper2.BackColor = System.Drawing.Color.Transparent;
            this.panelDamper2.Location = new System.Drawing.Point(250, 821);
            this.panelDamper2.Name = "panelDamper2";
            this.panelDamper2.Size = new System.Drawing.Size(59, 115);
            this.panelDamper2.TabIndex = 82;
            this.panelDamper2.Click += new System.EventHandler(this.panelDamper2_Click);
            // 
            // panelDamper3
            // 
            this.panelDamper3.BackColor = System.Drawing.Color.Transparent;
            this.panelDamper3.Location = new System.Drawing.Point(552, 654);
            this.panelDamper3.Name = "panelDamper3";
            this.panelDamper3.Size = new System.Drawing.Size(124, 49);
            this.panelDamper3.TabIndex = 83;
            this.panelDamper3.Click += new System.EventHandler(this.panelDamper3_Click);
            // 
            // panelDamper4
            // 
            this.panelDamper4.BackColor = System.Drawing.Color.Transparent;
            this.panelDamper4.Location = new System.Drawing.Point(1187, 419);
            this.panelDamper4.Name = "panelDamper4";
            this.panelDamper4.Size = new System.Drawing.Size(57, 115);
            this.panelDamper4.TabIndex = 84;
            this.panelDamper4.Click += new System.EventHandler(this.panelDamper4_Click);
            // 
            // panelDamper5
            // 
            this.panelDamper5.BackColor = System.Drawing.Color.Transparent;
            this.panelDamper5.Location = new System.Drawing.Point(1187, 822);
            this.panelDamper5.Name = "panelDamper5";
            this.panelDamper5.Size = new System.Drawing.Size(57, 115);
            this.panelDamper5.TabIndex = 85;
            this.panelDamper5.Click += new System.EventHandler(this.panelDamper5_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label23.Location = new System.Drawing.Point(1054, 777);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 30);
            this.label23.TabIndex = 86;
            this.label23.Text = "M8";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label24.Location = new System.Drawing.Point(1054, 375);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 30);
            this.label24.TabIndex = 87;
            this.label24.Text = "M9";
            // 
            // lblMotor9Speed
            // 
            this.lblMotor9Speed.AutoSize = true;
            this.lblMotor9Speed.BackColor = System.Drawing.Color.Transparent;
            this.lblMotor9Speed.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblMotor9Speed.ForeColor = System.Drawing.Color.Blue;
            this.lblMotor9Speed.Location = new System.Drawing.Point(1040, 557);
            this.lblMotor9Speed.Name = "lblMotor9Speed";
            this.lblMotor9Speed.Size = new System.Drawing.Size(96, 23);
            this.lblMotor9Speed.TabIndex = 88;
            this.lblMotor9Speed.Text = "0.00 rpm";
            // 
            // lblMotor8Speed
            // 
            this.lblMotor8Speed.AutoSize = true;
            this.lblMotor8Speed.BackColor = System.Drawing.Color.Transparent;
            this.lblMotor8Speed.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblMotor8Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.lblMotor8Speed.Location = new System.Drawing.Point(1040, 963);
            this.lblMotor8Speed.Name = "lblMotor8Speed";
            this.lblMotor8Speed.Size = new System.Drawing.Size(96, 23);
            this.lblMotor8Speed.TabIndex = 89;
            this.lblMotor8Speed.Text = "0.00 rpm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("RomanD", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label1.Location = new System.Drawing.Point(1193, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 90;
            this.label1.Text = "Damper 4";
            // 
            // Alarm_Timer
            // 
            this.Alarm_Timer.Enabled = true;
            this.Alarm_Timer.Interval = 1000;
            this.Alarm_Timer.Tick += new System.EventHandler(this.Alarm_Timer_Tick);
            // 
            // txtTempRoom
            // 
            this.txtTempRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempRoom.Font = new System.Drawing.Font("RomanD", 8F);
            this.txtTempRoom.Location = new System.Drawing.Point(1346, 616);
            this.txtTempRoom.Name = "txtTempRoom";
            this.txtTempRoom.Size = new System.Drawing.Size(60, 30);
            this.txtTempRoom.TabIndex = 91;
            this.txtTempRoom.Text = "24";
            this.txtTempRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SupplyFan_Simulate
            // 
            this.SupplyFan_Simulate.Interval = 200;
            this.SupplyFan_Simulate.Tick += new System.EventHandler(this.SupplyFan_Simulate_Tick);
            // 
            // lblBoilerSystemTempOut
            // 
            this.lblBoilerSystemTempOut.AutoSize = true;
            this.lblBoilerSystemTempOut.BackColor = System.Drawing.Color.Transparent;
            this.lblBoilerSystemTempOut.Font = new System.Drawing.Font("RomanD", 8F);
            this.lblBoilerSystemTempOut.ForeColor = System.Drawing.Color.Blue;
            this.lblBoilerSystemTempOut.Location = new System.Drawing.Point(929, 992);
            this.lblBoilerSystemTempOut.Name = "lblBoilerSystemTempOut";
            this.lblBoilerSystemTempOut.Size = new System.Drawing.Size(79, 23);
            this.lblBoilerSystemTempOut.TabIndex = 92;
            this.lblBoilerSystemTempOut.Text = "0.00 °C";
            // 
            // cmbSel
            // 
            this.cmbSel.Font = new System.Drawing.Font("RomanD", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSel.FormattingEnabled = true;
            this.cmbSel.Items.AddRange(new object[] {
            "Manual",
            "Random"});
            this.cmbSel.Location = new System.Drawing.Point(1346, 579);
            this.cmbSel.Name = "cmbSel";
            this.cmbSel.Size = new System.Drawing.Size(100, 31);
            this.cmbSel.TabIndex = 93;
            // 
            // Random_Timer
            // 
            this.Random_Timer.Enabled = true;
            this.Random_Timer.Interval = 20000;
            this.Random_Timer.Tick += new System.EventHandler(this.Random_Timer_Tick);
            // 
            // AHU
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HVAC_BacnetTCPIP.Properties.Resources.AHU2D;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1478, 1344);
            this.Controls.Add(this.cmbSel);
            this.Controls.Add(this.lblBoilerSystemTempOut);
            this.Controls.Add(this.txtTempRoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMotor8Speed);
            this.Controls.Add(this.lblMotor9Speed);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.panelDamper5);
            this.Controls.Add(this.panelDamper4);
            this.Controls.Add(this.panelDamper3);
            this.Controls.Add(this.panelDamper2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelDamper1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDamper3Pos);
            this.Controls.Add(this.lblDamper1Pos);
            this.Controls.Add(this.lblDamper2Pos);
            this.Controls.Add(this.lblDamper5Pos);
            this.Controls.Add(this.lblDamper4Pos);
            this.Controls.Add(this.panelMotor9);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panelMotor8);
            this.Controls.Add(this.lblChillerTempOut);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl);
            this.DoubleBuffered = true;
            this.Name = "AHU";
            this.Text = "AHU";
            this.Load += new System.EventHandler(this.AHU_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMotor9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelS1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblChillerTempOut;
        private System.Windows.Forms.Timer AHUTimer;
        private System.Windows.Forms.Panel panelMotor8;
        private System.Windows.Forms.Label lblDamper4Pos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox panelMotor9;
        private System.Windows.Forms.Label lblDamper5Pos;
        private System.Windows.Forms.Label lblDamper2Pos;
        private System.Windows.Forms.Label lblDamper1Pos;
        private System.Windows.Forms.Label lblDamper3Pos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer ReturnFan_Simulate;
        private System.Windows.Forms.Panel panelDamper1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panelDamper2;
        private System.Windows.Forms.Panel panelDamper3;
        private System.Windows.Forms.Panel panelDamper4;
        private System.Windows.Forms.Panel panelDamper5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblMotor9Speed;
        private System.Windows.Forms.Label lblMotor8Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Alarm_Timer;
        private System.Windows.Forms.TextBox txtTempRoom;
        private System.Windows.Forms.Timer SupplyFan_Simulate;
        private System.Windows.Forms.Panel panelS2;
        private System.Windows.Forms.Label lblBoilerSystemTempOut;
        private System.Windows.Forms.ComboBox cmbSel;
        private System.Windows.Forms.Timer Random_Timer;
    }
}