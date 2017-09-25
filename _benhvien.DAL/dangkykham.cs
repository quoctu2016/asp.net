using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class dangkykham
    {
        public static void dangkykham_Insert(int id_bs,int id_bn,DateTime ngaykham)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "dangkykham_Insert";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@id_bs",id_bs);
            cm.Parameters.AddWithValue("@id_bn",id_bn);
            cm.Parameters.AddWithValue("@ngaykham",ngaykham);
            DbSql.DbSql.executeNonQuery(cm);
        }
        public static int id_nguoidung(string usname)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "benhnhan_SelectIDBy_username";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@usname", usname);
            DataTable dt =  DbSql.DbSql.getData(cm);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public static bool dangkykham_check(DateTime ngaykham,int id_bn,int id_bs)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "dangkykham_check";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngaykham", ngaykham);
            cm.Parameters.AddWithValue("@id_bn", id_bn);
            cm.Parameters.AddWithValue("@id_bs", id_bs);
            DataTable dt =  DbSql.DbSql.getData(cm);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else return true;
        }
    }
}
