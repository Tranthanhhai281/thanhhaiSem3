<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="ThuVien_DocGia_DangKyMuonSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <br />
    <table style="width:750px ;" >
        <tr>
            <td>
                &nbsp;
                <div style="text-align: center">
                    <asp:Label ID="lbThongBao" runat="server" ForeColor="Red" ></asp:Label>
                </div>
                <div>
                <br />
                </div>
                </td>
                
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lbMaDocGia" runat="server" Text="Mã Đọc Giả"></asp:Label>
&nbsp;(*):<asp:TextBox ID="txtMaDocGia" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="tbDangNhap" runat="server" onclick="tbDangNhap_Click" 
                    Text="Đăng Nhập" />
            </td>
        </tr>
    </table>
</asp:Content>

