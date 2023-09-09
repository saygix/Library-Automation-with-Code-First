using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDP.Entity;

namespace NDP
{
    public partial class Form6 : Form
    {
        Context veri = new Context();
        int a, b, c;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SifreDegistir();
        }

        public void SifreDegistir()
        {
            if(textBox2.Text==textBox3.Text)
            {
                Kullanici m = veri.Kullanicis.Where(x =>x.sifre.ToString() == textBox1.Text).SingleOrDefault();

                if (m == null)
                {
                    MessageBox.Show("MEVCUT ŞİFRE YANLIŞ");
                }
                else if (m != null)
                {
                    var guncelle = veri.Kullanicis.Where(w => w.sifre.ToString() == textBox1.Text).FirstOrDefault();
                    guncelle.sifre = Convert.ToInt32(textBox2.Text);
                    veri.SaveChanges();
                    MessageBox.Show("ŞİFRE DEĞİŞTİRİLDİ");
                    this.Close();
                    Form1 frm1 = new Form1();
                    frm1.Show();
                }

            }
            else
            {
                MessageBox.Show("LÜTFEN İKİ ŞİFRENİNDE AYNI OLDUĞUNDAN EMİN OLUN");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            a = 1;
            b = e.X;
            c = e.Y;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox2.Text;  //textboxdeki metini metin değişkenine atıyor
            if (metin.Length < 6)           //metin 6 den küçükse
            {
                errorProvider1.SetError(textBox2, "BURASI EN AZ 6 HANELİ OLMALI"); //hata veriyor hata ikonu texbox1 11 olmayınca gitmiyor
            }
            else
            {
                errorProvider1.SetError(textBox2, ""); //hata vermiyor 
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox3.Text;  //textboxdeki metini metin değişkenine atıyor
            if (metin.Length < 6)           //metin 6 den küçükse
            {
                errorProvider1.SetError(textBox3, "BURASI EN AZ 6 HANELİ OLMALI"); //hata veriyor hata ikonu texbox1 11 olmayınca gitmiyor
            }
            else
            {
                errorProvider1.SetError(textBox3, ""); //hata vermiyor 
            }
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                this.SetDesktopLocation(MousePosition.X - b, MousePosition.Y - c);
            }
        }

        private void Form6_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;
        }
    }
}
