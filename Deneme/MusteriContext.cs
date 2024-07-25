using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme
{
    public class MusteriContext:DbContext
    {
        public DbSet<Musteri> Musteriler { get; set; }
    }
}
