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

namespace HVAC_BacnetTCPIP.Forms
{
    public partial class AHU : Form
    {
        Image Propeller_1 = Properties.Resources.Fan_Rotate_1;
        Image Propeller_2 = Properties.Resources.Fan_Rotate_2;
        public static AirHandlingUnitModel dataSource = new AirHandlingUnitModel();
        //Public Events to Dashboard Form
        public enum AHUAction
        {
            Start_MouseDown,
            Start_MouseUp,
            Stop_MouseDown,
            Stop_MouseUp,
        }
        //Mouse Events

        public delegate void AHUMouseEventHandler(object sender, MouseEventArgs e, AHUAction action);
        public event AHUMouseEventHandler AHUMouseEvent;


        int count;
        bool FirstScan ,T00, T01, T12, T20, T10, T21;
        bool Temp_Alarm;
        public AHU()
        {
            InitializeComponent();
        }

        private void panelMotor7_Click(object sender, EventArgs e)
        {
            Dashboard.motors[6].Text = "Chilled Water Pump M7";
            Dashboard.motors[6].Show();
        }

        private void panelControlValve9_Click(object sender, EventArgs e)
        {
            Dashboard.valves[8].Text = "Control Valve V9";
            Dashboard.valves[8].Show();
        }



        private void AHUTimer_Tick(object sender, EventArgs e)
        {
            lblChillerTempOut.Text = Chiller.dataSource.yHeatExchanger_PID2.ToString("F2") + " °C";
            lblBoilerSystemTempOut.Text = Boiler.dataSource.yHeatExchanger_PID2.ToString("F2") + " °C";

            lblDamper1Pos.Text = Dashboard.dampers[0].dataSource.DamperPosition.ToString("F2") + " %";
            lblDamper2Pos.Text = Dashboard.dampers[1].dataSource.DamperPosition.ToString("F2") + " %";
            lblDamper3Pos.Text = Dashboard.dampers[2].dataSource.DamperPosition.ToString("F2") + " %";
            lblDamper4Pos.Text = Dashboard.dampers[3].dataSource.DamperPosition.ToString("F2") + " %";
            lblDamper5Pos.Text = Dashboard.dampers[4].dataSource.DamperPosition.ToString("F2") + " %";

            lblMotor8Speed.Text = Dashboard.motors[7].dataSource.Speed.ToString("F2") + " rpm";
            lblMotor9Speed.Text = Dashboard.motors[8].dataSource.Speed.ToString("F2") + " rpm";

            T00 = FirstScan;
            T10 = dataSource.S1 && dataSource.Stop;
            T20 = dataSource.S2 && dataSource.Stop;
           
            T01 = dataSource.S0 && dataSource.Start;
            T12 = dataSource.S1 && Temp_Alarm;
            T21 = dataSource.S2 && !Temp_Alarm;
         

            dataSource.S0 = (dataSource.S0 || T00 || T10 || T20 ) && !T01;
            dataSource.S1 = (dataSource.S1 || T01 || T21 ) && !T12 && !T10;
            dataSource.S2 = (dataSource.S2 || T12) && !T20 && !T21;
           


            Dashboard.motors[8].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2;
            Dashboard.motors[7].dataSource.RunFeedBack = dataSource.S1 || dataSource.S2;
            Dashboard.dampers[4].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2;
            Dashboard.dampers[3].dataSource.OpenFeedBack = dataSource.S1 || dataSource.S2;
            Dashboard.dampers[2].dataSource.OpenFeedBack = dataSource.S1;

            Dashboard.dampers[1].dataSource.OpenFeedBack = dataSource.S2;
            Dashboard.dampers[0].dataSource.OpenFeedBack = dataSource.S2;

            panelS1.BackColor = dataSource.S1 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;
            panelS2.BackColor = dataSource.S2 ? Color.FromArgb(0, 200, 0) : Color.DarkGray;

            if (Dashboard.motors[7].dataSource.RunFeedBack)
            {
                SupplyFan_Simulate.Start();
            }
            else
            {
                SupplyFan_Simulate.Stop();
            }
            if (Dashboard.motors[8].dataSource.RunFeedBack)
            {
                ReturnFan_Simulate.Start();
            }
            else
            {
                ReturnFan_Simulate.Stop();
            }
        }

        int cnt;
        private void SupplyFan_Simulate_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (cnt == 1)
            {
                panelMotor8.BackgroundImage = Propeller_1;
            }
            else if (cnt == 2)
            {
                panelMotor8.BackgroundImage = Propeller_2;
            }
            else
            {
                cnt = 0;
            }
        }
        private void ReturnFan_Simulate_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
            {
                panelMotor9.BackgroundImage = Propeller_1;
            }
            else if (count == 2)
            {
                panelMotor9.BackgroundImage = Propeller_2;
            }
            else
            {
                count = 0;
            }
        }
        private void panelMotor9_Click(object sender, EventArgs e)
        {
            Dashboard.motors[8].Text = " Return Fan M9 ";
            Dashboard.motors[8].Show();
        }

        private void panelMotor8_Click(object sender, EventArgs e)
        {
            Dashboard.motors[7].Text = " Supply Fan M8 ";
            Dashboard.motors[7].Show();
        }
        private void panelDamper5_Click(object sender, EventArgs e)
        {
            Dashboard.dampers[4].Text = "Supply Air Damper D5";
            Dashboard.dampers[4].Show();
        }

        private void AHU_Load(object sender, EventArgs e)
        {
            FirstScan = true;
            cmbSel.SelectedIndex = 1;
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Start = true;
            AHUMouseEvent?.Invoke(this, e, AHUAction.Start_MouseDown);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Start = false;
            AHUMouseEvent?.Invoke(this, e, AHUAction.Start_MouseUp);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Stop = true;
            AHUMouseEvent?.Invoke(this, e, AHUAction.Stop_MouseDown);
        }
        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Stop = false;
            AHUMouseEvent?.Invoke(this, e, AHUAction.Stop_MouseUp);
        }


        bool Toggle;
        private void Random_Timer_Tick(object sender, EventArgs e)
        {
            if (cmbSel.SelectedItem.ToString() == "Random")
            {
                txtTempRoom.ReadOnly = true;
                txtTempRoom.Text = Toggle ? "24" : "26";
                Toggle = !Toggle;
            }
            else
            {
                txtTempRoom.ReadOnly = false;
            }
        }

  
        private void Alarm_Timer_Tick(object sender, EventArgs e)
        {
            if(float.Parse(txtTempRoom.Text) > 25)
            {
                Temp_Alarm = true;
            } else
            {
                Temp_Alarm = false;
            }
        }

        private void panelDamper4_Click(object sender, EventArgs e)
        {
            Dashboard.dampers[3].Text = "Return Air Damper D4";
            Dashboard.dampers[3].Show();
        }

        private void panelDamper3_Click(object sender, EventArgs e)
        {
            Dashboard.dampers[2].Text = "Mixing Air Damper D3";
            Dashboard.dampers[2].Show();
        }

        private void panelDamper2_Click(object sender, EventArgs e)
        {
            Dashboard.dampers[1].Text = "Fresh Air Damper D2";
            Dashboard.dampers[1].Show();
        }

        private void panelDamper1_Click(object sender, EventArgs e)
        {
            Dashboard.dampers[0].Text = "Exhauted Air Damper D1";
            Dashboard.dampers[0].Show();
        }
    }
}
