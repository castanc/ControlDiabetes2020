using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace DiabetesControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadCesarRegs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txFileName.Text))
            {
                Business.Business bo = new Business.Business();
                bo.LoadFromCesarRegs(txFileName.Text);
                txFileName.Text = "";
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"c:\glucosecontrol";
            if (ofd.ShowDialog() == DialogResult.OK)
                txFileName.Text = ofd.FileName;
        }

        private void btnLoadGlucoseData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txFileName.Text))
            {
                Business.Business bo = new Business.Business();
                bo.LoadFromGlucoseData(txFileName.Text);
                txFileName.Text = "";
            }
        }

        private void btnSplitData_Click(object sender, EventArgs e)
        {
            Business.Business bo = new Business.Business();
            bo.Split();
        }
    }
}
