using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Entity
{
    class Kullanici
    {
        [Key]
        public string tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string dtarihi { get; set; }
        public string telno { get; set; }
        public int sifre { get; set; }
    }
}
