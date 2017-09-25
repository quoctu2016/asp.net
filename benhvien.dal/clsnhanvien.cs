using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace benhvien.App_Code
{
    public class clsnhanvien
    {
        public static DataTable getNhanVien()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            return dt;
        }
    }
}