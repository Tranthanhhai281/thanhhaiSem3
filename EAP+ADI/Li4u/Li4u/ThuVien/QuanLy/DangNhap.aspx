<?xml version="1.0" encoding="utf-8" ?>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="login" UICulture="Auto"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            color: #6699FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panelform" runat="server" BackColor="#E0E0E0" Height="260px" 
            Width="370px" BackImageUrl="~/Image/nen.jpg" Font-Bold="True">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style1"><b>&nbsp;<asp:Label 
                ID="lbĐangNhap" runat="server" style="color: #0066FF" Text="Đăng Nhập" ></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp; </b>
            <asp:Label ID="lbMaNv" runat="server" Text="Mã Nhân Viên:(*)"></asp:Label>
            </span>
            <asp:TextBox ID="txtMaNv" runat="server" Width="146px" 
                style="margin-left: 13px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtMaNv" ErrorMessage="(*)"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Mật Khẩu:(*)" 
                style="color: #3399FF"></asp:Label>
            &nbsp;<asp:TextBox ID="txtMatKhau" runat="server" Width="141px" 
                style="margin-left: 8px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtMatKhau" ErrorMessage="(*)"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbCanhBao" runat="server" ForeColor="#FF6666"></asp:Label>
            <br />
            &nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="tbDangNhap" runat="server" Text="Đăng Nhập" 
                onclick="tbDangNhap_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/ThuVien/QuanLy/DangKyTaiKhoan.aspx">Đăng Ký</asp:HyperLink>
          
            
            
            </asp:Panel>
    
    </div>
        &nbsp;<br />
    </form>
</body>
<script language="javascript" type="text/javascript">
if(document.getElementById("txtMaNv").value=="*")
{
    opener.location.href="Default.aspx";//chuyển trang
    window.close();
}
</script>
<script language="javascript" type="text/javascript">
        function OpenLoginWindow() {
    var winWidth = 370;
    var winHeight = 270;
    winLeft=(screen.width-winWidth)/2;
    winTop=(screen.height-winHeight)/2;
    s=location.pathname.substring(0, location.pathname.indexOf("/",1))//s la "/Quanlytuyensinh"
    s="http://"+location.host+s+"/ThuVien/QuanLy/DangNhap.aspx";//localhost.host la "localhost:'so'"
    win=window.open(s,"DangNhap","resizable=no,scrollbars=no,width="+winWidth+",height="+winHeight+",left="+winLeft+",top="+winTop);
    win.focus();
    return false;
}
    </script>
</html>
