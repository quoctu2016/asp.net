<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="benhvien.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txttendn" defaultbutton="btndn">
    <div>
    <div id="wrapper">
        <h1>Đăng nhập</h1>
        Tên đăng nhập<br />
        <asp:TextBox ID="txttendn" runat="server" Width="200" Height="20"></asp:TextBox><br />
        Mật khẩu<br />
        <asp:TextBox ID="txtmk" runat="server" Width="200" TextMode="Password" Height="20"></asp:TextBox><br /><br />
        <asp:Button ID="btndn" runat="server" Text="Đăng nhập" OnClick="btndn_Click" /><br /><br />
        <asp:Label ID="lbtb" runat="server" Text=""></asp:Label>
        <br /><br />
        <a href="dangky.aspx">Nếu chưa có tài khoản bấm vào để đăng ký?</a>
    </div>
    </div>
    </form>
</body>
</html>
