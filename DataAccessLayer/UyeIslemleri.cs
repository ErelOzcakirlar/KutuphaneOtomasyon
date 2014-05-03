using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Entities;

namespace DataAccessLayer
{
    public class UyeIslemleri
    {
        public static List<Uye> getMembers()
        {
            List<Uye> Value = new List<Uye>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Uye", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
            return Value;
        }
        public static int record(Uye value)
        {
            int rvalue = 0;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "";
            if (value.ID == 0)
            {
                CommandString += "insert into dbo.Uye ";
                if (String.IsNullOrEmpty(value.Telefon))
                {
                    if (String.IsNullOrEmpty(value.Adres))
                    {
                        CommandString += "(Adi,Soyadi,TCKimlikNo,UyelikTarihi) values(";
                        CommandString += "'" + value.Adi + "'";
                        CommandString += ",'" + value.Soyadi + "'";
                        CommandString += ",'" + value.TCKimlik + "'";
                        CommandString += ",'" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "')";
                    }
                    else
                    {
                        CommandString += "(Adi,Soyadi,TCKimlikNo,Adresi,UyelikTarihi) values(";
                        CommandString += "'" + value.Adi + "'";
                        CommandString += ",'" + value.Soyadi + "'";
                        CommandString += ",'" + value.TCKimlik + "'";
                        CommandString += ",'" + value.Adres + "'";
                        CommandString += ",'" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "')";
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(value.Adres))
                    {
                        CommandString += "(Adi,Soyadi,TCKimlikNo,Telefon,UyelikTarihi) values(";
                        CommandString += "'" + value.Adi + "'";
                        CommandString += ",'" + value.Soyadi + "'";
                        CommandString += ",'" + value.TCKimlik + "'";
                        CommandString += ",'" + value.Telefon + "'";
                        CommandString += ",'" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "')";
                    }
                    else
                    {
                        CommandString += "values(";
                        CommandString += "'" + value.Adi + "'";
                        CommandString += ",'" + value.Soyadi + "'";
                        CommandString += ",'" + value.TCKimlik + "'";
                        CommandString += ",'" + value.Adres + "'";
                        CommandString += ",'" + value.Telefon + "'";
                        CommandString += ",'" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "')";
                    }
                }
                try
                {
                    SqlCommand cmd = new SqlCommand(CommandString, con);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows == 1)
                    {
                        cmd = new SqlCommand("select ID from dbo.Uye order by ID desc",con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            rvalue = reader.GetInt32(0);
                        }
                        else
                        {
                            rvalue = 0;
                        }
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        rvalue = 0;
                    }
                }
                catch (Exception ex)
                {
                    rvalue = 0;
                }
            }
            else
            {
                CommandString += "update dbo.Uye set ";
                if (String.IsNullOrEmpty(value.Telefon))
                {
                    if (String.IsNullOrEmpty(value.Adres))
                    {
                        CommandString += "Adi='" + value.Adi + "'";
                        CommandString += ",Soyadi='" + value.Soyadi + "'";
                        CommandString += ",TCKimlikNo='" + value.TCKimlik + "'";
                        CommandString += ",UyelikTarihi='" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "'";
                    }
                    else
                    {
                        CommandString += "Adi='" + value.Adi + "'";
                        CommandString += ",Soyadi='" + value.Soyadi + "'";
                        CommandString += ",TCKimlikNo='" + value.TCKimlik + "'";
                        CommandString += ",Adresi='" + value.Adres + "'";
                        CommandString += ",UyelikTarihi='" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "'";
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(value.Adres))
                    {
                        CommandString += "Adi='" + value.Adi + "'";
                        CommandString += ",Soyadi='" + value.Soyadi + "'";
                        CommandString += ",TCKimlikNo='" + value.TCKimlik + "'";
                        CommandString += ",Telefon='" + value.Telefon + "'";
                        CommandString += ",UyelikTarihi='" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "'";
                    }
                    else
                    {
                        CommandString += "Adi='" + value.Adi + "'";
                        CommandString += ",Soyadi='" + value.Soyadi + "'";
                        CommandString += ",TCKimlikNo='" + value.TCKimlik + "'";
                        CommandString += ",Adresi='" + value.Adres + "'";
                        CommandString += ",Telefon='" + value.Telefon + "'";
                        CommandString += ",UyelikTarihi='" + RaporIslemleri.convertToSqlDate(value.UyelikTarihi.ToShortDateString()) + "'";
                    }
                }
                CommandString += " where ID=" + value.ID.ToString();
                try
                {
                    SqlCommand cmd = new SqlCommand(CommandString, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rvalue = value.ID;
                }
                catch (Exception ex)
                {
                    rvalue = 0;
                }
            }
            return rvalue;
        }
    }
}
