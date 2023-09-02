using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Entity
{
    class İade
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }

        public string İadeTarihi { get; set; }
      
        public string KitapAdi { get; set; }
    }
}
