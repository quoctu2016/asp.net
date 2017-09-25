<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="lichsukham.aspx.cs" Inherits="benhvien.lichsukham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="text-align:center;font-weight:bold;">
                Lịch sử khám
        </legend>
        <asp:MultiView ID="mulls" runat="server" ActiveViewIndex="0">
            <asp:View ID="v1" runat="server">
                <div style="margin-left:200px;">Chọn bệnh nhân: <asp:DropDownList ID="cmbbenhnhan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbbenhnhan_SelectedIndexChanged"></asp:DropDownList>
                    <input id="hdid" type="hidden" />
                </div>
                <asp:GridView ID="gvlichsu" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%" OnSelectedIndexChanged="gvlichsu_SelectedIndexChanged" DataKeyNames="id" OnPageIndexChanging="gvlichsu_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="chuandoan" HeaderText="Chuẩn đoán" />
                        <asp:BoundField DataField="ngaykham" HeaderText="Ngày khám" DataFormatString="{0:dd/MM/yyyyy}" />
                        <asp:BoundField DataField="thanhtoan" HeaderText="Thanh toán" DataFormatString="{0:#,##}" />
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                        <asp:CommandField ButtonType="Button" HeaderText="Xem lịch sử thuốc" SelectText="Xem lịch sử" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Chưa khám trước đó"></asp:Label>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Wrap="False" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
               </asp:GridView>
            </asp:View>
            <asp:View ID="v2" runat="server">
                <asp:GridView ID="gvthuoc" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="tenthuoc" HeaderText="Tên thuốc" />
                        <asp:BoundField DataField="sl" HeaderText="Số lượng" />
                        <asp:BoundField DataField="donvi" HeaderText="Đơn vị" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        Chưa sử dụng thuốc trước đó<br />
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
                <div style="margin:50px auto;width:100px;">
                    <asp:Button ID="btnquaylai" runat="server" Text="Quay lại" Width="83px" OnClick="btnquaylai_Click" />

                </div>
            </asp:View>
        </asp:MultiView>
    </fieldset>
</asp:Content>
