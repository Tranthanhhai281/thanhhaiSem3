<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThemChucVu.aspx.cs" Inherits="ThuVien_QuanLy_ThemTacGia" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 219px;
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
        .style10
        {
            width: 219px;
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                <div style="background-color: #008080; text-align: center;">
                    <asp:Label ID="lbtieude" runat="server" Text="Thêm Chúc Vụ" 
                        style="color: #FFFFFF"></asp:Label></div>
                <div><br /></div></td>
        </tr>
        <tr>
            <td class="style10">
                </td>
            <td class="style9">
                <div>
                    <br />
                 </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="lbtenchucvu" runat="server" Text="Tên Chức Vụ:(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtchucvu" runat="server" style="margin-left: 10px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrong" runat="server" style="color: #FF0000" Text="(*)" 
                        Visible="False"></asp:Label>
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
                <div style="text-align: left">
                    <asp:Button ID="btThem" runat="server" Text="Thêm " Width="102px" 
                        onclick="lbThem_Click" style="margin-left: 133px" />
                    &nbsp;
                    <br /></div>
                <div><br /></div></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

