using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clsthongtinnguoidung
    {
        public static DataTable nguoidung_SelectByUsername(string username)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nguoidung_SelectByUsername";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@username", username);
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable nguoidung_BenhNhan(string username)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nguoidung_BenhNhan";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@username", username);
            return DbSql.DbSql.getData(cm);
        }
        public static void nguoidung_updateNhanVien(int id, string ten, int namsinh, string gt, int id_phong, string pass)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nguoidung_updateNhanVien";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@ten", ten);
            cm.Parameters.AddWithValue("@namsinh", namsinh);
            cm.Parameters.AddWithValue("@gioitinh", gt);
            cm.Parameters.AddWithValue("@id_phong", id_phong);
            cm.Parameters.AddWithValue("@password", pass);
            DbSql.DbSql.executeNonQuery(cm);
        }
    }
}
