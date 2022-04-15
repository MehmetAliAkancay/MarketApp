using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProje
{
    public class Urun
    {
        public string urunId { get; set; }
        public string urunIsim { get; set; }
        public double urunFiyat { get; set; }
        public int kampanya { get; set; }
        public DateTime kampanyatarih { get; set; }
        public int stok { get; set; }
    }
}
