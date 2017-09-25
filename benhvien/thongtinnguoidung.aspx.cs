using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _benhvien.DAL;
using System.Data;
namespace benhvien
{
    public partial class thongtinnguoidung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id_loainv"].ToString() == "4")
                {
                    loadInfoBenhNhan();
                }
                else
                {
                    loadInfoNhanVien();
                }
            }
        }
        void loadInfoBenhNhan()
        {
            DataTable dt = clsthongtinnguoidung.nguoidung_BenhNhan(Session["username"].ToString());
            txtten.Text = dt.Rows[0]["ten"].ToString();
            string a = dt.Rows[0]["namsinh"].ToString();
            DateTime b = Convert.ToDateTime(a);
            cmbnamsinh.Text = b.ToShortDateString();
            if (dt.Rows[0]["gioitinh"].ToString() == "Nam")
            {
                rdbnam.Checked = true;
            }
            else rdbnu.Checked = true;
            lbchucvu.Text = "Bệnh nhân";
            lbusername.Text = dt.Rows[0]["username"].ToString();
            txtpass.Text = dt.Rows[0]["userpassword"].ToString();
            bv.Visible = false;
            khoa.Visible = false;
            phong.Visible = false;
        }
        void loadInfoNhanVien()
        {
            loadcmbBV();
            loadcmbkhoa(1);
            loadcmbphong(1);

            DataTable dt = clsthongtinnguoidung.nguoidung_SelectByUsername(Session["username"].ToString());
            txtten.Text = dt.Rows[0]["ten"].ToString();
            cmbnamsinh.Text = dt.Rows[0]["namsinh"].ToString();
            if (dt.Rows[0]["gioitinh"].ToString() == "Nam")
            {
                rdbnam.Checked = true;
            }
            else rdbnu.Checked = true;
            lbchucvu.Text = dt.Rows[0]["chucvu"].ToString();
            cmbbv.SelectedValue = dt.Rows[0]["id_bv"].ToString();
            cmbkhoa.SelectedValue = dt.Rows[0]["id_khoa"].ToString();
            cmbphong.SelectedValue = dt.Rows[0]["id_phong"].ToString();
            lbusername.Text = dt.Rows[0]["username"].ToString();
            txtpass.Text = dt.Rows[0]["userpassword"].ToString();
            hdid.Value = dt.Rows[0]["id_loainv"].ToString();
            if (hdid.Value != "1")
            {
                cmbkhoa.Enabled = false;
                cmbbv.Enabled = false;
                cmbphong.Enabled = false;
            }
        }
        void loadcmbBV()
        {
            cmbbv.DataSource = clsbenhvien.getBV();
            cmbbv.DataValueField = "id";
            cmbbv.DataTextField = "ten";
            cmbbv.DataBind();
        }
        void loadcmbkhoa(int id)
        {
            cmbkhoa.DataSource = clskhoa.getKhoabyID_BV(id);
            cmbkhoa.DataValueField = "id";
            cmbkhoa.DataTextField = "ten";
            cmbkhoa.DataBind();
        }
        void loadcmbphong(int id)
        {
            cmbphong.DataSource = clsPhong.getphongbyID_khoa(id);
            cmbphong.DataValueField = "id";
            cmbphong.DataTextField = "ten";
            cmbphong.DataBind();
        }
        protected void cmbbv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(cmbbv.SelectedValue.ToString(), out val);
            cmbkhoa.DataSource = clskhoa.getKhoabyID_BV(val);
            cmbkhoa.DataValueField = "id";
            cmbkhoa.DataTextField = "ten";
            cmbkhoa.DataBind();
            int val1;
            Int32.TryParse(cmbkhoa.SelectedValue.ToString(), out val1);
            cmbphong.DataSource = clsPhong.getphongbyID_khoa(val1);
            cmbphong.DataValueField = "id";
            cmbphong.DataTextField = "ten";
            cmbphong.DataBind();
        }

        protected void cmbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(cmbkhoa.SelectedValue.ToString(), out val);
            cmbphong.DataSource = clsPhong.getphongbyID_khoa(val);
            cmbphong.DataValueField = "id";
            cmbphong.DataTextField = "ten";
            cmbphong.DataBind();
        }
        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != "" && txtten.Text != "")
            {
                if (Session["id_loainv"].ToString() == "4")
                {
                    string gioitinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                        clsbenhnhan.benhnhan_Update(int.Parse(Session["id"].ToString()), txtten.Text,DateTime.Parse(cmbnamsinh.Text), gioitinh, lbusername.Text, txtpass.Text);
                        loadInfoBenhNhan();
                        Response.Write("<script>alert('Sửa thành công thông tin')</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('Sửa không thành công')</script>");
                    }
                }
                else
                {
                    string giottinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                        clsthongtinnguoidung.nguoidung_updateNhanVien(int.Parse(Session["id"].ToString()), txtten.Text, int.Parse(cmbnamsinh.Text), giottinh, int.Parse(cmbphong.SelectedValue.ToString()), txtpass.Text);
                        DataTable dt = clsthongtinnguoidung.nguoidung_SelectByUsername(Session["username"].ToString());
                        txtten.Text = dt.Rows[0]["ten"].ToString();
                        cmbnamsinh.Text = dt.Rows[0]["namsinh"].ToString();
                        if (dt.Rows[0]["gioitinh"].ToString() == "Nam")
                        {
                            rdbnam.Checked = true;
                        }
                        else rdbnu.Checked = true;
                        lbchucvu.Text = dt.Rows[0]["chucvu"].ToString();
                        cmbbv.SelectedValue = dt.Rows[0]["id_bv"].ToString();
                        cmbkhoa.SelectedValue = dt.Rows[0]["id_khoa"].ToString();
                        cmbphong.SelectedValue = dt.Rows[0]["id_phong"].ToString();
                        lbusername.Text = dt.Rows[0]["username"].ToString();
                        txtpass.Text = dt.Rows[0]["userpassword"].ToString();
                        hdid.Value = dt.Rows[0]["id_loainv"].ToString();
                        if (hdid.Value != "1")
                        {
                            cmbkhoa.Enabled = false;
                            cmbbv.Enabled = false;
                            cmbphong.Enabled = false;
                        }
                        Response.Write("<script>alert('Sửa thành công nhân viên')</script>");
                    }
                    catch
                    {
                        loadInfoNhanVien();
                        Response.Write("<script>alert('Không thể sửa')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Nhập thiếu thông tin')</script>");
            }
            
        }
    }
}