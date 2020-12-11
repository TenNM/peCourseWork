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
            this.buttonFormSetCancel = new System.Windows.Forms.Button();
            this.labelPrecision = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFormSetOk
            // 
            this.buttonFormSetOk.Location = new System.Drawing.Point(230, 372);
            this.buttonFormSetOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFormSetOk.Name = "buttonFormSetOk";
            this.buttonFormSetOk.Size = new System.Drawing.Size(171, 63);
            this.buttonFormSetOk.TabIndex = 0;
            this.buttonFormSetOk.Text = "OK";
            this.buttonFormSetOk.UseVisualStyleBackColor = true;
            this.buttonFormSetOk.Click += new System.EventHandler(this.buttonFormSetOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prompts";
            // 
            // checkBoxPrompt
            // 
            this.checkBoxPrompt.AutoSize = true;
            this.checkBoxPrompt.Location = new System.Drawing.Point(42, 80);
            this.checkBoxPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxPrompt.Name = "checkBoxPrompt";
            this.checkBoxPrompt.Size = new System.Drawing.Size(155, 24);
            this.checkBoxPrompt.TabIndex = 2;
            this.checkBoxPrompt.Text = "checkBoxPrompt";
            this.checkBoxPrompt.UseVisualStyleBackColor = true;
            this.checkBoxPrompt.CheckedChanged += new System.EventHandler(this.checkBoxPrompt_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Presentation precision";
            // 
            // trackBarPrecision
            // 
            this.trackBarPrecision.Location = new System.Drawing.Point(42, 189);
            this.trackBarPrecision.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarPrecision.Name = "trackBarPrecision";
            this.trackBarPrecision.Size = new System.Drawing.Size(150, 69);
            this.trackBarPrecision.TabIndex = 5;
            this.trackBarPrecision.Scroll += new System.EventHandler(this.trackBarPrecision_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(336, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // buttonFormSetCancel
            // 
            this.buttonFormSetCancel.Location = new System.Drawing.Point(42, 372);
            this.buttonFormSetCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFormSetCancel.Name = "buttonFormSetCancel";
            this.buttonFormSetCancel.Size = new System.Drawing.Size(171, 63);
            this.buttonFormSetCancel.TabIndex = 7;
            this.buttonFormSetCancel.Text = "Cancel";
            this.buttonFormSetCancel.UseVisualStyleBackColor = true;
            this.buttonFormSetCancel.Click += new System.EventHandler(this.buttonFormSetCancel_Click);
            // 
            // labelPrecision
            // 
            this.labelPrecision.AutoSize = true;
            this.labelPrecision.Location = new System.Drawing.Point(202, 198);
            this.labelPrecision.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrecision.Name = "labelPrecision";
            this.labelPrecision.Size = new System.Drawing.Size(51, 20);
            this.labelPrecision.TabIndex = 8;
            this.labelPrecision.Text = "label3";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 449);
            this.Controls.Add(this.labelPrecision);
            this.Controls.Add(this.buttonFormSetCancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBarPrecision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxPrompt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFormSetOk);
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
        private System.Windows.Forms.Button buttonFormSetCancel;
        private System.Windows.Forms.Label labelPrecision;
    }
}