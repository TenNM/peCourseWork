namespace peCourseWork
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFormSetOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPrompt = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarPrecision = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFormSetOk
            // 
            this.buttonFormSetOk.Location = new System.Drawing.Point(74, 239);
            this.buttonFormSetOk.Name = "buttonFormSetOk";
            this.buttonFormSetOk.Size = new System.Drawing.Size(114, 41);
            this.buttonFormSetOk.TabIndex = 0;
            this.buttonFormSetOk.Text = "OK";
            this.buttonFormSetOk.UseVisualStyleBackColor = true;
            this.buttonFormSetOk.Click += new System.EventHandler(this.buttonForm2SetOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prompts";
            // 
            // checkBoxPrompt
            // 
            this.checkBoxPrompt.AutoSize = true;
            this.checkBoxPrompt.Location = new System.Drawing.Point(28, 52);
            this.checkBoxPrompt.Name = "checkBoxPrompt";
            this.checkBoxPrompt.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPrompt.TabIndex = 2;
            this.checkBoxPrompt.Text = "checkBoxPrompt";
            this.checkBoxPrompt.UseVisualStyleBackColor = true;
            this.checkBoxPrompt.CheckedChanged += new System.EventHandler(this.checkBoxPrompt_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Presentation precision";
            // 
            // trackBarPrecision
            // 
            this.trackBarPrecision.Location = new System.Drawing.Point(28, 123);
            this.trackBarPrecision.Name = "trackBarPrecision";
            this.trackBarPrecision.Size = new System.Drawing.Size(100, 45);
            this.trackBarPrecision.TabIndex = 5;
            this.trackBarPrecision.Scroll += new System.EventHandler(this.trackBarPrecision_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 123);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 20);
            this.textBox1.TabIndex = 6;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 292);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBarPrecision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxPrompt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFormSetOk);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFormSetOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPrompt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarPrecision;
        private System.Windows.Forms.TextBox textBox1;
    }
}