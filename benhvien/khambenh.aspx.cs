using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace benhvien
{
    public partial class khambenh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnhoanthanh.Visible = false;
                kethuoc.Visible = false;
                chuyenvien.Visible = false;
                load();
                loadcmbKeThuoc();
            }
        }
        void loadlichsu()
        {
            gvlichsu.DataSource = clskhambenh.lichsukham_ByID_BN(int.Parse(idbn.Value.ToString()));
            gvlichsu.DataBind();
        }
        void load()
        {
            gvBNcho.DataSource = clskhambenh.getBenhNhan_Cho(Session["username"].ToString());
            gvBNcho.DataBind();
        }
        void loadcmbKeThuoc()
        {
            cmbthuoc.DataSource = clskhambenh.thuoc_SelectAll();
            cmbthuoc.DataValueField = "id";
            cmbthuoc.DataTextField = "tenthuoc";
            cmbthuoc.DataBind();
        }
        void loadkethuoc()
        {
            gvkethuoc.DataSource = clskhambenh.khambenh_kethuoc_SelectAll();
            gvkethuoc.DataBind();
        }
        protected void upnv_Click(object sender, EventArgs e)
        {
            if (upnv.Text =="Xem lịch sử")
            {
                gvlichsu.Visible = true;
                loadlichsu();
                upnv.Text = "Đóng";
            }
            else
            {
                gvlichsu.Visible = false;
                upnv.Text = "Xem lịch sử";
            }
        }

        protected void gvBNcho_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvBNcho.DataKeys[gvBNcho.SelectedIndex].Value;
            mulkhambenh.ActiveViewIndex = 1;
            DataTable dt = clskhambenh.getBenhNhan_ChoByID(id);
            if (dt.Rows.Count > 0)
            {
                idbn.Value = dt.Rows[0]["id"].ToString();
                lbtenbn.Text = dt.Rows[0]["ten"].ToString();
                lbnamsinhbn.Text = dt.Rows[0]["namsinh"].ToString();
                lbgioitinh.Text = dt.Rows[0]["gioitinh"].ToString();
            }
        }

        protected void btnkethuoc_Click(object sender, EventArgs e)
        {
            kethuoc.Visible = true;
            btnluu.Visible = false;
            txtchuandoan.ReadOnly = true;
            txtthanhtoan.ReadOnly = true;
            btnhoanthanh.Visible = true;
            btnkethuoc.Visible = false;
            string ngaykham = DateTime.Now.ToString("yyyy/MM/dd");
            clskhambenh.khambenh_chuandoan(txtchuandoan.Text, int.Parse(idbn.Value), int.Parse(txtthanhtoan.Text), DateTime.Parse(ngaykham),false);
        }

        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtchuandoan.Text != "" && txtthanhtoan.Text != "")
            {
                try
                {
                    string ngaykham = DateTime.Now.ToString("yyyy/MM/dd");
                    clskhambenh.khambenh_chuandoan(txtchuandoan.Text, int.Parse(idbn.Value), int.Parse(txtthanhtoan.Text),DateTime.Parse(ngaykham),false);
                    Response.Write("<script>alert('Lưu thành công')</script>");
                    load();
                    txtthanhtoan.Text = "";
                    txtchuandoan.Text = "";
                    lbgioitinh.Text = "";
                    lbnamsinhbn.Text = "";
                    lbtenbn.Text = "";
                    mulkhambenh.ActiveViewIndex = 0;
                }
                catch
                {
                    Response.Write("<script>alert('Không thể lưu')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Bạn nhập thiếu thông tin')</script>");
                return;
            }
            
        }

        protected void btnthemthuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (clskhambenh.toathuoc_Check(int.Parse(cmbthuoc.SelectedValue.ToString())))
                {
                    clskhambenh.toathuoc_Insert(int.Parse(cmbthuoc.SelectedValue.ToString()), int.Parse(txtsl.Text), cmbdonvi.Text);
                    loadkethuoc();
                }
                else
                {
                    Response.Write("<script>alert('Thuốc đã tồn tại')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('Không thêm được')</script>");
            }
        }

        protected void btnhoanthanh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Response.Write("<script>alert('Hoàn thành')</script>");
            load();
            gvkethuoc.DataSource = dt;
            gvkethuoc.DataBind();
            txtsl.Text = "";
            txtthanhtoan.Text = "";
            txtchuandoan.Text = "";
            lbgioitinh.Text = "";
            lbnamsinhbn.Text = "";
            lbtenbn.Text = "";
            kethuoc.Visible = false;
            mulkhambenh.ActiveViewIndex = 0;
        }

        protected void btnchuyenvien_Click(object sender, EventArgs e)
        {
            chuyenvien.Visible = true;
            btnchuyenvien.Visible = false;
            btnluu.Visible = false;
            btnkethuoc.Visible = false;
            btnhoanthanh.Visible = true;
            DataTable dt = clskhambenh.khambenh_SelectCapDoByusername(Session["username"].ToString());
            lbBV1.Text = dt.Rows[0]["ten"].ToString();
            hdcapdo.Value = dt.Rows[0]["capdo"].ToString();
            if (hdcapdo.Value == "Huyện")
            {
                cmbbv2.DataSource = clsbenhvien.benhvien_SelectByCapdo("Tỉnh");
                cmbbv2.DataValueField = "id";
                cmbbv2.DataTextField = "ten";
                cmbbv2.DataBind();
            }
            if (hdcapdo.Value == "Tỉnh")
            {
                cmbbv2.DataSource = clsbenhvien.benhvien_SelectByCapdo("Thành phố");
                cmbbv2.DataValueField = "id";
                cmbbv2.DataTextField = "ten";
                cmbbv2.DataBind();
            }
            if (hdcapdo.Value == "Thành phố")
            {
                cmbbv2.Items.Add("Đã ở cấp cao nhất không thể chuyển");
                cmbbv2.Enabled = false;
            }
            string ngaykham = DateTime.Now.ToString("yyyy/MM/dd");
            clskhambenh.khambenh_chuandoan(txtchuandoan.Text, int.Parse(idbn.Value), int.Parse(txtthanhtoan.Text), DateTime.Parse(ngaykham), true);
        }
    }
}