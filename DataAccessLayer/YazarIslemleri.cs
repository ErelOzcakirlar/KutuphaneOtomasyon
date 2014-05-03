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
    public class YazarIslemleri
    {
        public static List<Yazar> getAuthors()
        {
            List<Yazar> Value = new List<Yazar>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");

            SqlCommand cmd = new SqlCommand("select * from dbo.Yazar", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
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
                catch(SqlNullValueException snve)
                {
                    ozgecmis = "";
                }
                Current.Ozgecmis = ozgecmis;
                Value.Add(Current);
            }
            reader.Close();
            con.Close();
            return Value;
        }

        public static Yazar getAuthor(int id)
        {
            Yazar Value = null;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Yazar where ID=" + id.ToString(), con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = reader.GetInt32(0);
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
                Value = Current;
            }
            reader.Close();
            con.Close();
            return Value;
        }

        public static int record(Yazar Value)
        {
            int rvalue = 0;

            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "";
            if (Value.ID == 0)
            {
                CommandString += "insert into dbo.Yazar";
                if (String.IsNullOrEmpty(Value.Ozgecmis))
                {
                    CommandString += " (Adi,Soyadi) values('" + Value.Adi + "','" + Value.Soyadi + "')";
                }
                else
                {
                    CommandString += " values('" + Value.Adi + "','" + Value.Soyadi + "','" + Value.Ozgecmis + "')";
                }
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        con.Close();
                        cmd = new SqlCommand("select ID from dbo.Yazar order by ID desc",con);
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
                catch(Exception ex)
                {
                    rvalue = 0;
                }
                con.Close();
            }
            else
            {
                CommandString += "update dbo.Yazar set";
                if (String.IsNullOrEmpty(Value.Ozgecmis))
                {
                    CommandString += " Adi='" + Value.Adi + "',Soyadi='" + Value.Soyadi + "'";
                }
                else
                {
                    CommandString += " Adi='" + Value.Adi + "',Soyadi='" + Value.Soyadi + "',Ozgecmis='" + Value.Ozgecmis + "'";
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

        public static String[] seperateName(String FullName)
        {
            FullName = FullName.Trim();
            int last_blank = -1;
            for (int i = 0; i < FullName.Length; i++)
            {
                if(FullName[i] == ' ')
                {
                    last_blank = i;
                }
            }
            String[] Value = new String[2];
            if (last_blank != -1)
            {
                Value[0] = FullName.Substring(0, last_blank).Trim();
                Value[1] = FullName.Substring(last_blank, FullName.Length - last_blank).Trim();
            }
            else if (FullName.Length > 0)
            {
                Value[0] = FullName;
            }
            return Value;
        }

    }
}
