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
    public partial class Form4 : Form
    {
        int a, b, c;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
                try
                {


                    Context veri = new Context();
                    Yonetici m = veri.Yoneticis.Where(x => x.ad == textBox1.Text && x.sifre.ToString() == textBox2.Text).SingleOrDefault();
                    if (m == null)
                    {
                        MessageBox.Show("YÖNETİCİ BULUNAMADI");
                    }
                    else if (m != null)
                    {
                        Form5 frm5 = new Form5();
                        frm5.Show();
                        MessageBox.Show("GİRİŞ YAPILDI");
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı Hatası: " + ex.Message);
                }
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == (sender as TextBox).Tag.ToString())
            {
                (sender as TextBox).ForeColor = SystemColors.WindowText;
                (sender as TextBox).Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == "")
            {
                (sender as TextBox).Text = (sender as TextBox).Tag.ToString();
                (sender as TextBox).ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == (sender as TextBox).Tag.ToString())
            {
                (sender as TextBox).ForeColor = SystemColors.WindowText;
                (sender as TextBox).Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == "")
            {
                (sender as TextBox).Text = (sender as TextBox).Tag.ToString();
                (sender as TextBox).ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
