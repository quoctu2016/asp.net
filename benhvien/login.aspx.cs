using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
namespace benhvien
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndn_Click(object sender, EventArgs e)
        {
            DataTable dt = clslogin.check_Login(txttendn.Text,txtmk.Text);
            if (dt.Rows.Count > 0)
            {
                Session["username"] = txttendn.Text;
                Session["id_loainv"] = dt.Rows[0]["id_loainv"].ToString();
                Session["id"] = dt.Rows[0]["id"].ToString();
                Response.Redirect("index.aspx");
            }
            else
            {
                lbtb.Text = "Nhập sai tên hoặc mật khẩu";
            }
        }
    }
}