namespace peCourseWork
{
    partial class FormPeCourseWork
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBoxField1 = new System.Windows.Forms.TextBox();
            this.textBoxField2 = new System.Windows.Forms.TextBox();
            this.labelField1 = new System.Windows.Forms.Label();
            this.labelField2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelTargetNow = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(17, 29);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(190, 181);
            this.treeView1.TabIndex = 0;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBoxField1
            // 
            this.textBoxField1.Location = new System.Drawing.Point(287, 32);
            this.textBoxField1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxField1.Name = "textBoxField1";
            this.textBoxField1.Size = new System.Drawing.Size(121, 20);
            this.textBoxField1.TabIndex = 1;
            // 
            // textBoxField2
            // 
            this.textBoxField2.Location = new System.Drawing.Point(287, 65);
            this.textBoxField2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxField2.Name = "textBoxField2";
            this.textBoxField2.Size = new System.Drawing.Size(121, 20);
            this.textBoxField2.TabIndex = 2;
            // 
            // labelField1
            // 
            this.labelField1.AutoSize = true;
            this.labelField1.Location = new System.Drawing.Point(217, 33);
            this.labelField1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelField1.Name = "labelField1";
            this.labelField1.Size = new System.Drawing.Size(35, 13);
            this.labelField1.TabIndex = 3;
            this.labelField1.Text = "Field1";
            // 
            // labelField2
            // 
            this.labelField2.AutoSize = true;
            this.labelField2.Location = new System.Drawing.Point(217, 68);
            this.labelField2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelField2.Name = "labelField2";
            this.labelField2.Size = new System.Drawing.Size(35, 13);
            this.labelField2.TabIndex = 4;
            this.labelField2.Text = "Field2";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(220, 106);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(53, 52);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            this.buttonAdd.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonAdd_DragDrop);
            this.buttonAdd.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonAdd_DragEnter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(287, 106);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(53, 52);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonDelete_DragDrop);
            this.buttonDelete.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonDelete_DragEnter);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(219, 192);
            this.textBoxDebug.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(189, 20);
            this.textBoxDebug.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveAsToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableTipsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // enableTipsToolStripMenuItem
            // 
            this.enableTipsToolStripMenuItem.Name = "enableTipsToolStripMenuItem";
            this.enableTipsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enableTipsToolStripMenuItem.Text = "On Tips";
            this.enableTipsToolStripMenuItem.Click += new System.EventHandler(this.enableTipsToolStripMenuItem_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(353, 106);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(53, 52);
            this.buttonChange.TabIndex = 9;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelTargetNow
            // 
            this.labelTargetNow.AutoSize = true;
            this.labelTargetNow.Location = new System.Drawing.Point(217, 177);
            this.labelTargetNow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTargetNow.Name = "labelTargetNow";
            this.labelTargetNow.Size = new System.Drawing.Size(61, 13);
            this.labelTargetNow.TabIndex = 10;
            this.labelTargetNow.Text = "Target now";
            // 
            // FormPeCourseWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 224);
            this.Controls.Add(this.labelTargetNow);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelField2);
            this.Controls.Add(this.labelField1);
            this.Controls.Add(this.textBoxField2);
            this.Controls.Add(this.textBoxField1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPeCourseWork";
            this.Text = "FormPeCourseWork";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPeCourseWork_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBoxField1;
        private System.Windows.Forms.TextBox textBoxField2;
        private System.Windows.Forms.Label labelField1;
        private System.Windows.Forms.Label labelField2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelTargetNow;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTipsToolStripMenuItem;
    }
}

