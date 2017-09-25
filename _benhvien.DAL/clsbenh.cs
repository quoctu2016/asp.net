using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clsbenh
    {
        public static DataTable loadbenh()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benh_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable getbenhByID_BV(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benh_SelectByID_BenhVien";
            cm.Parameters.AddWithValue("id",id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
