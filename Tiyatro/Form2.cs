using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace NYP_PROJE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 191, 55, 14);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 238, 27, 14);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);


            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            

            panel1.BackColor = Color.FromArgb(100, 40, 40, 40);
            this.BackColor = Color.FromArgb(120, 120, 120);
            label1.Text = "Tiyatro Edit";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button2.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Location = new Point(this.Location.X,this.Location.Y);
            frm1.Show();
        }

        bool tutuyom;
        int FareX, FareY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            tutuyom = true;
            FareX = Cursor.Position.X - this.Left;
            FareY = Cursor.Position.Y - this.Top;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tutuyom == true)
            {
                this.Left = Cursor.Position.X - FareX;
                this.Top = Cursor.Position.Y - FareY;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }

    
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            tutuyom = true;
            FareX = Cursor.Position.X - this.Left;
            FareY = Cursor.Position.Y - this.Top;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tutuyom == true)
            {
                this.Left = Cursor.Position.X - FareX;
                this.Top = Cursor.Position.Y - FareY;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 frm4 = new Form4();
            frm4.Location = new Point(this.Location.X, this.Location.Y);
            frm4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 frm5 = new Form5();
            frm5.Location = new Point(this.Location.X, this.Location.Y);
            frm5.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 frm6 = new Form6();
            frm6.Location = new Point(this.Location.X, this.Location.Y);
            frm6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 frm3 = new Form3();
            frm3.Location = new Point(this.Location.X, this.Location.Y);
            frm3.Show();
        }

    }
}
