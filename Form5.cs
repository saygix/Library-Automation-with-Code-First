using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDP.Entity;
using System.Data.SqlClient;
namespace NDP
{
    public partial class Form5 : Form
    {
        Context veri = new Context();
        int a, b, c;
        Kitap guncellenecek;
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(baglanti.baglnti);
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fr1 = new Form1();
            fr1.Show();

        }
        private void Form5_Load(object sender, EventArgs e)
        {
            veriçek();
            
        }

        public void KitapEkle()

        {
            Kitap kitap = new Kitap();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")  //Texboklar boşmu dolumu kontrol etme
            {
                MessageBox.Show("KİTAP EKLEME BAŞARISIZ");
            }
            else
            {
                kitap.kad = textBox1.Text;
                kitap.yazari = textBox2.Text;
                kitap.sayfa = Convert.ToInt32(textBox3.Text);
                veri.Kitaps.Add(kitap);
                veri.SaveChanges();
                MessageBox.Show("KİTAP EKLEME BAŞARILI");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapEkle();
            veriçek();
            temizle();


        }
        public void veriçek()
        {
            dataGridView1.GridColor = Color.Yellow;              //DataGridView rengini değiştirdim
            dataGridView2.GridColor = Color.Black; 
            dataGridView3.GridColor = Color.AliceBlue;              //DataGridView rengini değiştirdim
            dataGridView1.DataSource = veri.Kitaps.ToList();
            dataGridView2.DataSource = veri.Kitaps.ToList();
            dataGridView3.DataSource = veri.KitapAls.ToList();

        }
        public void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            KitapSil();
            veriçek();

        }
        public void KitapSil()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult sonuc = MessageBox.Show("Bu Kitabı Silmek İstiyormusunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (sonuc == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                    {

                        int id = Convert.ToInt32(item.Cells[0].Value);
                        veri.Kitaps.Remove(veri.Kitaps.Find(id));
                        veri.SaveChanges();
                        MessageBox.Show("KİTAP SİLME İŞLEMİ BAŞARILI");
                        dataGridView1.DataSource = veri.Kitaps.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("KİTAP SİLME İŞLEMİ BAŞARISIZ");

                }
            }

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            KitapDüzenle();
            temizle();

        }
        public void KitapDüzenle()
        {
          

                guncellenecek.kad = textBox4.Text;
                guncellenecek.yazari = textBox5.Text;
                guncellenecek.sayfa = Convert.ToInt32(textBox6.Text);
                veri.SaveChanges();
                dataGridView2.DataSource = veri.Kitaps.ToList();
                MessageBox.Show("KİTAP DÜZENLEME İŞLEMİ BAŞARILI");   
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {

                int Id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                guncellenecek = veri.Kitaps.Find(Id);
                textBox4.Text = guncellenecek.kad;
                textBox5.Text = guncellenecek.yazari;
                textBox6.Text = guncellenecek.sayfa.ToString();
            }
        }

        //formu none yapınca hareket ettmediği için hareket ettirme kodları
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
        //Texboxın textindde yazan arayı text tıklayınca yok eder
        private void textBox8_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == (sender as TextBox).Tag.ToString())
            {
                (sender as TextBox).ForeColor = SystemColors.WindowText;
                (sender as TextBox).Text = "";
            }
        }
        //Texboxın textindde yazan arayı text orayı boş bırakınca ara geri gelir

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == "")
            {
                (sender as TextBox).Text = (sender as TextBox).Tag.ToString();
                (sender as TextBox).ForeColor = SystemColors.GrayText;
            }
        }
        //tekboxa yazılan tcyi arar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var ara = from x in veri.KitapAls select x;
            if (textBox8.Text != null)
            {
                dataGridView3.DataSource = ara.Where(x => x.KullaniciAdi.Contains(textBox8.Text)).ToList();
            }
        }
        //Kitap adını Texboxa yazddırır
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
        }


        //Önce üzerimdekilerden iade alınaını silip İade tablosuna seçileni ekler
        public void İadeAl()
        {
            if (textBox8.Text == "" || textBox7.Text == "" || dateTimePicker1.Text == "")  //Texboklar boşmu dolumu kontrol etme
            {
                MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ.");
            }
            else
            {
                conn.Open();                                                                                                  //bağlantıyı aç
                SqlCommand komut = new SqlCommand("delete from KitapAls where KitapAdi=@ka and KullaniciAdi=@kur", conn); //UyeKitapAl tablosundaki kullanıcı ve kitap adi doğruysa veriyi çek
                komut.Parameters.AddWithValue("@ka", textBox7.Text);                                                       //ka değerine tekbox1'den alınan değeri ata
                komut.Parameters.AddWithValue("@Kur", textBox8.Text);                                                     //aynı şekilde kullanıcı adını label10'dan alınan değere ata
                komut.ExecuteNonQuery();                                                                                 //komudu çalıştır
                conn.Close();//bağlantıyı kapat
                veriçek();

                // burada datagridview'den sildiğimiz veriyi datagridview2'ye aktarıyoruz

                conn.Open();                                                                                                            //bağlantıyı aç
                SqlCommand komut2 = new SqlCommand("insert into İade (KullaniciAdi,KitapAdi,İadeTarihi) values(@ku,@kad,@it)", conn);   //Iade tablosundanki verileri eklemek için değerleri tanımlıyoruz
                komut2.Parameters.AddWithValue("@kad", textBox7.Text);                                                                //kad değerine texbox1'den alınan değere ata
                komut2.Parameters.AddWithValue("@it", this.dateTimePicker1.Text.ToString());                                         //it değerine datetimePicker2den alınan değeri ata                        
                komut2.Parameters.AddWithValue("@ku", textBox8.Text);                                                                //kur değerine label10'dan alınan değeri ata
                komut2.ExecuteNonQuery();
                MessageBox.Show("İADE EDİLDİ");
                conn.Close();                                                                                                     //bağlantıyı kapat
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            İadeAl();
        }
   //texboxlara harf yazımını engeller

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}



