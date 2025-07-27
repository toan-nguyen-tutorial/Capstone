using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using HVAC_BacnetTCPIP.Models;
using static HVAC_BacnetTCPIP.Forms.Boiler;

namespace HVAC_BacnetTCPIP.Forms
{
    public partial class Chiller : Form
    {

        // Fields
        public static ChillerModel dataSource { get; set; } = new ChillerModel();

        // Import Images
        Image motorOff = Properties.Resources.MOTOR_OFF_1;
        Image motorOn = Properties.Resources.Motor_ON_1;
        Image CentrifugalOff = Properties.Resources.Centrifugal_Pump_OFF;
        Image CentrifugalOn = Properties.Resources.Centrifugal_Pump_ON;
        Image[] propellerFrames = new Image[]
        {
            Properties.Resources.agitator_1,
            Properties.Resources.agitator_2,
            Properties.Resources.agitator_3,
            Properties.Resources.agitator_4
        };

        // Declare Tag
        bool FirstScan,S0, T01, T12, T23, T34, T45, T00, T10, T20, T30, T40, T50, T51, T41, PID1_Alarm, PID2_Alarm, AHU_Alarm, Bypass_Alarm_1, Bypass_Alarm_2, End;




        float Temp_AHU;
        int count, count_propeller;

        //Public Events to Dashboard Form
        public enum ChillerAction
        {
            Start_MouseDown,
            Start_MouseUp,
            Stop_MouseDown,
            Stop_MouseUp,
            Start_Click,
        }
        //Mouse Events
        
        public delegate void ChillerMouseEventHandler(object sender, MouseEventArgs e, ChillerAction action);
        public event ChillerMouseEventHandler ChillerMouseEvent;

        public delegate void ChillerClickEventHandler(object sender, ChillerAction action);
        public event ChillerClickEventHandler ChillerClickEvent;

        public Chiller()
        {
            InitializeComponent();
        }
        // Event Methods
        private void Fan_M3_Click(object sender, EventArgs e)
        {
            Dashboard.motors[2].Text = "Fan Cooling Tower M3";
            Dashboard.motors[2].Show();
        }

        private bool Toggle;
        private void Random_Timer_Tick(object sender, EventArgs e)
        {

            if (cmbSel.SelectedItem.ToString() == "Random")
            {
                txtTemp_AHU.ReadOnly = true;
                txtTemp_AHU.Text = Toggle ? "12" : "14";
                Toggle = !Toggle;
            }
            else
            {
                txtTemp_AHU.ReadOnly = false;
            }
        }

        private void CTWP_M4_Click(object sender, EventArgs e)
        {
            Dashboard.motors[3].Text = "Cooling Tower Water Pump M4";
            Dashboard.motors[3].Show();
        }

        private void CTWP_M5_Click(object sender, EventArgs e)
        {
            Dashboard.motors[4].Text = "Cooling Tower Water Pump M5";
            Dashboard.motors[4].Show();
        }

  

        private void Compressor_M6_Click(object sender, EventArgs e)
        {
            Dashboard.motors[5].Text = "Centrifugal Compressor M6";
            Dashboard.motors[5].Show();
        }

        private void CWP_M7_Click(object sender, EventArgs e)
        {
            Dashboard.motors[6].Text = "Chilled Water Pump M7";
            Dashboard.motors[6].Show();
        }

        private void HA_V3_Click(object sender, EventArgs e)
        {
            Dashboard.valves[2].Text = "Ball Valve V3";
            Dashboard.valves[2].Show();
        }

        private void HA_V4_Click(object sender, EventArgs e)
        {
            Dashboard.valves[3].Text = "Ball Valve V4";
            Dashboard.valves[3].Show();
        }

        private void CV_V5_Click(object sender, EventArgs e)
        {
            Dashboard.valves[4].Text = "Control Valve V5";
            Dashboard.valves[4].Show();
        }

        private void BPV_V6_Click(object sender, EventArgs e)
        {
            Dashboard.valves[5].Text = "ByPass Valve V6";
            Dashboard.valves[5].Show();
        }

        private void EV_V7_Click(object sender, EventArgs e)
        {
            Dashboard.valves[6].Text = "Expansion Valve V7";
            Dashboard.valves[6].Show();
        }

        private void BPV_V8_Click(object sender, EventArgs e)
        {
            Dashboard.valves[7].Text = "ByPass Valve V8";
            Dashboard.valves[7].Show();
        }

        private void CV_V9_Click(object sender, EventArgs e)
        {
            Dashboard.valves[8].Text = "Control Valve V9";
            Dashboard.valves[8].Show();
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Stop = false;
            ChillerMouseEvent?.Invoke(this, e, ChillerAction.Stop_MouseUp);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            dataSource.setpoint_PID1 = float.Parse(txtCoolingTowerSetpoint.Text) * 5f / 100;
            dataSource.setpoint_PID2 = float.Parse(txtChillerSetpoint.Text) * 5f / 100;
            ChillerClickEvent?.Invoke(e, ChillerAction.Start_Click);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Stop = true;
            ChillerMouseEvent?.Invoke(this, e, ChillerAction.Stop_MouseDown);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Start = false;
            ChillerMouseEvent?.Invoke(this, e, ChillerAction.Start_MouseUp);
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Start = true;
            ChillerMouseEvent?.Invoke(this, e, ChillerAction.Start_MouseDown);
        }

        private void PID1_Timer_Tick(object sender, EventArgs e)
        {
            dataSource.uk_1_PID1 = dataSource.primary_controller_1_PID1.Output(dataSource.setpoint_PID1, dataSource.yTemperatureSensor_PID1, 0.1f);
            dataSource.uk_2_PID1 = Clamp(dataSource.secondary_controller_1_PID1.Output(dataSource.uk_1_PID1, dataSource.yFlowRateSensor_PID1, 0.1f), 0.0f, 30.0f);
            dataSource.yValve_PID1 = dataSource.valve_1_PID1.Update(dataSource.uk_2_PID1);
            dataSource.yFlowRateSensor_PID1 = dataSource.flowSensor_1_PID1.Update(dataSource.yValve_PID1);
            dataSource.yHeatExchanger_PID1 = dataSource.heatExchanger_PID1.Update(dataSource.yValve_PID1);
            dataSource.yTemperatureSensor_PID1 = dataSource.temperatureSensor_PID1.Update(dataSource.yHeatExchanger_PID1);
        }
        private void PID2_Timer_Tick(object sender, EventArgs e)
        {
            dataSource.uk_1_PID2 = dataSource.primary_controller_1_PID2.Output(dataSource.setpoint_PID2, dataSource.yTemperatureSensor_PID2, 0.1f);
            dataSource.uk_2_PID2 = Clamp(dataSource.secondary_controller_1_PID2.Output(dataSource.uk_1_PID2, dataSource.yFlowRateSensor_PID2, 0.1f), 0.0f, 30.0f);
            dataSource.yValve_PID2 = dataSource.valve_1_PID2.Update(dataSource.uk_2_PID2);
            dataSource.yFlowRateSensor_PID2 = dataSource.flowSensor_1_PID2.Update(dataSource.yValve_PID2);
            dataSource.yHeatExchanger_PID2 = dataSource.heatExchanger_PID2.Update(dataSource.yValve_PID2);
            dataSource.yTemperatureSensor_PID2 = dataSource.temperatureSensor_PID2.Update(dataSource.yHeatExchanger_PID2);
        }
        private void Chiller_Load(object sender, EventArgs e)
        {
            FirstScan = true;
            cmbSel.SelectedIndex = 1;
        }



        private void ChillerTimer_Tick(object sender, EventArgs e)
        {


            lblSpeedMotor3.Text = Dashboard.motors[2].dataSource.Speed.ToString("F2") + " rpm";
            lblSpeedMotor4.Text = Dashboard.motors[3].dataSource.Speed.ToString("F2") + " rpm";
            lblSpeedMotor5.Text = Dashboard.motors[4].dataSource.Speed.ToString("F2") + " rpm";
            lblSpeedMotor6.Text = Dashboard.motors[5].dataSource.Speed.ToString("F2") + " rpm";
            lblSpeedMotor7.Text = Dashboard.motors[6].dataSource.Speed.ToString("F2") + " rpm";
            lblPositionValve3.Text = Dashboard.valves[2].dataSource.valvePosition.ToString("F1") + " %";
            lblPositionValve4.Text = Dashboard.valves[3].dataSource.valvePosition.ToString("F1") + " %";
            lblPositionValve6.Text = Dashboard.valves[5].dataSource.valvePosition.ToString("F1") + " %";
            lblPositionValve7.Text = Dashboard.valves[6].dataSource.valvePosition.ToString("F1") + " %";
            lblPositionValve8.Text = Dashboard.valves[7].dataSource.valvePosition.ToString("F1") + " %";



            if (Dashboard.valves[4].dataSource.Mode)
            {
                lblPositionValve5.Text = Dashboard.valves[4].dataSource.valvePosition.ToString("F1") + " %";
            }
            else
            {
                Dashboard.valves[4].dataSource.valvePosition = dataSource.uk_2_PID1 * 100f / 30;
                //lblPositionValve5.Text = (dataSource.uk_2_PID1 * 100.0f / 30).ToString("F1") + " %";
                lblPositionValve5.Text = Dashboard.valves[4].dataSource.valvePosition.ToString("F1") + " %";
            }

            if (Dashboard.valves[8].dataSource.Mode)
            {
                lblPositionValve9.Text = Dashboard.valves[8].dataSource.valvePosition.ToString("F1") + " %";
            }
            else
            {
                Dashboard.valves[8].dataSource.valvePosition = dataSource.uk_2_PID2 * 100f / 30;
                //lblPositionValve9.Text = (dataSource.uk_2_PID2 * 100.0f / 30).ToString("F1") + " %";
                lblPositionValve9.Text = Dashboard.valves[8].dataSource.valvePosition.ToString("F1") + " %";
            }




            if (Dashboard.motors[3].dataSource.RunFeedBack)
            {
                CTWP_M4.BackgroundImage = motorOn;
            }
            else
            {
                CTWP_M4.BackgroundImage = motorOff;
            }

            if (Dashboard.motors[4].dataSource.RunFeedBack)
            {
                CTWP_M5.BackgroundImage = motorOn;
            }
            else
            {
                CTWP_M5.BackgroundImage = motorOff;
            }

            if (Dashboard.motors[5].dataSource.RunFeedBack)
            {
                Compressor_M6.BackgroundImage = CentrifugalOn;
            }
            else
            {
                Compressor_M6.BackgroundImage = CentrifugalOff;
            }

            if (Dashboard.motors[6].dataSource.RunFeedBack)
            {
                CWP_M7.BackgroundImage = motorOn;
            }
            else
            {
                CWP_M7.BackgroundImage = motorOff;
            }



            panelS1.BackColor = dataSource.S1 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS2.BackColor = dataSource.S2 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS3.BackColor = dataSource.S3 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS4.BackColor = dataSource.S4 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS5.BackColor = dataSource.S5 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;


            Temp_AHU = float.Parse(txtTemp_AHU.Text);

           
            lblCTWP_Temp.Text = dataSource.yHeatExchanger_PID1.ToString("F2") + " °C";
            lblCHW_Temp.Text = dataSource.yHeatExchanger_PID2.ToString("F2") + " °C";





            // State Diagram

            T00 = FirstScan;
            T10 = dataSource.S1 && dataSource.Stop;
            T20 = dataSource.S2 && dataSource.Stop;
            T30 = dataSource.S3 && dataSource.Stop;
            T40 = dataSource.S4 && dataSource.Stop;
            T50 = dataSource.S5 && dataSource.Stop;

            T01 = S0 && dataSource.Start;
            T12 = dataSource.S1 && PID1_Alarm;
            T23 = dataSource.S2 && AHU_Alarm && Bypass_Alarm_1;
            T34 = dataSource.S3 && PID2_Alarm;
            T45 = dataSource.S4 && !AHU_Alarm && Bypass_Alarm_2;
            T51 = dataSource.S5 && End;

            S0 = (S0 || T00 || T10 || T20 || T30 || T40 || T50) && !T01;
            dataSource.S1 = (dataSource.S1 || T01 || T51) && !T12 && !T10;
            dataSource.S2 = (dataSource.S2 || T12) && !T20 && !T23;
            dataSource.S3 = (dataSource.S3 || T23) && !T30 && !T34;
            dataSource.S4 = (dataSource.S4 || T34) && !T40 && !T45;
            dataSource.S5 = (dataSource.S5 || T45) && !T50 && !T51;

            if (dataSource.Stop)
            {
                PID1_Alarm = false;
                PID2_Alarm = false;
                AHU_Alarm = false;
                Bypass_Alarm_1 = false;
                Bypass_Alarm_2 = false;
                End = false;
            }
            Dashboard.motors[2].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.motors[3].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.motors[4].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.valves[2].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.valves[3].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.valves[4].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4 || dataSource.S5;

            if (dataSource.S1) PID1_Timer.Start();
            Dashboard.valves[5].dataSource.OpenFeedBack = dataSource.S2 || dataSource.S3 || dataSource.S4;

            Dashboard.motors[5].dataSource.RunFeedBack = dataSource.S3 || dataSource.S4;
            Dashboard.valves[6].dataSource.OpenFeedBack = dataSource.S3 || dataSource.S4;
            Dashboard.motors[6].dataSource.RunFeedBack = dataSource.S3 || dataSource.S4;
            Dashboard.valves[8].dataSource.OpenFeedBack = dataSource.S3 || dataSource.S4 || dataSource.S5;

            if (dataSource.S3) PID2_Timer.Start();
            Dashboard.valves[7].dataSource.OpenFeedBack = dataSource.S4;

            if (dataSource.S5)
            {

                PID1_Alarm = false;
                PID2_Alarm = false;
                dataSource.setpoint_PID1 = 0;
                dataSource.setpoint_PID2 = 0;
                PID1_Timer.Start();
                PID2_Timer.Start();

                if (dataSource.yHeatExchanger_PID2 < 1 && dataSource.yHeatExchanger_PID1 < 1)
                {
                    PID1_Timer.Stop();
                    PID2_Timer.Stop();
                    End = true;
                }
            }
            else
            {
                End = false;
            }



        }


        private void Alarm_Timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (Temp_AHU > 13)
            {
                AHU_Alarm = true;
            }
            else
            {
                AHU_Alarm = false;
            }

            if (count == 30)
            {
                PID1_Alarm = dataSource.yHeatExchanger_PID1 > 26;
            }
            if (count == 60)
            {
                PID2_Alarm = dataSource.yHeatExchanger_PID2 > 6;
                count = 0;
            }
            if (Dashboard.valves[5].dataSource.valvePosition > 99)
            {
                Bypass_Alarm_1 = true;
            }
            else
            {
                Bypass_Alarm_1 = false;
            }

            if (Dashboard.valves[7].dataSource.valvePosition > 99)
            {
                Bypass_Alarm_2 = true;
            }
            else
            {
                Bypass_Alarm_2 = false;
            }
        }
        private void propeller_Timer_Tick(object sender, EventArgs e)
        {
            if (Dashboard.motors[3].dataSource.RunFeedBack)
            {
                panelFan.BackgroundImage = propellerFrames[count_propeller];
                count_propeller = (count_propeller + 1) % propellerFrames.Length;
            }
            else
            {
                panelFan.BackgroundImage = null;
                count_propeller = 0;
            }
        }

        


        // Functions
        float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }


        
    }
}
