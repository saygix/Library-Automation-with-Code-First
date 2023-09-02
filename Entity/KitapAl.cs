using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Entity
{
    class KitapAl
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string KitapAdi { get; set; }
        public string AldıgıTarih { get; set; }
    }
}
