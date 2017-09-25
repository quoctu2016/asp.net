using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
using System.Data;
using System.Data.SqlClient;
namespace benhvien
{
    public partial class tieptan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadcmbbenhvien();
                loadcmbbenh(1);
                loadcmbbacsi(1);
            }
        }
        void loadcmbbenhvien()
        {
            cmbbenhvien.DataSource = clsbenhvien.getBV();
            cmbbenhvien.DataTextField = "ten";
            cmbbenhvien.DataValueField = "id";
            cmbbenhvien.DataBind();
        }
        void loadcmbbenh(int idBenhVien)
        {
            cmbbenh.DataSource = clsbenh.getbenhByID_BV(idBenhVien);
            cmbbenh.DataTextField = "ten";
            cmbbenh.DataValueField = "id";
            cmbbenh.DataBind();
        }
        void loadcmbbacsi(int idbenh)
        {
            cmbbs.DataSource = clsnhanvien.getBacSiByID_Benh(idbenh);
            cmbbs.DataTextField = "ten";
            cmbbs.DataValueField = "id";
            cmbbs.DataBind();
        }

        protected void cmbbenhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(cmbbenhvien.SelectedValue.ToString(), out val);
            cmbbenh.DataSource = clsbenh.getbenhByID_BV(val);
            cmbbenh.DataTextField = "ten";
            cmbbenh.DataValueField = "id";
            cmbbenh.DataBind();
            int val1;
            Int32.TryParse(cmbbenh.SelectedValue.ToString(), out val1);
            cmbbs.DataSource = clsnhanvien.getBacSiByID_Benh(val1);
            cmbbs.DataTextField = "ten";
            cmbbs.DataValueField = "id";
            cmbbs.DataBind();
        }
        protected void cmbbenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(cmbbenh.SelectedValue.ToString(),out val);
            cmbbs.DataSource = clsnhanvien.getBacSiByID_Benh(val);
            cmbbs.DataTextField = "ten";
            cmbbs.DataValueField = "id";
            cmbbs.DataBind();
        }

        protected void btndatlich_Click(object sender, EventArgs e)
        {
            if(dangkykham.dangkykham_check(DateTime.Parse(txtngaykham.Text),int.Parse(Session["id"].ToString()),int.Parse(cmbbs.SelectedValue.ToString())))
            {
                try
                {
                    dangkykham.dangkykham_Insert(int.Parse(cmbbs.SelectedValue.ToString()), dangkykham.id_nguoidung(Session["username"].ToString()), DateTime.Parse(txtngaykham.Text));
                    Response.Write("<script>alert('Bạn đặt lịch thành công!')</script>");
                }
                catch
                {
                    Response.Write("<script>alert('Bạn đặt lịch không thành công!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Bạn đã đặt lịch giống!')</script>");
            }
        }
    }
}