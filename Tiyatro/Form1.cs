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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 191, 55, 14);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 238, 27, 14);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            panel1.BackColor = Color.FromArgb(100, 40, 40, 40);
            this.BackColor = Color.FromArgb(120, 120, 120);
            label1.Text = "Tiyatro Oyunları";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button2.Location.Y);
            var veri = File.ReadAllLines("path.json");
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                comboBox3.Items.Add(tut.Isim);
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
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_MouseDown_1(object sender, MouseEventArgs e)
        {

            tutuyom = true;
            FareX = Cursor.Position.X - this.Left;
            FareY = Cursor.Position.Y - this.Top;
        }

        private void label1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (tutuyom == true)
            {
                this.Left = Cursor.Position.X - FareX;
                this.Top = Cursor.Position.Y - FareY;
            }
        }

        private void label1_MouseUp_1(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 frm7 = new Form7();
            frm7.Location = new Point(this.Location.X, this.Location.Y);
            frm7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (comboBox3.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lutfen gerekli bilgileri seciniz!");
            }
            else
            {
                var veri = File.ReadAllLines("path.json");
                string[] gecici = new string[veri.Length];
                for (int i = 0; i < veri.Length; i++)
                {
                    gecici[i] = veri[i];
                }
                var satis = JsonSerializer.Deserialize<data>(veri[comboBox3.SelectedIndex]);

                if (comboBox1.SelectedItem.ToString() == "Ogrenci")
                {
                    if (satis.Satislar[0][0] == 0)
                    {
                        satis.Satislar[0][0] = 15 * Convert.ToInt32(textBox3.Text);
                        string log =DateTime.Now.ToString()+" Tarihinde "+ "\"" + comboBox3.SelectedItem.ToString() + "\"" + " Oyununa " + comboBox2.SelectedItem.ToString() + " Tarihine " + textBox3.Text + " tane " + comboBox1.SelectedItem.ToString() + " bilet satilmistir";
                        satis.Log.Add(log);
                    }
                    else
                    {
                        satis.Satislar[0][0] = satis.Satislar[0][0] + 15 * Convert.ToInt32(textBox3.Text);
                        string log = DateTime.Now.ToString() + " Tarihinde " + "\"" + comboBox3.SelectedItem.ToString() + "\"" + " Oyununa " + comboBox2.SelectedItem.ToString() + " Tarihine " + textBox3.Text + " tane " + comboBox1.SelectedItem.ToString() + " bilet satilmistir";
                        satis.Log.Add(log);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Tam")
                {
                    if (satis.Satislar[1][0] == 0)
                    {
                        satis.Satislar[1][0] = 20 * Convert.ToInt32(textBox3.Text);
                        string log = DateTime.Now.ToString() + " Tarihinde " + "\"" + comboBox3.SelectedItem.ToString() + "\"" + " Oyununa " + comboBox2.SelectedItem.ToString() + " Tarihine " + textBox3.Text + " tane " + comboBox1.SelectedItem.ToString() + " bilet satilmistir";
                        satis.Log.Add(log);
                    }
                    else
                    {
                        satis.Satislar[1][0] = satis.Satislar[1][0] + 20 * Convert.ToInt32(textBox3.Text);
                        string log = DateTime.Now.ToString() + " Tarihinde " + "\"" + comboBox3.SelectedItem.ToString() + "\"" + " Oyununa " + comboBox2.SelectedItem.ToString() + " Tarihine " + textBox3.Text + " tane " + comboBox1.SelectedItem.ToString() + " bilet satilmistir";
                        satis.Log.Add(log);
                    }
                }
                gecici[comboBox3.SelectedIndex] = JsonSerializer.Serialize(satis);
                File.WriteAllLines("path.json", gecici);
                textBox3.Clear();

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                comboBox2.Items.Clear();
                var veri = File.ReadAllLines("path.json");
                string[] gecici = new string[veri.Length];
                int index = 0;
                for (int i = 0; i < veri.Length; i++)
                {
                    gecici[i] = veri[i];
                }
                for (int i = 0; i < veri.Length; i++)
                {
                    var tut = JsonSerializer.Deserialize<data>(veri[i]);
                    if (tut.Isim == JsonSerializer.Deserialize<data>(veri[comboBox3.SelectedIndex]).Isim)
                    {
                        index = i;
                        break;
                    }
                }

                var tarihler = JsonSerializer.Deserialize<data>(veri[index]);
                foreach (var item in tarihler.Tarihler)
                {
                    comboBox2.Items.Add(item[0]);
                }
                comboBox2.Text = "";

                textBox1.Text = JsonSerializer.Deserialize<data>(veri[comboBox3.SelectedIndex]).Tur;
                textBox2.Text = JsonSerializer.Deserialize<data>(veri[comboBox3.SelectedIndex]).Perde;

            }
            catch
            {
                MessageBox.Show("Lutfen secmek istediginiz oyunun uzerine tiklayiniz!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Location = new Point(this.Location.X, this.Location.Y);
            frm2.Show();

        }


    }

}
