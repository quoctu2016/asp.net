using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clsthuoc
    {
        public static DataTable thuoc_SelectAll()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable thuoc_SelectbyID(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_SelectByID";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static void thuoc_Insert(string ten)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_Insert";
            cm.Parameters.AddWithValue("@ten", ten);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static void thuoc_update(int id,string ten)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_update";
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@ten", ten);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static bool thuoc_checkTen(string ten)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_selectByTen";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenthuoc", ten);
            DataTable dt = DbSql.DbSql.getData(cm);
            if (dt.Rows.Count > 0) return false;
            else return true;
        }
        public static void thuoc_Delete(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "thuoc_Delete";
            cm.Parameters.AddWithValue("@id", id);
            cm.CommandType = CommandType.StoredProcedure;
            DbSql.DbSql.executeNonQuery(cm);
        }
        //public static bool thuoc_CheckTen(string ten)
        //{
        //    SqlCommand cm = new SqlCommand();
        //    cm.CommandText = "thuoc_CheckTen";
        //    cm.Parameters.AddWithValue("@ten", ten);
        //    cm.CommandType = CommandType.StoredProcedure;
        //    DataTable dt = DbSql.DbSql.getData(cm);
        //    if (dt.Rows.Count > 0) return false;
        //    else return true;
        //}
    }
}
