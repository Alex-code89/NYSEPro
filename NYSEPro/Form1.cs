using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NYSEPro
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            float fcpu = perfCounterCPU.NextValue();
            float fram = perfCounterRAM.NextValue();
            float fhdd = perfCounterHDD.NextValue();


            //set value to CPU, RAM,  Hdd
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            metroProgressBarHDD.Value = (int)fhdd;


            //Update Value to CPU, RAM,  Hdd Label.
            metroLabelCPU.Text = string.Format("{0:0.00}%", fcpu);
            metroLabelRAM.Text = string.Format("{0:0.00}%", fram);
            metroLabelHDD.Text = string.Format("{0:0.00}%", fhdd);


        }

        private void metroProgressBarCPU_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBarRAM_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBarHDD_Click(object sender, EventArgs e)
        {

        }
    }
}
