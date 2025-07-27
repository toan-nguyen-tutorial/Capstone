using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using HVAC_BacnetTCPIP.Models;
using static HVAC_BacnetTCPIP.Faceplates.Valve;

namespace HVAC_BacnetTCPIP.Forms
{
    public partial class Boiler : Form
    {
        // Fields
        public static BoilerModel dataSource { get; set; } = new BoilerModel();

        Image MotorOff = Properties.Resources.MOTOR_OFF_1;
        Image MotorOn = Properties.Resources.Motor_ON_1;

        Image MotorOffRotate = Properties.Resources.MOTOR_OFF_1_LEFT;
        Image MotorOnRotate = Properties.Resources.Motor_ON_1_LEFT90;

        //Public Events to Dashboard Form
        public enum BoilerAction
        {
            Start_MouseDown,
            Start_MouseUp,
            Stop_MouseDown,
            Stop_MouseUp,
            Reset_MouseDown,
            Reset_MouseUp,
            Start_Click,
        }

        //Mouse Events
        public delegate void BoilerMouseEventHandler(object sender, MouseEventArgs e, BoilerAction action);
        public event BoilerMouseEventHandler BoilerMouseEvent;

        //Clicked Events
        public delegate void ValveClickEventHandler(object sender, BoilerAction action);
        public event ValveClickEventHandler BoilerClickEvent;
       
        public Boiler()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void Boiler_Load(object sender, EventArgs e)
        {
            FirstScan = true;
            cmbSel.SelectedIndex = 1; // Default Random 
        }

        //Functions

        float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }


        bool FirstScan, S0, T01, T12, T23, T34, T45, T00, T10, T20, T30, T40, T50, T51, PID1_Alarm, PID2_Alarm, AHU_Alarm, Bypass_Alarm_1, Bypass_Alarm_2, End;

        int count;
        float Temp_AHU;
        private void Alarm_Timer_Tick(object sender, EventArgs e)
        {
            count++;
            // Temp_AHU > 30 : enable
            // Temp_AHU < 30 : Disable
            if (Temp_AHU > 30)
            {
                AHU_Alarm = true;
            }
            else
            {
                AHU_Alarm = false;
            }

            if (count == 30)
            {
                PID1_Alarm = dataSource.yHeatExchanger_PID1 > 60;
            }
            if (count == 60)
            {
                PID2_Alarm = dataSource.yHeatExchanger_PID2 > 35;
                count = 0;
            }
            if (Dashboard.valves[12].dataSource.valvePosition > 99)
            {
                Bypass_Alarm_1 = true;
            }
            else
            {
                Bypass_Alarm_1 = false;
            }

            if (Dashboard.valves[11].dataSource.valvePosition > 99)
            {
                Bypass_Alarm_2 = true;
            }
            else
            {
                Bypass_Alarm_2 = false;
            }
        }

        private bool Toggle;
        private void Random_Timer_Tick(object sender, EventArgs e)
        {
            if(cmbSel.SelectedItem.ToString() == "Random")
            {
                txtTempAHUFeedback.ReadOnly = true;
                txtTempAHUFeedback.Text = Toggle ? "29" : "31";
                Toggle = !Toggle;
            } 
            else
            {
                txtTempAHUFeedback.ReadOnly = false;
            }
        }

        // Method Events
        private void BoilerTimer_Tick(object sender, EventArgs e)
        {
            dataSource.CMD = (dataSource.CMD || dataSource.Start) && !dataSource.Stop && !dataSource.Reset;

            if (dataSource.CMD)
            {

                lblStatus.ForeColor = Color.FromArgb(0, 200, 0);
                lblStatus.Text = "Running";
                panelStatus.BackColor = Color.FromArgb(0, 200, 0);

            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Stopped";
                panelStatus.BackColor = Color.FromArgb(224, 224, 224);
            }

            lblValvePosition1.Text = Dashboard.valves[0].dataSource.valvePosition.ToString("F2") + " %";
            lblValvePosition2.Text = Dashboard.valves[1].dataSource.valvePosition.ToString("F2") + " %";
            lblValvePosition12.Text = Dashboard.valves[11].dataSource.valvePosition.ToString("F2") + " %";
            lblValvePosition13.Text = Dashboard.valves[12].dataSource.valvePosition.ToString("F2") + " %";
;
            lblMotor1Speed.Text = Dashboard.motors[0].dataSource.Speed.ToString("F2") + " rpm";
            lblMotor2Speed.Text = Dashboard.motors[1].dataSource.Speed.ToString("F2") + " rpm";
            lblMotor10Speed.Text = Dashboard.motors[9].dataSource.Speed.ToString("F2") + " rpm";

            if (Dashboard.motors[0].dataSource.RunFeedBack)
            {
                panelMotor1.BackgroundImage = MotorOn;
            }
            else
            {
                panelMotor1.BackgroundImage = MotorOff;
            }
            
            if (Dashboard.motors[1].dataSource.RunFeedBack)
            {
                panelMotor2.BackgroundImage = MotorOn;
            }
            else
            {
                panelMotor2.BackgroundImage = MotorOff;
            }

            if (Dashboard.motors[9].dataSource.RunFeedBack)
            {
                panelMotor10.BackgroundImage = MotorOnRotate;
            }
            else
            {
                panelMotor10.BackgroundImage = MotorOffRotate;
            }

            if (Dashboard.valves[9].dataSource.Mode)
            {
                lblValvePosition10.Text = Dashboard.valves[9].dataSource.valvePosition.ToString("F2") + " %";
            }
            else
            {
                Dashboard.valves[9].dataSource.valvePosition = dataSource.uk_2_PID1 * 100f / 30;
                lblValvePosition10.Text = Dashboard.valves[9].dataSource.valvePosition.ToString("F1") + " %";
            }

            if (Dashboard.valves[10].dataSource.Mode)
            {
                lblValvePosition11.Text = Dashboard.valves[10].dataSource.valvePosition.ToString("F1") + " %";
            }
            else
            {
                
                 lblValvePosition11.Text = (dataSource.uk_2_PID2 * 100.0f / 30).ToString("F1") + " %";
                 lblValvePosition10.Text = Dashboard.valves[9].dataSource.valvePosition.ToString("F1") + " %";
            }




            panelS1.BackColor = dataSource.S1 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS2.BackColor = dataSource.S2 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS3.BackColor = dataSource.S3 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS4.BackColor = dataSource.S4 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS5.BackColor = dataSource.S5 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;




            Temp_AHU = float.Parse(txtTempAHUFeedback.Text);

           
            lblBoilerTempOut.Text = dataSource.yHeatExchanger_PID1.ToString("F2") + " °C";
            lblHeatExTempOut.Text = dataSource.yHeatExchanger_PID2.ToString("F2") + " °C";

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

            Dashboard.valves[0].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.valves[1].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.valves[9].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.motors[0].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            Dashboard.motors[1].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2 || dataSource.S3 || dataSource.S4;
            if (dataSource.S1) PID1_Timer.Start();

            //Bypass
            Dashboard.valves[12].dataSource.OpenFeedBack = dataSource.S2;

            Dashboard.motors[9].dataSource.RunFeedBack = dataSource.S3 || dataSource.S4;
            Dashboard.valves[10].dataSource.OpenFeedBack = dataSource.S3 || dataSource.S4;
            if (dataSource.S3) PID2_Timer.Start();

            //Bypass
            Dashboard.valves[11].dataSource.OpenFeedBack = dataSource.S4;

            if (dataSource.S5)
            {

                PID1_Alarm = false;
                PID2_Alarm = false;
                dataSource.setpoint_PID1 = 0;
                dataSource.setpoint_PID2 = 0;
                Dashboard.valves[9].dataSource.OpenFeedBack = dataSource.S5;
                Dashboard.valves[10].dataSource.OpenFeedBack = dataSource.S5;
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
            if (dataSource.Stop)
            {
                PID1_Alarm = false;
                PID2_Alarm = false;
                AHU_Alarm = false;
                Bypass_Alarm_1 = false;
                Bypass_Alarm_2 = false;
                End = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dataSource.setpoint_PID1 = float.Parse(txtTempBoilerSP.Text) * 5f / 100;
            dataSource.setpoint_PID2 = float.Parse(txtTempHeatExSP.Text) * 5f / 100;
            BoilerClickEvent?.Invoke(this, BoilerAction.Start_Click);
        }
        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Start = true;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Start_MouseDown);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Start = false;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Start_MouseUp);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Stop = true;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Stop_MouseDown);
        }
        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Stop = false;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Stop_MouseUp);
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Reset = true;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Reset_MouseDown);
        }
        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Reset = false;
            BoilerMouseEvent?.Invoke(this, e, BoilerAction.Reset_MouseUp);
        }

        private void panelMotor1_Click(object sender, EventArgs e)
        {
            Dashboard.motors[0].Text = "Boiler Water Pump M1";
            Dashboard.motors[0].Show();
        }

        private void panelMotor2_Click(object sender, EventArgs e)
        {
            Dashboard.motors[1].Text = "Boiler Water Pump M2";
            Dashboard.motors[1].Show();
        }
        private void panelMotor10_Click(object sender, EventArgs e)
        {
            Dashboard.motors[9].Text = "Glycol Water Pump M10";
            Dashboard.motors[9].Show();
        }
        
        private void panelValve1_Click(object sender, EventArgs e)
        {
            Dashboard.valves[0].Text = "Ball Valve V1";
            Dashboard.valves[0].Show();
        }

        private void panelValve2_Click(object sender, EventArgs e)
        {
            Dashboard.valves[1].Text = "Ball Valve V2";
            Dashboard.valves[1].Show();
        }

        private void panelValve10_Click(object sender, EventArgs e)
        {
            Dashboard.valves[9].Text = "Control Valve V10";
            Dashboard.valves[9].Show();
        }

        private void panelValve11_Click(object sender, EventArgs e)
        {
            Dashboard.valves[10].Text = "Control Valve V11";
            Dashboard.valves[10].Show();
        }

        private void panelValve12_Click(object sender, EventArgs e)
        {
            Dashboard.valves[11].Text = "ByPass Valve V12";
            Dashboard.valves[11].Show();
        }

        private void panelValve13_Click(object sender, EventArgs e)
        {
            Dashboard.valves[12].Text = "ByPass Valve V13";
            Dashboard.valves[12].Show();
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
    }
}