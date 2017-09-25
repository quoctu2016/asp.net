<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tieptan.aspx.cs" Inherits="benhvien.tieptan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Đặt lịch khám</h1>
    <p>
        <table style="width:100%;">
            <tr>
                <td>Tên bệnh viện:</td>
                <td>
                    <asp:DropDownList ID="cmbbenhvien" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbbenhvien_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Tên bệnh</td>
                <td>
                    <asp:DropDownList ID="cmbbenh" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbbenh_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Tên bác sĩ</td>
                <td>
                    <asp:DropDownList ID="cmbbs" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ngày khám</td>
                <td>
                    <asp:TextBox ID="txtngaykham" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btndatlich" runat="server" Text="Đặt lịch" OnClick="btndatlich_Click" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
