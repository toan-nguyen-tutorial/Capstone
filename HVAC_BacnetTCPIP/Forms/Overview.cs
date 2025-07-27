using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;




namespace HVAC_BacnetTCPIP.Forms
{
    public partial class Overview : Form
    {
        private PdfViewer pdfViewer;
        public Overview()
        {
            InitializeComponent();
        }

        private void Overview_Load(object sender, EventArgs e)
        {

            string tempPath = Path.Combine(Path.GetTempPath(), "Full.pdf");
            File.WriteAllBytes(tempPath, Properties.Resources.Full);

            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            this.Controls.Add(pdfViewer);
            pdfViewer.Document = PdfiumViewer.PdfDocument.Load(tempPath);
        }
    }

}
