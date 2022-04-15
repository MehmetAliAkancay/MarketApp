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
    public partial class KampanyaUrun : Form
    {
        public KampanyaUrun()
        {
            InitializeComponent();
        }
        Tedarikci tedarikci2 = new Tedarikci();
        Urun urun = new Urun();
        Urun urun1 = new Urun();
        Urun urun2 = new Urun();
        Urun urun3 = new Urun();

        private void KampanyaUrun_Load(object sender, EventArgs e)
        {
            tedarikci2.tedarikIsim = "Kampanya Urunleri Ltd. Şti.";
            tedarikci2.Sehir = "İstanbul";
            tedarikci2.Ilce = "Florya";
            tedarikci2.Mahalle = "Kurşunlu Mah.";
            tedarikci2.AcikAdres = "Mutlu Sk. No:7";

            urun.urunId = "8G921";
            urun.urunIsim = "Kefal Çaydanlık ";
            urun.urunFiyat = 69.99;
            urun.kampanya = 0;
            urun.stok = 24;
            Market.KampanyaUrunEkle(urun);
           
            urun1.urunId = "8G922";
            urun1.urunIsim = "Babidas Spor Ayakkabı";
            urun1.urunFiyat = 229.99;
            urun1.kampanya = 0;
            urun1.stok = 35;
            Market.KampanyaUrunEkle(urun1);
            
            urun2.urunId = "8G923";
            urun2.urunIsim = "Lazer Oyuncu Mause";
            urun2.urunFiyat = 145.45;
            urun2.kampanya = 0;
            urun2.stok = 16;
            Market.KampanyaUrunEkle(urun2);
            
            urun3.urunId = "8G924";
            urun3.urunIsim = "Naber-Castell 12li Pastel Boya";
            urun3.urunFiyat = 19.99;
            urun3.kampanya = 0;
            urun3.stok = 18;
            Market.KampanyaUrunEkle(urun3);
            dgvKampanyaUrun.DataSource = null;
            dgvKampanyaUrun.DataSource = Market.kampanyaurun;

            for (int i = 0; i < dgvKampanyaUrun.Columns.Count - 1; i++)
            {
                dgvKampanyaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvKampanyaUrun.Columns[dgvKampanyaUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvKampanyaUrun.Columns.Count; i++)
            {
                int sutun = dgvKampanyaUrun.Columns[i].Width;
                dgvKampanyaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvKampanyaUrun.Columns[i].Width = sutun;
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
                dgvKampanyaUrun.DataSource = null;
                dgvKampanyaUrun.DataSource = Market.kampanyaurun;

                for (int i = 0; i < dgvKampanyaUrun.Columns.Count - 1; i++)
                {
                    dgvKampanyaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgvKampanyaUrun.Columns[dgvKampanyaUrun.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvKampanyaUrun.Columns.Count; i++)
                {
                    int sutun = dgvKampanyaUrun.Columns[i].Width;
                    dgvKampanyaUrun.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvKampanyaUrun.Columns[i].Width = sutun;
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
            MessageBox.Show(tedarikci2.TedarikListele());
        }
    }
}
