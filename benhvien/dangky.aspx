<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangky.aspx.cs" Inherits="benhvien.dangky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <link href="Content/dangky.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <fieldset>
            <legend style="text-align:center;font-size:20px;font-weight:bold">Thông tin đăng ký</legend>
            <table style="width:100%;">
                <tr>
                    <td style="text-align:right">
                        Tên bệnh nhân:</td>
                    <td>
                        <asp:TextBox ID="txtten" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập tên" ControlToValidate="txtten" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td style="text-align:right">Năm sinh:</td>
                    <td>
                        <asp:TextBox ID="cmbnamsinh" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Giới tính:</td>
                    <td>
                        <asp:RadioButton ID="rdbnam" runat="server" Text="Nam" Checked="true" GroupName="gioitinh"/>
                        <asp:RadioButton ID="rdbnu" runat="server" Text="Nữ" GroupName="gioitinh" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Tên đăng nhập:</td>
                    <td>
                        <asp:TextBox ID="txttendn" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn phải nhập tên đăng nhập" ControlToValidate="txttendn" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Mật khẩu:</td>
                    <td>
                        <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn phải nhập mật khẩu" ControlToValidate="txtpass" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Nhập lại mật khẩu:</td>
                    <td>
                        <asp:TextBox ID="txtrepass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn phải nhập lại mật khẩu" ControlToValidate="txtrepass" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass" ControlToValidate="txtrepass" ErrorMessage="Bạn nhập mật khẩu lại sai" ForeColor="#FF3300">*</asp:CompareValidator>
                    </td>
                </tr>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnluu" runat="server" Text="Đăng ký" OnClick="btnluu_Click" />
                        <input id="Reset1" type="reset" value="Làm lại" /></td>
                </tr>
                </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
