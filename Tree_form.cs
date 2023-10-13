using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Naidis_Vorm
{
    internal class Tree_form:Form
    {
        Button btn;
        TreeView tree;
        Label lbl;
        RadioButton r1, r2;
        CheckBox c1, c2;
        TextBox txt_box;
        PictureBox pb;
        Label txtLabel;
        bool isBtnVisible = false;
        bool isLblVisible = false;
        bool isTxtVisible = false;
        bool isr1Visible = false;
        bool isr2Visible = false;
        bool isc1Visible = false;
        bool isc2Visible = false;
        public Tree_form()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text="Vorm põhi elementidega";
            tree= new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Vajuta mind";
            btn.Location = new Point(150, 60);
            btn.Click += Btn_Click;
            btn.MouseLeave += Btn_MouseLeave;
            //label
            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl= new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width,0);
            lbl.Size = new Size(this.Width, 0);
            lbl.Size = new Size(this.Width, btn.Location.Y);
            lbl.BackColor= Color.HotPink;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            lbl.BorderStyle= BorderStyle.Fixed3D;
            this.Controls.Add(lbl);
            lbl.Visible= false;
            //Tekstkast
            treeNode.Nodes.Add(new TreeNode("Tekst-Textbox"));
            txt_box= new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height= 50;
            txt_box.Width= 100;
            txt_box.Text = "...";
            txt_box.Location = new Point(tree.Width, btn.Top+btn.Height+5);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
            //Radiobutton
            treeNode.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            r1= new RadioButton();
            r1.Text = "Valik 1";
            r1.Location = new Point(tree.Width, txt_box.Location.Y+txt_box.Height);
            r1.Visible= false;
            r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
            r2= new RadioButton();
            r2.Text = "Valik 2";
            r2.Location = new Point(r1.Location.X+r1.Width, txt_box.Location.Y + txt_box.Height);
            r2.Visible= false;
            r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
            //CheckBox
            treeNode.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            c1 = new CheckBox();
            c1.Text = "Näita nupp";
            c1.Location = new Point(tree.Width, r2.Location.Y + r2.Height);
            c1.Visible = false;
            c1.CheckedChanged += new EventHandler(Checkboxes_Changed);
            c2 = new CheckBox();
            c2.Text = "Näita veel midagi";
            c2.Location = new Point(c1.Location.X + c1.Width, r2.Location.Y + r2.Height);
            c2.Visible = false;
            c2.CheckedChanged += new EventHandler(Checkboxes_Changed);
            //pictureBox
            pb = new PictureBox();
            pb.Location= new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Image= new Bitmap("../../../images.jpg");
            pb.Size = new Size(200, 200);
            pb.SizeMode=PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            //txtLbl
            txtLabel = new Label();
            txtLabel.Location = new Point(txt_box.Right + 10, txt_box.Top);
            txtLabel.AutoSize = true;
            this.Controls.Add(txtLabel);
            txt_box.TextChanged += (sender, e) => UpdateTextBoxLabel();//Это лямбда-выражение, которое представляет собой обработчик
                                                                       //события. Оно состоит из двух параметров sender и e, которые представляют
                                                                       //отправителя события и
                                                                       //аргументы события (обычно не используются в данном случае)
                                                                       //treeNode.Nodes.Add(new TreeNode("DataGridView"));
                                                                       //DataSet ds = new DataSet("XML fail. Raamat");
                                                                       //ds.ReadXml(@"..\..\..\books.xml");
                                                                       //DataGridView dataGrid = new DataGridView();
                                                                       //dataGrid.Location = new Point(tree.Width + pb.Width, pb.Location.Y);
                                                                       //dataGrid.Height = 200;
                                                                       //dataGrid.Width = 300;
                                                                       //dataGrid.DataSource = ds;
                                                                       //dataGrid.AutoGenerateColumns = true;
                                                                       //dataGrid.DataMember = "book";


            Button openNewWindowButton = new Button();
            openNewWindowButton.Text = "Triangle";
            openNewWindowButton.Location = new Point(150, 80);
            openNewWindowButton.Click += OpenNewWindowButton_Click;
            this.Controls.Add(openNewWindowButton);


            //this.Controls.Add(dataGrid);
            tree.Nodes.Add(treeNode);
            //this.Controls.Add(dataGrid);
            tree.Nodes.Add(treeNode);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(txt_box);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            lbl.Visible= false;
            btn.Visible= false;
            txt_box.Visible= false;
            r1.Visible= false;
            r2.Visible= false;

        }
        private void OpenNewWindowButton_Click(object sender, EventArgs e)
        {
            Tree_form newForm = new Tree_form();
            newForm.Show();

            Triangle triangle = new Triangle(6, 7, 8);
            double perimeter = triangle.Perimeter();
            double surface = triangle.Surface();

            MessageBox.Show($"Perimeter: {perimeter}, Surface: {surface}, Triangle type: {CalculateSemiPerimeter}");
        }
        private void Txt_box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?",
                    "Küsimus", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes) { this.Text= txt_box.Text; }
            }
        }
        private void UpdateTextBoxLabel()
        {
            txtLabel.Text = txt_box.Text;
        }
        private void Checkboxes_Changed(object? sender, EventArgs e)
        {
            if (c1.Checked)
            {
                this.BackColor = Color.MistyRose;
            }
            else if (c2.Checked)
            {
                this.BackColor = Color.SlateBlue;
            }
        }

        private void Radiobuttons_Changed(object? sender, EventArgs e)
        {
            if(r1.Checked)
            {
                this.BackColor= Color.Pink;
            }
            else if(r2.Checked) 
            {
                this.BackColor= Color.Black;
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Lavender;
        }
        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if(e.Node.Text=="Nupp-Button")
            {
                isBtnVisible = !isBtnVisible;
                btn.Visible = isBtnVisible;
            }
            else if(e.Node.Text == "Silt-Label")
            {
                isLblVisible = !isLblVisible;
                lbl.Visible = isLblVisible;
            }
            else if(e.Node.Text== "Tekst-Textbox" && txt_box.Visible==false)
            {
                tree.SelectedNode= null;
                isTxtVisible = !isTxtVisible;
                txt_box.Visible = isTxtVisible;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton" && r1.Visible == true)
            {
                r1.Visible = false;
                r2.Visible = false;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton" && r1.Visible == false)
            {
                r1.Visible = true;
                r2.Visible = true;
            }
            else if (e.Node.Text == "Märkeruut-Checkbox" && c1.Visible == false)
            {
                tree.SelectedNode = null;
                isc1Visible = !isc1Visible;
                c1.Visible = isc1Visible;
                c2.Visible = isc1Visible;
            }
            else if(e.Node.Text=="")
            {
                tree.SelectedNode = null;
                pb.Visible = true;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Aqua)
            {
                btn.BackColor = Color.Chocolate;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }
        }

        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            btn.BackColor = Color.Black;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            btn.BackColor = Color.Red;
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                btn.BackColor = Color.White;
            }
        }

        private void Btn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Double");
            }
        }
    }
}
