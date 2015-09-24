using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Sovellus hakee SQL serveriltä DemoxOy-tietokannasta läsnäolot-taulusta kaikki
namespace databaseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetData_DataReader();
            GetData_DataTable();
        }
        static void GetData_DataTable()
        {
            //UI-kerros datan esittämistä varten
            try
            {
                //haetaan data DataTablen avulla
                //DataTable dt = GetDataSimple();
                DataTable dt = GetDataReal();

                string rivi = "";
                //loopitetaan DataTablen rivit läpi
                foreach (DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach (DataColumn col in dt.Columns)
                    {
                        rivi += dr[col].ToString() + "\t";
                    }
                    Console.WriteLine(rivi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static DataTable GetDataSimple()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Masa", "mainio");
            return dt;
        }

        static DataTable GetDataReal()
        {
            //DBkerros, haetaan DemoxOy-tietokannasta taulun länsäolot tietueet
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";// WHERE asioid='H4113'";
                string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"]; 
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static void GetData_DataReader()
        {
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid='H4113'";
                string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //luodaan reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            //käydään rdr läpi
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }
                            }
                            else
                            {
                                Console.Write("Tietueita ei ole olemassa!");
                            }
                            //Suljetaan reader
                            rdr.Close();
                        }
                    }
                    //Suljetaan tietokantayhteys
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
