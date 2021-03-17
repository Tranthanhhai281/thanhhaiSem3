<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThongKe.aspx.cs" Inherits="ThuVien_QuanLy_ThongKe" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="text-align: left">
                <div><ul><li>
                    <asp:HyperLink ID="lnkthongketacgia" runat="server" style="font-size: small" 
                        NavigateUrl="~/ThuVien/QuanLy/ThongKeTacGia.aspx">Thông Kê Tác Giả</asp:HyperLink></li></ul></div>
                    <div><ul><li>
                    <asp:HyperLink ID="lnkThongkenhaxuatban" runat="server" style="font-size: small" 
                            NavigateUrl="~/ThuVien/QuanLy/ThongKeNhaXuatBan.aspx">Thống Kê Nhà Xuất Bản</asp:HyperLink></li></ul></div>
                        <div><ul><li>
                         <asp:HyperLink ID="lnkdocgiamuonsachquahan" runat="server" style="font-size: small" 
                            NavigateUrl="~/ThuVien/QuanLy/ThongKeSachQuaHan.aspx">Thống Kê Sách Quá Hạn
                        </asp:HyperLink></li></ul></div>
                         <div><ul><li>
                         <asp:HyperLink ID="lnkthongkesachgiahan" runat="server" style="font-size: small" 
                            NavigateUrl="~/ThuVien/QuanLy/ThongKeSachGiaHan.aspx">Thống Kê Sách Gian Hạn
                        </asp:HyperLink></li></ul></div>
                        <div><ul><li>
                         <asp:HyperLink ID="lnkthongkedocgiadangkymuon" runat="server" style="font-size: small" 
                            NavigateUrl="~/ThuVien/QuanLy/ThongKeLuotDangKy.aspx">Thống Kê Lượt Đăng Ký
                        </asp:HyperLink></li></ul></div>
                        <div><ul><li>
                         <asp:HyperLink ID="lnkthongkesachmuon" runat="server" style="font-size: small" 
                            NavigateUrl="~/ThuVien/QuanLy/ThongKeLuotMuon.aspx">Thống Kê Lượt Mượn
                        </asp:HyperLink></li></ul></div>
                    </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

