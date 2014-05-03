using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Entities;

namespace KutuphaneOtomasyon
{
    public partial class Form6 : Form
    {
        Decimal[] Values;
        int KiralamaID;
        Decimal Gecikme=0,Hasar=0;
        public Form6(Decimal[] values,int kiralamaID)
        {
            InitializeComponent();
            this.Values = values;
            this.KiralamaID = kiralamaID;
            KiraTB.Text = "1";
            Gecikme = values[0];
            GecikmeTB.Text = Gecikme.ToString();
            Hasar = values[1];
            HasarTB.Text = Hasar.ToString();
            ToplamTB.Text = values[2].ToString();
            OdemeCB.DataSource = KiralamaIslemleri.getPayTypes();
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            if (OdemeCB.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ödeme tipini seçin");
            }
            else
            {
                if (KiralamaIslemleri.teslimAl(KiralamaID, Gecikme, Hasar,(Bilesen)OdemeCB.SelectedItem))
                {
                    MessageBox.Show("İşlem başarılı");
                }
                else
                {
                    MessageBox.Show("İşlem sırasında bir hata oluştu.");
                }
                this.Close();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
