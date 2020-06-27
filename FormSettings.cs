using System;
using System.Windows.Forms;

namespace peCourseWork
{
    
    public partial class FormSettings : Form
    {
        ToolTip toolTip1 = new ToolTip();
        public FormSettings()
        {
            InitializeComponent();
            initializationTip();
            checkBoxPrompt.Checked = Properties.Settings.Default.ShowPrompts;
            trackBarPrecision.Value = Properties.Settings.Default.EPSGUI;
        }

        private void initializationTip()
        {

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 2000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 400;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.Active = Properties.Settings.Default.ShowPrompts;//??????????????

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.checkBoxPrompt, "designed to turn prompt on or off");
            toolTip1.SetToolTip(this.trackBarPrecision, "designed to round when displayed to user");
            toolTip1.SetToolTip(this.textBox1, "debug");

            //toolTip1.SetToolTip(this.menuStrip1.fileToolStripMenuItem, "Fail");

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
