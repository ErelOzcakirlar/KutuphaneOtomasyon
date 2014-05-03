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
    public class KitapIslemleri
    {
        #region Search
        public static List<Kitap> search(string kitapAdi)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select * from dbo.Kitap where Adi like '%" + kitapAdi + "%'";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
                Value.Add(Current);
            }
            reader.Close();
            con.Close();
            return Value;
        }
        public static List<Kitap> search(Yazar[] yazarlar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select ID,Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Ozet,Kapak ";
            CommandString += "from dbo.Kitap join dbo.KitapYazar on dbo.Kitap.ID = dbo.KitapYazar.KitapID where ";
            int counter = 0;
            foreach (Yazar item in yazarlar)
            {
                if (item.ID != 0)
                {
                    CommandString += "dbo.KitapYazar.YazarID=" + item.ID.ToString() + " or ";
                    counter++;
                }
            }
            if (counter > 0)
            {
                CommandString = CommandString.Remove(CommandString.Length - 4);
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
        public static List<Kitap> search(int[] yillar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select * from dbo.Kitap where ";
            foreach (int item in yillar)
            {
                CommandString += "dbo.Kitap.BasimYili='" + item.ToString() + "' or ";
            }
            CommandString = CommandString.Remove(CommandString.Length - 4);
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        public static List<Kitap> search(string kitapAdi, Yazar[] yazarlar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select ID,Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Ozet,Kapak ";
            CommandString += "from dbo.Kitap join dbo.KitapYazar on dbo.Kitap.ID = dbo.KitapYazar.KitapID where ";
            CommandString += "(Adi like '%" + kitapAdi + "%') and (";
            int counter = 0;
            foreach (Yazar item in yazarlar)
            {
                if (item.ID != 0)
                {
                    CommandString += "dbo.KitapYazar.YazarID=" + item.ID.ToString() + " or ";
                    counter++;
                }
            }
            if (counter > 0)
            {
                CommandString = CommandString.Remove(CommandString.Length - 4);
                CommandString += ")";
            }
            else
            {
                CommandString = CommandString.Remove(CommandString.Length - 6);
            }
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        public static List<Kitap> search(string kitapAdi, int[] yillar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select * from dbo.Kitap where ";
            CommandString += "(Adi like '%" + kitapAdi + "%') and (";
            foreach (int item in yillar)
            {
                CommandString += "dbo.Kitap.BasimYili='" + item.ToString() + "' or ";
            }
            CommandString = CommandString.Remove(CommandString.Length - 4);
            CommandString += ")";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        public static List<Kitap> search(Yazar[] yazarlar, int[] yillar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select ID,Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Ozet,Kapak ";
            CommandString += "from dbo.Kitap join dbo.KitapYazar on dbo.Kitap.ID = dbo.KitapYazar.KitapID where (";
            int counter = 0;
            foreach (Yazar item in yazarlar)
            {
                if (item.ID != 0)
                {
                    CommandString += "dbo.KitapYazar.YazarID=" + item.ID.ToString() + " or ";
                    counter++;
                }
            }
            if (counter > 0)
            {
                CommandString = CommandString.Remove(CommandString.Length - 4);
                CommandString += ") and (";
            }
            foreach (int item in yillar)
            {
                CommandString += "dbo.Kitap.BasimYili='" + item.ToString() + "' or ";
            }
            CommandString = CommandString.Remove(CommandString.Length - 4);
            CommandString += ")";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        public static List<Kitap> search(string kitapAdi, Yazar[] yazarlar, int[] yillar)
        {
            List<Kitap> Value = new List<Kitap>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "select ID,Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Ozet,Kapak ";
            CommandString += "from dbo.Kitap join dbo.KitapYazar on dbo.Kitap.ID = dbo.KitapYazar.KitapID where ";
            CommandString += "(Adi like '%" + kitapAdi + "%') and (";
            int counter = 0;
            foreach (Yazar item in yazarlar)
            {
                if (item.ID != 0)
                {
                    CommandString += "dbo.KitapYazar.YazarID=" + item.ID.ToString() + " or ";
                    counter++;
                }
            }
            if (counter > 0)
            {
                CommandString = CommandString.Remove(CommandString.Length - 4);
                CommandString += ") and (";
            }
            foreach (int item in yillar)
            {
                CommandString += "dbo.Kitap.BasimYili='" + item.ToString() + "' or ";
            }
            CommandString = CommandString.Remove(CommandString.Length - 4);
            CommandString += ")";
            SqlCommand cmd = new SqlCommand(CommandString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        #endregion
        public static bool record(Kitap value)
        {
            bool check = true;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "";
            #region insert
            if (value.ID == 0)
            {
                CommandString += "insert into dbo.Kitap ";
                int[] YazarID = null;
                if (value.Author != null)
                {
                    YazarID = new int[value.Author.Length];
                    for (int i = 0; i < value.Author.Length; i++)
                    {
                        if (value.Author[i].ID != 0)
                        {
                            YazarID[i] = value.Author[i].ID;
                        }
                        else
                        {
                            int id = YazarIslemleri.record(value.Author[i]);
                            if (id != 0)
                            {
                                YazarID[i] = id;
                            }
                            else
                            {
                                check = false;
                                break;
                            }//iç if
                        }//dış if
                    }//for
                }//en dış if
                int YayineviID = 0;
                if (check)
                {
                    if (value.Publisher.ID != 0)
                    {
                        YayineviID = value.Publisher.ID;
                    }
                    else
                    {
                        int id = YayineviIslemleri.record(value.Publisher);
                        if (id != 0)
                        {
                            YayineviID = id;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                int KategoriID = 0;
                if (check)
                {
                    if (value.Category.ID != 0)
                    {
                        KategoriID = value.Category.ID;
                    }
                    else
                    {
                        int id = KategoriIslemleri.record(value.Category);
                        if (id != 0)
                        {
                            KategoriID = id;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                if (check)
                {
                    if (String.IsNullOrEmpty(value.Kapak))
                    {
                        if (String.IsNullOrEmpty(value.Ozet))
                        {
                            CommandString += "(Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret) values(";
                            CommandString += "'" + value.Adi + "'";
                            CommandString += ",'" + value.BasimYili.ToString() + "'";
                            CommandString += "," + YayineviID.ToString();
                            CommandString += "," + KategoriID.ToString();
                            CommandString += "," + value.SayfaSayisi.ToString();
                            CommandString += "," + (value.HasarDurumu ? "1" : "0");
                            CommandString += "," + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += "," + value.Fiyat.ToString().Replace(',', '.') + ")";
                        }
                        else
                        {
                            CommandString += "(Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Ozet) values(";
                            CommandString += "'" + value.Adi + "'";
                            CommandString += ",'" + value.BasimYili.ToString() + "'";
                            CommandString += "," + YayineviID.ToString();
                            CommandString += "," + KategoriID.ToString();
                            CommandString += "," + value.SayfaSayisi.ToString();
                            CommandString += "," + (value.HasarDurumu ? "1" : "0");
                            CommandString += "," + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += "," + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",'" + value.Ozet + "')";
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(value.Ozet))
                        {
                            CommandString += "(Adi,BasimYili,YayineviID,KategoriID,SayfaSayisi,HasarDurumu,KiralamaDurumu,Ucret,Kapak) values(";
                            CommandString += "'" + value.Adi + "'";
                            CommandString += ",'" + value.BasimYili.ToString() + "'";
                            CommandString += "," + YayineviID.ToString();
                            CommandString += "," + KategoriID.ToString();
                            CommandString += "," + value.SayfaSayisi.ToString();
                            CommandString += "," + (value.HasarDurumu ? "1" : "0");
                            CommandString += "," + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += "," + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",'" + value.Kapak + "')";
                        }
                        else
                        {
                            CommandString += " values(";
                            CommandString += "'" + value.Adi + "'";
                            CommandString += ",'" + value.BasimYili.ToString() + "'";
                            CommandString += "," + YayineviID.ToString();
                            CommandString += "," + KategoriID.ToString();
                            CommandString += "," + value.SayfaSayisi.ToString();
                            CommandString += "," + (value.HasarDurumu ? "1" : "0");
                            CommandString += "," + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += "," + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",'" + value.Ozet + "'";
                            CommandString += ",'" + value.Kapak + "')";
                        }
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand(CommandString, con);
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            con.Close();
                            cmd = new SqlCommand("select ID from dbo.Kitap order by ID desc", con);
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            int KitapID = 0;
                            if (reader.Read())
                            {
                                KitapID = reader.GetInt32(0);
                            }
                            else
                            {
                                check = false;
                            }
                            reader.Close();
                            con.Close();
                            if (check && YazarID != null)
                            {

                                foreach (int item in YazarID)
                                {
                                    cmd = new SqlCommand("insert into dbo.KitapYazar values(" + KitapID.ToString() + "," + item.ToString() + ")", con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }

                            }
                        }
                        else
                        {
                            con.Close();
                            check = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        check = false;
                    }
                }
            }
            #endregion
            #region update
            else
            {
                CommandString += "update dbo.Kitap set ";
                int[] YazarID = null;
                if (value.Author != null)
                {
                    YazarID = new int[value.Author.Length];
                    for (int i = 0; i < value.Author.Length; i++)
                    {
                        if (value.Author[i].ID != 0)
                        {
                            YazarID[i] = value.Author[i].ID;
                        }
                        else
                        {
                            int id = YazarIslemleri.record(value.Author[i]);
                            if (id != 0)
                            {
                                YazarID[i] = id;
                            }
                            else
                            {
                                check = false;
                                break;
                            }//iç if
                        }//dış if
                    }//for
                }//en dış if
                int YayineviID = 0;
                if (check)
                {
                    if (value.Publisher.ID != 0)
                    {
                        YayineviID = value.Publisher.ID;
                    }
                    else
                    {
                        int id = YayineviIslemleri.record(value.Publisher);
                        if (id != 0)
                        {
                            YayineviID = id;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                int KategoriID = 0;
                if (check)
                {
                    if (value.Category.ID != 0)
                    {
                        KategoriID = value.Category.ID;
                    }
                    else
                    {
                        int id = KategoriIslemleri.record(value.Category);
                        if (id != 0)
                        {
                            KategoriID = id;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                if (check)
                {
                    if (String.IsNullOrEmpty(value.Kapak))
                    {
                        if (String.IsNullOrEmpty(value.Ozet))
                        {

                            CommandString += "Adi='" + value.Adi + "'";
                            CommandString += ",BasimYili='" + value.BasimYili.ToString() + "'";
                            CommandString += ",YayineviID=" + YayineviID.ToString();
                            CommandString += ",KategoriID=" + KategoriID.ToString();
                            CommandString += ",SayfaSayisi=" + value.SayfaSayisi.ToString();
                            CommandString += ",HasarDurumu=" + (value.HasarDurumu ? "1" : "0");
                            CommandString += ",KiralamaDurumu=" + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += ",Ucret=" + value.Fiyat.ToString().Replace(',', '.');
                        }
                        else
                        {

                            CommandString += "Adi='" + value.Adi + "'";
                            CommandString += ",BasimYili='" + value.BasimYili.ToString() + "'";
                            CommandString += ",YayineviID=" + YayineviID.ToString();
                            CommandString += ",KategoriID=" + KategoriID.ToString();
                            CommandString += ",SayfaSayisi=" + value.SayfaSayisi.ToString();
                            CommandString += ",HasarDurumu=" + (value.HasarDurumu ? "1" : "0");
                            CommandString += ",KiralamaDurumu=" + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += ",Ucret=" + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",Ozet='" + value.Ozet + "'";
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(value.Ozet))
                        {
                            CommandString += "Adi='" + value.Adi + "'";
                            CommandString += ",BasimYili='" + value.BasimYili.ToString() + "'";
                            CommandString += ",YayineviID=" + YayineviID.ToString();
                            CommandString += ",KategoriID=" + KategoriID.ToString();
                            CommandString += ",SayfaSayisi=" + value.SayfaSayisi.ToString();
                            CommandString += ",HasarDurumu=" + (value.HasarDurumu ? "1" : "0");
                            CommandString += ",KiralamaDurumu=" + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += ",Ucret=" + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",Kapak='" + value.Kapak + "'";
                        }
                        else
                        {

                            CommandString += "Adi='" + value.Adi + "'";
                            CommandString += ",BasimYili='" + value.BasimYili.ToString() + "'";
                            CommandString += ",YayineviID=" + YayineviID.ToString();
                            CommandString += ",KategoriID=" + KategoriID.ToString();
                            CommandString += ",SayfaSayisi=" + value.SayfaSayisi.ToString();
                            CommandString += ",HasarDurumu=" + (value.HasarDurumu ? "1" : "0");
                            CommandString += ",KiralamaDurumu=" + (value.KiralamaDurumu ? "1" : "0");
                            CommandString += ",Ucret=" + value.Fiyat.ToString().Replace(',', '.');
                            CommandString += ",Ozet='" + value.Ozet + "'";
                            CommandString += ",Kapak='" + value.Kapak + "'";
                        }
                    }
                    CommandString += " where ID = " + value.ID;
                    try
                    {
                        SqlCommand cmd = new SqlCommand(CommandString, con);
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 1 && YazarID != null)
                        {
                            con.Close();
                            cmd = new SqlCommand("delete from dbo.KitapYazar where KitapID=" + value.ID.ToString(), con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            foreach (int item in YazarID)
                            {
                                cmd = new SqlCommand("insert into dbo.KitapYazar values(" + value.ID.ToString() + "," + item.ToString() + ")", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else
                        {
                            con.Close();
                            check = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        check = false;
                    }
                }
            }
            #endregion
            return check;
        }
    }
}
