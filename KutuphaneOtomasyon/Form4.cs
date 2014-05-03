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
    public partial class Form4 : Form
    {
        Uye Current;
        public Form4()
        {
            InitializeComponent();
            refresh();
            UyeCB.SelectedIndex = -1;
            AdTB.Text = "";
            SoyadTB.Text = "";
            TCKimlikTB.Text = "";
            TelefonTB.Text = "";
            AdresRTB.Text = "";
            Current = new Uye("", "", "",DateTime.Now);
        }

        private void refresh()
        {
            UyeCB.DataSource = UyeIslemleri.getMembers();
            UyeCB.ValueMember = "ID";
            UyeCB.DisplayMember = "Display";
        }

        private void UyeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UyeCB.SelectedIndex != -1)
            {
                Current = (Uye)UyeCB.SelectedItem;
                AdTB.Text = Current.Adi;
                SoyadTB.Text = Current.Soyadi;
                TCKimlikTB.Text = Current.TCKimlik;
                if (Current.Telefon != null)
                {
                    TelefonTB.Text = Current.Telefon;
                }
                if (Current.Adres != null)
                {
                    AdresRTB.Text = Current.Adres;
                }

            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (String.IsNullOrEmpty(AdTB.Text))
            {
                check = false;
                MessageBox.Show("Lütfen ad girin");
            }
            if (check && String.IsNullOrEmpty(SoyadTB.Text))
            {
                check = false;
                MessageBox.Show("Lütfen soyad girin");
            }
            if (check)
            {
                if (String.IsNullOrEmpty(TCKimlikTB.Text))
                {
                    check = false;
                    MessageBox.Show("Lütfen kimlik no girin");
                }
                else if (TCKimlikTB.Text.Length != 11)
                {
                    check = false;
                    MessageBox.Show("Geçersiz kimlik numarası");
                }
                else
                {
                    foreach (char item in TCKimlikTB.Text)
                    {
                        if (!Char.IsDigit(item))
                        {
                            check = false;
                            MessageBox.Show("Geçersiz kimlik numarası");
                            break;
                        }
                    }
                }
            }
            if (check && !String.IsNullOrEmpty(TelefonTB.Text))
            {
                foreach (char item in TelefonTB.Text)
                {
                    if (!Char.IsDigit(item) && item != '+' && item != '(' && item != ')')
                    {
                        check = false;
                        MessageBox.Show("Geçersiz telefon numarası");
                        break;
                    }
                }
            }
            if (check)
            {
                Current.Adi = AdTB.Text;
                Current.Soyadi = SoyadTB.Text;
                Current.TCKimlik = TCKimlikTB.Text;
                Current.Telefon = TelefonTB.Text;
                Current.Adres = AdresRTB.Text;
                int result = UyeIslemleri.record(Current);
                if ( result != 0)
                {
                    MessageBox.Show("Başarıyla kaydedildi\nÜye numarası : " + result.ToString());
                    refresh();
                    UyeCB.SelectedValue = result;
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu");
                }
            }
        }
    }
}
