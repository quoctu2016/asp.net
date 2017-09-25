using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clsbenhnhan
    {
        public static DataTable benhnhan_SelectAll()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable benhnhan_SelectByID(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_SelectByID";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static void benhnhan_Insert(string ten, DateTime namsinh,string gioitinh,string username, string password)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_Insert";
            cm.Parameters.AddWithValue("@ten", ten);
            cm.Parameters.AddWithValue("@namsinh", namsinh);
            cm.Parameters.AddWithValue("@gioitinh", gioitinh);
            cm.Parameters.AddWithValue("@username", username);
            cm.Parameters.AddWithValue("@password", password);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static void benhnhan_Update(int id,string ten, DateTime namsinh, string gioitinh, string username, string password)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_Update";
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@ten", ten);
            cm.Parameters.AddWithValue("@namsinh", namsinh);
            cm.Parameters.AddWithValue("@gioitinh", gioitinh);
            cm.Parameters.AddWithValue("@username", username);
            cm.Parameters.AddWithValue("@password", password);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static void benhnhan_Delete(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_Delete";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
    }
}
