<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="quanlythuoc.aspx.cs" Inherits="benhvien.quanlythuoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="text-align:center;font-weight:bold;">
                Quản lý thuốc
        </legend>
                <asp:GridView ID="gvthuoc" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="50%" DataKeyNames="id" OnPageIndexChanging="gvthuoc_PageIndexChanging" OnSelectedIndexChanged="gvthuoc_SelectedIndexChanged" OnRowDeleting="gvthuoc_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Mã thuốc">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên thuốc">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tenthuoc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("tenthuoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Chọn" />
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
        <br />
        <br />
        <table style="margin-left:200px;text-align:center">
            <tr>
                <th colspan="2" style="text-align:center">
                    <input id="hdformat" runat="server" type="hidden" />
                    Thông tin thuốc</th>
            </tr>
            <tr>
                <td class="auto-style1">Mã thuốc:</td>
                <td>
                    <asp:TextBox ID="txtid" runat="server" Width="283px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1">Tên thuốc:</td>
                <td>
                    <asp:TextBox ID="txtten" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td>
                    <asp:Button ID="btnluu" runat="server" Text="Lưu" Width="79px" OnClick="btnluu_Click" />
                    <asp:Button ID="btnthem" runat="server" Text="Thêm mới" OnClick="btnthem_Click" />
                </td>
            </tr>
            </table>
        <br />
    </fieldset>
</asp:Content>
