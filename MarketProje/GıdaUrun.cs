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
    public partial class GıdaUrun : Form
    {
        public GıdaUrun()
        {
            InitializeComponent();
        }
        Tedarikci tedarikci1 = new Tedarikci();
        Urun urun = new Urun();
        Urun urun1 = new Urun();
        Urun urun2 = new Urun();
        Urun urun3 = new Urun();
        private void GıdaUrun_Load(object sender, EventArgs e)
        {
            tedarikci1.tedarikIsim = "Gıda Urunleri Ltd. Şti.";
            tedarikci1.Sehir = "İstanbul";
            tedarikci1.Ilce = "Kadıköy";
            tedarikci1.Mahalle = "FerhatPaşa";
            tedarikci1.AcikAdres = "Hanber Sk. No:8";

            urun.urunId = "8F764";
            urun.urunIsim = "Ekmek";
            urun.urunFiyat = 1.25;
            urun.stok = 205;
            Market.GıdaUrunEkle(urun);
            
            urun1.urunId = "8F765";
            urun1.urunIsim = "Bimbat Karışık Kuruyemiş";
            urun1.urunFiyat = 12.49;
            urun1.stok = 104;
            Market.GıdaUrunEkle(urun1);
            
            urun2.urunId = "8F766";
            urun2.urunIsim = "Koritos Peynirli Cips";
            urun2.urunFiyat = 4.64;
            urun2.stok = 67;
            Market.GıdaUrunEkle(urun2);
            
            urun3.urunId = "8F767";
            urun3.urunIsim = "Ondomie Körili Noodle";
            urun3.urunFiyat = 2.45;
            urun3.stok = 162;
            Market.GıdaUrunEkle(urun3);
            dgvGidaUrun.DataSource = null;
            dgvGidaUrun.DataSource = Market.gıdaurun;

            for (int i = 0; i < dgvGidaUrun.Columns.Count - 1; i++)
                {
                dgvGidaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            dgvGidaUrun.Columns[dgvGidaUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvGidaUrun.Columns.Count; i++)
                {
                    int sutun = dgvGidaUrun.Columns[i].Width;
                    dgvGidaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvGidaUrun.Columns[i].Width = sutun;
                }

        }
        public void Kampanya(string id, int kampanya,double fiyat,Urun urun)
        {
            if (id == txtUrunId.Text)
            {
                kampanya = Convert.ToInt16(txtUrunKampanya.Text);
                fiyat -= (kampanya * fiyat / 100);
                urun.kampanya = kampanya;
                urun.urunFiyat = fiyat;
                urun.kampanyatarih = DateTime.Now;
                dgvGidaUrun.DataSource = null;
                dgvGidaUrun.DataSource = Market.gıdaurun;

                for (int i = 0; i < dgvGidaUrun.Columns.Count - 1; i++)
                {
                    dgvGidaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgvGidaUrun.Columns[dgvGidaUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvGidaUrun.Columns.Count; i++)
                {
                    int sutun = dgvGidaUrun.Columns[i].Width;
                    dgvGidaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvGidaUrun.Columns[i].Width = sutun;
                }
            }
        }

        private void btnKampanyaUygula_Click(object sender, EventArgs e)
        {
            Kampanya(urun.urunId, urun.kampanya, urun.urunFiyat,urun);
            Kampanya(urun1.urunId, urun1.kampanya, urun1.urunFiyat,urun1);
            Kampanya(urun2.urunId, urun2.kampanya, urun2.urunFiyat,urun2);
            Kampanya(urun3.urunId, urun3.kampanya, urun3.urunFiyat,urun3);
        }

        private void btnTedarikAdres_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tedarikci1.TedarikListele());
        }
    }
}
