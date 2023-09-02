using NDP.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace NDP
{
    public partial class Form1 : Form
    {
        int a, b, c;
        public static string Kullanici;     //Form2 kısmına veri çekmek için kullanıcı string olarak tanımlama

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Context veri = new Context();
            veri.Database.Create();
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void login()
        {
         
                try
                {
                    Context veri = new Context();
                    Kullanici m = veri.Kullanicis.Where(x => x.tc == maskedTextBox1.Text && x.sifre.ToString() == textBox2.Text).SingleOrDefault();

                    if (m == null)
                    {
                        MessageBox.Show("KULLANICI BULUNAMADI");
                    }
                    else if (m != null)
                    {
                    Form2 frm2 = new Form2();
                        frm2.Show();
                        MessageBox.Show("GİRİŞ YAPILDI");
                        this.Hide();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı Hatası: " + ex.Message);
                }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Kullanici = maskedTextBox1.Text;
            login();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)               //CheckBox seçili ise
            {
                textBox2.PasswordChar = '\0';   //göster

            }
            else                               //değilse
            {
                textBox2.PasswordChar = '*';   //gizle

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            a= 1;
            b= e.X;
            c = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                this.SetDesktopLocation(MousePosition.X - b, MousePosition.Y -c);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;
        }
    }
}
