using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.BACnet;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using HVAC_BacnetTCPIP.Faceplates;
using HVAC_BacnetTCPIP.Forms;
using HVAC_BacnetTCPIP.Mapping;
using HVAC_BacnetTCPIP.Views;



namespace HVAC_BacnetTCPIP
{
    public partial class Dashboard : Form
    {
        //Fields
        private int borderSize = 2;
        private Button currentButton;   
        private Form activeForm;
        private Size formSize;


        private Forms.Boiler boilerForm;
        private Forms.Chiller chillerForm;
        private Forms.AHU AHUForm;
        private Forms.Overview OverviewForm;


        // Bacnet Object Id Boiler System:

        BacnetObjectId Boiler_Start = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 300);
        BacnetObjectId Boiler_Stop = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 301);
        BacnetObjectId Boiler_Reset = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 302);
        BacnetObjectId Boiler_CMD = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 303);
        BacnetObjectId Boiler_Fault = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 304);
        BacnetObjectId Boiler_State_1 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 305);
        BacnetObjectId Boiler_State_2 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 306);
        BacnetObjectId Boiler_State_3 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 307);
        BacnetObjectId Boiler_State_4 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 308);
        BacnetObjectId Boiler_State_5 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 309);



        BacnetObjectId Boiler_TempSP = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 100);
        BacnetObjectId Boiler_TempOut = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 101);
        BacnetObjectId HeatExchanger_TempSP = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 102);
        BacnetObjectId HeatExchanger_TempOut = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 103);




        // Bacnet Object Id Chiller && Cooling Tower System :


        BacnetObjectId Chiller_Start = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 310);
        BacnetObjectId Chiller_Stop = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 311);
        BacnetObjectId Chiller_State_1 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 312);
        BacnetObjectId Chiller_State_2 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 313);
        BacnetObjectId Chiller_State_3 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 314);
        BacnetObjectId Chiller_State_4 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 315);
        BacnetObjectId Chiller_State_5 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 316);


        BacnetObjectId CoolingTower_TempSP = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 110);
        BacnetObjectId CoolingTower_TempOut = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 111);
        BacnetObjectId Chiller_TempSP = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 112);
        BacnetObjectId Chiller_TempOut = new BacnetObjectId(BacnetObjectTypes.OBJECT_ANALOG_VALUE, 113);
      
   
        
        //Bacnet Object Air Handling Unit
        BacnetObjectId AHU_Start = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 317);
        BacnetObjectId AHU_Stop = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 318);
        BacnetObjectId AHU_State_1 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 319);
        BacnetObjectId AHU_State_2 = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_VALUE, 320);







        //Declare Forms &  Mapping Data
        private Dictionary<Motor, MotorMapping> motorMap = new Dictionary<Motor, MotorMapping>();
        public static List<Motor> motors { get; set; } = new List<Motor>();


        private Dictionary<Valve, ValveMapping> valveMap = new Dictionary<Valve, ValveMapping>();
        public static List<Valve> valves { get; set; } = new List<Valve>();

        private Dictionary<Damper, DamperMapping> damperMap = new Dictionary<Damper, DamperMapping>();
        public static List<Damper> dampers { get; set; } = new List<Damper>();



        public Dashboard()
        {
            InitializeComponent();
            CollapseMenu();
            this.Padding = new Padding(borderSize); // Border Size
            this.BackColor = Color.FromArgb(98, 102, 244); //Border Color 
            btnCloseChildForm.Visible = false;
            BacnetActivity.Run();

        }



        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                //m.Result = IntPtr.Zero;
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        private void panelTilteBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
                formSize = this.ClientSize;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ThemeColor.ChangeColorBrightness(Color.FromArgb(19, 45, 101), -0.3);
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("SansSerif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTilteBar.BackColor = Color.White;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(Color.FromArgb(19, 45, 101), 0);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    previousBtn.BackColor = Color.FromArgb(19, 45, 101);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("SansSerif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

            }
        }



        private void OpenChildForm(Form childForm, object btnSender)
        {

            foreach (Control ctrl in panelDesktopPane.Controls)
            {
                if (ctrl != childForm)
                    ctrl.Hide();
            }


            if (activeForm != null)
                activeForm.Hide();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;



            childForm.Location = new Point(
                 (panelDesktopPane.Width - childForm.Width) / 2 ,
                 (panelDesktopPane.Height - childForm.Height) / 2
             );

           
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTilte.Text = childForm.Text;

        }


        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelDesktopPane.Controls)
            {
                if (ctrl is Button)
                    ctrl.Show();
            }

            if (activeForm != null)
            {
                activeForm.Hide();
            }
            Reset();
            groupControl.Show();
        }

        private void Reset()
        {
            DisableButton();
            lblTilte.Text = "DASHBOARD";
            panelTilteBar.BackColor = Color.White;
            panelLogo.BackColor = Color.FromArgb(19, 45, 101);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            GeneralTags.Mode = true;
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Maximized;
           
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            foreach (Control ctrl in panelDesktopPane.Controls)
            {
                if (ctrl is Button)
                    ctrl.Show();
            }

            if (activeForm != null)
            {
                activeForm.Hide();
            }
            Reset();
            groupControl.Show();
        }
  

        private void btnChiller_Click(object sender, EventArgs e)
        {
            if (chillerForm == null || chillerForm.IsDisposed)
                chillerForm = new Forms.Chiller();

            OpenChildForm(chillerForm, sender);
            groupControl.Hide();
            chillerForm.ChillerMouseEvent += HandleChillerMouse;
            chillerForm.ChillerClickEvent += HandleChillerClick;
        }
     
        private void btnBoiler_Click(object sender, EventArgs e)
        {
            if (boilerForm == null || boilerForm.IsDisposed)
                boilerForm = new Forms.Boiler();

            OpenChildForm(boilerForm, sender);
            groupControl.Hide();

            boilerForm.BoilerMouseEvent += HandleBoilerMouse;
            boilerForm.BoilerClickEvent += HandleBoilerClick;

        }

        private void btnAHU_Click(object sender, EventArgs e)
        {
            if (AHUForm == null || AHUForm.IsDisposed)
                AHUForm = new Forms.AHU();

            OpenChildForm(AHUForm, sender);
            groupControl.Hide();
            AHUForm.AHUMouseEvent += HandleAHUMouse;
        
        }
        private void btnTag_Click(object sender, EventArgs e)
        {
            if (OverviewForm == null || OverviewForm.IsDisposed)
                OverviewForm = new Forms.Overview();
            OpenChildForm(OverviewForm, sender);
            groupControl.Hide();
        }




        // **********  Event Methods  **********
        private void btnGenerateMotors_Click(object sender, EventArgs e)
        {
            GenerateMotors(int.Parse(txtMotorQuantity.Texts));
            Main_Timer.Enabled = true;
        }

        private void btnGenerateValves_Click(object sender, EventArgs e)
        {
            GenerateValves(int.Parse(txtValveQuantity.Texts));
        }
        private void Btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            ControlPaint.DrawBorder(e.Graphics, btn.ClientRectangle,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset);

        }

        private void HandleMotorAction(object sender, MouseEventArgs e, Motor.MotorAction action)
        {
            if (sender is Motor motor && motorMap.TryGetValue(motor, out MotorMapping mapping))
            {
                switch (action)
                {
                    case Motor.MotorAction.Start_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Start, new BacnetValue(1));
                        break;

                    case Motor.MotorAction.Start_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Start, new BacnetValue(0));
                        break;

                    case Motor.MotorAction.Stop_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Stop, new BacnetValue(1));
                        break;

                    case Motor.MotorAction.Stop_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Stop, new BacnetValue(0));
                        break;

                    case Motor.MotorAction.Reset_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(1));
                        break;

                    case Motor.MotorAction.Reset_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(0));
                        break;
                }
            }
        }

        private void HandleValveAction(object sender, MouseEventArgs e, Valve.ValveAction action)
        {
            if (sender is Valve valve && valveMap.TryGetValue(valve, out ValveMapping mapping))
            {
                switch (action)
                {
                    case Valve.ValveAction.Open_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Open, new BacnetValue(1));
                        break;

                    case Valve.ValveAction.Open_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Open, new BacnetValue(0));
                        break;

                    case Valve.ValveAction.Close_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Close, new BacnetValue(1));
                        break;

                    case Valve.ValveAction.Close_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Close, new BacnetValue(0));
                        break;

                    case Valve.ValveAction.Reset_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(1));
                        break;

                    case Valve.ValveAction.Reset_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(0));
                        break;
                }
            }
        }

        private void HandleValveClick(object sender, Valve.ValveAction action)
        {
            if (sender is Valve valve && valveMap.TryGetValue(valve, out ValveMapping mapping))
            {
                switch (action)
                {
                    case Valve.ValveAction.Open_Click:
                        BacnetActivity.SetBacObjectPresentValue(mapping.SetPosition, new BacnetValue(valve.dataSource.SetPosition));
                        break;
                }
            }
        }


        private void HandleBoilerMouse(object sender, MouseEventArgs e, Boiler.BoilerAction action)
        {
            switch (action)
            {
                case Boiler.BoilerAction.Start_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Start, new BacnetValue(1));
                    break;

                case Boiler.BoilerAction.Start_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Start, new BacnetValue(0));
                    break;

                case Boiler.BoilerAction.Stop_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Stop, new BacnetValue(1));
                    break;

                case Boiler.BoilerAction.Stop_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Stop, new BacnetValue(0));
                    break;

                case Boiler.BoilerAction.Reset_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Reset, new BacnetValue(1));
                    break;

                case Boiler.BoilerAction.Reset_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_Reset, new BacnetValue(0));
                    break;
            }
        }

        private void HandleBoilerClick(object sender, Boiler.BoilerAction action)
        {
        
             switch (action)
             {
                 case Boiler.BoilerAction.Start_Click:
                    BacnetActivity.SetBacObjectPresentValue(Boiler_TempSP, new BacnetValue(Boiler.dataSource.setpoint_PID1 * 100f/5));
                    BacnetActivity.SetBacObjectPresentValue(HeatExchanger_TempSP, new BacnetValue(Boiler.dataSource.setpoint_PID2 * 100f / 5));
                    break;
             }
            
        }

        private void HandleChillerMouse(object sender, MouseEventArgs e, Chiller.ChillerAction action)
        {
            switch (action)
            {
                case Chiller.ChillerAction.Start_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(Chiller_Start, new BacnetValue(1));
                    break;

                case Chiller.ChillerAction.Start_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(Chiller_Start, new BacnetValue(0));
                    break;

                case Chiller.ChillerAction.Stop_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(Chiller_Stop, new BacnetValue(1));
                    break;

                case Chiller.ChillerAction.Stop_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(Chiller_Stop, new BacnetValue(0));
                    break;
            }
        }
        private void HandleChillerClick(object sender, Chiller.ChillerAction action)
        {

            switch (action)
            {
                case Chiller.ChillerAction.Start_Click:
                    BacnetActivity.SetBacObjectPresentValue(CoolingTower_TempSP, new BacnetValue(Chiller.dataSource.setpoint_PID1 * 100f / 5));
                    BacnetActivity.SetBacObjectPresentValue(Chiller_TempSP, new BacnetValue(Chiller.dataSource.setpoint_PID2 * 100f / 5));
                    break;
            }

        }


        private void HandleDamperMouse(object sender, MouseEventArgs e, Damper.DamperAction action)
        {
            if (sender is Damper damper && damperMap.TryGetValue(damper, out DamperMapping mapping))
            {
                switch (action)
                {
                    case Damper.DamperAction.Open_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Open, new BacnetValue(1));
                        break;

                    case Damper.DamperAction.Open_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Open, new BacnetValue(0));
                        break;

                    case Damper.DamperAction.Close_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Close, new BacnetValue(1));
                        break;

                    case Damper.DamperAction.Close_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Close, new BacnetValue(0));
                        break;

                    case Damper.DamperAction.Reset_MouseDown:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(1));
                        break;

                    case Damper.DamperAction.Reset_MouseUp:
                        BacnetActivity.SetBacObjectPresentValue(mapping.Reset, new BacnetValue(0));
                        break;
                }
            }
        }

        private void HandleDamperClick(object sender, Damper.DamperAction action)
        {
            if (sender is Damper damper && damperMap.TryGetValue(damper, out DamperMapping mapping))
            {
                switch (action)
                {
                    case Damper.DamperAction.Open_Click:
                        BacnetActivity.SetBacObjectPresentValue(mapping.SetPosition, new BacnetValue(damper.dataSource.SetPosition));
                        break;
                }
            }
        }
        private void HandleAHUMouse(object sender, MouseEventArgs e, AHU.AHUAction action)
        {
            switch (action)
            {
                case AHU.AHUAction.Start_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(AHU_Start, new BacnetValue(1));
                    break;

                case AHU.AHUAction.Start_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(AHU_Start, new BacnetValue(0));
                    break;

                case AHU.AHUAction.Stop_MouseDown:
                    BacnetActivity.SetBacObjectPresentValue(AHU_Stop, new BacnetValue(1));
                    break;

                case AHU.AHUAction.Stop_MouseUp:
                    BacnetActivity.SetBacObjectPresentValue(AHU_Stop, new BacnetValue(0));
                    break;
            }
        }




        public static bool isInternalChange { get; set; } = false;
        private void Main_Timer_Tick(object sender, EventArgs e)
        {
            // Motor Group:
            for (int i = 0; i < motors.Count; i++)
            {
                var motor = motors[i];

                if (motorMap.TryGetValue(motor, out MotorMapping mapping))
                {
                    // Get Data from SCADA
                    //motor.dataSource.Mode = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Mode).Value);
                    motor.dataSource.Start = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Start).Value);
                    motor.dataSource.Stop = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Stop).Value);
                    motor.dataSource.Reset = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Reset).Value);

                    // Send Data to SCADA
                    //Console.WriteLine($"Motor {i + 1}: RunFeedBack = {motor.dataSource.RunFeedBack}, Fault = {motor.dataSource.Fault}");
                    BacnetActivity.SetBacObjectPresentValue(mapping.RunFeedBack, new BacnetValue(motor.dataSource.RunFeedBack));
                    BacnetActivity.SetBacObjectPresentValue(mapping.Fault, new BacnetValue(motor.dataSource.Fault));


                    BacnetActivity.SetBacObjectPresentValue(mapping.Speed, new BacnetValue(motor.dataSource.Speed));
                    BacnetActivity.m_storage.WriteProperty(mapping.Runtime, BacnetPropertyIds.PROP_PRESENT_VALUE, new BacnetValue(BacnetApplicationTags.BACNET_APPLICATION_TAG_CHARACTER_STRING, TimeSpan.FromSeconds(motor.dataSource.Runtime).ToString(@"hh\:mm\:ss")));
                }
            }

            // Valve Group:    
            for (int i = 0; i < valves.Count; i++)
            {
                var valve = valves[i];

                if (valveMap.TryGetValue(valve, out ValveMapping mapping))
                {
                    // Get Data from SCADA
                    valve.dataSource.Mode = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Mode).Value);
                    valve.dataSource.Open = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Open).Value);
                    valve.dataSource.Close = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Close).Value);
                    valve.dataSource.Reset = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Reset).Value);
                   
                    
                   float newValveSetPosition = (float)BacnetActivity.GetBacObjectPresentValue(mapping.SetPosition).Value;
                  
                    if (Math.Abs(newValveSetPosition - valve.dataSource.SetPosition) > 0.1f)
                    {
                        valve.dataSource.SetPosition = newValveSetPosition;
                        valves[i].txtSetPosition.Texts = newValveSetPosition.ToString();
                    }

                    //Console.WriteLine(valve.dataSource.SetPosition);

                    // Send Data to SCADA
                    BacnetActivity.SetBacObjectPresentValue(mapping.OpenFeedBack, new BacnetValue(valve.dataSource.OpenFeedBack));
                    BacnetActivity.SetBacObjectPresentValue(mapping.Fault, new BacnetValue(valve.dataSource.Fault));
                    BacnetActivity.SetBacObjectPresentValue(mapping.ValvePosition, new BacnetValue(valve.dataSource.valvePosition));
                }
            }


            // Damper Group:    
            for (int i = 0; i < dampers.Count; i++)
            {
                var damper = dampers[i];

                if (damperMap.TryGetValue(damper, out DamperMapping mapping))
                {
                    // Get Data from SCADA
                    damper.dataSource.Mode = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Mode).Value);
                    damper.dataSource.Open = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Open).Value);
                    damper.dataSource.Close = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Close).Value);
                    damper.dataSource.Reset = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(mapping.Reset).Value);


                    float newDamperSetPosition = (float)BacnetActivity.GetBacObjectPresentValue(mapping.SetPosition).Value;
                    if (Math.Abs(newDamperSetPosition - damper.dataSource.SetPosition) > 0.1f)
                    {
                        damper.dataSource.SetPosition = newDamperSetPosition;
                        dampers[i].txtDamperSP.Texts = newDamperSetPosition.ToString();

                    }

                    // Send Data to SCADA
                    
                    BacnetActivity.SetBacObjectPresentValue(mapping.OpenFeedBack, new BacnetValue(damper.dataSource.OpenFeedBack));
                    BacnetActivity.SetBacObjectPresentValue(mapping.Fault, new BacnetValue(damper.dataSource.Fault));
                    BacnetActivity.SetBacObjectPresentValue(mapping.DamperPosition, new BacnetValue(damper.dataSource.DamperPosition));
                }

            }



            // ***** Boiler Group *****

            // Send Data to SCADA:
            BacnetActivity.SetBacObjectPresentValue(Boiler_CMD, new BacnetValue(Boiler.dataSource.CMD));
            BacnetActivity.SetBacObjectPresentValue(Boiler_Fault, new BacnetValue(Boiler.dataSource.Fault));
            BacnetActivity.SetBacObjectPresentValue(Boiler_State_1, new BacnetValue(Boiler.dataSource.S1));
            BacnetActivity.SetBacObjectPresentValue(Boiler_State_2, new BacnetValue(Boiler.dataSource.S2));
            BacnetActivity.SetBacObjectPresentValue(Boiler_State_3, new BacnetValue(Boiler.dataSource.S3));
            BacnetActivity.SetBacObjectPresentValue(Boiler_State_4, new BacnetValue(Boiler.dataSource.S4));
            BacnetActivity.SetBacObjectPresentValue(Boiler_State_5, new BacnetValue(Boiler.dataSource.S5));
            BacnetActivity.SetBacObjectPresentValue(Boiler_TempOut, new BacnetValue(Boiler.dataSource.yHeatExchanger_PID1));
            BacnetActivity.SetBacObjectPresentValue(HeatExchanger_TempOut, new BacnetValue(Boiler.dataSource.yHeatExchanger_PID2));

            //Get Data Form SCADA:
            Boiler.dataSource.Start = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(Boiler_Start).Value);
            Boiler.dataSource.Stop = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(Boiler_Stop).Value);
            Boiler.dataSource.Reset = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(Boiler_Reset).Value);
            


            float newBoilerTempSP = (float)BacnetActivity.GetBacObjectPresentValue(Boiler_TempSP).Value;
            float newHeatExTempSP = (float)BacnetActivity.GetBacObjectPresentValue(HeatExchanger_TempSP).Value;
            if (Math.Abs(newBoilerTempSP - (Boiler.dataSource.setpoint_PID1 * 100f / 5)) > 0.1f)
            {
                
                Boiler.dataSource.setpoint_PID1 = newBoilerTempSP * 5f/100;
                boilerForm.txtTempBoilerSP.Text = newBoilerTempSP.ToString();
            }

            if (Math.Abs(newHeatExTempSP - (Boiler.dataSource.setpoint_PID2 * 100f / 5)) > 0.1f)
            {

                Boiler.dataSource.setpoint_PID2 = newHeatExTempSP * 5f / 100;
                boilerForm.txtTempHeatExSP.Text = newHeatExTempSP.ToString();
            }

            // ***** Chiller Group *****

            //Send Data to SCADA 
            BacnetActivity.SetBacObjectPresentValue(Chiller_State_1, new BacnetValue(Chiller.dataSource.S1));
            BacnetActivity.SetBacObjectPresentValue(Chiller_State_2, new BacnetValue(Chiller.dataSource.S2));
            BacnetActivity.SetBacObjectPresentValue(Chiller_State_3, new BacnetValue(Chiller.dataSource.S3));
            BacnetActivity.SetBacObjectPresentValue(Chiller_State_4, new BacnetValue(Chiller.dataSource.S4));
            BacnetActivity.SetBacObjectPresentValue(Chiller_State_5, new BacnetValue(Chiller.dataSource.S5));
            BacnetActivity.SetBacObjectPresentValue(CoolingTower_TempOut, new BacnetValue(Chiller.dataSource.yHeatExchanger_PID1));
            BacnetActivity.SetBacObjectPresentValue(Chiller_TempOut, new BacnetValue(Chiller.dataSource.yHeatExchanger_PID2));

          
            float newCTWTempSP = (float)BacnetActivity.GetBacObjectPresentValue(CoolingTower_TempSP).Value;
            float newChillerTempSP = (float)BacnetActivity.GetBacObjectPresentValue(Chiller_TempSP).Value;
            if (Math.Abs(newCTWTempSP - (Chiller.dataSource.setpoint_PID1 * 100f / 5)) > 0.1f)
            {

                Chiller.dataSource.setpoint_PID1 = newCTWTempSP * 5f / 100;
                chillerForm.txtCoolingTowerSetpoint.Text = newCTWTempSP.ToString();
            }

            if (Math.Abs(newChillerTempSP - (Chiller.dataSource.setpoint_PID2 * 100f / 5)) > 0.1f)
            {

                Chiller.dataSource.setpoint_PID2 = newChillerTempSP * 5f / 100;
                chillerForm.txtChillerSetpoint.Text = newChillerTempSP.ToString();
            }


            //Get Data Form SCADA:
            Chiller.dataSource.Start = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(Chiller_Start).Value);
            Chiller.dataSource.Stop = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(Chiller_Stop).Value);


            //AHU Group :
            //Send Data to SCADA
            BacnetActivity.SetBacObjectPresentValue(AHU_State_1, new BacnetValue(AHU.dataSource.S1));
            BacnetActivity.SetBacObjectPresentValue(AHU_State_2, new BacnetValue(AHU.dataSource.S2));
            //Get Data From SCADA
            AHU.dataSource.Start = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(AHU_Start).Value);
            AHU.dataSource.Stop = Convert.ToBoolean(BacnetActivity.GetBacObjectPresentValue(AHU_Stop).Value);
        }

        // **********  Functions  **********
        private void GenerateMotors(int quantity)
        {
         
            if (quantity < 1 || quantity > 20)
            {
                MessageBox.Show("Please enter a value from 1 to 20!");
                return;
            }

            var oldButtons = panelDesktopPane.Controls
                .OfType<Button>()
                .Where(b => b.Text.Contains("Motor"))
                .ToList();


           
            foreach (var btn in oldButtons)
            {
                panelDesktopPane.Controls.Remove(btn);
                btn.Dispose();
            }

            motors.Clear();
            motorMap.Clear();

            // Button Parameters
            int buttonWidth = 150;
            int buttonHeight = 50;
            int spacing = 10;
            int columns = 5;
            int startX = 20;
            int startY = 150;

            for (int i = 0; i < quantity; i++)
            {

                Motor motor = new Motor();
                motors.Add(motor);

                uint baseBV = (uint)(i * 6);
                uint baseAV = (uint)(i * 2);
                uint baseDTV = (uint)i;
                MotorMapping mapping = new MotorMapping(baseBV, baseAV, baseDTV);
                motorMap[motor] = mapping;
                
                motor.MotorActionEvent += HandleMotorAction;

                Button btn = new Button
                {
                    Name = $"btnMotor{i + 1}",
                    Text = $"Motor {i + 1}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(
                        startX + (i % columns) * (buttonWidth + spacing),
                        startY + (i / columns) * (buttonHeight + spacing)
                    ),
                    Tag = i,
                    BackColor = Color.Teal,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point)
                };
                btn.FlatAppearance.BorderColor = Color.LightSlateGray;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
                btn.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;


                btn.Paint += Btn_Paint;

                btn.Click += (s, e) =>
                {
                    int index = (int)((Button)s).Tag;
                    motorMap[motor] = new MotorMapping(baseBV, baseAV, baseDTV);
                    motors[index].MotorActionEvent += HandleMotorAction;
                    motors[index].Text = $"MOTOR {index + 1}";
                    motors[index].Show();
                    motors[index].BringToFront();

                };

                panelDesktopPane.Controls.Add(btn);
            }
        }

        private void GenerateValves(int quantity)
        {

            if (quantity < 1 || quantity > 20)
            {
                MessageBox.Show("Please enter a value from 1 to 20!");
                return;
            }

            var oldButtons = panelDesktopPane.Controls
                .OfType<Button>()
                .Where(b => b.Text.Contains("Valve"))
                .ToList();

            foreach (var btn in oldButtons)
            {
                panelDesktopPane.Controls.Remove(btn);
                btn.Dispose();
            }

            valves.Clear();
            valveMap.Clear();

            // Button Parameters
            int buttonWidth = 150;
            int buttonHeight = 50;
            int spacing = 10;
            int columns = 5;
            int startX = 820;
            int startY = 150;

            for (int i = 0; i < quantity; i++)
            {

                Valve valve = new Valve();
                valves.Add(valve);

                uint baseBV = (uint)(120 + i * 6);
                uint baseAV = (uint)(40 + i * 3);
                ValveMapping mapping = new ValveMapping(baseBV, baseAV);
                valveMap[valve] = mapping;

                valve.ValveActionEvent += HandleValveAction;
                valve.ValveClickEvent += HandleValveClick;

                Button btn = new Button
                {
                    Name = $"btnValve{i + 1}",
                    Text = $"Valve {i + 1}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(
                        startX + (i % columns) * (buttonWidth + spacing),
                        startY + (i / columns) * (buttonHeight + spacing)
                    ),
                    Tag = i,
                    BackColor = Color.Teal,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point)
                };
                btn.FlatAppearance.BorderColor = Color.LightSlateGray;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
                btn.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;


                btn.Paint += Btn_Paint;

                btn.Click += (s, e) =>
                {
                    int index = (int)((Button)s).Tag;
                    valveMap[valve] = new ValveMapping(baseBV, baseAV);
                    valves[index].ValveActionEvent += HandleValveAction;
                    valves[index].Text = $"Valve {index + 1}";
                    valves[index].Show();
                    valves[index].BringToFront();

                };

                panelDesktopPane.Controls.Add(btn);
            }

        }

        private void GenerateDampers(int quantity)
        {

            if (quantity < 1 || quantity > 5)
            {
                MessageBox.Show("Please enter a value from 1 to 5!");
                return;
            }

            var oldButtons = panelDesktopPane.Controls
                .OfType<Button>()
                .Where(b => b.Text.Contains("Damper"))
                .ToList();

            foreach (var btn in oldButtons)
            {
                panelDesktopPane.Controls.Remove(btn);
                btn.Dispose();
            }

            dampers.Clear();
            damperMap.Clear();

            // Button Parameters
            int buttonWidth = 150;
            int buttonHeight = 50;
            int spacing = 10;
            int columns = 5;
            int startX = 20;
            int startY = 390;

            for (int i = 0; i < quantity; i++)
            {

                Damper damper = new Damper();
                dampers.Add(damper);

                uint baseBV = (uint)(240 + i * 6);
                uint baseAV = (uint)(120 + i * 2);
                DamperMapping mapping = new DamperMapping(baseBV, baseAV);
                damperMap[damper] = mapping;

                damper.DamperMouseEvent += HandleDamperMouse;
                damper.DamperClickEvent += HandleDamperClick;

                Button btn = new Button
                {
                    Name = $"btnDamper{i + 1}",
                    Text = $"Damper {i + 1}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(
                        startX + (i % columns) * (buttonWidth + spacing),
                        startY + (i / columns) * (buttonHeight + spacing)
                    ),
                    Tag = i,
                    BackColor = Color.Teal,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point)
                };
                btn.FlatAppearance.BorderColor = Color.LightSlateGray;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
                btn.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;


                btn.Paint += Btn_Paint;

                btn.Click += (s, e) =>
                {
                    int index = (int)((Button)s).Tag;
                    damperMap[damper] = new DamperMapping(baseBV, baseAV);
                    dampers[index].DamperMouseEvent += HandleDamperMouse;
                    dampers[index].Text = $"Damper {index + 1}";
                    dampers[index].Show();
                    dampers[index].BringToFront();

                };

                panelDesktopPane.Controls.Add(btn);
            }

        }

        private void btnGenerateDampers_Click(object sender, EventArgs e)
        {
            GenerateDampers(int.Parse(txtDamperQuantity.Texts));
        }

        private void DateTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

     
    }
}
