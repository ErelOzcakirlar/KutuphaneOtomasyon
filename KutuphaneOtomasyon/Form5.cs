using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using DataAccessLayer;

namespace KutuphaneOtomasyon
{
    public partial class Form5 : Form
    {
        bool Type;
        Kitap Current;
        int KiralamaID;
        Decimal Kira = 1, Gecikme, Hasar;
        List<Uye> Uyeler;
        public static bool KIRALA = true, TESLIM_AL = false;

        public Form5(bool type, Kitap ktp)
        {
            InitializeComponent();
            this.Type = type;
            Current = ktp;
            KitapTB.Text = Current.ToString();
            Uyeler = UyeIslemleri.getMembers();
            if (Type)
            {
                this.Text = "Kitap Kirala";
                HasarCB.Hide();
                label6.Hide();
                UcretTB.Hide();
                label5.Hide();
                Finish.Text = "Kirala";
            }
            else
            {
                this.Text = "Kitap Teslim Al";
                int[] Temp = KiralamaIslemleri.getLastRent(Current.ID);
                KiralamaID = Temp[0];
                foreach (Uye item in Uyeler)
                {
                    if (item.ID == Temp[1])
                    {
                        UyeList.Items.Add(item);
                        UyeList.Enabled = false;
                        UyeNoTB.Enabled = false;
                        UyeAdiTB.Enabled = false;
                        break;
                    }
                }
                Gecikme = KiralamaIslemleri.gecikmeHesapla(KiralamaID);
                HasarCB.Checked = Current.HasarDurumu;
                ucretHesapla();
                Finish.Text = "Teslim Al";
            }
        }

        private void setList()
        {
            UyeList.Items.Clear();
            String UyeNoText = UyeNoTB.Text;
            for (int i = 0; i < UyeNoText.Length; i++)
            {
                if (!Char.IsNumber(UyeNoText[i]))
                {
                    UyeNoText = UyeNoText.Remove(i, 1);
                    i--;
                }
            }
            UyeNoTB.Text = UyeNoText;
            int UyeNo = 0;
            try
            {
                if (!String.IsNullOrEmpty(UyeNoText))
                {
                    UyeNo = int.Parse(UyeNoText);
                }
            }
            catch (StackOverflowException soe)
            {
                MessageBox.Show("Girdiğiniz üye numarası fazla uzun");
            }
            String UyeAdiText = UyeAdiTB.Text;
            if (UyeNo != 0)
            {
                if (String.IsNullOrEmpty(UyeAdiText))
                {
                    foreach (Uye item in Uyeler)
                    {
                        if (UyeNo == item.ID)
                        {
                            UyeList.Items.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (Uye item in Uyeler)
                    {
                        if (UyeNo == item.ID && (item.Adi.Contains(UyeAdiText) || UyeAdiText.Contains(item.Adi)))
                        {
                            UyeList.Items.Add(item);
                        }
                    }
                }
            }
            else if (!String.IsNullOrEmpty(UyeAdiText))
            {
                foreach (Uye item in Uyeler)
                {
                    if (item.Adi.Contains(UyeAdiText) || UyeAdiText.Contains(item.Adi))
                    {
                        UyeList.Items.Add(item);
                    }
                }
            }
        }

        private void ucretHesapla()
        {
            Decimal Ucret = Kira + Hasar + Gecikme;
            UcretTB.Text = Ucret.ToString();
        }

        private void UyeNoTB_TextChanged(object sender, EventArgs e)
        {
            setList();
        }

        private void UyeAdiTB_TextChanged(object sender, EventArgs e)
        {
            setList();
        }

        private void HasarCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HasarCB.Checked && !Current.HasarDurumu)
            {
                Hasar = Current.Fiyat / 2;
                ucretHesapla();
            }
            else if (!HasarCB.Checked)
            {
                Hasar = 0;
                ucretHesapla();
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            if (Type)
            {
                if (UyeList.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen kitabı kiralayacak üyeyi seçin");
                }
                else
                {
                    Uye Person = (Uye)UyeList.SelectedItem;
                    int RentCount = KiralamaIslemleri.getRentCount(Person.ID);
                    if (RentCount < 3)
                    {
                        if (KiralamaIslemleri.kirala(Person.ID, Current.ID))
                        {
                            MessageBox.Show("Kiralama işlemi başarılı");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("İşlem sırasında bir hata oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show(Person.Adi + " " + Person.Soyadi + ", daha önce 3 kitap kiralamış,\n" +
                        "Başka bir kitap kiralamak için önce kiraladığı kitapların en az birini iade etmeli.");
                    }
                }
            }
            else
            {
                Decimal toplam = Kira + Gecikme + Hasar;
                Decimal[] values = new Decimal[3];
                values[0] = Gecikme;
                values[1] = Hasar;
                values[2] = toplam;
                Form6 Payment = new Form6(values,KiralamaID);
                Payment.ShowDialog();
                this.Close();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
