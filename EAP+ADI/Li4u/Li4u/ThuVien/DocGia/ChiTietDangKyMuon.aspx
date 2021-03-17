<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietDangKyMuon.aspx.cs" Inherits="ThuVien_DocGia_ChiTietDangKyMuon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width:750px ;">
        <tr>
            <td colspan="3" style="text-align: center">
            <div><br /></div>
            <div>
                <asp:Label ID="blthongtin" runat="server" ForeColor="#6666FF" 
                    Text="Thông Tin Đăng Ký"></asp:Label>
                <br /></div>
                <div><br /></div>
                <div>
                    <asp:Label ID="lbThongBao" runat="server" ForeColor="#FF5050"></asp:Label>
                    <br /></div>
                <div><br /></div>
                </td>
        </tr>
        <tr>
            <td style="width:50px;">
                &nbsp;</td>
            <td>
                <div>
                    <asp:Label ID="lbMaDocGia" runat="server" Text="Mã Đọc Giả:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lbMaDG" runat="server" ForeColor="#3366FF"></asp:Label>
                    <br /></div>
                <div><br />&nbsp;
                    <asp:Label ID="lbMaSach" runat="server" Text="Mã Sách(*):"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lbSach" runat="server" style="color: #FF0000" Text="Label"></asp:Label>
                    <br /></div>
                <div><br /></div>
               
                    <div><br /></div>
                    <div style="text-align: center">
                    &nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbThanhCong" runat="server" 
                            style="text-align: center; font-style: italic;"></asp:Label>
                    <br /></div></td>
            <td style="width:50px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                 <div><br /></div> 
                 <div> 
                     <asp:Button ID="tbDangKy" runat="server" onclick="tbDangKy_Click1" 
                         Text="Đồng Ý" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btCancel" runat="server" onclick="btCancel_Click" 
                         Text="Không Đồng Ý" />
                </div>    
                <div><br /></div>
            </td>
        </tr>
    </table>
</asp:Content>

