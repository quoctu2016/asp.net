using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clslichsukham
    {
        public static DataTable toathuoc_SelectAll(int id_lskham)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "toathuoc_SelectAll";
            cm.Parameters.AddWithValue("@id_lskham", id_lskham);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
