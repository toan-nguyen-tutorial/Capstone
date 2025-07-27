using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HVAC_BacnetTCPIP.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HVAC_BacnetTCPIP.Faceplates
{
    public partial class Motor : Form
    {
        // Fields
        public MotorModel dataSource = new MotorModel();
        
        // Import Images
        Image motorOff = Properties.Resources.Motor_OFF;
        Image motorOn = Properties.Resources.Motor_ON;
        Image switchLeft = Properties.Resources.switch_left;
        Image switchRight = Properties.Resources.switch_right;
        Image warningRed = Properties.Resources.warning_red;
        Image warningYellow = Properties.Resources.warning_yellow;

        // Public events to Dashboard Form
        public enum MotorAction
        {
            Start_MouseDown,
            Start_MouseUp,
            Stop_MouseDown,
            Stop_MouseUp,
            Reset_MouseDown,
            Reset_MouseUp,
        }
        public delegate void MotorActionEventHandler(object sender, MouseEventArgs e, MotorAction action);
       
        public event MotorActionEventHandler MotorActionEvent;


        public Motor()
        {
            InitializeComponent();
            
            this.FormClosing += (sender, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            };
        }
        

        int count;
        

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Start = true;
            MotorActionEvent?.Invoke(this, e, MotorAction.Start_MouseDown);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Start = false;
            MotorActionEvent?.Invoke(this, e, MotorAction.Start_MouseUp);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Stop = true;
            MotorActionEvent?.Invoke(this, e, MotorAction.Stop_MouseDown);
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Stop = false;
            MotorActionEvent?.Invoke(this, e, MotorAction.Stop_MouseUp);
        }
        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Reset = true;
            dataSource.simFault = false;
            MotorActionEvent?.Invoke(this, e, MotorAction.Reset_MouseDown);
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Reset = false;
            MotorActionEvent?.Invoke(this, e, MotorAction.Reset_MouseUp);
        }
        private void Motor_Form_Load(object sender, EventArgs e)
        {
            /***** Initialize Form *****/

            // Mode = 1 - Mannual

            Toggle = false;
            picSwitch.BackgroundImage = switchLeft;
            picSwitch.BackColor = Color.Transparent;
            picSwitch.BackgroundImageLayout = ImageLayout.Stretch;

            //Motor - OFF
            dataSource.Mode = true;

        }
        private bool Toggle;
        private void picSwitch_Click(object sender, EventArgs e)
        {
            Toggle = !Toggle;
            if (Toggle)
            {
                picSwitch.BackgroundImage = switchLeft;
                dataSource.Mode = true;
            }
            else
            {
                picSwitch.BackgroundImage = switchRight;
                dataSource.Mode = false;
            }
        }


        private void Main_SCL_Tick(object sender, EventArgs e)
        {
            if (dataSource.Mode)
            {
                if (setSpeed.Value != 0) 
                    dataSource.CMD = (dataSource.CMD || dataSource.Start) && !dataSource.Stop && !dataSource.Fault;

                dataSource.RunFeedBack = dataSource.CMD && !dataSource.simFault;
                if (!dataSource.RunFeedBack)
                {
                    picMotor.BackgroundImage = motorOff;
                    picMotor.BackColor = Color.Transparent;
                    picMotor.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.setSpeed = 0;
                    dataSource.uk = dataSource.pid.Output(dataSource.setSpeed, dataSource.Speed, 0.001f);
                    dataSource.Speed = dataSource.plant.Update(dataSource.uk) * 60 / 2 * 3.14159265358979f;
                    
                    if (dataSource.Speed < 0) dataSource.Speed = 0;
                    txtSpeed.Text = Clamp(dataSource.Speed, 0, 1000).ToString("F1") + " rpm";

                }
                else
                {
                    picMotor.BackgroundImage = motorOn;
                    picMotor.BackColor = Color.Transparent;
                    picMotor.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.setSpeed = (float)setSpeed.Value;
                    dataSource.uk = dataSource.pid.Output(dataSource.setSpeed, dataSource.Speed, 0.001f);
                    dataSource.Speed = dataSource.plant.Update(dataSource.uk) * 60 / 2 * 3.14159265358979f;
                    txtSpeed.Text = Clamp(dataSource.Speed, 0, 1000).ToString("F1") + " rpm";
                }
            }
            else
            {
                if (dataSource.RunFeedBack)
                {
                    picMotor.BackgroundImage = motorOn;
                    picMotor.BackColor = Color.Transparent;
                    picMotor.BackgroundImageLayout = ImageLayout.Stretch;

                    dataSource.setSpeed = (float)setSpeed.Value;
                    dataSource.uk = dataSource.pid.Output(dataSource.setSpeed, dataSource.Speed, 0.001f);
                    dataSource.Speed = dataSource.plant.Update(dataSource.uk) * 60 / 2 * 3.14159265358979f;
                    txtSpeed.Text = Clamp(dataSource.Speed, 0, 1000).ToString("F1") + " rpm";

                }   
                else
                {
                    picMotor.BackgroundImage = motorOff;
                    picMotor.BackColor = Color.Transparent;
                    picMotor.BackgroundImageLayout = ImageLayout.Stretch;

                    dataSource.setSpeed = 0;
                    dataSource.uk = dataSource.pid.Output(dataSource.setSpeed, dataSource.Speed, 0.001f);
                    dataSource.Speed = dataSource.plant.Update(dataSource.uk) * 60 / 2 * 3.14159265358979f;
                    if (dataSource.Speed < 0) dataSource.Speed = 0;
                    txtSpeed.Text = Clamp(dataSource.Speed, 0, 1000).ToString("F1") + " rpm";
                }
            }
        }

        // Runtime

        private void timerRuntime_Tick(object sender, EventArgs e)
        {
            if (dataSource.RunFeedBack)
            {
                dataSource.Runtime++;
                txtRuntime.Text = TimeSpan.FromSeconds(dataSource.Runtime).ToString(@"hh\:mm\:ss");
            }
            else
            {
                dataSource.Runtime = 0;
                txtRuntime.Text = TimeSpan.FromSeconds(dataSource.Runtime).ToString(@"hh\:mm\:ss");
            }
        }

      

        int temp;
        bool Flag;
       

        // Simulate Fault
        private void timer1s_Tick(object sender, EventArgs e)
        {
            if (dataSource.CMD)
            {
                temp++;
                if (temp > 10)
                {
                    Flag = true;
                   
                }
            }
            else
            {
                Flag = false;
                temp = 0;
               
            }

            // Simulate Fault
            if (Flag && !dataSource.RunFeedBack)
            {
                dataSource.Fault = true;
                picFault.Visible = true;

            }
            if (dataSource.Reset)
            {
                dataSource.Fault = false;
                picFault.Visible = false;
            }
            // Animation
            if (dataSource.Fault)
            {
                if (count == 0)
                {
                    picFault.BackgroundImage = warningRed;
                    count = 1;
                }
                else
                {
                    picFault.BackgroundImage = warningYellow;
                    count = 0;
                }
                picFault.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void picMotor_Click(object sender, EventArgs e)
        {
            dataSource.simFault = true;
        }

 

        private void btnStart_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnStart.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset);
        }

        private void btnStop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnStart.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset);
        }

        private void btnReset_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnStart.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset,
            SystemColors.MenuText, 1, ButtonBorderStyle.Outset);
        }

        private void setSpeed_Scroll(object sender, EventArgs e)
        {
            lblValue.Text = setSpeed.Value.ToString();
            int min = setSpeed.Minimum;
            int max = setSpeed.Maximum;
            int range = max - min;

            float percent = (float)(setSpeed.Value - min) / range;

            int sliderHeight = setSpeed.Height - 16;
            int x = (int)((1 - percent) * sliderHeight);
            lblValue.Left = setSpeed.Right - lblValue.Width + 10;
            lblValue.Top = setSpeed.Top + x - 3;
            lblValue.Visible = true;
            lblValue.BringToFront();
        }

        float Clamp(float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

       
    }
}
