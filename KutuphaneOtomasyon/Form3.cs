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
    public partial class Form3 : Form
    {
        public static int YAZAR = 0;
        public static int YAYINEVI = 1;
        public static int KATEGORI = 2;
        Yazar CurrentYaz;
        Yayinevi CurrentYay;
        Kategori CurrentKat;
        int Type;

        public Form3(String Title, Object Edition, int type)
        {
            InitializeComponent();
            this.Text = Title;
            KurulusYiliNUD.Maximum = DateTime.Now.Year;
            this.Type = type;
            switch (Type)
            {
                case 0:
                    label5.Text = "Yazar :";
                    comboBox1.DataSource = YazarIslemleri.getAuthors();
                    label2.Text = "Özgeçmiş :";
                    label4.Hide();
                    KurulusYiliNUD.Hide();
                    KurulusYiliCB.Hide();

                    CurrentYaz = (Yazar)Edition;

                    if (comboBox1.Items.Contains(CurrentYaz))
                    {
                        comboBox1.SelectedItem = CurrentYaz;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = -1;
                        AdiTB.Text = CurrentYaz.Adi;
                        SoyadiTB.Text = CurrentYaz.Soyadi;
                        richTextBox1.Text = CurrentYaz.Ozgecmis;
                    }

                    break;
                case 1:
                    label5.Text = "Yayınevi :";
                    comboBox1.DataSource = YayineviIslemleri.getPublishers();
                    label2.Text = "Adres :";
                    label3.Hide();
                    SoyadiTB.Hide();
                    KurulusYiliNUD.Enabled = false;
                    KurulusYiliCB.Checked = false;

                    CurrentYay = (Yayinevi)Edition;

                    if (comboBox1.Items.Contains(CurrentYay))
                    {
                        comboBox1.SelectedItem = CurrentYay;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = -1;
                        AdiTB.Text = CurrentYay.Adi;
                        richTextBox1.Text = CurrentYay.Adres;
                        if (CurrentYay.KurulusYili != 0)
                        {
                            KurulusYiliNUD.Value = CurrentYay.KurulusYili;
                            KurulusYiliCB.Checked = true;
                        }
                    }
                    break;
                case 2:
                    comboBox1.DataSource = KategoriIslemleri.getCategories();
                    label3.Hide();
                    SoyadiTB.Hide();
                    label4.Hide();
                    KurulusYiliNUD.Hide();
                    KurulusYiliCB.Hide();

                    CurrentKat = (Kategori)Edition;

                    if (comboBox1.Items.Contains(CurrentKat))
                    {
                        comboBox1.SelectedItem = CurrentKat;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = -1;
                        AdiTB.Text = CurrentKat.Adi;
                        richTextBox1.Text = CurrentKat.Aciklama;
                    }
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                switch (Type)
                {
                    case 0:
                        CurrentYaz = (Yazar)comboBox1.SelectedItem;
                        AdiTB.Text = CurrentYaz.Adi;
                        SoyadiTB.Text = CurrentYaz.Soyadi;
                        richTextBox1.Text = CurrentYaz.Ozgecmis;
                        break;
                    case 1:
                        CurrentYay = (Yayinevi)comboBox1.SelectedItem;
                        AdiTB.Text = CurrentYay.Adi;
                        richTextBox1.Text = CurrentYay.Adres;
                        if (CurrentYay.KurulusYili != 0)
                        {
                            KurulusYiliNUD.Value = CurrentYay.KurulusYili;
                            KurulusYiliCB.Checked = true;
                        }
                        break;
                    case 2:
                        CurrentKat = (Kategori)comboBox1.SelectedItem;
                        AdiTB.Text = CurrentKat.Adi;
                        richTextBox1.Text = CurrentKat.Aciklama;
                        break;
                }
            }

        }

        private void KurulusYiliCB_CheckedChanged(object sender, EventArgs e)
        {
            KurulusYiliNUD.Enabled = KurulusYiliCB.Checked;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AdiTB.Text))
            {
                MessageBox.Show("Lütfen bir isim girin");
            }
            else
            {
                switch (this.Type)
                {
                    case 0:
                        CurrentYaz.Adi = AdiTB.Text;
                        CurrentYaz.Soyadi = SoyadiTB.Text;
                        CurrentYaz.Ozgecmis = richTextBox1.Text;
                        if (YazarIslemleri.record(CurrentYaz) != 0)
                        {
                            MessageBox.Show("Başarıyla kaydedildi");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt sırasında bir hata oluştu");
                        }
                        break;
                    case 1:
                        CurrentYay.Adi = AdiTB.Text;
                        CurrentYay.Adres = richTextBox1.Text;
                        if (KurulusYiliCB.Checked)
                        {
                            CurrentYay.KurulusYili = (int)KurulusYiliNUD.Value;
                        }
                        if (YayineviIslemleri.record(CurrentYay) != 0)
                        {
                            MessageBox.Show("Başarıyla kaydedildi");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt sırasında bir hata oluştu");
                        }
                        break;
                    case 2:
                        CurrentKat.Adi = AdiTB.Text;
                        CurrentKat.Aciklama = richTextBox1.Text;
                        if (KategoriIslemleri.record(CurrentKat) != 0)
                        {
                            MessageBox.Show("Başarıyla kaydedildi");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt sırasında bir hata oluştu");
                        }
                        break;
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
