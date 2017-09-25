using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
namespace benhvien
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpmenu.DataSource = clslogin.login_PhanQuyen(Session["username"].ToString());
                rpmenu.DataBind();
            }
        }
    }
}