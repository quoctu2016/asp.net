<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thongtinnguoidung.aspx.cs" Inherits="benhvien.thongtinnguoidung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="text-align:center;font-weight:bold;">
                Thông tin người dùng
        </legend>
        <table style="width:80%;margin:0px auto;" runat="server">
            <tr >
                <td style="text-align:right">
                    <input id="hdid" type="hidden" runat="server" />
                    Tên người dùng:</td>
                <td style="padding:10px">
                    <asp:TextBox ID="txtten" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Năm sinh:</td>
                <td style="padding:10px">
                    <asp:DropDownList ID="cmbnamsinh" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Giới tính:</td>
                <td style="padding:10px">
                    <asp:RadioButton ID="rdbnam" runat="server" Checked="True" GroupName="gioitinh" Text="Nam" />
                    <asp:RadioButton ID="rdbnu" runat="server" GroupName="gioitinh" Text="Nữ" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Chức vụ:</td>
                <td style="padding:10px">
                    <asp:Label ID="lbchucvu" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr id="bv" runat="server">
                <td style="text-align:right">Tên bệnh viện:</td>
                <td style="padding:10px">

                        <asp:DropDownList ID="cmbbv" runat="server" OnSelectedIndexChanged="cmbbv_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                </td>
            </tr>
            <tr id="khoa" runat="server">
                <td style="text-align:right">Tên khoa: </td>
                <td style="padding:10px">

                        <asp:DropDownList ID="cmbkhoa" runat="server" OnSelectedIndexChanged="cmbkhoa_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                </td>
            </tr>
            <tr id="phong" runat="server">
                <td style="text-align:right">Tên phòng:</td>
                <td style="padding:10px">

                        <asp:DropDownList ID="cmbphong" runat="server" AutoPostBack="True">
                        </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">Tên đăng nhập:</td>
                <td style="padding:10px">
                    <asp:Label ID="lbusername" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Mật khẩu:</td>
                <td style="padding:10px">
                    <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnluu" runat="server" Text="Lưu" OnClick="btnluu_Click" Width="87px" />

                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
