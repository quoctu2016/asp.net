using DbSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _benhvien.DAL
{
    public class clsnhanvien
    {
        public DataTable getNhanVien()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            return dt;
        }
        public static DataTable getNhanVienByID(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_SelectbyID";
            cm.Parameters.AddWithValue("@id",id);
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            return dt;
        }
        public void addNV(string ten,int namsinh,string gt,int id_phong,int id_lnv,string usname,string pass)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_Insert";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ten",ten);
            cm.Parameters.AddWithValue("@namsinh", namsinh);
            cm.Parameters.AddWithValue("@gioitinh", gt);
            cm.Parameters.AddWithValue("@id_phong", id_phong);
            cm.Parameters.AddWithValue("@id_loainv", id_lnv);
            cm.Parameters.AddWithValue("@username", usname);
            cm.Parameters.AddWithValue("@password", pass);
                DbSql.DbSql.executeNonQuery(cm);
        }
        public void updateNV(int id,string ten, int namsinh, string gt, int id_phong, int id_lnv, string usname, string pass)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_Update";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@ten", ten);
            cm.Parameters.AddWithValue("@namsinh", namsinh);
            cm.Parameters.AddWithValue("@gioitinh", gt);
            cm.Parameters.AddWithValue("@id_phong", id_phong);
            cm.Parameters.AddWithValue("@id_loainv", id_lnv);
            cm.Parameters.AddWithValue("@username", usname);
            cm.Parameters.AddWithValue("@password", pass);
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static void deleteNV(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nhanvien_Delete";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id", id);
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static DataTable getBacSi()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "bacsi_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable getBacSiByID_Benh(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "bacsi_SelectByID_Benh";
            cm.Parameters.AddWithValue("id",id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static bool nguoidung_CheckUsername(string username)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "nguoidung_CheckUsername";
            cm.Parameters.AddWithValue("username", username);
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            if (dt.Rows.Count > 0) return false;
            else return true;
        }
    }
}
