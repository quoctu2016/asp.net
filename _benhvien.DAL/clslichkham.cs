using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _benhvien.DAL
{
    public class clslichkham
    {
        public static DataTable lichkham_SelectByDate(DateTime ngaykham)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "lichkham_SelectByDate";
            cm.Parameters.AddWithValue("@ngaykham", ngaykham);
            cm.CommandType = CommandType.StoredProcedure;
            return DbSql.DbSql.getData(cm);
        }
    }
}
