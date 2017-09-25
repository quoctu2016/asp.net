<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="khambenh.aspx.cs" Inherits="benhvien.khambenh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend style="font-weight:bold;font-size:30px">Bệnh nhân chờ</legend>
        <asp:MultiView ID="mulkhambenh" runat="server" ActiveViewIndex="0" >
            <asp:View ID ="v1" runat="server" >
                <asp:GridView ID="gvBNcho" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="id" OnSelectedIndexChanged="gvBNcho_SelectedIndexChanged" Width="90%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ten" HeaderText="Tên bệnh nhân">
                        <ControlStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="namsinh" HeaderText="Năm sinh">
                        <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gioitinh" HeaderText="Giới tính">
                        <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Tạo phiếu khám" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" BackColor="#0066FF" CausesValidation="False" CommandName="Select" ForeColor="White" Text="Tạo phiếu" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        Không có bệnh nhân đặt lịch hôm nay
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
            </asp:View>
            <asp:View ID ="v2" runat="server">
                <asp:HiddenField ID="idbn" runat="server" />
                    <table style="align-content:center;margin-left:100px;">
                    <tr>
                        <th style="width:300px">Tên Bệnh nhân: 
                        <asp:Label ID="lbtenbn" runat="server" Text="Label"></asp:Label></th>
                    </tr><tr>
                        <th style="width:250px">Giới tính:
                            <asp:Label ID="lbgioitinh" runat="server" Text="Label"></asp:Label>
                            </th>
                    </tr>
                        <tr>
                            
                        <th style="width:250px">Năm sinh: 
                        <asp:Label ID="lbnamsinhbn" runat="server" Text="Label"></asp:Label></th>
                        </tr>
                    </table>
                <div class="btn" style="margin-top:20px;"><asp:LinkButton ID="upnv" runat="server" ForeColor="White" Width="100%" OnClick="upnv_Click">Xem lịch sử</asp:LinkButton></div>
                <asp:GridView ID="gvlichsu" runat="server" Visible="False" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="chuandoan" HeaderText="Chuẩn đoán" />
                        <asp:BoundField DataField="ngaykham" HeaderText="Ngày khám" DataFormatString="{0:dd/MM/yyyyy}" />
                        <asp:BoundField DataField="thanhtoan" HeaderText="Thanh toán" DataFormatString="{0:#,##}" Visible="False" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Chưa khám trước đó"></asp:Label>
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
                <table style="width: 100%;">
                    <tr>
                        <td>Chuẩn đoán:</td>
                        <td><asp:TextBox ID="txtchuandoan" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Thanh toán</td>
                        <td>
                            <asp:TextBox ID="txtthanhtoan" runat="server" TextMode="Number" Width="189px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="color:red">(*)Nhấn vào kê thuốc nếu cần</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnluu" runat="server" Text="Lưu" OnClick="btnluu_Click" />   <asp:Button ID="btnkethuoc" runat="server" Text="Kê thuốc" OnClick="btnkethuoc_Click" />
                            <asp:Button ID="btnchuyenvien" runat="server" OnClick="btnchuyenvien_Click" Text="Chuyển viện" />
                        </td>
                    </tr>
                    <tr runat="server" id="chuyenvien"> 
                        <td>Chuyển viện</td>
                        <td>
                            Bệnh viện hiện tại: 
                            <asp:Label ID="lbBV1" runat="server"></asp:Label>
                            <br />
                            <input id="hdcapdo" type="hidden"  runat="server"/>
                            <br />
                            Bệnh viện chuyển tới: <asp:DropDownList ID="cmbbv2" runat="server"></asp:DropDownList><br /><br />
                        </td>
                    </tr>
                    <tr id="kethuoc" runat="server">
                        <td>
                            Kê thuốc</td>
                        <td>
                            Tên thuốc:&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="cmbthuoc" runat="server"></asp:DropDownList><br /><br />
                            Số lượng:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtsl" runat="server" TextMode="Number"></asp:TextBox><br /><br />
                            Đơn vị:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="cmbdonvi" runat="server">
                                <asp:ListItem>Vĩ</asp:ListItem>
                                <asp:ListItem>Viên</asp:ListItem>
                                <asp:ListItem>Hộp</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="btnthemthuoc" runat="server" Text="Thêm thuốc" OnClick="btnthemthuoc_Click" /><br />
                            <asp:GridView ID="gvkethuoc" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Tên thuốc">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tenthuoc") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("tenthuoc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("sl") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("sl") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("donvi") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("donvi") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <EmptyDataTemplate>
                                    Chưa kê thuốc
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
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnhoanthanh" runat="server" Text="Hoàn thành" OnClick="btnhoanthanh_Click" /></td>
                    </tr>
                </table>
                 </asp:View>
        </asp:MultiView>
            
    </fieldset>
</asp:Content>
