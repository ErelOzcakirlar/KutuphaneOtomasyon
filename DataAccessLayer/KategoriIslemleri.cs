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
    public class KategoriIslemleri
    {
        public static List<Kategori> getCategories()
        {
            List<Kategori> Value = new List<Kategori>();
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Kategori", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string adi = reader.GetString(1);
                Kategori Current = new Kategori(id, adi);
                string aciklama;
                try
                {
                    aciklama = reader.GetString(2);
                }
                catch (SqlNullValueException snve)
                {
                    aciklama = "";
                }
                Current.Aciklama = aciklama;
                Value.Add(Current);
            }
            reader.Close();
            con.Close();
            return Value;
        }

        public static Kategori getCategory(int id)
        {
            Kategori Value = null;
            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("select * from dbo.Kategori where ID=" + id.ToString(), con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Value = new Kategori( reader.GetInt32(0), reader.GetString(1) );
                try
                {
                    Value.Aciklama = reader.GetString(2);
                }
                catch (SqlNullValueException snve)
                {
                    Value.Aciklama = "";
                }
            }
            reader.Close();
            con.Close();
            return Value;
        }

        public static int record(Kategori Value)
        {
            int rvalue = 0;

            SqlConnection con = new SqlConnection("Server=.;Database=KutuphaneOtomasyon;Trusted_Connection=true");
            String CommandString = "";
            if (Value.ID == 0)
            {
                CommandString += "insert into dbo.Kategori";
                if (String.IsNullOrEmpty(Value.Aciklama))
                {
                    CommandString += " (Adi) values('" + Value.Adi + "')";
                }
                else
                {
                    CommandString += " values('" + Value.Adi + "','" + Value.Aciklama + "')";
                }
                SqlCommand cmd = new SqlCommand(CommandString, con);
                con.Open();
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        con.Close();
                        cmd = new SqlCommand("select ID from dbo.Kategori order by ID desc",con);
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
                CommandString += "update dbo.Kategori set";
                if (String.IsNullOrEmpty(Value.Aciklama))
                {
                    CommandString += " Adi='" + Value.Adi + "'";
                }
                else
                {
                    CommandString += " Adi='" + Value.Adi + "',Aciklama='" + Value.Aciklama + "'";
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
