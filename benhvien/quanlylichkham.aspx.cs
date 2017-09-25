using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
namespace benhvien
{
    public partial class quanlylichkham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtngaykham.Text = DateTime.Now.ToString();
                loadLich();
            }
        }
        void loadLich()
        {
            gvQLLichKham.DataSource = clslichkham.lichkham_SelectByDate(DateTime.Now);
            gvQLLichKham.DataBind();
        }
        protected void txtngaykham_TextChanged(object sender, EventArgs e)
        {
                gvQLLichKham.DataSource = clslichkham.lichkham_SelectByDate(DateTime.Parse(txtngaykham.Text));
                gvQLLichKham.DataBind();
        }
    }
}