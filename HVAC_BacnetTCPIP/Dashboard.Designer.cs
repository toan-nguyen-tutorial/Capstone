namespace HVAC_BacnetTCPIP
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnTag = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnAHU = new FontAwesome.Sharp.IconButton();
            this.btnBoiler = new FontAwesome.Sharp.IconButton();
            this.btnChiller = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTilteBar = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnCloseChildForm = new FontAwesome.Sharp.IconButton();
            this.lblTilte = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateDampers = new System.Windows.Forms.Button();
            this.txtDamperQuantity = new RJCodeAdvance.RJControls.RJTextBox();
            this.groupValve = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateValves = new System.Windows.Forms.Button();
            this.txtValveQuantity = new RJCodeAdvance.RJControls.RJTextBox();
            this.groupMotor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateMotors = new System.Windows.Forms.Button();
            this.txtMotorQuantity = new RJCodeAdvance.RJControls.RJTextBox();
            this.Main_Timer = new System.Windows.Forms.Timer(this.components);
            this.DateTimer = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTilteBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.groupControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupValve.SuspendLayout();
            this.groupMotor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.panelMenu.Controls.Add(this.btnTag);
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnAHU);
            this.panelMenu.Controls.Add(this.btnBoiler);
            this.panelMenu.Controls.Add(this.btnChiller);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(230, 944);
            this.panelMenu.TabIndex = 0;
            // 
            // btnTag
            // 
            this.btnTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTag.FlatAppearance.BorderSize = 0;
            this.btnTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTag.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold);
            this.btnTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTag.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnTag.IconColor = System.Drawing.Color.White;
            this.btnTag.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTag.IconSize = 30;
            this.btnTag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTag.Location = new System.Drawing.Point(0, 292);
            this.btnTag.Name = "btnTag";
            this.btnTag.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTag.Size = new System.Drawing.Size(230, 48);
            this.btnTag.TabIndex = 11;
            this.btnTag.Tag = "Tags";
            this.btnTag.Text = "   Tags";
            this.btnTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTag.UseVisualStyleBackColor = false;
            this.btnTag.Click += new System.EventHandler(this.btnTag_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 30;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 896);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 15);
            this.btnExit.Size = new System.Drawing.Size(230, 48);
            this.btnExit.TabIndex = 10;
            this.btnExit.Tag = "exit";
            this.btnExit.Text = "   Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAHU
            // 
            this.btnAHU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnAHU.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAHU.FlatAppearance.BorderSize = 0;
            this.btnAHU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAHU.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAHU.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAHU.IconChar = FontAwesome.Sharp.IconChar.Hotel;
            this.btnAHU.IconColor = System.Drawing.Color.White;
            this.btnAHU.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAHU.IconSize = 30;
            this.btnAHU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAHU.Location = new System.Drawing.Point(0, 244);
            this.btnAHU.Name = "btnAHU";
            this.btnAHU.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAHU.Size = new System.Drawing.Size(230, 48);
            this.btnAHU.TabIndex = 9;
            this.btnAHU.Tag = "AHU";
            this.btnAHU.Text = "   AHU";
            this.btnAHU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAHU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAHU.UseVisualStyleBackColor = false;
            this.btnAHU.Click += new System.EventHandler(this.btnAHU_Click);
            // 
            // btnBoiler
            // 
            this.btnBoiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnBoiler.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBoiler.FlatAppearance.BorderSize = 0;
            this.btnBoiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoiler.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold);
            this.btnBoiler.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBoiler.IconChar = FontAwesome.Sharp.IconChar.Fire;
            this.btnBoiler.IconColor = System.Drawing.Color.White;
            this.btnBoiler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBoiler.IconSize = 30;
            this.btnBoiler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoiler.Location = new System.Drawing.Point(0, 196);
            this.btnBoiler.Name = "btnBoiler";
            this.btnBoiler.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBoiler.Size = new System.Drawing.Size(230, 48);
            this.btnBoiler.TabIndex = 8;
            this.btnBoiler.Tag = "Boiler ";
            this.btnBoiler.Text = "   Boiler";
            this.btnBoiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoiler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBoiler.UseVisualStyleBackColor = false;
            this.btnBoiler.Click += new System.EventHandler(this.btnBoiler_Click);
            // 
            // btnChiller
            // 
            this.btnChiller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnChiller.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChiller.FlatAppearance.BorderSize = 0;
            this.btnChiller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiller.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChiller.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnChiller.IconChar = FontAwesome.Sharp.IconChar.TemperatureArrowDown;
            this.btnChiller.IconColor = System.Drawing.Color.White;
            this.btnChiller.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChiller.IconSize = 30;
            this.btnChiller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChiller.Location = new System.Drawing.Point(0, 148);
            this.btnChiller.Name = "btnChiller";
            this.btnChiller.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnChiller.Size = new System.Drawing.Size(230, 48);
            this.btnChiller.TabIndex = 7;
            this.btnChiller.Tag = "Chiller";
            this.btnChiller.Text = "   Chiller";
            this.btnChiller.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChiller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChiller.UseVisualStyleBackColor = false;
            this.btnChiller.Click += new System.EventHandler(this.btnChiller_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.White;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 30;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(230, 48);
            this.btnHome.TabIndex = 6;
            this.btnHome.Tag = "Home";
            this.btnHome.Text = "   Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.panelLogo.Controls.Add(this.btnMenu);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(230, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(170, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(60, 60);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTilteBar
            // 
            this.panelTilteBar.BackColor = System.Drawing.Color.White;
            this.panelTilteBar.Controls.Add(this.lblDateTime);
            this.panelTilteBar.Controls.Add(this.btnMaximize);
            this.panelTilteBar.Controls.Add(this.btnClose);
            this.panelTilteBar.Controls.Add(this.btnMinimize);
            this.panelTilteBar.Controls.Add(this.btnCloseChildForm);
            this.panelTilteBar.Controls.Add(this.lblTilte);
            this.panelTilteBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTilteBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelTilteBar.Location = new System.Drawing.Point(230, 0);
            this.panelTilteBar.Name = "panelTilteBar";
            this.panelTilteBar.Size = new System.Drawing.Size(1453, 60);
            this.panelTilteBar.TabIndex = 1;
            this.panelTilteBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("RomanD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Green;
            this.lblDateTime.Location = new System.Drawing.Point(1081, 25);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(337, 35);
            this.lblDateTime.TabIndex = 14;
            this.lblDateTime.Text = "HH:mm:ss dd/MM/yyyy";
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.ExternalLink;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.Location = new System.Drawing.Point(1364, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(45, 25);
            this.btnMaximize.TabIndex = 13;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(74)))), ((int)(((byte)(130)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 20;
            this.btnClose.Location = new System.Drawing.Point(1409, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(1319, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 25);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCloseChildForm.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCloseChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseChildForm.IconSize = 40;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(60, 60);
            this.btnCloseChildForm.TabIndex = 10;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTilte
            // 
            this.lblTilte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTilte.AutoSize = true;
            this.lblTilte.Font = new System.Drawing.Font("RomanD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.lblTilte.Location = new System.Drawing.Point(646, 9);
            this.lblTilte.Name = "lblTilte";
            this.lblTilte.Size = new System.Drawing.Size(233, 46);
            this.lblTilte.TabIndex = 6;
            this.lblTilte.Text = "DASHBOARD";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDesktopPane.Controls.Add(this.groupControl);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDesktopPane.Location = new System.Drawing.Point(230, 60);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1453, 884);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.groupBox1);
            this.groupControl.Controls.Add(this.groupValve);
            this.groupControl.Controls.Add(this.groupMotor);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupControl.Size = new System.Drawing.Size(1453, 130);
            this.groupControl.TabIndex = 1;
            this.groupControl.TabStop = false;
            this.groupControl.Text = "Create Multiple Faceplate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGenerateDampers);
            this.groupBox1.Controls.Add(this.txtDamperQuantity);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(972, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAMPER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity";
            // 
            // btnGenerateDampers
            // 
            this.btnGenerateDampers.BackColor = System.Drawing.Color.Teal;
            this.btnGenerateDampers.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnGenerateDampers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerateDampers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGenerateDampers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateDampers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateDampers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateDampers.Location = new System.Drawing.Point(263, 32);
            this.btnGenerateDampers.Name = "btnGenerateDampers";
            this.btnGenerateDampers.Size = new System.Drawing.Size(150, 50);
            this.btnGenerateDampers.TabIndex = 6;
            this.btnGenerateDampers.Text = "Generate";
            this.btnGenerateDampers.UseVisualStyleBackColor = false;
            this.btnGenerateDampers.Click += new System.EventHandler(this.btnGenerateDampers_Click);
            // 
            // txtDamperQuantity
            // 
            this.txtDamperQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txtDamperQuantity.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDamperQuantity.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDamperQuantity.BorderRadius = 0;
            this.txtDamperQuantity.BorderSize = 2;
            this.txtDamperQuantity.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamperQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDamperQuantity.Location = new System.Drawing.Point(145, 35);
            this.txtDamperQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtDamperQuantity.Multiline = false;
            this.txtDamperQuantity.Name = "txtDamperQuantity";
            this.txtDamperQuantity.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDamperQuantity.PasswordChar = false;
            this.txtDamperQuantity.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDamperQuantity.PlaceholderText = "";
            this.txtDamperQuantity.Size = new System.Drawing.Size(90, 45);
            this.txtDamperQuantity.TabIndex = 7;
            this.txtDamperQuantity.Texts = "5";
            this.txtDamperQuantity.UnderlinedStyle = false;
            // 
            // groupValve
            // 
            this.groupValve.Controls.Add(this.label2);
            this.groupValve.Controls.Add(this.btnGenerateValves);
            this.groupValve.Controls.Add(this.txtValveQuantity);
            this.groupValve.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupValve.Location = new System.Drawing.Point(485, 39);
            this.groupValve.Name = "groupValve";
            this.groupValve.Size = new System.Drawing.Size(487, 88);
            this.groupValve.TabIndex = 1;
            this.groupValve.TabStop = false;
            this.groupValve.Text = "VALVE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quantity";
            // 
            // btnGenerateValves
            // 
            this.btnGenerateValves.BackColor = System.Drawing.Color.Teal;
            this.btnGenerateValves.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnGenerateValves.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerateValves.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGenerateValves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateValves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValves.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateValves.Location = new System.Drawing.Point(263, 32);
            this.btnGenerateValves.Name = "btnGenerateValves";
            this.btnGenerateValves.Size = new System.Drawing.Size(150, 50);
            this.btnGenerateValves.TabIndex = 6;
            this.btnGenerateValves.Text = "Generate";
            this.btnGenerateValves.UseVisualStyleBackColor = false;
            this.btnGenerateValves.Click += new System.EventHandler(this.btnGenerateValves_Click);
            // 
            // txtValveQuantity
            // 
            this.txtValveQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txtValveQuantity.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtValveQuantity.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtValveQuantity.BorderRadius = 0;
            this.txtValveQuantity.BorderSize = 2;
            this.txtValveQuantity.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValveQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValveQuantity.Location = new System.Drawing.Point(145, 35);
            this.txtValveQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtValveQuantity.Multiline = false;
            this.txtValveQuantity.Name = "txtValveQuantity";
            this.txtValveQuantity.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtValveQuantity.PasswordChar = false;
            this.txtValveQuantity.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtValveQuantity.PlaceholderText = "";
            this.txtValveQuantity.Size = new System.Drawing.Size(90, 45);
            this.txtValveQuantity.TabIndex = 7;
            this.txtValveQuantity.Texts = "15";
            this.txtValveQuantity.UnderlinedStyle = false;
            // 
            // groupMotor
            // 
            this.groupMotor.Controls.Add(this.label1);
            this.groupMotor.Controls.Add(this.btnGenerateMotors);
            this.groupMotor.Controls.Add(this.txtMotorQuantity);
            this.groupMotor.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupMotor.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMotor.Location = new System.Drawing.Point(3, 39);
            this.groupMotor.Name = "groupMotor";
            this.groupMotor.Size = new System.Drawing.Size(482, 88);
            this.groupMotor.TabIndex = 0;
            this.groupMotor.TabStop = false;
            this.groupMotor.Text = "MOTOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quantity";
            // 
            // btnGenerateMotors
            // 
            this.btnGenerateMotors.BackColor = System.Drawing.Color.Teal;
            this.btnGenerateMotors.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnGenerateMotors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerateMotors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGenerateMotors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateMotors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateMotors.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateMotors.Location = new System.Drawing.Point(277, 32);
            this.btnGenerateMotors.Name = "btnGenerateMotors";
            this.btnGenerateMotors.Size = new System.Drawing.Size(150, 50);
            this.btnGenerateMotors.TabIndex = 6;
            this.btnGenerateMotors.Text = "Generate";
            this.btnGenerateMotors.UseVisualStyleBackColor = false;
            this.btnGenerateMotors.Click += new System.EventHandler(this.btnGenerateMotors_Click);
            // 
            // txtMotorQuantity
            // 
            this.txtMotorQuantity.AutoSize = true;
            this.txtMotorQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txtMotorQuantity.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtMotorQuantity.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtMotorQuantity.BorderRadius = 0;
            this.txtMotorQuantity.BorderSize = 2;
            this.txtMotorQuantity.Font = new System.Drawing.Font("RomanD", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotorQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMotorQuantity.Location = new System.Drawing.Point(152, 35);
            this.txtMotorQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotorQuantity.Multiline = false;
            this.txtMotorQuantity.Name = "txtMotorQuantity";
            this.txtMotorQuantity.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMotorQuantity.PasswordChar = false;
            this.txtMotorQuantity.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMotorQuantity.PlaceholderText = "";
            this.txtMotorQuantity.Size = new System.Drawing.Size(90, 45);
            this.txtMotorQuantity.TabIndex = 7;
            this.txtMotorQuantity.Texts = "15";
            this.txtMotorQuantity.UnderlinedStyle = false;
            // 
            // Main_Timer
            // 
            this.Main_Timer.Tick += new System.EventHandler(this.Main_Timer_Tick);
            // 
            // DateTimer
            // 
            this.DateTimer.Enabled = true;
            this.DateTimer.Interval = 1000;
            this.DateTimer.Tick += new System.EventHandler(this.DateTimer_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1683, 944);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTilteBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "ap";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTilteBar.ResumeLayout(false);
            this.panelTilteBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.groupControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupValve.ResumeLayout(false);
            this.groupValve.PerformLayout();
            this.groupMotor.ResumeLayout(false);
            this.groupMotor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTilteBar;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Label lblTilte;
        private FontAwesome.Sharp.IconButton btnAHU;
        private FontAwesome.Sharp.IconButton btnBoiler;
        private FontAwesome.Sharp.IconButton btnChiller;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMenu;

        private FontAwesome.Sharp.IconButton btnCloseChildForm;
        private System.Windows.Forms.Timer Main_Timer;
        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.GroupBox groupMotor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateMotors;
        private RJCodeAdvance.RJControls.RJTextBox txtMotorQuantity;
        private System.Windows.Forms.GroupBox groupValve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateValves;
        private RJCodeAdvance.RJControls.RJTextBox txtValveQuantity;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer DateTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateDampers;
        private RJCodeAdvance.RJControls.RJTextBox txtDamperQuantity;
        private FontAwesome.Sharp.IconButton btnTag;
    }
}