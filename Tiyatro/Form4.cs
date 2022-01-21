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
    public partial class Form4 : Form
    {
        public Form4()
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
            label1.Text = "Tarih Ekle-Cikart";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button3.Location.Y);



            var veri = File.ReadAllLines("path.json");
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                listBox1.Items.Add(tut.Isim);
            }
        }

        string isim = "";
        int selectindex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           if(isim == "")
           {
                if(listBox1.SelectedIndex != -1)
                {
                    if(comboBox2.Text != "")
                    {
                        var veri = File.ReadAllLines("path.json");
                        int index = 0;
                        int index2 = 0;

                        bool var = false;

                        string[] gecici = new string[veri.Length];
                        for (int i = 0; i < veri.Length; i++)
                        {
                            gecici[i] = veri[i];
                        }
                        for (int i = 0; i < veri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(veri[i]);
                            if (tut.Isim == listBox1.SelectedItem.ToString())
                            {
                                index = i;
                                break;
                            }
                        }

                        var degisecek = JsonSerializer.Deserialize<data>(veri[index]);
                        string[] tarih = { comboBox2.Text };

                        if (degisecek.Tarihler.Count == 0)
                        {
                            degisecek.Tarihler.Add(tarih);
                        }
                        else
                        {
                            foreach (var item in degisecek.Tarihler)
                            {
                                if (item[0] == comboBox2.Text)
                                {
                                    var = true;
                                    break;
                                }
                                else
                                {
                                    index2++;
                                    var = false;
                                }
                            }

                            if (var == true)
                            {
                                degisecek.Tarihler[index2][0] = comboBox2.Text;
                                MessageBox.Show("Eklemeye calistiginiz tarih zaten var!");
                            }
                            else
                            {
                                degisecek.Tarihler.Add(tarih);
                            }
                        }
                        var degisti = JsonSerializer.Serialize(degisecek);
                        gecici[index] = degisti;
                        File.WriteAllLines("path.json", gecici);
                        comboBox2.Items.Clear();
                        var yeniveri = File.ReadAllLines("path.json");
                        var yenitarihlist = JsonSerializer.Deserialize<data>(yeniveri[index]);
                        foreach (var item in yenitarihlist.Tarihler)
                        {
                            comboBox2.Items.Add(item[0]);
                        }
                        comboBox2.Text = "";
                        isim = "";
                    }
                    else
                    {
                        MessageBox.Show("Oyun tarihi bos birakilamaz!");
                    }
                    

                }
                else
                {
                    MessageBox.Show("Lutfen oyun seciniz!");
                }

            }
           else
           {
                if (comboBox2.Text != "")
                {
                    var veri = File.ReadAllLines("path.json");
                    string[] gecici = new string[veri.Length];
                    for (int i = 0; i < veri.Length; i++)
                    {
                        gecici[i] = veri[i];
                    }

                    var degisecek = JsonSerializer.Deserialize<data>(veri[listBox1.SelectedIndex]);

                    degisecek.Tarihler[selectindex][0] = comboBox2.Text;
                    gecici[listBox1.SelectedIndex] = JsonSerializer.Serialize(degisecek);
                    File.WriteAllLines("path.json", gecici);
                    comboBox2.Items.Clear();
                    var yeniveri = File.ReadAllLines("path.json");
                    var yenitarihlist = JsonSerializer.Deserialize<data>(yeniveri[listBox1.SelectedIndex]);
                    foreach (var item in yenitarihlist.Tarihler)
                    {
                        comboBox2.Items.Add(item[0]);
                    }
                    comboBox2.Text = "";
                    isim = "";
                    selectindex = 0;
                }
                else
                {
                    MessageBox.Show("Oyun tarihi bos birakilamaz!");
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 frm2 = new Form2();
            frm2.Location = new Point(this.Location.X, this.Location.Y);
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isim == "")
            {
                MessageBox.Show("Lutfen cikartmak istediginiz tarihi seciniz");
            }
            else
            {
                var veri = File.ReadAllLines("path.json");
                string[] gecici = new string[veri.Length];
                for (int i = 0; i < veri.Length; i++)
                {
                    gecici[i] = veri[i];
                }

                var silinecek = JsonSerializer.Deserialize<data>(veri[listBox1.SelectedIndex]);
                if(comboBox2.Text == "")
                {
                    MessageBox.Show("Lutfen tarih kutucugunu bos birakmayin!");
                }
                else
                {

                    silinecek.Tarihler.RemoveAt(comboBox2.SelectedIndex);
                    gecici[listBox1.SelectedIndex] = JsonSerializer.Serialize(silinecek);
                    File.WriteAllLines("path.json", gecici);
                    comboBox2.Items.Clear();
                    var yeniveri = File.ReadAllLines("path.json");
                    var yenitarihlist = JsonSerializer.Deserialize<data>(yeniveri[listBox1.SelectedIndex]);
                    foreach (var item in yenitarihlist.Tarihler)
                    {
                        comboBox2.Items.Add(item[0]);
                    }
                    comboBox2.Text = "";
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            isim = comboBox2.SelectedItem.ToString();
            selectindex = comboBox2.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                    if (tut.Isim == JsonSerializer.Deserialize<data>(veri[listBox1.SelectedIndex]).Isim)
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
                isim = "";
            }
            catch
            {
                MessageBox.Show("Lutfen secmek istediginiz oyunun uzerine tiklayiniz!");
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

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            tutuyom = false;
            FareX = 0;
            FareY = 0;
        }
    }
}
