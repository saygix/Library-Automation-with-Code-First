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
using System.Data.SqlClient;
namespace NDP
{
    public partial class Form2 : Form
    {
        Context veri = new Context();
        int a, b, c;
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(baglanti.baglnti);
        Kitap k = new Kitap();
        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = Form1.Kullanici;
            comboBox1.DataSource =k.Cek();
            KitapGöster();
            IadeGoster();
        }
  

        public void KitapAll()
        {
            KitapAl kitap = new KitapAl();
            if ( textBox1.Text == "" ||  dateTimePicker1.Text == "")  //Texboklar boşmu dolumu kontrol etme
            {
                MessageBox.Show("KİTAP ALMA İŞLEMİ BAŞARISIZ");
            }
            else
            {
                conn.Open();                                                                                              //bağlantıyı aç
                string kayit = "insert into KitapAls (KullaniciAdi,KitapAdi,AldıgıTarih) values (@ku,@ka,@at)";        //kayıt değikeni ile UyeKitapAl tablosundanki verileri eklemek için değerleri tanımlıyoruz
                SqlCommand komut = new SqlCommand(kayit, conn);                                                          //komut tanımlıyoruz. bu da kayıttaki cümleciğimizle connetionla balıyor
                komut.Parameters.AddWithValue("@ku", button1.Text);                                                    //ku değerine textbox9den alınan değeri ata demek
                komut.Parameters.AddWithValue("@ka", textBox1.Text);                                                  //ka değerine textbox9den alınan değeri ata demek
                komut.Parameters.AddWithValue("@at", dateTimePicker1.Text);                          //at değerine dateTimerPicker1'den alınan değeri ata demek
                komut.ExecuteNonQuery();//komudu çalıştır
                MessageBox.Show("KİTAP ALMA İŞLEMİ BAŞARILI");
                conn.Close();
               
            }
        }

        public void KitapGöster()
        {
            conn.Open();                                                                                          //bağlantıyı aç
            string kayit = "SELECT KullaniciAdi,KitapAdi,AldıgıTarih From KitapAls where KullaniciAdi=@ku";    //kayıt değikeni ile UyeKitapAl tablosundanki verileri eklemek için değerleri tanımlıyoruz 
            SqlCommand komut = new SqlCommand(kayit, conn);                                                     //komut tanımlıyoruz. bu da kayıttaki cümleciğimizle connetionla balıyor
            komut.Parameters.AddWithValue("@ku", button1.Text);                                                //giren kullanıcını tcsini label10'a atıyor.
            SqlDataAdapter dr = new SqlDataAdapter(komut);                                                    //Ardından DataAdapter verilerimizi çektik.
            DataTable dt = new DataTable();                                                                  //çekilen verileri barındırmak için DataTable oluşturduk
            dr.Fill(dt);                                                                                    //Son adımda ise bu çekilen verileri Fill komutu ile oluşturulan DataTable a aktardım
            dataGridView1.DataSource = dt;                                                                 //aldığım kitaplarrı görmek için dataGridView1 verileri çağırdım
            conn.Close();

        }

        public void IadeGoster()
        {
            conn.Open();
            string kayit = "SELECT KullaniciAdi,KitapAdi,İadeTarihi From İade where KullaniciAdi=@ku"; //Iade tablosunda girilen diğer veriler doğru olduğu yerde veri çek
            SqlCommand komut = new SqlCommand(kayit, conn);                                           //kayıttaki sql cümleciğini veritabanımıza uygular
            komut.Parameters.AddWithValue("@ku", button1.Text);                                      //ku değerine label10'dan alınan değeri ata
            SqlDataAdapter dr = new SqlDataAdapter(komut);                                          //Ardından DataAdapter verilerimizi çektik.
            DataTable dt = new DataTable();                                                        //çekilen verileri barındırmak için DataTable oluşturduk
            dr.Fill(dt);                                                                          //Son adımda ise bu çekilen verileri Fill komutu ile oluşturulan DataTable a aktardım
            dataGridView2.DataSource = dt;                                                       //dataGridView2 ye verileri çağırdım
            conn.Close();                                                                       //bağlantıyı kapat
        }
        private void gÜVENLİÇIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkış Yapmak İstiyor musunuz?", "Evet", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
            }


        }

        private void şİFREMİUNUTTUMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void hESAPDEİĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0)  //comboboxın içinde tanımlanan kitap varsa
            {
                checkedListBox1.Items.Add(comboBox1.SelectedItem.ToString());  //checkedlistboxa aktar
            }
            else  //yoksa
            {
                MessageBox.Show("BÖYLE BİR KİTAP BULUNAMADI"); //hata mesajını ver
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            a = 1;
            b = e.X;
            c = e.Y;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                this.SetDesktopLocation(MousePosition.X - b, MousePosition.Y - c);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            KitapAll();
            KitapGöster();
            textBox1.Clear();                 //Texboxı temizle

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = checkedListBox1.SelectedItem.ToString();  //checkedlistboxta seçileni texboxa yazdır 

        }
    }
}
