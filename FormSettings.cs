using System;
using System.Windows.Forms;

namespace peCourseWork
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            checkBoxPrompt.Checked = Properties.Settings.Default.ShowPrompts;
            trackBarPrecision.Value = Properties.Settings.Default.EPSGUI;
        }
        //-------------------------------------------------------------------------------
        private void checkBoxPrompt_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPrompts = checkBoxPrompt.Checked;
            //Properties.Settings.Default.Save();
            if (Properties.Settings.Default.ShowPrompts) { checkBoxPrompt.Text = "now on"; }
            else checkBoxPrompt.Text = "now off";

            textBox1.Text = Properties.Settings.Default.ShowPrompts.ToString();//debug
        }

        private void trackBarPrecision_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.EPSGUI = (byte)trackBarPrecision.Value;
            //Properties.Settings.Default.Save();
            textBox1.Text = Properties.Settings.Default.EPSGUI.ToString();//debug
        }

        private void buttonForm2SetOk_Click(object sender, EventArgs e)
        {
            //this.Close();
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void buttonFormSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------end
    }
}
