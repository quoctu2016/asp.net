
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _benhvien.DAL
{
    public class clslogin
    {
        public static DataTable check_Login(string usname, string pass)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "dangnhap_Search";
            cm.Parameters.AddWithValue("@username", usname);
            cm.Parameters.AddWithValue("@userpassword", pass);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable login_PhanQuyen(string usname)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "dangnhap_Phanquyen";
            cm.Parameters.AddWithValue("@username", usname);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
