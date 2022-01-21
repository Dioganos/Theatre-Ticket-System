using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace NYP_PROJE
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 191, 55, 14);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 238, 27, 14);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            panel1.BackColor = Color.FromArgb(100, 40, 40, 40);
            this.BackColor = Color.FromArgb(120, 120, 120);
            label1.Text = "LOG";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button3.Location.Y);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            var veri = File.ReadAllLines("path.json");

            string[] gecici = new string[veri.Length];
            for (int i = 0; i < veri.Length; i++)
            {
                gecici[i] = veri[i];
            }
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                foreach (var item in tut.Log)
                {
                    listBox1.Items.Add(item);
                }
            }

            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                string ogrsatti = (tut.Satislar[0][0] / 15).ToString();
                string tamsatti = (tut.Satislar[1][0] / 20).ToString();
                string totallogmessage = "\""+tut.Isim+"\"" + " Isimli oyun toplamda " + ogrsatti + " tane ogrenci , " + tamsatti + " tane tam bilet satarak toplamda " + (tut.Satislar[0][0] + tut.Satislar[1][0]).ToString() + " ₺ kazanc sagladi!";
                listBox2.Items.Add(totallogmessage);
            }





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

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tutuyom == true)
            {
                this.Left = Cursor.Position.X - FareX;
                this.Top = Cursor.Position.Y - FareY;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Location = new Point(this.Location.X, this.Location.Y);
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            var veri = File.ReadAllLines("path.json");
            string[] gecici = new string[veri.Length];
            for (int i = 0; i < veri.Length; i++)
            {
                gecici[i] = veri[i];
            }
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                tut.Satislar[0][0] = 0;
                tut.Satislar[1][0] = 0;
                tut.Log.Clear();
                gecici[i] = JsonSerializer.Serialize(tut);

                string ogrsatti = (tut.Satislar[0][0] / 15).ToString();
                string tamsatti = (tut.Satislar[1][0] / 20).ToString();
                string totallogmessage = "\"" + tut.Isim + "\"" + " Isimli oyun toplamda " + ogrsatti + " tane ogrenci , " + tamsatti + " tane tam bilet satarak toplamda " + (tut.Satislar[0][0] + tut.Satislar[1][0]).ToString() + " ₺ kazanc sagladi!";
                listBox2.Items.Add(totallogmessage);
            }
            File.WriteAllLines("path.json", gecici);

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }
    }
}
