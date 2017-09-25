using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _benhvien.DAL
{
    public class clsPhong
    {
        public static DataTable getphong()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "phong_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            return dt;
        }
        public static DataTable getphongbyID_khoa(int id_khoa)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "phong_SelectById_khoa";
            cm.Parameters.AddWithValue("@id_khoa", id_khoa);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
