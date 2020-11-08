using System;
using System.Drawing;
using System.IO;
using System.Reflection;
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
        const string ERR_NODE_NOT_IS_NULL_OR_IMMUTABLE = "Node not found or immutable";

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
        SpecialNumbers sn1;
        SpecialNumbers sn2;
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

            f1();//d
            openNoDialog();//d
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
            toolTip.SetToolTip(this.menuStrip1, "Toolbar, has a wide range of tools");

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
                        labelField1.Text = "abs";
                        labelField2.Text = "fi";
                    }
                    break;

                case CoArith ct:
                    {
                        textBoxField1.Text = ct.re.ToString();//!!!!!!!!!!
                        textBoxField2.Text = ct.im.ToString();
                        labelField1.Text = "re";
                        labelField2.Text = "im";
                    }
                    break;

                case Fraction ct:
                    {
                        textBoxField1.Text = ct.num.ToString();//!!!!!!!!!!
                        textBoxField2.Text = ct.den.ToString();
                        labelField1.Text = "num";
                        labelField2.Text = "den";
                    }
                    break;
            }

            switch (e.Node.Text)
            {
                case ARITHMETIC:
                    {
                        labelField1.Text = "re";
                        labelField2.Text = "im";
                    } break;
                case TRIGINOMETRIC:
                    {
                        labelField1.Text = "abs";
                        labelField2.Text = "fi";
                    }
                    break;
                case DEVISION:
                    {
                        labelField1.Text = "num";
                        labelField2.Text = "den";
                    }
                    break;

                case NUMBERS:
                case COMPLEX:
                    {
                        labelField1.Text = "?";
                        labelField2.Text = "?";
                    }
                    break;
            }//switch text

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

        void AskSave() // Ask Save on exit
        {
            DialogResult res = MessageBox.Show("save data?", "PeCourseWork", MessageBoxButtons.YesNoCancel);
            switch (res)
            {
                case DialogResult.Yes: { saveNoDialog(); Application.Exit(); } break;
                case DialogResult.No: Application.Exit(); break; 
            }
        }
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
        //---------------------------------------------------------save/load !!!!!!!!!!!!!! old file IO class ver
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e){ AskSave();}
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
            f1Close();
        }
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1();
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
        //---
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void TextBox_DragDrop(object sender, DragEventArgs e)//sender textbox !!!!!!!!!
        {
            TextBox senderTb = sender as TextBox;
            TreeNode grabedByMouseNode = null;
            Chart findeCr = FindControl("DrawChart") as Chart;

            string[] eFormats = e.Data.GetFormats();
            grabedByMouseNode = e.Data.GetData(eFormats[1]) as TreeNode;

            if (grabedByMouseNode != null && canWeDamageThisNode(grabedByMouseNode.Text))
            {
                if (senderTb.Name.Equals("textBoxX"))
                {                   
                    sn1 = grabedByMouseNode.Tag as SpecialNumbers;
                    senderTb.Text = grabedByMouseNode.Text;
                    DrawSpecialNumOnGraph(sn1, "Series1");
                    findeCr.Series[2].Points.Clear();
                }
                else if (senderTb.Name.Equals("textBoxY"))
                {
                    sn2 = grabedByMouseNode.Tag as SpecialNumbers;
                    senderTb.Text = grabedByMouseNode.Text;
                    DrawSpecialNumOnGraph(sn2, "Series2");
                    findeCr.Series[2].Points.Clear();
                }
            }//node
            else
            {
                textBoxDebug.Text = ERR_NODE_NOT_IS_NULL_OR_IMMUTABLE;
                return;
            }
                
            
        }//m
        #endregion
        //---------------------------------------------------------------------------------hot keys
        #region hot keys
        private void FormPeCourseWork_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)//???????????????????
            {
                //e.Modifiers == Keys.Escape
                if (e.Modifiers == Keys.Escape)
                    Application.Exit();
                else AskSave();
            }

            else if (e.Alt && e.Control && e.KeyCode == Keys.S) { saveDialogShow(); }
            else if (e.Alt && e.Control && e.KeyCode == Keys.O) { openDialogShow(); }

            else if (e.Control && e.KeyCode == Keys.S) { saveNoDialog(); }
            else if (e.Control && e.KeyCode == Keys.O) { openNoDialog(); }

            else if (e.Control && e.KeyCode == Keys.Oemplus) { addInTreeNodeMk2(); }
            else if (e.Control && e.KeyCode == Keys.Delete) { delFrTreeNode(); }
            else if (e.Control && e.KeyCode == Keys.Tab) { changeTreeNode(); }

            //else if(e.KeyCode == Keys.Right) { textBoxDebug.Text = "r"; }
        }
        #endregion
        //--------------------------------------------------------------------------foo
        #region Foo
        private object FindControl(string name)
        { 
            foreach(Control c in Controls)
            {
                if (c.Name.Equals(name)) return c;
            }
            return null;
        }
        //-------------------------------------------
        private CoArith SpecialNumToCoArith(SpecialNumbers sn)
        {
            switch (sn)
            {
                case CoArith ca: return sn as CoArith;
                case CoTrigonometric ct: return (sn as CoTrigonometric).convertToArith();
                case Fraction f: return new CoArith(f.fractionToDouble(), 0);
                default: return null;
            }
        }
        private void DrawSpecialNumOnGraph(SpecialNumbers sn, string seriesName)
        {
            Chart c = null;
            foreach (object o in Controls)
            {
                if(o is Chart)
                {
                    c = o as Chart;
                    break;
                }
            }
            if(c != null)
            {
                var seriesArr = c.Series;
                Series s = null;
                switch (seriesName)
                {
                    case "Series1":
                    case "Series2":
                    case "Series3": s = seriesArr.FindByName(seriesName); break;
                }
                if(s != null)
                {
                    s.Points.Clear();//!!!!!!!!!!!!!!!!1
                    s.Points.AddXY(0, 0);//!!!!!!!!!!!!!!!!!!!!
                    switch (sn)
                    {
                        case Fraction f: s.Points.AddXY(f.fractionToDouble(), 0); break;
                        case CoArith ca: s.Points.AddXY(ca.re, ca.im); break;
                        case CoTrigonometric ct:
                            {
                                CoArith coArithTemp = ct.convertToArith();
                                s.Points.AddXY(coArithTemp.re, coArithTemp.im);
                            } break;
                    }
                }
                //series1.Points.AddXY(0, 0);
            }
        }//m
        private void buttonDrawClick(object sender, EventArgs e)
        {
            textBoxDebug.Text = "bDrawClick";//b
            SpecialNumbers snRes = null;

            if (sn1 != null && sn2 != null)
            {
                ComboBox findedCb = FindControl("comboBoxF1Operations") as ComboBox;
                if(findedCb != null)
                {
                    switch (findedCb.SelectedItem)
                    {
                        case "+": snRes = SpecialNumToCoArith(sn1) + SpecialNumToCoArith(sn2); break;
                        case "-": snRes = SpecialNumToCoArith(sn1) - SpecialNumToCoArith(sn2); break;
                        case "x": snRes = SpecialNumToCoArith(sn1) * SpecialNumToCoArith(sn2); break;
                        case "/": snRes = SpecialNumToCoArith(sn1) / SpecialNumToCoArith(sn2); break;
                        default: return;
                    }                  
                    DrawSpecialNumOnGraph(snRes, "Series3");
                }              
            }
        }

        private void buttonDrawClear(object sender, EventArgs e)
        {
            Chart findeCr = FindControl("DrawChart") as Chart;
            TextBox findTextBoxX = FindControl("textBoxX") as TextBox;
            TextBox findTextBoxY = FindControl("textBoxY") as TextBox;

            if (findeCr != null && findTextBoxX.Text != null && findTextBoxY != null)
            {
                findeCr.Series[0].Points.Clear();
                findeCr.Series[1].Points.Clear();
                findeCr.Series[2].Points.Clear();
                findTextBoxX.Text = "";
                findTextBoxY.Text = "";
                sn1 = null;
                sn2 = null;
            }
        }
        private void DrawTextBoxComboBox()
        {
            //-------TextBox
            TextBox textBoxX = new TextBox();
            textBoxX.Location = new Point(16, 245);
            textBoxX.Size = new Size(100, 50);
            textBoxX.AllowDrop = true;
            textBoxX.DragEnter += TextBox_DragEnter;
            textBoxX.DragEnter += TextBox_DragDrop;
            textBoxX.Name = "textBoxX";
            textBoxX.ReadOnly = true;
            this.Controls.Add(textBoxX);

            TextBox textBoxY = new TextBox();
            textBoxY.Location = new Point(216, 245);
            textBoxY.Size = new Size(100, 50);
            textBoxY.AllowDrop = true;
            textBoxY.DragEnter += TextBox_DragEnter;
            textBoxY.DragEnter += TextBox_DragDrop;
            textBoxY.Name = "textBoxY";
            textBoxY.ReadOnly = true;
            this.Controls.Add(textBoxY);

            //-------ComboBox

            string[] operation = { "+", "-", "x", "/" }; 

            ComboBox comboBox = new ComboBox();
            comboBox.Location = new Point(146, 245);
            comboBox.Size = new Size(40, 50);
            comboBox.Items.AddRange(operation);
            comboBox.SelectedIndex = 0;
            comboBox.Font = new System.Drawing.Font("", 11);//"Times New Roman"
            comboBox.Name = "comboBoxF1Operations";
            this.Controls.Add(comboBox);

            //-------Button
            Button buttonDraw = new Button();
            buttonDraw.Location = new Point(346, 245);
            buttonDraw.Size = new Size(80, 20);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Text = "Draw";
            buttonDraw.Click += buttonDrawClick;
            this.Controls.Add(buttonDraw);

            Button buttonClear = new Button();
            buttonClear.Location = new Point(385, 580);
            buttonClear.Size = new Size(50, 50);
            buttonClear.Name = "buttonClear";
            buttonClear.Text = "Clear";
            buttonClear.Click += buttonDrawClear;
            this.Controls.Add(buttonClear);

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 2000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 400;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.Active = Properties.Settings.Default.ShowPrompts;//??????????????

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(textBoxX, "field X for adding a tree element with further rendering");
            toolTip.SetToolTip(textBoxY, "field Y for adding a tree element with further rendering");
            toolTip.SetToolTip(comboBox, "choice of operation between two expressions");
            toolTip.SetToolTip(buttonDraw, "the button is designed to add the resulting number");
            toolTip.SetToolTip(buttonClear, "button to clear chart contents");
           
        }
        private void DrawChart()
        {
            Chart chart = new Chart();
            chart.Name = "DrawChart";
            chart.Location = new Point(16, 280);// 16 220 
            chart.Size = new Size(350, 350);
            chart.MouseWheel += chart1_MouseWheel;
            toolTip.SetToolTip(chart, "А graph for drawing numbers and their interactions");
            //
            ChartArea chartArea = new ChartArea("ChartArea1");
            chart.ChartAreas.Add(chartArea);
            //chartArea.AxisX.Title = "x";
            //chartArea.AxisY.Title = "y";

            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.Interval = 1;
            //chart.ChartAreas[0].AxisX.ScaleView.Zoom(-5, 5);
            //chart.ChartAreas[0].AxisY.ScaleView.Zoom(-5, 5);
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisY.IsMarginVisible = false;//default false?

            //s1
            Series series1 = new Series("Series1");
            series1.ChartType = SeriesChartType.Line;
            chart.Series.Add(series1);
            chart.Series[0].BorderWidth = 5;
            //s1

            //s2
            Series series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Line;
            chart.Series.Add(series2);
            chart.Series[1].BorderWidth = 5;
            //s2

            //s3
            Series series3 = new Series("Series3");
            series3.ChartType = SeriesChartType.Line;
            chart.Series.Add(series3);
            chart.Series[2].BorderWidth = 5;
            //s3

            this.Controls.Add(chart);
        }
        private void f1()
        {
            this.Height = 700;//600
            this.textBoxDebug.Text = this.Height.ToString();//d

            DrawTextBoxComboBox();
            DrawChart();          
        }
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }
        private void f1Close()
        {
            this.Height = 263;//fix
            this.textBoxDebug.Text = this.Height.ToString();//d

            foreach (object o in Controls)
            {
                switch (o)
                {
                    case Chart c: c.Dispose(); break;
                    case ChartArea ca: ca.Dispose(); break;
                    case Series s: s.Dispose(); break;
                    case Button b: if (b.Name.Equals("Draw") || b.Name.Equals("Clear")) b.Dispose(); break;
                    case TextBox tb: if (tb.Name.Equals("textBoxX") || tb.Name.Equals("textBoxY")) tb.Dispose(); break;
                    case ComboBox cb: if (cb.Name.Equals("comboBoxF1Operations")) cb.Dispose(); break;
                }
            }
        }//delete buttons and other

        #endregion
        //-----------------------------------------------------------------------------end
    }
}
