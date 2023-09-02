using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP.Entity
{
    class Context:DbContext
    {
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Yonetici> Yoneticis { get; set; }
        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<KitapAl> KitapAls { get; set; }
        public DbSet<İade> İades { get; set; }




    }
}
