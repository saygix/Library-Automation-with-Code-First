using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NDP.Entity
{
    class Kitap:ICek
    {
        [Key]
        public int id { get; set; }
        public string kad { get; set; }
        public string yazari { get; set; }
        public int sayfa { get; set; }
        public List<string> Cek()
        {
            SqlConnection conn = new SqlConnection();  //yeni connection tanımlamı
            conn.ConnectionString = "Data Source=localhost\\SQLEXPRESS03;Initial Catalog=NDP;Integrated Security=True;";   //tekrar veri tabanına bağlantı
            SqlCommand komut = new SqlCommand();              //yeni  command tanımı adı da komut
            komut.CommandText = "SELECT *FROM Kitaps"; //KitapEkleSil tablosundaki verileri çek
            komut.Connection = conn;                        //veri bağlantısını çağırmak 
            komut.CommandType = CommandType.Text;          // CommandText özelliği saklı yordamın adına ayarlanmalıdır.Komut, Execute yöntemlerinden birini çağırdığınızda bu saklı yordamı yürütür.
            List<string> kitap = new List<string>();
            SqlDataReader dr;                             //SqlDataReader tanımlıyoruz adı dr
            conn.Open();                                 //bağlantıyı aç
            dr = komut.ExecuteReader();                 //komudu çalıştırıp dr'ye atıyoruz
            while (dr.Read())                          //read okumaya devam ederse okudukça döngüye giriyor
            {
                kitap.Add(dr["kad"].ToString());
            }
            conn.Close();
            return kitap;
        }
    }

}
