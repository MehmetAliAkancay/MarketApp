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
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }
        public void YavruForm(Form Yavru)
        {
            bool durum = false;
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == Yavru.Text)
                {
                    durum = true;
                    eleman.Activate();
                }
            }

            if (durum == false)
            {
                Yavru.MdiParent = this;
                Yavru.Show();
            }
        
        }
        private void tsbCalisan_Click(object sender, EventArgs e)
        {
            Market1 market1 = new Market1();
            YavruForm(market1);
        }

        private void tsmiTemizlik_Click(object sender, EventArgs e)
        {
            TemizlikUrun temizlik = new TemizlikUrun();
            YavruForm(temizlik);
        }

        private void tsbSube_Click(object sender, EventArgs e)
        {
            SubeEklemeEkrani subeEkleme = new SubeEklemeEkrani();
            YavruForm(subeEkleme);
        }

        private void tsmiGida_Click(object sender, EventArgs e)
        {
            GıdaUrun gıda = new GıdaUrun();
            YavruForm(gıda);
        }

        private void tsmiKampanya_Click(object sender, EventArgs e)
        {
            KampanyaUrun kampanya = new KampanyaUrun();
            YavruForm(kampanya);
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            YavruForm(anaSayfa);
        }
    }
}
