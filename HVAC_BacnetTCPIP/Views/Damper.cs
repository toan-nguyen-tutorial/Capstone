using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using HVAC_BacnetTCPIP.Faceplates;
using HVAC_BacnetTCPIP.Models;
using static HVAC_BacnetTCPIP.Faceplates.Valve;

namespace HVAC_BacnetTCPIP.Views
{
    public partial class Damper : Form
    {
        public DamperModel dataSource = new DamperModel();
        Image DamperClose = Properties.Resources.Damper_Close_removebg;
        Image DamperOpen = Properties.Resources.Damper_Open_removebg;

        public enum DamperAction
        {
            Open_MouseDown,
            Open_MouseUp,
            Close_MouseDown,
            Close_MouseUp,
            Reset_MouseDown,
            Reset_MouseUp,
            Open_Click,
        }


        public delegate void DamperMouseEventHandler(object sender, MouseEventArgs e, DamperAction action);
        public event DamperMouseEventHandler DamperMouseEvent;

        public delegate void DamperClickEventHandler(object sender, DamperAction action);
        public event DamperClickEventHandler DamperClickEvent;

        public Damper()
        {
            InitializeComponent();
        }

        private void Sampling_100ms_Tick(object sender, EventArgs e)
        {
            if (radioMan.Checked) dataSource.Mode = true;
            if (radioAuto.Checked) dataSource.Mode = false;

            if (dataSource.Mode)
            {
                dataSource.CMD = (dataSource.CMD || dataSource.Open) && !dataSource.Close;
                dataSource.OpenFeedBack = dataSource.CMD;
                if (!dataSource.OpenFeedBack)
                {
                    dataSource.SetPosition = 0;
                    picDamper.BackgroundImage = DamperClose;
                    picDamper.BackColor = Color.Transparent;
                    picDamper.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.uk = dataSource.pid.Output(dataSource.SetPosition, dataSource.DamperPosition, 0.001f);
                    dataSource.DamperPosition = dataSource.plant.Update(dataSource.uk);

                    
                  
                }
                else
                {
                    picDamper.BackgroundImage = DamperOpen;
                    picDamper.BackColor = Color.Transparent;
                    picDamper.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.uk = dataSource.pid.Output(dataSource.SetPosition, dataSource.DamperPosition, 0.001f);
                    dataSource.DamperPosition = dataSource.plant.Update(dataSource.uk);
                 
                }

                if (dataSource.DamperPosition < 0) dataSource.DamperPosition = 0;
                if (dataSource.DamperPosition > 100) dataSource.DamperPosition = 100;

                txtDamperPosition.Texts = Clamp(dataSource.DamperPosition, 0, 100).ToString("F1") + " %";
            }
            else
            {
                if (!dataSource.OpenFeedBack)
                {
                    picDamper.BackgroundImage = DamperClose;
                    picDamper.BackColor = Color.Transparent;
                    picDamper.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.SetPosition = 0;
                    dataSource.uk = dataSource.pid.Output(dataSource.SetPosition, dataSource.DamperPosition, 0.001f);
                    dataSource.DamperPosition = dataSource.plant.Update(dataSource.uk);

                }
                else
                {
                    picDamper.BackgroundImage = DamperOpen;
                    picDamper.BackColor = Color.Transparent;
                    picDamper.BackgroundImageLayout = ImageLayout.Stretch;
                    dataSource.uk = dataSource.pid.Output(dataSource.SetPosition, dataSource.DamperPosition, 0.001f);
                    dataSource.DamperPosition = dataSource.plant.Update(dataSource.uk);
                    
                }
                if (dataSource.DamperPosition < 0) dataSource.DamperPosition = 0;
                if (dataSource.DamperPosition > 100) dataSource.DamperPosition = 100;
                txtDamperPosition.Texts = Clamp(dataSource.DamperPosition, 0, 100).ToString("F1") + " %";

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataSource.SetPosition = float.Parse(txtDamperSP.Texts);
            DamperClickEvent?.Invoke(this, DamperAction.Open_Click);
        }

        float Clamp(float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        private void btnOpen_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Open = true;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Open_MouseDown);
        }
        private void btnOpen_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Open = false;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Open_MouseUp);
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Close = true;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Close_MouseDown);
        }
        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Close = false;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Close_MouseUp);
        }
        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            dataSource.Reset = true;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Reset_MouseDown);
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            dataSource.Reset = false;
            DamperMouseEvent?.Invoke(this, e, DamperAction.Reset_MouseUp);
        }
        private void Damper_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

      
    }
}
