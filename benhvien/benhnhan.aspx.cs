using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using _benhvien.DAL;
namespace benhvien
{
    public partial class benhnhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1980; i <= 2017; i++)
                {
                    cmbnamsinh.Items.Add(i + "");
                }
                loadbenhnhan();
            }
        }
        void loadbenhnhan()
        {
            gvBenhNhan.DataSource = clsbenhnhan.benhnhan_SelectAll();
            gvBenhNhan.DataBind();
        }

        protected void btnaddbn_Click(object sender, EventArgs e)
        {
            mulnv.ActiveViewIndex = 1;
            hdformat.Value = "insert";
        }

        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "" && txtpass.Text != "" && txttendn.Text != "")
            {
                if (hdformat.Value == "insert")
                {
                    string gioitinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                        if (clsnhanvien.nguoidung_CheckUsername(txttendn.Text))
                        {
                            clsbenhnhan.benhnhan_Insert(txtten.Text, cmbnamsinh.Text, gioitinh, txttendn.Text, txtpass.Text);
                            Response.Write("<script>alert('Thêm thành công bệnh nhân')</script>");
                            loadbenhnhan();
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
                        Response.Write("<script>alert('Không thể thêm bệnh nhân')</script>");
                    }

                }
                else
                {
                    string gioitinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                    try
                    {
                            clsbenhnhan.benhnhan_Update(int.Parse(hdid.Value),txtten.Text, cmbnamsinh.Text, gioitinh, txttendn.Text, txtpass.Text);
                        Response.Write("<script>alert('Sửa thành công bệnh nhân')</script>");
                        loadbenhnhan();
                        mulnv.ActiveViewIndex = 0;
                        txtpass.Text = "";
                        txtten.Text = "";
                        txttendn.Text = "";
                    }
                    catch(Exception ex)
                    {
                        Response.Write("<script>alert('"+ex.Message.ToString()+"')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Nhập thiếu thông tin')</script>");
            }
        }

        protected void gvBenhNhan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBenhNhan.PageIndex = e.NewPageIndex;
            loadbenhnhan();
        }

        protected void gvBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvBenhNhan.DataKeys[gvBenhNhan.SelectedIndex].Value;
            mulnv.ActiveViewIndex = 1;
            hdid.Value = id + "";
            hdformat.Value = "update";
            DataTable dt = clsbenhnhan.benhnhan_SelectByID(int.Parse(hdid.Value.ToString()));
            if (dt.Rows[0]["gioitinh"].ToString() == "Nam") rdbnam.Checked = true; else rdbnu.Checked = true;
            txtten.Text = dt.Rows[0]["ten"].ToString();
            txttendn.Text = dt.Rows[0]["username"].ToString();
            txtpass.Text = dt.Rows[0]["userpassword"].ToString();
            cmbnamsinh.Text = dt.Rows[0]["namsinh"].ToString();
        }

        protected void gvBenhNhan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(((Label)gvBenhNhan.Rows[e.RowIndex].FindControl("lbid")).Text);
            try
            {
                clsbenhnhan.benhnhan_Delete(id);
                loadbenhnhan();
                Response.Write("<script>alert('Xóa thành công bệnh nhân')</script>");
            }
            catch
            {
                Response.Write("<script>alert('Xóa không thành công bệnh nhân')</script>");
            }
        }
    }
}