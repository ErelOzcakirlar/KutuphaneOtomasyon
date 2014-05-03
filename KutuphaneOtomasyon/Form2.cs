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
    public partial class Form2 : Form
    {
        Kitap Current;
        public Form2(String Title, Kitap Addition)
        {
            InitializeComponent();

            YazarCB.DataSource = YazarIslemleri.getAuthors();
            YazarCB.SelectedIndex = -1;
            YazarList.Items.Clear();

            YayineviCB.DataSource = YayineviIslemleri.getPublishers();
            KategoriCB.DataSource = KategoriIslemleri.getCategories();

            this.Text = Title;
            Current = Addition;

            KitapTB.Text = Current.Adi;

            BasimYiliNUD.Maximum = DateTime.Now.Year;
            BasimYiliNUD.Value = Current.BasimYili;

            SayfaSayisiNUD.Maximum = Decimal.MaxValue;
            SayfaSayisiNUD.Value = Current.SayfaSayisi;

            FiyatTB.Text = Current.Fiyat.ToString();

            Hasar.Checked = Current.HasarDurumu;

            KapakTB.Text = Current.Kapak;

            OzetRTB.Text = Current.Ozet;

            if (Current.Publisher != null)
            {
                if (YayineviCB.Items.Contains(Current.Publisher))
                {
                    YayineviCB.SelectedItem = Current.Publisher;
                }
                else
                {
                    YayineviCB.Text = Current.Publisher.Adi;
                    YayineviCB.SelectedIndex = -1;
                }
            }
            else
            {
                YayineviCB.SelectedIndex = -1;
            }

            if (Current.Category != null)
            {
                if (KategoriCB.Items.Contains(Current.Category))
                {
                    KategoriCB.SelectedItem = Current.Category;
                }
                else
                {
                    KategoriCB.Text = Current.Category.Adi;
                    KategoriCB.SelectedIndex = -1;
                }
            }
            else
            {
                KategoriCB.SelectedIndex = -1;
            }

            if (Current.Author != null)
            {
                YazarList.Items.AddRange(Current.Author);
            }

        }

        private void refreshAuthors()
        {
            int first = YazarList.Items.Count;
            Yazar Selected = (Yazar)YazarCB.SelectedItem;
            YazarCB.DataSource = YazarIslemleri.getAuthors();
            int last = YazarList.Items.Count;
            if (Selected != null)
            {
                if (YazarCB.Items.Contains(Selected))
                {
                    YazarCB.SelectedItem = Selected;
                }
            }
            else
            {
                YazarCB.SelectedIndex = -1;
            }
            for (int i = first; i < last; i++)
            {
                YazarList.Items.RemoveAt(i);
            }
        }

        private void YayineviDuzenle_Click(object sender, EventArgs e)
        {
            if (YayineviCB.SelectedIndex != -1)
            {
                Form3 Edit = new Form3("Yayınevi Düzenle", (Yayinevi)YayineviCB.SelectedItem, Form3.YAYINEVI);
                Edit.ShowDialog();
            }
            else if (!String.IsNullOrEmpty(YayineviCB.Text))
            {
                int id = YayineviIslemleri.record(new Yayinevi(YayineviCB.Text));
                if (id != 0)
                {
                    YayineviCB.DataSource = YayineviIslemleri.getPublishers();
                    foreach (Yayinevi item in YayineviCB.Items)
                    {
                        if (item.ID == id)
                        {
                            YayineviCB.SelectedItem = item;
                            break;
                        }
                    }
                    Form3 Edit = new Form3("Yayınevi Düzenle", (Yayinevi)YayineviCB.SelectedItem, Form3.YAYINEVI);
                    Edit.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Lütfen düzenlenecek kategoriyi seçin");
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek yayınevini seçin");
            }
        }

        private void KategoriDuzenle_Click(object sender, EventArgs e)
        {
            if (KategoriCB.SelectedIndex != -1)
            {
                Form3 Edit = new Form3("Kategori Düzenle", (Kategori)KategoriCB.SelectedItem, Form3.KATEGORI);
                Edit.ShowDialog();
            }
            else if (!String.IsNullOrEmpty(KategoriCB.Text))
            {
                int id = KategoriIslemleri.record(new Kategori(KategoriCB.Text));
                if (id != 0)
                {
                    KategoriCB.DataSource = KategoriIslemleri.getCategories();
                    foreach (Kategori item in KategoriCB.Items)
                    {
                        if (item.ID == id)
                        {
                            KategoriCB.SelectedItem = item;
                            break;
                        }
                    }
                    Form3 Edit = new Form3("Kategori Düzenle", (Kategori)KategoriCB.SelectedItem, Form3.KATEGORI);
                    Edit.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Lütfen düzenlenecek kategoriyi seçin");
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek kategoriyi seçin");
            }
        }

        private void YazarCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YazarCB.SelectedIndex != -1 && !YazarList.Items.Contains(YazarCB.SelectedItem))
            {
                YazarList.Items.Add(YazarCB.SelectedItem);
            }
        }

        private void YazarEkle_Click(object sender, EventArgs e)
        {
            bool check = false;
            String[] AdSoyad = YazarIslemleri.seperateName(YazarCB.Text);
            String Ad = AdSoyad[0];
            String Soyad = AdSoyad[1];
            foreach (Yazar item in YazarCB.Items)
            {
                if (item.Adi.Equals(Ad) && item.Soyadi.Equals(Soyad) && !YazarList.Items.Contains(item))
                {
                    YazarList.Items.Add(item);
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                Yazar Current = new Yazar(Ad, Soyad);
                if (!YazarList.Items.Contains(Current))
                {
                    YazarList.Items.Add(Current);
                }
            }
        }

        private void YazarDuzenle_Click(object sender, EventArgs e)
        {
            if (YazarList.SelectedIndex != -1)
            {
                Yazar Edition = (Yazar)YazarList.SelectedItem;
                if (Edition.ID == 0)
                {
                    int id = YazarIslemleri.record(Edition);
                    if (id != 0)
                    {
                        YazarList.Items.Remove(YazarList.SelectedItem);
                        Edition = YazarIslemleri.getAuthor(id);
                        YazarList.Items.Add(Edition);
                        YazarList.SelectedItem = Edition;
                        
                    }
                }
                Form3 Edit = new Form3("Yazar Düzenle", Edition, Form3.YAZAR);
                Edit.ShowDialog();
                refreshAuthors();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek yazarı seçin");
            }
        }

        private void YazarListSil_Click(object sender, EventArgs e)
        {
            if (YazarList.SelectedIndex != -1)
            {
                YazarList.Items.Remove(YazarList.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek filtreyi seçin");
            }
        }

        private void YazarListTemizle_Click(object sender, EventArgs e)
        {
            YazarList.Items.Clear();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal Fiyat = Decimal.Parse(FiyatTB.Text);

                bool check = true;
                if (String.IsNullOrEmpty(KitapTB.Text))
                {
                    check = false;
                    MessageBox.Show("Lütfen kitap adını girin");
                }
                if (check && String.IsNullOrEmpty(YayineviCB.Text))
                {
                    check = false;
                    MessageBox.Show("Lütfen yayınevi girin");
                }
                if (check && String.IsNullOrEmpty(KategoriCB.Text))
                {
                    check = false;
                    MessageBox.Show("Lütfen kategori girin");
                }
                if (check)
                {
                    Current.Adi = KitapTB.Text;
                    Current.BasimYili = (int)BasimYiliNUD.Value;
                    if (YazarList.Items.Count > 0)
                    {
                        Yazar[] Yazarlar = new Yazar[YazarList.Items.Count];
                        YazarList.Items.CopyTo(Yazarlar, 0);
                        Current.Author = Yazarlar;
                    }
                    if (YayineviCB.SelectedIndex != -1)
                    {
                        Current.Publisher = (Yayinevi)YayineviCB.SelectedItem;
                    }
                    else
                    {
                        String Isim = YayineviCB.Text;
                        bool added = false;
                        foreach (Yayinevi item in YayineviCB.Items)
                        {
                            if (item.Adi.Equals(Isim))
                            {
                                Current.Publisher = item;
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            Current.Publisher = new Yayinevi(Isim);
                        }
                    }
                    if (KategoriCB.SelectedIndex != -1)
                    {
                        Current.Category = (Kategori)KategoriCB.SelectedItem;
                    }
                    else
                    {
                        String Isim = KategoriCB.Text;
                        bool added = false;
                        foreach (Kategori item in KategoriCB.Items)
                        {
                            if (item.Adi.Equals(Isim))
                            {
                                Current.Category = item;
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            Current.Category = new Kategori(Isim);
                        }
                    }
                    Current.SayfaSayisi = (int)SayfaSayisiNUD.Value;
                    Current.HasarDurumu = Hasar.Checked;
                    Current.Fiyat = Fiyat;
                    Current.Ozet = OzetRTB.Text;
                    Current.Kapak = KapakTB.Text;
                    if (KitapIslemleri.record(Current))
                    {
                        MessageBox.Show("Başarıyla kaydedildi");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt sırasında bir hata oluştu");
                    }
                    this.Close();
                }


            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("Fiyat kaydedilirken hata oluştu\n" + ane.Message);
            }
            catch (FormatException nfe)
            {
                MessageBox.Show("Fiyat kaydedilirken hata oluştu\n" + nfe.Message);
            }
            catch (OverflowException oe)
            {
                MessageBox.Show("Fiyat kaydedilirken hata oluştu\n" + oe.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
