using System;
using System.Windows.Forms;

namespace peCourseWork
{  
    public partial class FormSettings : Form
    {
        #region init
        ToolTip toolTip1 = new ToolTip();
        public FormSettings()
        {
            InitializeComponent();
            initializationTip();
            checkBoxPrompt.Checked = Properties.Settings.Default.ShowPrompts;
            trackBarPrecision.Value = Properties.Settings.Default.EPSGUI;
            if (Properties.Settings.Default.ShowPrompts) { checkBoxPrompt.Text = "now on"; }//!!!!!
            else checkBoxPrompt.Text = "now off";
        }

        private void initializationTip()
        {
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 2000;
            toolTip1.InitialDelay = 400;
            toolTip1.ReshowDelay = 400;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.Active = Properties.Settings.Default.ShowPrompts;//??????????????

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.checkBoxPrompt, "designed to turn prompt on or off");
            toolTip1.SetToolTip(this.trackBarPrecision, "designed to round when displayed to user");
            toolTip1.SetToolTip(this.textBox1, "debug");
        }
        #endregion
        //-------------------------------------------------------------------------------
        #region GUI
        private void checkBoxPrompt_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPrompts = checkBoxPrompt.Checked;

            if (Properties.Settings.Default.ShowPrompts) { checkBoxPrompt.Text = "now on"; }
            else checkBoxPrompt.Text = "now off";

            textBox1.Text = Properties.Settings.Default.ShowPrompts.ToString();//debug
        }

        private void trackBarPrecision_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.EPSGUI = (byte)trackBarPrecision.Value;

            textBox1.Text = Properties.Settings.Default.EPSGUI.ToString();//debug
        }

        private void buttonFormSetOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            toolTip1.Active = Properties.Settings.Default.ShowPrompts;
            (this.Owner as FormPeCourseWork).toolTip.Active = Properties.Settings.Default.ShowPrompts;

            this.Dispose();
            //this.Close();
        }

        private void buttonFormSetCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //this.Close();
        }
        #endregion
        //--------------------------------------------------------------------------end
    }
}
