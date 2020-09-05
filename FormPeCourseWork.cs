using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace peCourseWork
{
    public partial class FormPeCourseWork : Form
    {
        #region constants
        const string FILE_IO_PATH = "peFormPeCourseWorkData.bin";

        const string ERR_WRONG_TEXTBOX = "Input data is not number";
        const string ERR_CANT_ADD_IN_THIS_NODE = "Can't add in this node";
        const string ERR_CANT_DEL_THIS_NODE = "Can't delete this node";
        const string ERR_CANT_COPY_THIS_NODE = "Can't copy this node";

        const string BUTTON_TEXT_ADD = "Add";
        const string BUTTON_TEXT_DEL = "Delete";
        const string BUTTON_TEXT_CHANGE = "Change";
        const string BUTTON_TEXT_ADD_2ND = "Copy";

        const string NUMBERS = "numbers";
        const string COMPLEX = "complex";
        const string ARITHMETIC = "arithmetic";
        const string TRIGINOMETRIC = "trigonometric";
        const string DEVISION = "devision";

        const string REALLY_LOAD_TREE_NODE = "Are you really want load tree? " +
            "Current tree will be removed.";

        #endregion
        #region inits
        // Create the ToolTip and associate with the Form container
        internal ToolTip toolTip = new ToolTip();
        TreeNode treeNode = new TreeNode(NUMBERS);
        public FormPeCourseWork()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//blocked size of form
            this.MaximizeBox = false;//blocked form expansion
            DrawTreeNodeFrame();
            buttonDelete.AllowDrop = true;
            buttonAdd.AllowDrop = true;
            this.KeyPreview = true;

            initializationTip();

            f1();
        }

        protected void DrawTreeNodeFrame()
        {
            treeNode.Nodes.Add(COMPLEX);
            treeNode.Nodes[0].Nodes.Add(ARITHMETIC);
            //treeNode.Nodes[0].Nodes[0].Nodes.Add("child_arithmetic");//do not del this, it is insruction

            treeNode.Nodes[0].Nodes.Add(TRIGINOMETRIC);
            //treeNode.Nodes[0].Nodes[1].Nodes.Add("child_trigonometric");

            treeNode.Nodes.Add(DEVISION);
            //treeNode.Nodes[1].Nodes.Add("child_devision");

            treeView1.Nodes.Add(treeNode);
            treeView1.ExpandAll();
        }
        private void initializationTip()
        {

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 2000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 400;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.Active = Properties.Settings.Default.ShowPrompts;//??????????????

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(this.buttonAdd, "Adds an item to the end of the selected branch");
            toolTip.SetToolTip(this.buttonDelete, "Deletes the item at the end of the selected branch");
            toolTip.SetToolTip(this.buttonChange, "Changes the item to the end of the selected branch");
            toolTip.SetToolTip(this.textBoxField2, "Field2 for displaying data of the corresponding class");
            toolTip.SetToolTip(this.textBoxField1, "Field1 for displaying data of the corresponding class");
            toolTip.SetToolTip(this.textBoxDebug, "Debug field");
            toolTip.SetToolTip(this.treeView1, "Displays class hierarchy");
            //toolTip1.SetToolTip(this.menuStrip1.fileToolStripMenuItem, "Fail");

        }
        #endregion
        #region treeView
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)//if u select node
        {
            object o = e.Node.Tag;
            switch (o)
            {
                case CoTrigonometric ct:
                    {
                        textBoxField1.Text = ct.abs.ToString();//!!!!!!!!!!
                        textBoxField2.Text = ct.fi.ToString();
                    }
                    break;

                case CoArith ct:
                    {
                        textBoxField1.Text = ct.re.ToString();//!!!!!!!!!!
                        textBoxField2.Text = ct.im.ToString();
                    }
                    break;

                case Fraction ct:
                    {
                        textBoxField1.Text = ct.num.ToString();//!!!!!!!!!!
                        textBoxField2.Text = ct.den.ToString();
                    }
                    break;
            }

            if (e.Node.Tag != null)//debug
            {
                textBoxDebug.Text = e.Node.Tag.ToString();
            }
            else textBoxDebug.Text = "null";
        }

        private bool canWeAddInThisNode(string nodeText)//add
        {
            switch (nodeText)
            {
                case NUMBERS:
                case COMPLEX: return false;
                default: return true;
            }
        }
        private bool canWeDamageThisNode(string nodeText)//delete
        {
            switch (nodeText)
            {
                case NUMBERS:
                case COMPLEX:
                case ARITHMETIC:
                case TRIGINOMETRIC:
                case DEVISION: return false;
                default: return true;
            }
        }
        #endregion
        //-----------------------------------------------------------------------------process
        #region process
        private double[] getDataFromTextBoxes()
        {
            double[] resArray = new double[2];
            if (textBoxField1.Text.Length != 0 && textBoxField2.Text.Length != 0)
            {
                string field1 = Service.dotsToCommas(textBoxField1.Text);
                string field2 = Service.dotsToCommas(textBoxField2.Text);
                if (Service.stringIsNumber(field1) && Service.stringIsNumber(field2))
                {
                    resArray[0] = Convert.ToDouble(field1);
                    resArray[1] = Convert.ToDouble(field2);
                    return resArray;
                }
                else return null;
            }
            else return null;
        }
        private void addInTreeNodeMk2()
        {
            double[] resArray = getDataFromTextBoxes();
            string treeNodeNow = treeView1.SelectedNode.Text;
            if (canWeAddInThisNode(treeNodeNow))
            {
                if (resArray != null)
                {
                    switch (treeNodeNow)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    {
                        case ARITHMETIC:
                            {
                                CoArith ca = new CoArith(resArray[0], resArray[1]);
                                treeNode.Nodes[0].Nodes[0].Nodes.Add(ca.ToString());
                                treeNode.Nodes[0].Nodes[0].LastNode.Tag = ca;
                            }
                            break;
                        case TRIGINOMETRIC:
                            {
                                CoTrigonometric ct = new CoTrigonometric(resArray[0], resArray[1]);
                                treeNode.Nodes[0].Nodes[1].Nodes.Add(ct.ToString());//add only label, no link
                                treeNode.Nodes[0].Nodes[1].LastNode.Tag = ct;//add link
                            }
                            break;
                        case DEVISION:
                            {
                                Fraction fr = new Fraction((int)resArray[0], (int)resArray[1]);
                                treeNode.Nodes[1].Nodes.Add(fr.ToString());
                                treeNode.Nodes[1].LastNode.Tag = fr;
                            }
                            break;
                    }
                }
                else MessageBox.Show(ERR_WRONG_TEXTBOX);
            }
            else MessageBox.Show(ERR_CANT_ADD_IN_THIS_NODE);
            buttons1stFoo();
        } 
        private void delFrTreeNode()
        {
            if (canWeDamageThisNode(treeView1.SelectedNode.Text) ){
                treeView1.SelectedNode.Tag = null;
                treeView1.SelectedNode.Remove();
            }
            else MessageBox.Show(ERR_CANT_DEL_THIS_NODE);
            buttons1stFoo();
        }
        private void changeTreeNode()
        {
            double[] resArray = getDataFromTextBoxes();
            object o = treeView1.SelectedNode.Tag;
            switch (o)
            {
                case CoTrigonometric ct:
                    {
                        ct.abs = resArray[0];
                        ct.fi = resArray[1];
                    }
                    break;

                case CoArith ca:
                    {
                        ca.re = resArray[0];
                        ca.im = resArray[1];
                    }
                    break;

                case Fraction fr:
                    {
                        fr.num = (int)resArray[0];
                        fr.den = (int)resArray[1];
                    }
                    break;
            }
            treeView1.SelectedNode.Text = o.ToString();
            textBoxDebug.Text = o.ToString();//debug
        }
        #endregion
        //---------------------------------------------------------save/load !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        #region file IO
        private void saveDialogShow()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bin files (*.bin)|*.bin";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //{ return; }
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    FileIOSerializer.saveMk2(treeNode, myStream);
                    myStream.Close();
                }
            }
        }
        private void openDialogShow()
        {
            Stream myStream;
            //FileStream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "bin files (*.bin)|*.bin";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = "C:\\Users\\tenmv\\source\\repos\\pe7\\bin\\Debug";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) //{ return; }
            {
                //string filePath = openFileDialog1.FileName;
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    FileIOSerializer.loadMk2(ref treeNode, myStream);
                    treeView1.Nodes.Clear();//
                    treeView1.Nodes.Add(treeNode);//
                    treeView1.ExpandAll();//
                    myStream.Close();
                }
            }
        }
        private void saveNoDialog()
        {
            FileIOSerializer.saveMk2(treeNode, FILE_IO_PATH);
        }
        private void openNoDialog()
        {
            DialogResult result = MessageBox.Show(REALLY_LOAD_TREE_NODE, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                FileIOSerializer.loadMk2(ref treeNode, FILE_IO_PATH);
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(treeNode);
                treeView1.ExpandAll();
            }
        }
        #endregion
        //---------------------------------------------------------------------------------Buttons
        #region Buttons
        private void buttonAdd_Click(object sender, EventArgs e){ addInTreeNodeMk2(); }
        private void buttonDelete_Click(object sender, EventArgs e){ delFrTreeNode(); }
        private void buttonChange_Click(object sender, EventArgs e){ changeTreeNode(); }//!!!!!!
        #endregion
        //---------------------------------------------------------------------------------Menu
        #region Menu
        private void saveToolStripMenuItem_Click(object sender, EventArgs e){ saveNoDialog();}
        private void openToolStripMenuItem_Click(object sender, EventArgs e){ openNoDialog(); }
        //-----
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e){ saveDialogShow(); }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e){ openDialogShow(); }
        //-----
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings();
            fs.Owner = this;
            fs.ShowDialog();
        }
        //-----
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = 263;//fix
            this.textBoxDebug.Text = this.Height.ToString();//d

            //del b
        }
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1();
        }
        private void f1()
        {
            this.Height = 600;
            this.textBoxDebug.Text = this.Height.ToString();//d

            Chart chart = new Chart();
            chart.Location = new Point(16, 220);
            chart.Size = new Size(300, 300);
            
            //
            ChartArea chartArea = new ChartArea("ChartArea1");
            chart.ChartAreas.Add(chartArea);

            Series series = new Series("Series1");
            chart.Series.Add(series);
            
            series.ChartType = SeriesChartType.Line;//new
            //chartArea.AxisX.Title = "x";
            //chartArea.AxisY.Title = "y";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.Interval = 1;
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(-5, 5);
            chart.ChartAreas[0].AxisY.ScaleView.Zoom(-5, 5);
            //chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisY.IsMarginVisible = false;//default false?

            for (double i = 0; i < 100; i+= 0.1)
            {
                series.Points.AddXY(i, Math.Sin(i) + i);
            }
            //chart.Invalidate();
            //
            this.Controls.Add(chart);
        }
        #endregion
        //------------------------------------------------------------------------DragDrop
        #region DragDrop
        private void buttons1stFoo()
        {
            buttonAdd.Text = BUTTON_TEXT_ADD;
            buttonChange.Enabled = true;
        }
        private void buttons2ndFoo()
        {
            buttonAdd.Text = BUTTON_TEXT_ADD_2ND;
            buttonChange.Enabled = false;
        }
        //-----
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
            var ret = DoDragDrop(e.Item, DragDropEffects.Move);
            if (DragDropEffects.None == ret) { buttons1stFoo(); }
        }
        //-----
        private void buttonDelete_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
            buttons2ndFoo();
        }
        private void buttonDelete_DragDrop(object sender, DragEventArgs e){ delFrTreeNode(); }
        //-----
        private void buttonAdd_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
            buttons2ndFoo();
        }
        private void buttonAdd_DragDrop(object sender, DragEventArgs e)
        {
            if (treeView1.SelectedNode != null && canWeDamageThisNode(treeView1.SelectedNode.Text))
            {
                TreeNode clonedNode = (TreeNode)treeView1.SelectedNode.Clone();
                treeView1.SelectedNode.Parent.Nodes.Add(clonedNode);
            }
            else MessageBox.Show(ERR_CANT_COPY_THIS_NODE);
            buttons1stFoo();
        }
        #endregion
        //---------------------------------------------------------------------------------hot keys
        #region hot keys
        private void FormPeCourseWork_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {}

            else if (e.Alt && e.Control && e.KeyCode == Keys.S) { saveDialogShow(); }
            else if (e.Alt && e.Control && e.KeyCode == Keys.O) { openDialogShow(); }

            else if (e.Control && e.KeyCode == Keys.S) { saveNoDialog(); }
            else if (e.Control && e.KeyCode == Keys.O) { openNoDialog(); }

            else if (e.Control && e.KeyCode == Keys.Oemplus) { addInTreeNodeMk2(); }
            else if (e.Control && e.KeyCode == Keys.Delete) { delFrTreeNode(); }
            else if (e.Control && e.KeyCode == Keys.Tab) { changeTreeNode(); }
        }
        #endregion
        //-----------------------------------------------------------------------------end
    }
}
