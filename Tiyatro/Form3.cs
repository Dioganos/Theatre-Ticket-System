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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 191, 55, 14);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 238, 27, 14);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 40, 40, 40);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 9, 131, 199);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            panel1.BackColor = Color.FromArgb(100, 40, 40, 40);
            this.BackColor = Color.FromArgb(120, 120, 120);
            label1.Text = "Tiyayro Ekle-Cikart";
            label1.Location = new Point((panel1.Width - label1.Size.Width) / 2, button2.Location.Y);


            var veri = File.ReadAllLines("path.json");
            for (int i = 0; i < veri.Length; i++)
            {
                var tut = JsonSerializer.Deserialize<data>(veri[i]);
                comboBox1.Items.Add(tut.Isim);
            }
            comboBox1.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 frm2 = new Form2();
            frm2.Location = new Point(this.Location.X, this.Location.Y);
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        string isim = "";
        
        private void button4_Click(object sender, EventArgs e)
        {
            if(isim == "")
            {
                int[] defsatbir = new int[1];
                int[] defsatiki = new int[1];
                var kayit = new data { Tarihler = new List<string[]>(), Satislar = new List<int[]>() , Log = new List<string>()};
                kayit.Satislar.Add(defsatbir);
                kayit.Satislar.Add(defsatiki);
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Lütfen isimi boş bırakmayınız!");
                }
                else
                {
                    kayit.Isim = comboBox1.Text;
                    var veri = JsonSerializer.Serialize(kayit);
                    var eskiveri = File.ReadAllLines("path.json");

                    if (eskiveri.Length.ToString() != "0")
                    {
                        bool var = false;
                        int index = 0;
                        string[] gecici = new string[eskiveri.Length];
                        for (int i = 0; i < eskiveri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(eskiveri[i]);
                            if (tut.Isim == kayit.Isim)
                            {
                                index = i;
                                var = true;
                                break;
                            }
                        }
                        if (var != true)
                        {
                            for (int i = 0; i < eskiveri.Length; i++)
                            {
                                gecici[i] = eskiveri[i];
                            }
                            Array.Resize(ref gecici, gecici.Length + 1);
                            gecici[gecici.Length - 1] = veri;
                            File.WriteAllLines("path.json", gecici);
                        }
                        else
                        {
                            MessageBox.Show("Eklemeye calistiginiz oyun zaten var");
                        }

                        comboBox1.Items.Clear();
                        var yeniveri = File.ReadAllLines("path.json");
                        for (int i = 0; i < yeniveri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(yeniveri[i]);
                            comboBox1.Items.Add(tut.Isim);
                        }
                        comboBox1.Text = "";
                        isim = "";
                    }
                    else
                    {
                        File.WriteAllText("path.json", veri);
                        comboBox1.Items.Clear();
                        var yeniveri = File.ReadAllLines("path.json");
                        for (int i = 0; i < yeniveri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(yeniveri[i]);
                            comboBox1.Items.Add(tut.Isim);
                        }
                        comboBox1.Text = "";
                        isim = "";
                    }
                }
                
            }
            else
            {
                int[] defsatbir = new int[1];
                int[] defsatiki = new int[1];
                var kayit = new data { Tarihler = new List<string[]>(), Satislar = new List<int[]>() , Log = new List<string>()   };
                kayit.Satislar.Add(defsatbir);
                kayit.Satislar.Add(defsatiki);
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Lütfen isimi boş bırakmayınız!");
                }
                else
                {
                    kayit.Isim = comboBox1.Text;
                    var veri = JsonSerializer.Serialize(kayit);
                    var eskiveri = File.ReadAllLines("path.json");

                    int index = 0;
                    string[] gecici = new string[eskiveri.Length];
                    for (int i = 0; i < eskiveri.Length; i++)
                    {
                        var tut = JsonSerializer.Deserialize<data>(eskiveri[i]);
                        if (tut.Isim == kayit.Isim)
                        {
                            index = i;
                            break;
                        }
                    }

                    eskiveri[index] = veri;
                    for (int i = 0; i < eskiveri.Length; i++)
                    {
                        gecici[i] = eskiveri[i];
                    }
                    File.WriteAllLines("path.json", gecici);
                    comboBox1.Items.Clear();
                    var yeniveri = File.ReadAllLines("path.json");
                    for (int i = 0; i < yeniveri.Length; i++)
                    {
                        var tut = JsonSerializer.Deserialize<data>(yeniveri[i]);
                        comboBox1.Items.Add(tut.Isim);
                    }
                    comboBox1.Text = "";
                    isim = "";
                }
                
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (isim == "")
            {
                if(comboBox1.Text == "")
                {
                    MessageBox.Show("Lutfen ismi bos birakmayiniz.");
                }
                else
                {
                    var eskiveri = File.ReadAllLines("path.json");

                    if (eskiveri.Length.ToString() != "0")
                    {
                        bool var = false;
                        int index = 0;
                        string[] gecici = new string[eskiveri.Length + 1];
                        for (int i = 0; i < eskiveri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(eskiveri[i]);
                            if (tut.Isim == comboBox1.Text)
                            {
                                index = i;
                                var = true;
                                break;
                            }
                        }
                        if (var == true)
                        {
                            for (int i = 0; i < eskiveri.Length; i++)
                            {
                                gecici[i] = eskiveri[i];
                            }
                            gecici[index] = null;
                            for (int i = index; i < eskiveri.Length; i++)
                            {
                                gecici[i] = gecici[i + 1];
                            }

                            Array.Resize(ref gecici, gecici.Length - 2);
                            File.WriteAllLines("path.json", gecici);
                            comboBox1.Items.Clear();
                            var yeniveri = File.ReadAllLines("path.json");
                            for (int i = 0; i < yeniveri.Length; i++)
                            {
                                var tut = JsonSerializer.Deserialize<data>(yeniveri[i]);
                                comboBox1.Items.Add(tut.Isim);
                            }
                            comboBox1.Text = "";
                            isim = "";
                        }
                        else
                        {
                            MessageBox.Show("Cikartmaya calistiginiz oyun bulunamadi!");
                        }
                    }
                }
            }
            else
            {
                var eskiveri = File.ReadAllLines("path.json");

                if(eskiveri.Length.ToString() != "0")
                {
                    bool var = false;
                    int index = 0;
                    string[] gecici = new string[eskiveri.Length + 1];
                    for (int i = 0; i < eskiveri.Length; i++)
                    {
                        var tut = JsonSerializer.Deserialize<data>(eskiveri[i]);
                        if (tut.Isim == comboBox1.Text)
                        {
                            index = i;
                            var = true;
                            break;
                        }
                    }
                    if (var == true)
                    {
                        for (int i = 0; i < eskiveri.Length; i++)
                        {
                            gecici[i] = eskiveri[i];
                        }
                        gecici[index] = null;
                        for (int i = index; i < eskiveri.Length; i++)
                        {
                            gecici[i] = gecici[i + 1];
                        }

                        Array.Resize(ref gecici, gecici.Length - 2);
                        File.WriteAllLines("path.json", gecici);
                        comboBox1.Items.Clear();
                        var yeniveri = File.ReadAllLines("path.json");
                        for (int i = 0; i < yeniveri.Length; i++)
                        {
                            var tut = JsonSerializer.Deserialize<data>(yeniveri[i]);
                            comboBox1.Items.Add(tut.Isim);
                        }
                        comboBox1.Text = "";
                        isim = "";
                    }
                    else
                    {
                        MessageBox.Show("Cikartmaya calistiginiz oyun bulunamadi!");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isim = comboBox1.SelectedItem.ToString();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tutuyom == true)
            {
                this.Left = Cursor.Position.X - FareX;
                this.Top = Cursor.Position.Y - FareY;
            }
        }
    }
}
