using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _benhvien.DAL
{
    public class clsLoainv
    {
        public static DataTable getLoainv()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "loainhanvien_SelectAll";
            cm.CommandType = CommandType.StoredProcedure;
            DataTable dt = DbSql.DbSql.getData(cm);
            return dt;
        }
    }
}
