﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProje
{
    public class Tedarikci:Adres
    {
        public string tedarikIsim { get; set; }

        public string TedarikListele()
        {
            string temp="";
            temp+=tedarikIsim+Environment.NewLine+Sehir+Environment.NewLine+Ilce+Environment.NewLine+Mahalle+
                Environment.NewLine + AcikAdres;
            return temp;
        }
    }   

}
