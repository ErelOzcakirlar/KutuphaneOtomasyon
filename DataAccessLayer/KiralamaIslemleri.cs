using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class KiralamaIslemleri
    {
        public static int[] getLastRent(int KitapID)
        {
            int[] value = new int[2];
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select ID,UyeID,TeslimDurumu from dbo.Kiralama where KitapID=" + KitapID.ToString() + " order by ID desc", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (!reader.GetBoolean(2))
                {
                    value[0] = reader.GetInt32(0);
                    value[1] = reader.GetInt32(1);
                }
            }
            reader.Close();
            con.Close();
            return value;
        }
        public static Decimal gecikmeHesapla(int id)
        {
            Decimal value = 0;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select KiralamaTarihi from dbo.KiralamaDetay where ID=" + id.ToString(), con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DateTime KiralamaTarihi = reader.GetDateTime(0);
                int Fark = (DateTime.Now - KiralamaTarihi).Days;
                if (Fark > 10)
                {
                    value = Fark - 10;
                }
            }
            con.Close();
            return value;
        }
        public static int getRentCount(int UyeID)
        {
            int counter = 0;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select TeslimDurumu from dbo.Kiralama where UyeID=" + UyeID.ToString(), con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.GetBoolean(0))
                {
                    counter++;
                }
            }
            reader.Close();
            con.Close();
            return counter;
        }
        public static List<Bilesen> getPayTypes()
        {
            List<Bilesen> Value = new List<Bilesen>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.OdemeTipi", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bilesen Current = new Bilesen(reader.GetInt32(0), reader.GetString(1));
                Value.Add(Current);
            }
            reader.Close();
            con.Close();
            return Value;
        }
        public static bool kirala(int UyeID, int KitapID)
        {
            bool check = true;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "insert into dbo.Kiralama values(";
            CommandString += KitapID.ToString();
            CommandString += "," + UyeID.ToString();
            CommandString += ",0) insert into dbo.KiralamaDetay (KiralamaTarihi,VarsayilanTeslim) values(";
            CommandString += "'" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToShortDateString()) + "'";
            CommandString += ",'" + RaporIslemleri.convertToSqlDate(DateTime.Now.AddDays(10).ToShortDateString()) + "')";
            CommandString += " update dbo.Kitap set KiralamaDurumu=1 where ID=" + KitapID.ToString();
            SqlCommand cmd = new SqlCommand(CommandString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }
        public static bool teslimAl(int kiralamaID, Decimal Gecikme, Decimal Hasar, Bilesen OdemeTipi)
        {
            bool check = true;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            int KitapID=0,UyeID = 0;
            SqlCommand cmd = new SqlCommand("select KitapID,UyeID from dbo.Kiralama where ID=" + kiralamaID.ToString(), con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    KitapID = reader.GetInt32(0);
                    UyeID = reader.GetInt32(1);
                }
                else
                {
                    check = false;
                }
                reader.Close();
                con.Close();
                String CommandString = "";
                int KiraID = 0;
                if (check)
                {
                    CommandString = "insert into dbo.Odeme values(";
                    CommandString += "'" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToShortDateString()) + "'";
                    CommandString += "," + UyeID.ToString();
                    CommandString += ",'Kira Bedeli'";
                    CommandString += ",1";
                    CommandString += "," + OdemeTipi.ID.ToString() + ")";
                    cmd = new SqlCommand(CommandString, con);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows == 1)
                    {
                        cmd = new SqlCommand("select ID from dbo.Odeme order by ID desc", con);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            KiraID = reader.GetInt32(0);
                        }
                        else
                        {
                            check = false;
                        }
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    if (Gecikme > 0)
                    {
                        int GecikmeID = 0;
                        CommandString = "insert into dbo.Odeme values(";
                        CommandString += "'" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToShortDateString()) + "'";
                        CommandString += "," + UyeID.ToString();
                        CommandString += ",'Gecikme Bedeli'";
                        CommandString += "," + Gecikme.ToString().Replace(',', '.');
                        CommandString += "," + OdemeTipi.ID.ToString() + ")";
                        cmd = new SqlCommand(CommandString, con);
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rows == 1)
                        {
                            cmd = new SqlCommand("select ID from dbo.Odeme order by ID desc", con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                GecikmeID = reader.GetInt32(0);
                            }
                            else
                            {
                                check = false;
                            }
                            reader.Close();
                            con.Close();
                        }
                        else
                        {
                            check = false;
                        }
                        if (check)
                        {
                            if (Hasar > 0)
                            {
                                int HasarID = 0;
                                CommandString = "insert into dbo.Odeme values(";
                                CommandString += "'" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToShortDateString()) + "'";
                                CommandString += "," + UyeID.ToString();
                                CommandString += ",'Hasar Bedeli'";
                                CommandString += "," + Hasar.ToString().Replace(',', '.');
                                CommandString += "," + OdemeTipi.ID.ToString() + ")";
                                cmd = new SqlCommand(CommandString, con);
                                con.Open();
                                rows = cmd.ExecuteNonQuery();
                                con.Close();
                                if (rows == 1)
                                {
                                    cmd = new SqlCommand("select ID from dbo.Odeme order by ID desc", con);
                                    con.Open();
                                    reader = cmd.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        HasarID = reader.GetInt32(0);
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                    reader.Close();
                                    con.Close();
                                }
                                else
                                {
                                    check = false;
                                }
                                if (check)
                                {
                                    CommandString = "update dbo.Kiralama set TeslimDurumu=1 where ID=" + kiralamaID.ToString();
                                    CommandString += " update dbo.KiralamaDetay set TeslimTarihi='" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToString()) + "'";
                                    CommandString += ",Deformasyon=1";
                                    CommandString += ",KiraOdemesi=" + KiraID.ToString();
                                    CommandString += ",GecikmeOdemesi=" + GecikmeID.ToString();
                                    CommandString += ",HasarOdemesi=" + HasarID.ToString();
                                    CommandString += " where ID=" + kiralamaID.ToString();
                                    CommandString += " update dbo.Kitap set HasarDurumu=1";
                                    CommandString += ",KiralamaDurumu=0";
                                    CommandString += " where ID=" + KitapID.ToString();
                                    cmd = new SqlCommand(CommandString, con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            else
                            {
                                CommandString = "update dbo.Kiralama set TeslimDurumu=1 where ID=" + kiralamaID.ToString();
                                CommandString += " update dbo.KiralamaDetay set TeslimTarihi='" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToString()) + "'";
                                CommandString += ",Deformasyon=0";
                                CommandString += ",KiraOdemesi=" + KiraID.ToString();
                                CommandString += ",GecikmeOdemesi=" + GecikmeID.ToString();
                                CommandString += " where ID=" + kiralamaID.ToString();
                                CommandString += " update dbo.Kitap set KiralamaDurumu=0";
                                CommandString += " where ID=" + KitapID.ToString();
                                cmd = new SqlCommand(CommandString, con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        if (Hasar > 0)
                        {
                            int HasarID = 0;
                            CommandString = "insert into dbo.Odeme values(";
                            CommandString += "'" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToShortDateString()) + "'";
                            CommandString += "," + UyeID.ToString();
                            CommandString += ",'Hasar Bedeli'";
                            CommandString += "," + Hasar.ToString().Replace(',', '.');
                            CommandString += "," + OdemeTipi.ID.ToString() + ")";
                            cmd = new SqlCommand(CommandString, con);
                            con.Open();
                            int rows = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rows == 1)
                            {
                                cmd = new SqlCommand("select ID from dbo.Odeme order by ID desc", con);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    HasarID = reader.GetInt32(0);
                                }
                                else
                                {
                                    check = false;
                                }
                                reader.Close();
                                con.Close();
                            }
                            else
                            {
                                check = false;
                            }
                            if (check)
                            {
                                CommandString = "update dbo.Kiralama set TeslimDurumu=1 where ID=" + kiralamaID.ToString();
                                CommandString += " update dbo.KiralamaDetay set TeslimTarihi='" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToString()) + "'";
                                CommandString += ",Deformasyon=1";
                                CommandString += ",KiraOdemesi=" + KiraID.ToString();
                                CommandString += ",HasarOdemesi=" + HasarID.ToString();
                                CommandString += " where ID=" + kiralamaID.ToString();
                                CommandString += " update dbo.Kitap set HasarDurumu=1";
                                CommandString += ",KiralamaDurumu=0";
                                CommandString += " where ID=" + KitapID.ToString();
                                cmd = new SqlCommand(CommandString, con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else
                        {
                            CommandString = "update dbo.Kiralama set TeslimDurumu=1 where ID=" + kiralamaID.ToString();
                            CommandString += " update dbo.KiralamaDetay set TeslimTarihi='" + RaporIslemleri.convertToSqlDate(DateTime.Now.ToString()) + "'";
                            CommandString += ",Deformasyon=0";
                            CommandString += ",KiraOdemesi=" + KiraID.ToString();
                            CommandString += " where ID=" + kiralamaID.ToString();
                            CommandString += " update dbo.Kitap set KiralamaDurumu=0";
                            CommandString += " where ID=" + KitapID.ToString();
                            cmd = new SqlCommand(CommandString, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                check = false;
            }

            return check;
        }
    }
}
