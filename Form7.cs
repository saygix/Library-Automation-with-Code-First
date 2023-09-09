using NDP.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP
{
    public partial class Form7 : Form
    {
        Context veri = new Context();
        int a, b, c;
        public Form7()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SifremiUnuttum()
        {

            if (textBox1.Text == textBox2.Text) 
            {
                Kullanici m = veri.Kullanicis.Where(x => x.tc == maskedTextBox2.Text).SingleOrDefault();

                if (m == null)
                {
                    MessageBox.Show("KAYITLI KULLANICI BULUNAMADI");
                }
                else if (m != null)
                {
                    var guncelle = veri.Kullanicis.Where(w => w.tc == maskedTextBox2.Text).FirstOrDefault();
                    guncelle.sifre = Convert.ToInt32(textBox1.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SifremiUnuttum();
        }

     //girilen şifre 6 dan Küçükse eror veriyor
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox1.Text;  //textbox1deki metini metin değişkenine atıyor
            if (metin.Length < 6)           //metin 6 den küçükse
            {
                errorProvider1.SetError(textBox1, "BURASI EN AZ 6 HANELİ OLMALI"); //hata veriyor hata ikonu texbox1 11 olmayınca gitmiyor
            }
            else
            {
                errorProvider1.SetError(textBox1, ""); //hata vermiyor 
            }
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


        //Formun none özelliğini kullandığım için hareket etmiyordu bu kodlar hareket etmesini sağlar.
        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            a = 1;
            b = e.X;
            c = e.Y;
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                this.SetDesktopLocation(MousePosition.X - b, MousePosition.Y - c);
            }
        }

        private void Form7_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;
        } 
    }
}
