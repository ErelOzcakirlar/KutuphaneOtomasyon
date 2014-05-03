using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessLayer
{
    public class RaporIslemleri
    {
        public static String convertToSqlDate(String DateString)
        {
            char[] dot = new char[] { '.' };
            String[] Values = DateString.Split(dot);
            return Values[1] + "." + Values[0] + "." + Values[2];
        }

        public static List<Uye> mostAciveMember(DateTime First, DateTime Last)
        {
            List<Uye> Value = new List<Uye>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select UyeID,COUNT(UyeID) as KiralamaSayisi from dbo.Kiralama" +
                " join dbo.KiralamaDetay on Kiralama.ID = KiralamaDetay.ID" +
                " where KiralamaDetay.KiralamaTarihi between";
            CommandString += " '" + convertToSqlDate(First.ToShortDateString()) + "' and";
            CommandString += " '" + convertToSqlDate(Last.ToShortDateString()) + "' group by UyeID";
            CommandString += " order by KiralamaSayisi desc";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int max=0;
            List<int> Uyeler = new List<int>();
            if (reader.Read())
            {
                max = reader.GetInt32(1);
                Uyeler.Add(reader.GetInt32(0));
            }
            while (reader.Read())
            {
                int currentCount = reader.GetInt32(1);
                if (currentCount == max)
                {
                    Uyeler.Add(reader.GetInt32(0));
                }
                else if (currentCount < max)
                {
                    break;
                }
            }
            reader.Close();
            con.Close();
            if(Uyeler.Count > 0)
            {
                CommandString = "select * from dbo.Uye where ";
                foreach (int item in Uyeler)
                {
                    CommandString += "ID=" + item.ToString() + " or ";
                }
                CommandString = CommandString.Remove(CommandString.Length - 4);
                cmd = new SqlCommand(CommandString, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye Current = new Uye(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(6));
                    try
                    {
                        Current.Adres = reader.GetString(4);
                    }
                    catch (SqlNullValueException snve)
                    {
                        Current.Adres = "";
                    }
                    try
                    {
                        Current.Telefon = reader.GetString(5);
                    }
                    catch (SqlNullValueException snve)
                    {
                        Current.Telefon = "";
                    }
                    Value.Add(Current);
                }
                reader.Close();
                con.Close();
            }
            
            return Value;
        }
        public static List<Kitap> mostRentedBook(DateTime First, DateTime Last)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select KitapID,COUNT(KitapID) as KiralamaSayisi from dbo.Kiralama" +
                " join dbo.KiralamaDetay on Kiralama.ID = KiralamaDetay.ID" +
                " where KiralamaDetay.KiralamaTarihi between";
            CommandString += " '" + convertToSqlDate(First.ToShortDateString()) + "' and";
            CommandString += " '" + convertToSqlDate(Last.ToShortDateString()) + "' group by KitapID";
            CommandString += " order by KiralamaSayisi desc";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int max = 0;
            List<int> Kitaplar = new List<int>();
            if (reader.Read())
            {
                max = reader.GetInt32(1);
                Kitaplar.Add(reader.GetInt32(0));
            }
            while (reader.Read())
            {
                int currentCount = reader.GetInt32(1);
                if (currentCount == max)
                {
                    Kitaplar.Add(reader.GetInt32(0));
                }
                else if (currentCount < max)
                {
                    break;
                }
            }
            reader.Close();
            con.Close();
            if (Kitaplar.Count > 0)
            {
                CommandString = "select * from dbo.Kitap where ";
                foreach (int item in Kitaplar)
                {
                    CommandString += "ID=" + item.ToString() + " or ";
                }
                CommandString = CommandString.Remove(CommandString.Length - 4);
                cmd = new SqlCommand(CommandString, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    SqlConnection AuthorCon = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
                    SqlCommand AuthorCmd = new SqlCommand("select YazarID from dbo.KitapYazar where KitapID = " + id.ToString(), AuthorCon);
                    AuthorCon.Open();
                    SqlDataReader AuthorReader = AuthorCmd.ExecuteReader();
                    List<Yazar> YazarList = new List<Yazar>();
                    while (AuthorReader.Read())
                    {
                        YazarList.Add(YazarIslemleri.getAuthor(AuthorReader.GetInt32(0)));
                    }
                    AuthorReader.Close();
                    AuthorCon.Close();
                    Yazar[] Yazarlar = null;
                    if (YazarList.Count > 0)
                    {
                        Yazarlar = new Yazar[YazarList.Count];
                        YazarList.CopyTo(Yazarlar);
                    }
                    Yayinevi Publisher = YayineviIslemleri.getPublisher(reader.GetInt32(3));
                    Kategori Category = KategoriIslemleri.getCategory(reader.GetInt32(4));
                    Kitap Current = new Kitap(id, reader.GetString(1), int.Parse(reader.GetString(2)), Yazarlar, Publisher, Category,
                        reader.GetInt32(5), reader.GetBoolean(7), reader.GetBoolean(6), reader.GetDecimal(8));
                    try
                    {
                        Current.Ozet = reader.GetString(9);
                    }
                    catch (SqlNullValueException snve)
                    {
                        Current.Ozet = "";
                    }
                    try
                    {
                        Current.Kapak = reader.GetString(10);
                    }
                    catch (SqlNullValueException snve)
                    {
                        Current.Kapak = "";
                    }
                    if (!Value.Contains(Current))
                    {
                        Value.Add(Current);
                    }
                }
                reader.Close();
                con.Close();
            }
            return Value;
        }
        public static List<Yazar> mostPopularAuthor(DateTime First, DateTime Last)
        {
            List<Yazar> Value = new List<Yazar>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select YazarID,COUNT(YazarID) as TercihSayisi from dbo.Kiralama ";
            CommandString += "join dbo.KiralamaDetay on Kiralama.ID = KiralamaDetay.ID ";
            CommandString += "join dbo.Kitap on Kitap.ID = Kiralama.KitapID ";
            CommandString += "join dbo.KitapYazar on Kitap.ID = KitapYazar.KitapID ";
            CommandString += "where KiralamaDetay.KiralamaTarihi between ";
            CommandString += "'" + convertToSqlDate(First.ToShortDateString()) + "' and ";
            CommandString += "'" + convertToSqlDate(Last.ToShortDateString()) + "'";
            CommandString += " group by YazarID order by TercihSayisi desc";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int max = 0;
            List<int> Authors = new List<int>();
            if (reader.Read())
            {
                max = reader.GetInt32(1);
                Authors.Add(reader.GetInt32(0));
            }
            while (reader.Read())
            {
                int currentCount = reader.GetInt32(1);
                if (currentCount == max)
                {
                    Authors.Add(reader.GetInt32(0));
                }
                else if (currentCount < max)
                {
                    break;
                }
            }
            reader.Close();
            con.Close();
            if (Authors.Count > 0)
            {
                CommandString = "select * from dbo.Yazar where ";
                foreach (int item in Authors)
                {
                    CommandString += "ID=" + item.ToString() + " or ";
                }
                CommandString = CommandString.Remove(CommandString.Length - 4);
                cmd = new SqlCommand(CommandString, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string adi = reader.GetString(1);
                    string soyadi = reader.GetString(2);
                    Yazar Current = new Yazar(id, adi, soyadi);
                    string ozgecmis;
                    try
                    {
                        ozgecmis = reader.GetString(3);
                    }
                    catch (SqlNullValueException snve)
                    {
                        ozgecmis = "";
                    }
                    Current.Ozgecmis = ozgecmis;
                    Value.Add(Current);
                }
                reader.Close();
                con.Close();
            }
            return Value;
        }
        public static List<Yayinevi> mostPopularPublisher(DateTime First, DateTime Last)
        {
            List<Yayinevi> Value = new List<Yayinevi>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select YayineviID,COUNT(YayineviID) as TercihSayisi from dbo.Kiralama ";
            CommandString += "join dbo.KiralamaDetay on Kiralama.ID = KiralamaDetay.ID ";
            CommandString += "join dbo.Kitap on Kitap.ID = Kiralama.KitapID ";
            CommandString += "where KiralamaDetay.KiralamaTarihi between ";
            CommandString += "'" + convertToSqlDate(First.ToShortDateString()) + "' and ";
            CommandString += "'" + convertToSqlDate(Last.ToShortDateString()) + "'";
            CommandString += " group by YayineviID order by TercihSayisi desc";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int max = 0;
            List<int> Publishers = new List<int>();
            if (reader.Read())
            {
                max = reader.GetInt32(1);
                Publishers.Add(reader.GetInt32(0));
            }
            while (reader.Read())
            {
                int currentCount = reader.GetInt32(1);
                if (currentCount == max)
                {
                    Publishers.Add(reader.GetInt32(0));
                }
                else if (currentCount < max)
                {
                    break;
                }
            }
            reader.Close();
            con.Close();
            if (Publishers.Count > 0)
            {
                CommandString = "select * from dbo.Yayinevi where ";
                foreach (int item in Publishers)
                {
                    CommandString += "ID=" + item.ToString() + " or ";
                }
                CommandString = CommandString.Remove(CommandString.Length - 4);
                cmd = new SqlCommand(CommandString, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string adi = reader.GetString(1);
                    Yayinevi Current = new Yayinevi(id, adi);
                    string adresi, kurulus;
                    int yil;
                    try
                    {
                        adresi = reader.GetString(2);
                    }
                    catch (SqlNullValueException snve)
                    {
                        adresi = "";
                    }
                    try
                    {
                        kurulus = reader.GetString(3);
                        yil = int.Parse(kurulus);
                    }
                    catch (SqlNullValueException snve)
                    {
                        yil = 0;
                    }


                    Current.Adres = adresi;
                    Current.KurulusYili = yil;
                    Value.Add(Current);
                }
                reader.Close();
                con.Close();
            }
            return Value;
        }
        public static List<Odeme> getPayments(DateTime First, DateTime Last, Bilesen Type)
        {
            List<Odeme> Value = new List<Odeme>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select Tarih,Uye.Adi,Uye.Soyadi,Aciklama,Tutar";
            if(Type == null)
            {
                CommandString += ",OdemeTipi.Adi";
                CommandString += " from dbo.Odeme";
                CommandString += " join dbo.Uye on Uye.ID = Odeme.UyeID";
                CommandString += " join dbo.OdemeTipi on OdemeTipi.ID = Odeme.OdemeTipi";
                CommandString += " where (Tarih between ";
                CommandString += "'" + convertToSqlDate(First.ToShortDateString()) + "' and ";
                CommandString += "'" + convertToSqlDate(Last.ToShortDateString()) + "')";
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Odeme Current = new Odeme(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetDecimal(4), reader.GetString(5));
                    Value.Add(Current);
                }
                reader.Close();
                con.Close();
            }
            else
            {
                CommandString += " from dbo.Odeme";
                CommandString += " join dbo.Uye on Uye.ID = Odeme.UyeID";
                CommandString += " join dbo.OdemeTipi on OdemeTipi.ID = Odeme.OdemeTipi";
                CommandString += " where (Tarih between ";
                CommandString += "'" + convertToSqlDate(First.ToShortDateString()) + "' and ";
                CommandString += "'" + convertToSqlDate(Last.ToShortDateString()) + "')";
                CommandString += " and (Odeme.OdemeTipi=" + Type.ID.ToString() + ")";
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Odeme Current = new Odeme(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetDecimal(4), "");
                    Value.Add(Current);
                }
                reader.Close();
                con.Close();
            }
            
            return Value;
        }
    }
}
