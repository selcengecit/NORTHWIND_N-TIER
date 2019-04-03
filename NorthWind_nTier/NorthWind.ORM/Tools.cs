using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NorthWind.ORM
{
    class Tools
    {
        //3.Yol 
        //UI projesinde App.config içerisine bağlantı paramtresi eklenir
        internal static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);

        internal static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                return (affected > 0);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}
