using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Entity
{
    class Yonetici
    {
        [Key]
        public string ad { get; set; }
        public int sifre { get; set; }

    }
}
