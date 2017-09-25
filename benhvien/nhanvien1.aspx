<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="nhanvien1.aspx.cs" Inherits="benhvien.nhanvien1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <fieldset>
        <legend style="font-weight:bold;font-size:30px">Nhân viên
            <br />
        </legend>
<asp:MultiView ID="mulnv" runat="server" ActiveViewIndex="0">
        <asp:View ID="v1" runat="server">
            <div class="btn"><asp:LinkButton ID="btnaddbn" runat="server" ForeColor="White" OnClick="upnv_Click">Thêm nhân viên</asp:LinkButton></div>
        <asp:GridView ID="gvNhanVien" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" DataKeyNames="id" Width="90%" OnRowDeleting="gvNhanVien_RowDeleting" OnSelectedIndexChanged="gvNhanVien_SelectedIndexChanged" AllowSorting="True" OnPageIndexChanging="gvNhanVien_PageIndexChanging" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ten" HeaderText="Tên nhân viên" >
                <ControlStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="gioitinh" HeaderText="Giới tính">
                <ControlStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="namsinh" HeaderText="Năm sinh" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="chucvu" HeaderText="Chức vụ" />
                <asp:BoundField DataField="tenphong" HeaderText="Tên phòng" />
                <asp:BoundField DataField="tenkhoa" HeaderText="Tên khoa" />
                <asp:BoundField DataField="tenbv" HeaderText="Tên bệnh viện" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Chọn" />
                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#3366CC" ForeColor="White" HorizontalAlign="Center" Wrap="True" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" BorderStyle="None" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </asp:View>
         <asp:View ID="v2" runat="server">
             <asp:HiddenField ID="hdid" runat="server" />
            <asp:HiddenField ID="hdformat" runat="server" />
            <table style="width:100%;">
                <tr>
                    <td style="text-align:right">
                        Tên nhân viên:</td>
                    <td>
                        <asp:TextBox ID="txtten" runat="server"></asp:TextBox>
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
                    <td style="text-align:right">

                        Chức vụ:</td>
                    <td>

                        <asp:DropDownList ID="cmbLoainv" runat="server">
                        </asp:DropDownList>

                    </td>
                </tr>
                
                <tr>
                    <td style="text-align:right">

                        Bệnh viện:</td>
                    <td>

                        <asp:DropDownList ID="cmbbv" runat="server" OnSelectedIndexChanged="cmbbv_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                
                <tr>
                    <td style="text-align:right">

                        Khoa:</td>
                    <td>

                        <asp:DropDownList ID="cmbkhoa" runat="server" OnSelectedIndexChanged="cmbkhoa_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                
                <tr>
                    <td style="text-align:right">

                        Phòng:</td>
                    <td>

                        <asp:DropDownList ID="cmbphong" runat="server" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Tên đăng nhập:</td>
                    <td>
                        <asp:TextBox ID="txttendn" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Mật khẩu</td>
                    <td>
                        <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnluu" runat="server" Text="Lưu" OnClick="btnluu_Click" /></td>
                </tr>
        </asp:View>
         </asp:MultiView>
    </fieldset>
</asp:Content>
