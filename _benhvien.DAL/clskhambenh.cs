using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clskhambenh
    {
        public static DataTable getBenhNhan_Cho(string username)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khambenh_SelectBy_username";
            cm.Parameters.AddWithValue("@usname", username);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable getBenhNhan_ChoByID(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_SelectByID";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable lichsukham_ByID_BN(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "lichsukham_SelectByID_BN";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable khambenh_kethuoc_SelectAll()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khambenh_kethuoc_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable thuoc_SelectAll()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static void khambenh_chuandoan(string chuandoan,int id_bn,int thanhtoan,DateTime ngaykham,bool chuyenvien)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khambenh_chuandoan";
            cm.Parameters.AddWithValue("@chuandoan", chuandoan);
            cm.Parameters.AddWithValue("@id_bn", id_bn);
            cm.Parameters.AddWithValue("@thanhtoan", thanhtoan);
            cm.Parameters.AddWithValue("@ngaykham", ngaykham);
            cm.Parameters.AddWithValue("@chuyenvien", chuyenvien);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static void toathuoc_Insert(int id_thuoc, int sl, string donvi)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "toathuoc_Insert";
            cm.Parameters.AddWithValue("@id_thuoc", id_thuoc);
            cm.Parameters.AddWithValue("@sl", sl);
            cm.Parameters.AddWithValue("@donvi", donvi);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static DataTable khambenh_SelectCapDoByusername(string username)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khambenh_SelectCapDoByusername";
            cm.Parameters.AddWithValue("@username", username);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static bool toathuoc_Check(int id_thuoc)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "toathuoc_Check";
            cm.Parameters.AddWithValue("@id_thuoc", id_thuoc);
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            if (dt.Rows.Count > 0) return false;
            else return true;
        }
    }
}
