using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _benhvien.DAL;
namespace benhvien
{
    public partial class quanlythuoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadthuoc();
            }
        }
        void loadthuoc()
        {
            gvthuoc.DataSource = clsthuoc.thuoc_SelectAll();
            gvthuoc.DataBind();
        }

        protected void gvthuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvthuoc.DataKeys[gvthuoc.SelectedIndex].Value;
            DataTable dt = clsthuoc.thuoc_SelectbyID(id);
            if (dt.Rows.Count > 0)
            {
                hdformat.Value = "update";
                txtid.Text = dt.Rows[0]["id"].ToString();
                txtten.Text = dt.Rows[0]["tenthuoc"].ToString();
            }
        }

        protected void gvthuoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvthuoc.PageIndex = e.NewPageIndex;
            loadthuoc();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            hdformat.Value = "insert";
            btnthem.Visible = false;
            txtid.Text = "";
            txtten.Text = "";
        }

        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "")
            {
                if (hdformat.Value == "update")
                {
                    try
                    {
                        if (clsthuoc.thuoc_checkTen(txtten.Text))
                        {
                            clsthuoc.thuoc_update(int.Parse(txtid.Text), txtten.Text);
                            loadthuoc();
                            Response.Write("<script>alert('Sửa thành công thuốc')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Tên thuốc bị trùng')</script>");
                            return;
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('Không thể sửa thuốc')</script>");
                    }
                }
                else
                {
                    try
                    {
                        if (clsthuoc.thuoc_checkTen(txtten.Text))
                        {
                            clsthuoc.thuoc_Insert(txtten.Text);
                            loadthuoc();
                            btnthem.Visible = true;
                            txtten.Text = "";
                            Response.Write("<script>alert('Thêm thành công thuốc')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Thuốc đã tồn tại')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('Không thể thêm thuốc')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Nhập thiếu thông tin thuốc')</script>");
            }
        }

        protected void gvthuoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(((Label)gvthuoc.Rows[e.RowIndex].FindControl("Label1")).Text);
            try
            {
                clsthuoc.thuoc_Delete(id);
                loadthuoc();
                Response.Write("<script>alert('Xóa thành công thuốc')</script>");
                txtid.Text = "";
                txtten.Text = "";
            }
            catch
            {
                Response.Write("<script>alert('Không thể xóa thuốc')</script>");
            }
        }
    }
}