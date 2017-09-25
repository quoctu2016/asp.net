using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clsbenhvien
    {
        public static DataTable getBV()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhvien_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable benhvien_SelectByCapdo(string capdo)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhvien_SelectByCapdo";
            cm.Parameters.AddWithValue("@capdo", capdo);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
