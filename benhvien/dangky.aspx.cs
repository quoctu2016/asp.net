﻿using _benhvien.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace benhvien
{
    public partial class dangky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1980; i <= 2017; i++)
                {
                    cmbnamsinh.Items.Add(i + "");
                }
            }
        }

        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "" && txtpass.Text != "" && txttendn.Text != "")
            {
                string gioitinh = (rdbnam.Checked) ? "Nam" : "Nữ";
                try
                {
                    if (clsnhanvien.nguoidung_CheckUsername(txttendn.Text))
                    {
                        clsbenhnhan.benhnhan_Insert(txtten.Text, cmbnamsinh.Text, gioitinh, txttendn.Text, txtpass.Text);
                        Response.Write("<script>alert('Đăng ký thành công')</script>");
                        txtpass.Text = "";
                        txtten.Text = "";
                        txttendn.Text = "";
                        Response.Redirect("login.aspx");
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
                Response.Write("<script>alert('Nhập thiếu thông tin')</script>");
            }
        }
    }
}