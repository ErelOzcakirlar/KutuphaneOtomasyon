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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            dateTimeFirst.Value = DateTime.Now.Date;
            dateTimeLast.Value = DateTime.Now.Date;
            dateTimeLast.MinDate = dateTimeFirst.Value;
            List<Bilesen> OdemeTipleri = KiralamaIslemleri.getPayTypes();
            OdemeTipiCB.Items.Add("Tümü");
            foreach (Bilesen item in OdemeTipleri)
            {
                OdemeTipiCB.Items.Add(item);
            }
            label5.Hide();
            OdemeTipiCB.Hide();
        }

        private void setDateTime()
        {
            int period = PeriyotCB.SelectedIndex;
            DateTime Current = dateTimeFirst.Value;
            switch (period)
            {
                case -1:
                case 0:
                    if (dateTimeLast.Value < dateTimeFirst.Value)
                    {
                        dateTimeLast.MinDate = dateTimeFirst.Value;
                        dateTimeLast.Value = dateTimeFirst.Value;
                    }
                    break;
                case 1:
                    dateTimeLast.MinDate = dateTimeFirst.Value;
                    dateTimeLast.Value = dateTimeFirst.Value;
                    break;
                case 2:
                    while (Current.DayOfWeek != DayOfWeek.Monday)
                    {
                        Current = Current.AddDays(-1);
                    }
                    if (Current != dateTimeFirst.Value)
                    {
                        dateTimeFirst.Value = Current;
                    }
                    dateTimeLast.MinDate = dateTimeFirst.Value;
                    dateTimeLast.Value = Current.AddDays(6);
                    break;
                case 3:
                    if (Current.Day > 1)
                    {
                        Current = Current.AddDays(1 - Current.Day);
                    }
                    if (Current != dateTimeFirst.Value)
                    {
                        dateTimeFirst.Value = Current;
                    }
                    if (Current.Month == 2)
                    {
                        if (DateTime.IsLeapYear(Current.Year))
                        {
                            dateTimeLast.MinDate = dateTimeFirst.Value;
                            dateTimeLast.Value = Current.AddDays(28);
                        }
                        else
                        {
                            dateTimeLast.MinDate = dateTimeFirst.Value;
                            dateTimeLast.Value = Current.AddDays(27);
                        }
                    }
                    else if (Current.Month == 4 || Current.Month == 6 || Current.Month == 9 || Current.Month == 11)
                    {
                        dateTimeLast.MinDate = dateTimeFirst.Value;
                        dateTimeLast.Value = Current.AddDays(29);
                    }
                    else
                    {
                        dateTimeLast.MinDate = dateTimeFirst.Value;
                        dateTimeLast.Value = Current.AddDays(30);
                    }
                    break;
                case 4:
                    if (Current.DayOfYear > 1)
                    {
                        Current = Current.AddDays(1 - Current.DayOfYear);
                    }
                    if (Current != dateTimeFirst.Value)
                    {
                        dateTimeFirst.Value = Current;
                    }
                    if (DateTime.IsLeapYear(Current.Year))
                    {
                        dateTimeLast.MinDate = dateTimeFirst.Value;
                        dateTimeLast.Value = Current.AddDays(365);
                    }
                    else
                    {
                        dateTimeLast.MinDate = dateTimeFirst.Value;
                        dateTimeLast.Value = Current.AddDays(364);
                    }
                    break;
            }
        }

        private void TypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCB.SelectedIndex == 4)
            {
                label5.Show();
                OdemeTipiCB.Show();
            }
            else
            {
                label5.Hide();
                OdemeTipiCB.Hide();
            }
        }

        private void PeriyotCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PeriyotCB.SelectedIndex == 0 || PeriyotCB.SelectedIndex == -1)
            {
                dateTimeLast.Enabled = true;
                setDateTime();
            }
            else
            {
                dateTimeLast.Enabled = false;
                setDateTime();
            }
        }

        private void dateTimeFirst_ValueChanged(object sender, EventArgs e)
        {
            setDateTime();
        }

        private void Raporla_Click(object sender, EventArgs e)
        {
            ResultList.Items.Clear();
            int index = TypeCB.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Lütfen rapor türünü seçin");
            }
            else if (index == 0)
            {
                List<Kitap> Kitaplar = RaporIslemleri.mostRentedBook(dateTimeFirst.Value, dateTimeLast.Value);
                foreach (Kitap item in Kitaplar)
                {
                    ResultList.Items.Add(item);
                }
                if (ResultList.Items.Count == 0)
                {
                    ResultList.Items.Add("Seçtiğiniz tarih aralığında kitap kiralama işlemi yapılmamıştır");
                }
            }
            else if (index == 1)
            {
                List<Uye> Uyeler = RaporIslemleri.mostAciveMember(dateTimeFirst.Value, dateTimeLast.Value);
                foreach (Uye item in Uyeler)
                {
                    ResultList.Items.Add(item);
                }
                if (ResultList.Items.Count == 0)
                {
                    ResultList.Items.Add("Seçtiğiniz tarih aralığında kitap kiralama işlemi yapılmamıştır");
                }
            }
            else if (index == 2)
            {
                List<Yazar> Authors = RaporIslemleri.mostPopularAuthor(dateTimeFirst.Value, dateTimeLast.Value);
                foreach (Yazar item in Authors)
                {
                    ResultList.Items.Add(item);
                }
                if (ResultList.Items.Count == 0)
                {
                    ResultList.Items.Add("Seçtiğiniz tarih aralığında kitap kiralama işlemi yapılmamıştır");
                }
            }
            else if (index == 3)
            {
                List<Yayinevi> Publishers = RaporIslemleri.mostPopularPublisher(dateTimeFirst.Value, dateTimeLast.Value);
                foreach (Yayinevi item in Publishers)
                {
                    ResultList.Items.Add(item);
                }
                if (ResultList.Items.Count == 0)
                {
                    ResultList.Items.Add("Seçtiğiniz tarih aralığında kitap kiralama işlemi yapılmamıştır");
                }
            }
            else
            {
                if (OdemeTipiCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir ödeme tipi seçin");
                }
                else if (OdemeTipiCB.SelectedIndex == 0)
                {
                    List<Odeme> Payments = RaporIslemleri.getPayments(dateTimeFirst.Value, dateTimeLast.Value, null);
                    foreach (Odeme item in Payments)
                    {
                        ResultList.Items.Add(item);
                    }
                    if (ResultList.Items.Count == 0)
                    {
                        ResultList.Items.Add("Seçtiğiniz tarih aralığında ödeme işlemi yapılmamıştır");
                    }
                }
                else
                {
                    List<Odeme> Payments = RaporIslemleri.getPayments(dateTimeFirst.Value, dateTimeLast.Value, (Bilesen)OdemeTipiCB.SelectedItem);
                    foreach (Odeme item in Payments)
                    {
                        ResultList.Items.Add(item);
                    }
                    if (ResultList.Items.Count == 0)
                    {
                        ResultList.Items.Add("Seçtiğiniz tarih aralığında ödeme işlemi yapılmamıştır");
                    }
                }
            }
        }
    }
}
