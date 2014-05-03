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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshAuthors();
            setList();
            BasimYiliNUD.Maximum = DateTime.Now.Year;
            BasimYiliNUD.Value = DateTime.Now.Year;
        }

        private void setList()
        {
            String KitapAdi = KitapTB.Text.Replace("'","");
            int yazar = YazarList.Items.Count;
            int basimyili = BasimYiliList.Items.Count;

            if (!String.IsNullOrEmpty(KitapAdi))
            {
                KitapAdi = KitapAdi.Trim().Replace(' ', '%');
                if (yazar > 0)
                {
                    Yazar[] Yazarlar = new Yazar[yazar];
                    YazarList.Items.CopyTo(Yazarlar, 0);

                    if (basimyili > 0)
                    {
                        int[] Yillar = new int[basimyili];
                        for (int i = 0; i < basimyili; i++)// CopyTo çalışmadı
                        {
                            Yillar[i] = (int)(BasimYiliList.Items[i]);
                        }
                        KitapList.DataSource = KitapIslemleri.search(KitapAdi, Yazarlar, Yillar);
                    }
                    else
                    {
                        KitapList.DataSource = KitapIslemleri.search(KitapAdi, Yazarlar);
                    }
                }
                else
                {
                    if (basimyili > 0)
                    {
                        int[] Yillar = new int[basimyili];
                        for (int i = 0; i < basimyili; i++)
                        {
                            Yillar[i] = (int)(BasimYiliList.Items[i]);
                        }
                        KitapList.DataSource = KitapIslemleri.search(KitapAdi, Yillar);
                    }
                    else
                    {
                        KitapList.DataSource = KitapIslemleri.search(KitapAdi);
                    }
                }
            }
            else
            {
                if (yazar > 0)
                {
                    Yazar[] Yazarlar = new Yazar[yazar];
                    YazarList.Items.CopyTo(Yazarlar, 0);

                    if (basimyili > 0)
                    {
                        int[] Yillar = new int[basimyili];
                        for (int i = 0; i < basimyili; i++)
                        {
                            Yillar[i] = (int)(BasimYiliList.Items[i]);
                        }
                        KitapList.DataSource = KitapIslemleri.search(Yazarlar, Yillar);
                    }
                    else
                    {
                        KitapList.DataSource = KitapIslemleri.search(Yazarlar);
                    }
                }
                else
                {
                    if (basimyili > 0)
                    {
                        int[] Yillar = new int[basimyili];
                        for (int i = 0; i < basimyili; i++)
                        {
                            Yillar[i] = (int)(BasimYiliList.Items[i]);
                        }
                        KitapList.DataSource = KitapIslemleri.search(Yillar);
                    }
                    else
                    {
                        KitapList.DataSource = new List<Kitap>();
                    }
                }
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

        private void KitapTB_TextChanged(object sender, EventArgs e)
        {
            setList();
        }

        private void YazarCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YazarCB.SelectedIndex != -1 && !YazarList.Items.Contains(YazarCB.SelectedItem))
            {
                YazarList.Items.Add(YazarCB.SelectedItem);
                setList();
            }

        }

        private void YazarFEB_Click(object sender, EventArgs e)
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
            setList();
        }

        private void YazarListSil_Click(object sender, EventArgs e)
        {
            if (YazarList.SelectedIndex != -1)
            {
                YazarList.Items.Remove(YazarList.SelectedItem);
                setList();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek filtreyi seçin");
            }
        }

        private void YazarListTemizle_Click(object sender, EventArgs e)
        {
            YazarList.Items.Clear();
            setList();
        }

        private void BasimYiliFEB_Click(object sender, EventArgs e)
        {
            if (!BasimYiliList.Items.Contains((int)BasimYiliNUD.Value))
            {
                BasimYiliList.Items.Add((int)BasimYiliNUD.Value);
                setList();
            }

        }

        private void BasimYiliListSil_Click(object sender, EventArgs e)
        {
            if (BasimYiliList.SelectedIndex != -1)
            {
                BasimYiliList.Items.Remove(BasimYiliList.SelectedItem);
                setList();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek filtreyi seçin");
            }
        }

        private void BasimYiliListTemizle_Click(object sender, EventArgs e)
        {
            BasimYiliList.Items.Clear();
            setList();
        }

        private void KitapEkle_Click(object sender, EventArgs e)
        {
            Kitap Yeni = new Kitap(null, (int)BasimYiliNUD.Value, null, null, null, 0, false, false, 0);
            if (!String.IsNullOrEmpty(KitapTB.Text))
            {
                Yeni.Adi = KitapTB.Text;
            }
            if (BasimYiliList.Items.Count == 1)
            {
                Yeni.BasimYili = (int)BasimYiliList.Items[0];
            }
            if (!String.IsNullOrEmpty(YazarCB.Text))
            {
                String[] AdSoyad = YazarIslemleri.seperateName(YazarCB.Text);
                String Ad = AdSoyad[0];
                String Soyad = AdSoyad[1];
                bool check = false;
                foreach (Yazar item in YazarCB.Items)
                {
                    if (item.Adi.Equals(Ad) && item.Soyadi.Equals(Soyad))
                    {
                        check = true;
                        break;
                    }
                }
                Yazar[] Yazarlar;
                if (check)
                {
                    Yazarlar = new Yazar[YazarList.Items.Count];
                    YazarList.Items.CopyTo(Yazarlar, 0);
                }
                else
                {
                    Yazarlar = new Yazar[YazarList.Items.Count + 1];
                    YazarList.Items.CopyTo(Yazarlar, 0);
                    Yazarlar[YazarList.Items.Count] = new Yazar(Ad, Soyad);
                }
                Yeni.Author = Yazarlar;
            }
            else if (YazarList.Items.Count > 0)
            {
                Yazar[] Yazarlar = new Yazar[YazarList.Items.Count];
                YazarList.Items.CopyTo(Yazarlar, 0);
                Yeni.Author = Yazarlar;
            }
            Form2 EkleForm = new Form2("Yeni Kitap Ekle", Yeni);
            EkleForm.ShowDialog();
            refreshAuthors();
            setList();

        }

        private void KitapDuzenle_Click(object sender, EventArgs e)
        {
            if (KitapList.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz kitabı seçin");
            }
            else
            {
                Form2 DuzenleForm = new Form2("Kitap Düzenle", (Kitap)KitapList.SelectedItem);
                DuzenleForm.ShowDialog();
                refreshAuthors();
                setList();
            }
        }

        private void YazarDuzenle_Click(object sender, EventArgs e)
        {
            Form3 Edit = new Form3("Yazar Düzenle", new Yazar("",""), Form3.YAZAR);
            Edit.ShowDialog();
            refreshAuthors();
            setList();
        }

        private void KategoriDuzenle_Click(object sender, EventArgs e)
        {
            Form3 Edit = new Form3("Kategori Düzenle", new Kategori(""), Form3.KATEGORI);
            Edit.ShowDialog();
            setList();
        }

        private void YayineviDuzenle_Click(object sender, EventArgs e)
        {
            Form3 Edit = new Form3("Yayınevi Düzenle", new Yayinevi(""), Form3.YAYINEVI);
            Edit.ShowDialog();
            setList();
        }

        private void UyeDuzenle_Click(object sender, EventArgs e)
        {
            Form4 Edit = new Form4();
            Edit.ShowDialog();
        }

        private void KitapKirala_Click(object sender, EventArgs e)
        {
            if (KitapList.Items.Count == 0)
            {
                MessageBox.Show("Lütfen kiralamak istediğiniz kitabı aratarak bulun ve seçin");
            }
            else if (KitapList.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kiralamak istediğiniz kitabı seçin");
            }
            else
            {
                Kitap Temp = (Kitap)KitapList.SelectedItem;
                if (Temp.KiralamaDurumu)
                {
                    MessageBox.Show("Tebrikler! Az önce zaten kiralanmış bir kitabı kiralamaya çalıştınız\n" +
                        "Eğer şu an karşınızda 'Ben bu kitabı kiralamak istiyorum' diyerek seçtiğiniz kitabı size uzatan bir üye varsa,\n" +
                        "Şu olaylardan biri olmuş olabilir;\n" +
                        "1-) Hanzonun biri kitabı teslim etmeyi geciktirince kitabı kütüphaneye çaktırmadan bırakıp tüyümüş olabilir,\n" +
                        "2-) Öküzün biri (bu öküz siz de olabilirsiniz) kitabı teslim almış ancak sisteme teslim alma girişi yapmamış olabilir,\n" +
                        "   (Bu öküzü tespit ederseniz kendisine ödemeyi nasıl tahsil ettiğini sorun)\n" +
                        "3-) Yine aynı veya benzeri bir öküz kitabı kiralamadığı halde sisteme kiralama girişi yapmış olabilir.");
                }
                else
                {
                    Form5 Kirala = new Form5(Form5.KIRALA, Temp);
                    Kirala.ShowDialog();
                    setList();
                }
            }
        }

        private void KitapTeslimAl_Click(object sender, EventArgs e)
        {
            if (KitapList.Items.Count == 0)
            {
                MessageBox.Show("Lütfen teslim almak istediğiniz kitabı aratarak bulun ve seçin");
            }
            else if (KitapList.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen teslim almak istediğiniz kitabı seçin");
            }
            else
            {
                Kitap Temp = (Kitap)KitapList.SelectedItem;
                if (!Temp.KiralamaDurumu)
                {
                    MessageBox.Show("Tebrikler! Az önce zaten kütüphanede olan bir kitabı teslim almaya çalıştınız\n" +
                        "Eğer şu an karşınızda 'Ben bu kitabı teslim etmek istiyorum' diyerek seçtiğiniz kitabı size uzatan bir üye varsa,\n" +
                        "Şu olaylardan biri olmuş olabilir;\n" +
                        "1-) Şu an size bakan üye kitabı kütüphaneden alırken kimseye bir şey söylememiş olabilir,\n" +
                        "2-) Öküzün biri (bu öküz siz de olabilirsiniz) kitabı kiralamış ancak sisteme kiralama girişi yapmamış olabilir,\n" +
                        "3-) Yine aynı veya benzeri bir öküz kitabı teslim aldığı halde sisteme teslim alma girişi yapmamış olabilir.\n" +
                        "    (Böyle bir öküz tespit ederseniz kendisine ödemeyi nasıl tahsil ettiğini sorun)");
                }
                else
                {
                    Form5 TeslimAl = new Form5(Form5.TESLIM_AL, Temp);
                    TeslimAl.ShowDialog();
                    setList();
                }
            }
        }

        private void RaporAl_Click(object sender, EventArgs e)
        {
            Form7 Rapor = new Form7();
            Rapor.ShowDialog();
        }
    }
}
