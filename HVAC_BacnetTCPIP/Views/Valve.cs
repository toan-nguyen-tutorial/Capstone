using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HVAC_BacnetTCPIP.Classes;
using HVAC_BacnetTCPIP.Forms;
using HVAC_BacnetTCPIP.Models;
using static HVAC_BacnetTCPIP.Faceplates.Motor;

namespace HVAC_BacnetTCPIP.Faceplates
{
    public partial class Valve : Form
    {

        // Fields
        public ValveModel dataSource = new ValveModel();

        // Import Images
        Image ControlValve_OFF = Properties.Resources.ControlValve_OFF;
        Image ControlValve_ON = Properties.Resources.ControlVavle_ON;

        //Public Events to Dashboard Form
        public enum ValveAction
        {
            Open_MouseDown,
            Open_MouseUp,
            Close_MouseDown,
            Close_MouseUp,
            Reset_MouseDown,
            Reset_MouseUp,
            Open_Click,
        }


        public delegate void ValveActionEventHandler(object sender, MouseEventArgs e, ValveAction action);
        public event ValveActionEventHandler ValveActionEvent;

        public delegate void ValveClickEventHandler(object sender, ValveAction action);
        public event ValveClickEventHandler ValveClickEvent;

        public Valve()
        {
            InitializeComponent();
        }

        // Functions
        float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        // Method Events

        private void Sampling_1000ms_Tick(object sender, EventArgs e)
        {
            if (radioMan.Checked) dataSource.Mode = true;
            if (radioAuto.Checked) dataSource.Mode = false;


            if (dataSource.Mode)
            {
                dataSource.CMD = (dataSource.CMD || dataSource.Open) && !dataSource.Close && !dataSource.Fault;
                dataSource.OpenFeedBack = dataSource.CMD && !dataSource.simFault;

                if (dataSource.OpenFeedBack)
                {
                    picControlValve.BackgroundImage = ControlValve_ON;
                    picControlValve.BackColor = Color.Transparent;
                    picControlValve.BackgroundImageLayout = ImageLayout.Stretch;

                    dataSource.uk = Clamp(dataSource.G_PID.Output(dataSource.SetPosition * 4.438f / 100, dataSource.yFlowSensor, 0.1f), 0f, 4.438f); // Clamp & Convert 0 - 100 Percent to 0 - 4.438 Voltage
                    dataSource.yValve = dataSource.G_Valve.Update(dataSource.uk);
                    dataSource.yFlowSensor = dataSource.G_FlowSensor.Update(dataSource.yValve);
                    dataSource.valvePosition = Clamp(dataSource.yFlowSensor * 100/4.438f, 0, 100);
                
                }

                else
                {
                    dataSource.SetPosition = 0;
                    dataSource.uk = Clamp(dataSource.G_PID.Output(dataSource.SetPosition * 4.438f / 100, dataSource.yFlowSensor, 0.1f), 0f, 4.438f); // Clamp & Convert 0 - 100 Percent to 0 - 4.438 Voltage
                    dataSource.yValve = dataSource.G_Valve.Update(dataSource.uk);
                    dataSource.yFlowSensor = dataSource.G_FlowSensor.Update(dataSource.yValve);
                    dataSource.valvePosition = Clamp(dataSource.yFlowSensor * 100 / 4.438f, 0, 100);
                    picControlValve.BackgroundImage = ControlValve_OFF;
                    picControlValve.BackColor = Color.Transparent;
                    picControlValve.BackgroundImageLayout = ImageLayout.Stretch;
                }


                if (dataSource.valvePosition < 0) dataSource.valvePosition = 0;
                if (dataSource.valvePosition > 100) dataSource.valvePosition = 100;

                txtFlowRateSensor.Texts = dataSource.yFlowSensor.ToString("F3") + " Voltage";
                txtFlowRate.Texts = dataSource.yValve.ToString("F3") + " cm³ /min";
                txtValvePosition.Texts = dataSource.valvePosition.ToString("F3") + " %";
            }
            else
            {
                if (dataSource.OpenFeedBack)
                {
                    
                    picControlValve.BackgroundImage = ControlValve_ON;
                    picControlValve.BackColor = Color.Transparent;
                    picControlValve.BackgroundImageLayout = ImageLayout.Stretch;

                    dataSource.uk = Clamp(dataSource.G_PID.Output(dataSource.SetPosition * 4.438f / 100, dataSource.yFlowSensor, 0.1f), 0f, 4.438f); // Clamp & Convert 0 - 100 Percent to 0 - 4.438 Voltage
                    dataSource.yValve = dataSource.G_Valve.Update(dataSource.uk);
                    dataSource.yFlowSensor = dataSource.G_FlowSensor.Update(dataSource.yValve);
                    dataSource.valvePosition = Clamp(dataSource.yFlowSensor * 100 / 4.438f, 0, 100);


                }

                else
                {
                    dataSource.SetPosition = 0;
                    dataSource.uk = Clamp(dataSource.G_PID.Output(dataSource.SetPosition * 4.438f / 100, dataSource.yFlowSensor, 0.1f), 0f, 4.438f); // Clamp & Convert 0 - 100 Percent to 0 - 4.438 Voltage
                    dataSource.yValve = dataSource.G_Valve.Update(dataSource.uk);
                    dataSource.yFlowSensor = dataSource.G_FlowSensor.Update(dataSource.yValve);
                    dataSource.valvePosition = Clamp(dataSource.yFlowSensor * 100 / 4.438f, 0, 100);
                    picControlValve.BackgroundImage = ControlValve_OFF;
                    picControlValve.BackColor = Color.Transparent;
                    picControlValve.BackgroundImageLayout = ImageLayout.Stretch;
                }


                if (dataSource.valvePosition < 0) dataSource.valvePosition = 0;
                if (dataSource.valvePosition > 100) dataSource.valvePosition = 100;

                txtFlowRateSensor.Texts = dataSource.yFlowSensor.ToString("F3") + " Voltage";
                txtFlowRate.Texts = dataSource.yValve.ToString("F3") + " cm³ /min";
                txtValvePosition.Texts = dataSource.valvePosition.ToString("F3") + " %";
            }
        }
        
 

      
        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataSource.SetPosition = float.Parse(txtSetPosition.Texts);
            ValveClickEvent?.Invoke(this, ValveAction.Open_Click);
        }

        private void btnOpen_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Open = true;
            ValveActionEvent?.Invoke(this, e, ValveAction.Open_MouseDown);
        }

        private void btnOpen_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Open = false;
            ValveActionEvent?.Invoke(this, e, ValveAction.Open_MouseUp);
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Close = true;
            ValveActionEvent?.Invoke(this, e, ValveAction.Close_MouseDown);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Close = false;
            ValveActionEvent?.Invoke(this, e, ValveAction.Close_MouseUp);
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Reset = true;
            ValveActionEvent?.Invoke(this, e, ValveAction.Reset_MouseDown);
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Reset = false;
            ValveActionEvent?.Invoke(this, e, ValveAction.Reset_MouseUp);
        }

        private void btnOpen_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnOpen.ClientRectangle,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset);
        }

        private void btnClose_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnClose.ClientRectangle,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset);
        }

        private void btnReset_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnReset.ClientRectangle,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.White, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset,
               Color.Gray, 1, ButtonBorderStyle.Outset);
        }

        private void Valve_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

   
  
    }
}
