using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using System.Data.SqlTypes;

namespace DataAccessLayer
{
    public class YayineviIslemleri
    {
        public static List<Yayinevi> getPublishers()
        {
            List<Yayinevi> Value = new List<Yayinevi>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Yayinevi", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string adi = reader.GetString(1);
                Yayinevi Current = new Yayinevi(id, adi);
                string adresi,kurulus;
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
            return Value;
        }

        public static Yayinevi getPublisher(int id)
        {
            Yayinevi Value = null;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Yayinevi where ID=" + id.ToString(), con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Value = new Yayinevi(reader.GetInt32(0),reader.GetString(1));
                try
                {
                    Value.Adres = reader.GetString(2);
                }
                catch (SqlNullValueException snve)
                {
                    Value.Adres = "";
                }
                try
                {
                    Value.KurulusYili = int.Parse(reader.GetString(3));
                }
                catch (SqlNullValueException snve)
                {
                    Value.KurulusYili = 0;
                }
            }
            reader.Close();
            con.Close();
            return Value;
        }

        public static int record(Yayinevi Value)
        {
            int rvalue = 0;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "";
            if (Value.ID == 0)
            {
                CommandString += "insert into dbo.Yayinevi";
                if (String.IsNullOrEmpty(Value.Adres))
                {
                    if (Value.KurulusYili == 0)
                    {
                        CommandString += " (Adi) values('" + Value.Adi + "')";
                    }
                    else
                    {
                        CommandString += " (Adi,KurulusYili) values('" + Value.Adi + "','" + Value.KurulusYili.ToString() + "')";
                    }
                    
                }
                else
                {
                    if (Value.KurulusYili == 0)
                    {
                        CommandString += " (Adi,Adresi) values('" + Value.Adi + "','" + Value.Adres + "')";
                    }
                    else
                    {
                        CommandString += " (Adi,Adresi,KurulusYili) values('" + Value.Adi + "','" + Value.Adres + "','" + Value.KurulusYili.ToString() + "')";
                    }
                }
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        con.Close();
                        cmd = new SqlCommand("select ID from dbo.Yayinevi order by ID desc",con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        rvalue = reader.GetInt32(0);
                        reader.Close();
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
                con.Close();
            }
            else
            {
                CommandString += "update dbo.Yayinevi set";
                if (String.IsNullOrEmpty(Value.Adres))
                {
                    if (Value.KurulusYili == 0)
                    {
                        CommandString += " Adi='" + Value.Adi + "'";
                    }
                    else
                    {
                        CommandString += " Adi='" + Value.Adi + "',KurulusYili='" + Value.KurulusYili.ToString() + "'";
                    }
                }
                else
                {
                    if (Value.KurulusYili == 0)
                    {
                        CommandString += " Adi='" + Value.Adi + "',Adresi='" + Value.Adres + "'";
                    }
                    else
                    {
                        CommandString += " Adi='" + Value.Adi + "',Adresi='" + Value.Adres + "',KurulusYili='" + Value.KurulusYili.ToString() + "'";
                    }
                }
                CommandString += " where ID=" + Value.ID.ToString();
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        rvalue = Value.ID;
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
                con.Close();
            }
            return rvalue;
        }
    }
}
