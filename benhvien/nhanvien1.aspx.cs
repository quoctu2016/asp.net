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
    public partial class nhanvien1 : System.Web.UI.Page
    {
        clsnhanvien nv = new clsnhanvien();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cmbbv_SelectedIndexChanged(null, null);
                cmbkhoa_SelectedIndexChanged(null, null);
                loadNV();
                loadcmbBV();
                loadcmbloainv();
                loadcmbkhoa(1);
                loadcmbphong(1);
            }
        }
        void loadNV()
        {
            gvNhanVien.DataSource = nv.getNhanVien();
            gvNhanVien.DataBind();
        }

        protected void gvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvNhanVien.DataKeys[gvNhanVien.SelectedIndex].Value;
            mulnv.ActiveViewIndex = 1;
            hdid.Value = id+"";
            hdformat.Value = "update";
            DataTable dt = clsnhanvien.getNhanVienByID(int.Parse(hdid.Value.ToString()));
            if (dt.Rows[0]["gioitinh"].ToString() == "Nam") rdbnam.Checked = true; else rdbnu.Checked = true;
            txtten.Text = dt.Rows[0]["ten"].ToString();
            txttendn.Text = dt.Rows[0]["username"].ToString();
            txtpass.Text = dt.Rows[0]["userpassword"].ToString();
            cmbnamsinh.Text = dt.Rows[0]["namsinh"].ToString();
            cmbLoainv.SelectedValue = dt.Rows[0]["id_loainv"].ToString();
            cmbbv.SelectedValue = dt.Rows[0]["id_bv"].ToString();
            loadcmbkhoa(int.Parse(dt.Rows[0]["id_bv"].ToString()));
            loadcmbphong(int.Parse(dt.Rows[0]["id_khoa"].ToString()));
            //cmbkhoa.SelectedValue = dt.Rows[0]["id_khoa"].ToString();
            //cmbphong.SelectedValue = dt.Rows[0]["id_phong"].ToString();
        }

        protected void upnv_Click(object sender, EventArgs e)
        {
            mulnv.ActiveViewIndex = 1;
            hdformat.Value = "insert";
        }

        void loadcmbkhoa(int id)
        {
            cmbkhoa.DataSource = clskhoa.getKhoabyID_BV(id);
            cmbkhoa.DataValueField = "id";
            cmbkhoa.DataTextField = "ten";
            cmbkhoa.DataBind();
        }
        void loadcmbkhoaByID(int id)
        {
            cmbkhoa.DataSource = clskhoa.getKhoaByid(id);
            cmbkhoa.DataValueField = "id";
            cmbkhoa.DataTextField = "ten";
            cmbkhoa.DataBind();
        }
        void loadcmbBV()
        {
            cmbbv.DataSource = clsbenhvien.getBV();
            cmbbv.DataValueField = "id";
            cmbbv.DataTextField = "ten";
            cmbbv.DataBind();
        }
        void loadcmbphong(int id)
        {
            cmbphong.DataSource = clsPhong.getphongbyID_khoa(id);
            cmbphong.DataValueField = "id";
            cmbphong.DataTextField = "ten";
            cmbphong.DataBind();
        }
        void loadcmbloainv()
        {
            cmbLoainv.DataSource = clsLoainv.getLoainv();
            cmbLoainv.DataValueField = "id";
            cmbLoainv.DataTextField = "ten";
            cmbLoainv.DataBind();
        }

        protected void cmbbv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbv.SelectedValue != null)
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
        }

        protected void cmbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbkhoa.SelectedValue != null)
            {
                int val;
                Int32.TryParse(cmbkhoa.SelectedValue.ToString(), out val);
                cmbphong.DataSource = clsPhong.getphongbyID_khoa(val);
                cmbphong.DataValueField = "id";
                cmbphong.DataTextField = "ten";
                cmbphong.DataBind();
            }
        }
        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "" && txtpass.Text != "" && txttendn.Text != "")
            {
                if (hdformat.Value == "update")
                {
                    clsnhanvien nv = new clsnhanvien();
                    string giottinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                            nv.updateNV(int.Parse(hdid.Value), txtten.Text, DateTime.Parse(cmbnamsinh.Text), giottinh, int.Parse(cmbphong.SelectedValue.ToString()), int.Parse(cmbLoainv.SelectedValue.ToString()), txttendn.Text, txtpass.Text);

                            Response.Write("<script>alert('Sửa thành công nhân viên')</script>");
                            loadNV();
                            mulnv.ActiveViewIndex = 0;
                            txtpass.Text = "";
                            txtten.Text = "";
                            txttendn.Text = "";
                    }
                    catch
                    {
                        Response.Write("<script>alert('Không thể sửa nhân viên')</script>");
                    }
                }
                else
                {
                    clsnhanvien nv = new clsnhanvien();
                    string giottinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                        if (clsnhanvien.nguoidung_CheckUsername(txttendn.Text))
                        {
                            nv.addNV(txtten.Text, DateTime.Parse(cmbnamsinh.Text), giottinh, int.Parse(cmbphong.SelectedValue.ToString()), int.Parse(cmbLoainv.SelectedValue.ToString()), txttendn.Text, txtpass.Text);
                        Response.Write("<script>alert('Thêm thành công nhân viên')</script>");
                        loadNV();
                        mulnv.ActiveViewIndex = 0;
                        txtpass.Text = "";
                        txtten.Text = "";
                        txttendn.Text = "";
                        }
                        else
                        {
                            Response.Write("<script>alert('Trùng tên đăng nhập')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('Không thể thêm nhân viên')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Bạn nhập thiếu thông tin')</script>");
            }
        }

        protected void gvNhanVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(((Label)gvNhanVien.Rows[e.RowIndex].FindControl("lbid")).Text);
            try
            {
                clsnhanvien.deleteNV(id);
                loadNV();
                Response.Write("<script>alert('Xóa thành công nhân viên')</script>");
            }
            catch
            {
                Response.Write("<script>alert('Không thể xóa nhân viên')</script>");
            }
        }

        protected void gvNhanVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNhanVien.PageIndex = e.NewPageIndex;
            loadNV();
        }
    }
}