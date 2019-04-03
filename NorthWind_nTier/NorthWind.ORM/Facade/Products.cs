using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using NorthWind.ORM.Entity;

namespace NorthWind.ORM.Facade
{
    public class Products
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listProducts", Tools.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Insert(Product p)
        {
            SqlCommand cmd = new SqlCommand("insertProduct", Tools.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prodName", p.ProductName);
            cmd.Parameters.AddWithValue("@unitPrice", p.UnitPrice);
            cmd.Parameters.AddWithValue("@unitsInStock", p.UnitsInStock);
            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
