<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="quanlylichkham.aspx.cs" Inherits="benhvien.quanlylichkham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <fieldset>
        <legend style="font-weight:bold;font-size:30px">Quản lý lịch khám
            <br />
        </legend>
        <br />
        <div style="margin-left:200px;">
            Chọn ngày: <asp:TextBox ID="txtngaykham" runat="server" TextMode="Date" AutoPostBack="True" OnTextChanged="txtngaykham_TextChanged"></asp:TextBox></div>
        <asp:GridView ID="gvQLLichKham" runat="server" Width="70%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ten" HeaderText="Bệnh nhân" />
                <asp:BoundField DataField="tenbacsi" HeaderText="Bác sĩ" />
                <asp:BoundField DataField="ngaykham" DataFormatString="{0:dd/MM/yyyyy}" HeaderText="Ngày dặt" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataTemplate>
                Không có ai đặt lịch
            </EmptyDataTemplate>
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
    </fieldset>
    <br />
    <br />
</asp:Content>
