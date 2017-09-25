using _benhvien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace benhvien
{
    public partial class lichsukham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id_loainv"].ToString() == "4")
                {
                    cmbbenhnhan.Visible = false;
                    loadlichsu();
                }
                if (Session["id_loainv"].ToString() == "1")
                {
                    loadcmbbenhnhan();
                    cmbbenhnhan_SelectedIndexChanged(null, null);
                }
            }
        }
        void loadlichsu()
        {
            gvlichsu.DataSource = clskhambenh.lichsukham_ByID_BN(int.Parse(Session["id"].ToString()));
            gvlichsu.DataBind();
        }
        void loadcmbbenhnhan()
        {
            cmbbenhnhan.DataSource = clsbenhnhan.benhnhan_SelectAll();
            cmbbenhnhan.DataValueField = "id";
            cmbbenhnhan.DataTextField = "ten";
            cmbbenhnhan.DataBind();
        }

        protected void gvlichsu_SelectedIndexChanged(object sender, EventArgs e)
        {
            mulls.ActiveViewIndex = 1;
            int id = (int)gvlichsu.DataKeys[gvlichsu.SelectedIndex].Value;
            gvthuoc.DataSource = clslichsukham.toathuoc_SelectAll(id);
            gvthuoc.DataBind();
        }
        protected void cmbbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbenhnhan.SelectedValue != null)
            {
                int val;
                Int32.TryParse(cmbbenhnhan.SelectedValue.ToString(), out val);
                gvlichsu.DataSource = clskhambenh.lichsukham_ByID_BN(val);
                gvlichsu.DataBind();
            }
        }

        protected void btnquaylai_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            gvthuoc.DataSource = dt;
            gvthuoc.DataBind();
            mulls.ActiveViewIndex = 0;
        }

        protected void gvlichsu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvlichsu.PageIndex = e.NewPageIndex;
            loadlichsu();
        }
    }
}