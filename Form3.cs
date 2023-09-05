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
    public partial class Form3 : Form
    {
        int a, b, c;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            KullanıcıEkle();
            
        }
        public void KullanıcıEkle()
        {
           if(textBox4.Text.Length<6 )
            {
                MessageBox.Show("ŞİFRE 6 HANELİ RAKAMDAN OLUŞMALIDIR");
            }
           else
            {

                Context veri = new Context();
                Kullanici uye = new Kullanici();
                if (maskedTextBox3.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Text == "" || maskedTextBox1.Text == "" || textBox4.Text == "")  //Texboklar boşmu dolumu kontrol etme
                {
                    MessageBox.Show("KAYIT BAŞARISIZ");
                }
                else
                {
                    uye.tc = maskedTextBox3.Text;
                    uye.ad = textBox2.Text;
                    uye.soyad = textBox3.Text;
                    uye.dtarihi =dateTimePicker1.Text;
                    uye.telno = maskedTextBox1.Text;
                    uye.sifre = Convert.ToInt32(textBox4.Text);
                    veri.Kullanicis.Add(uye);
                    veri.SaveChanges();
                    MessageBox.Show("KAYIT BAŞARILI");
                    this.Close();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)               //CheckBox seçili ise
            {
                textBox4.PasswordChar = '\0';   //göster

            }
            else                               //değilse
            {
                textBox4.PasswordChar = '*';   //gizle

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            a = 1;
            b = e.X;
            c = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                this.SetDesktopLocation(MousePosition.X - b, MousePosition.Y - c);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;

        }
    }
}
