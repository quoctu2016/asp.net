using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _benhvien.DAL
{
    public class clskhoa
    {
        public static DataTable getKhoa()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khoa_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable getKhoaByid(int id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khoa_SelectByid";
            cm.Parameters.AddWithValue("id", id);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
        public static DataTable getKhoabyID_BV(int id_bv)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "khoa_SelectById_bv";
            cm.Parameters.AddWithValue("@id_bv",id_bv);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
