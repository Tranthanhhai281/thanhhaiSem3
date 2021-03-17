<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThemTacGia.aspx.cs" Inherits="ThuVien_QuanLy_ThemTacGia" Title="Untitled Page" %>

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
        .style8
        {
            width: 20px;
            height: 77px;
        }
        .style9
        {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                <div style="background-color: #008080">
                    <asp:Label ID="lbtieude" runat="server" Text="Thêm Tác Giả" 
                        style="color: #FFFFFF"></asp:Label></div>
                <div><br /></div></td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
                <div>
                 </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="lbnxb" runat="server" Text="Tên Tác Giả:(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtTacGia" runat="server" style="margin-left: 10px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbthongbaorong" runat="server" style="color: #FF0000" Text="(*)"></asp:Label>
                </div>
                <div></div></td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                <div><br /></div>
                <div>
                    <asp:Button ID="lbThem" runat="server" Text="Thêm " Width="102px" 
                        onclick="lbThem_Click" />
                    &nbsp;
                    <asp:Button ID="lbKhongThem" runat="server" Text="Không Thêm" 
                        style="margin-left: 47px" onclick="lbKhongThem_Click" />
                    <br /></div>
                <div><br /></div></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

