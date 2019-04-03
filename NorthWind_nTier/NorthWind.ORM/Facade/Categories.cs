using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NorthWind.ORM.Entity;

namespace NorthWind.ORM.Facade
{
   public class Categories
    {
        //connection tanımlanır
        //select,insert,update,delete metodları yazılır
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listCategories", Tools.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Insert(Category c)
        {
            SqlCommand cmd = new SqlCommand("insertCategory", Tools.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catName", c.CategoryName);
            cmd.Parameters.AddWithValue("@catDesc", c.Description);
            return Tools.ExecuteNonQuery(cmd);
        }
       
    }
}
