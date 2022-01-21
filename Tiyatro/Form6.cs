﻿using System;
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
    public partial class Form6 : Form
    {
        public Form6()
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
            label1.Text = "Perde Sayisi Duzenle";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button3.Location.Y);

            var veri = File.ReadAllLines("path.json");
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                listBox1.Items.Add(tut.Isim);
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
            Form2 frm2 = new Form2();
            frm2.Location = new Point(this.Location.X, this.Location.Y);
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "")
                {

                    var veri = File.ReadAllLines("path.json");
                    string[] gecici = new string[veri.Length];
                    for (int i = 0; i < veri.Length; i++)
                    {
                        gecici[i] = veri[i];
                    }

                    var eskiveri = JsonSerializer.Deserialize<data>(veri[listBox1.SelectedIndex]);
                    eskiveri.Perde = textBox1.Text;
                    gecici[listBox1.SelectedIndex] = JsonSerializer.Serialize(eskiveri);
                    File.WriteAllLines("path.json", gecici);
                    textBox1.Text = "";
                    var yeniveri = File.ReadAllLines("path.json");
                    textBox1.Text = JsonSerializer.Deserialize<data>(yeniveri[listBox1.SelectedIndex]).Perde;
                }
                else
                {
                    MessageBox.Show("Oyun perde sayisi bos birakilamaz!");
                }
            }
            catch
            {
                MessageBox.Show("Lutfen bir oyun seciniz!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = "";
                var veri = File.ReadAllLines("path.json");
                var perde = JsonSerializer.Deserialize<data>(veri[listBox1.SelectedIndex]).Perde;
                textBox1.Text = perde;
            }
            catch
            {
                MessageBox.Show("Lutfen secmek istediginiz oyunun uzerine tiklayiniz!");
            }
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }
    }
}
