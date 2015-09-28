using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä5
{
    class DBDemoxOy
    {
       public static void GetData_DataTable()
        {
            //UI-kerros datan esittämistä varten
            try
            {
                //haetaan data DataTablen avulla
                //DataTable dt = GetDataSimple();
                DataTable dt = GetDataReal("");

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

        public static DataTable GetDataSimple()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Masa", "mainio");
            return dt;
        }

        public static DataTable GetDataReal(string asioid)
        {
            //DBkerros, haetaan DemoxOy-tietokannasta taulun länsäolot tietueet
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";// WHERE asioid=''";
                if(asioid != "")
                {
                    sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid='" + asioid + "'";
                }
                string connStr = Tehtävä5.Properties.Settings.Default.connectionStringDbEight;
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
    }
}
