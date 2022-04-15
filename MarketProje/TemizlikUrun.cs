using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketProje
{
    public partial class TemizlikUrun : Form
    {
        public TemizlikUrun()
        {
            InitializeComponent();
        }
        Tedarikci tedarikci = new Tedarikci();
        Urun urun = new Urun();
        Urun urun1 = new Urun();
        Urun urun2 = new Urun();
        Urun urun3 = new Urun();
        private void TemizlikUrun_Load(object sender, EventArgs e)
        {   
            tedarikci.tedarikIsim = "Temizlik Urunleri Ltd. Şti.";
            tedarikci.Sehir = "İstanbul";
            tedarikci.Ilce = "Bayrampaşa";
            tedarikci.Mahalle = "Cevatpaşa";
            tedarikci.AcikAdres = "Okul Sk.";
            
            urun.urunId = "7E965";
            urun.urunIsim = "XYZ Bulaşık Deterjanı 250ml";
            urun.urunFiyat = 19.99;
            urun.kampanya = 0;
            urun.stok = 153;
            Market.UrunEkle(urun);
           
            urun1.urunId = "7E966";
            urun1.urunIsim = "Cifff Yağ Sökücü 100ml";
            urun1.urunFiyat = 19.99;
            urun1.kampanya = 0;
            urun1.stok = 154;
            Market.UrunEkle(urun1);
            
            urun2.urunId = "7E967";
            urun2.urunIsim = "Turkish-Brite Bulaşık Süngeri 3'lü";
            urun2.urunFiyat = 2.99;
            urun2.kampanya = 0;
            urun2.stok = 46;
            Market.UrunEkle(urun2);
            
            urun3.urunId = "7E968"; 
            urun3.urunIsim = "Bongi Toz Çamaşır Deterjanı 6KG";
            urun3.urunFiyat = 39.99;
            urun3.kampanya = 0;
            urun3.stok = 24;
            Market.UrunEkle(urun3);
            dgvTemizlikUrun.DataSource = null;
            dgvTemizlikUrun.DataSource = Market.temizlikurun;

            for (int i = 0; i < dgvTemizlikUrun.Columns.Count - 1; i++)
            {
                dgvTemizlikUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvTemizlikUrun.Columns[dgvTemizlikUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvTemizlikUrun.Columns.Count; i++)
            {
                int sutun = dgvTemizlikUrun.Columns[i].Width;
                dgvTemizlikUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvTemizlikUrun.Columns[i].Width = sutun;
            }
        }

        public void Kampanya(string id, int kampanya, double fiyat, Urun urun)
        {
            if (id == txtUrunId.Text)
            {
                kampanya = Convert.ToInt16(txtUrunKampanya.Text);
                fiyat -= (kampanya * fiyat / 100);
                urun.kampanya = kampanya;
                urun.urunFiyat = fiyat;
                urun.kampanyatarih = DateTime.Now;
                dgvTemizlikUrun.DataSource = null;
                dgvTemizlikUrun.DataSource = Market.temizlikurun;

                for (int i = 0; i < dgvTemizlikUrun.Columns.Count - 1; i++)
                {
                    dgvTemizlikUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgvTemizlikUrun.Columns[dgvTemizlikUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvTemizlikUrun.Columns.Count; i++)
                {
                    int sutun = dgvTemizlikUrun.Columns[i].Width;
                    dgvTemizlikUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvTemizlikUrun.Columns[i].Width = sutun;
                }
            }
        }
        private void btnKampanyaUygula_Click(object sender, EventArgs e)
        {
            Kampanya(urun.urunId, urun.kampanya, urun.urunFiyat, urun);
            Kampanya(urun1.urunId, urun1.kampanya, urun1.urunFiyat, urun1);
            Kampanya(urun2.urunId, urun2.kampanya, urun2.urunFiyat, urun2);
            Kampanya(urun3.urunId, urun3.kampanya, urun3.urunFiyat, urun3);
        }

        private void btnTedarikAdres_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tedarikci.TedarikListele());
        }
    }
}
