<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="LapChiTietHoaDon.aspx.cs" Inherits="ThuVien_QuanLy_LapChiTietViPham" Title="Untitled Page" %>

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
            height: 68px;
        }
        .style9
        {
            height: 68px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
            <div style="text-align: center"><asp:Label ID="lbtieude0" runat="server" Text="Lập Hóa Đơn"></asp:Label><br /></div>
                  <div><br /></div>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
                <div style="text-align: left">
                    &nbsp;
                    <asp:Label ID="lbtieude1" runat="server" style="text-align: left" 
                        Text="Mã Hóa Đơn(*):"></asp:Label>
                    <asp:TextBox ID="txtmahoadon" runat="server" style="margin-left: 10px"></asp:TextBox>
                    <asp:Label ID="lbrongmahoadon" runat="server" Text="(*)" 
                        style="color: #FF0000; background-color: #FFFFFF"></asp:Label>
                </div>
                <div><br /></div>
                <div style="text-align: left">
                    &nbsp;
                    <asp:Label ID="lbtieude2" runat="server" Text="Mã Lượt Mượn:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lbmaluotmuon" runat="server" Text="" style="color: #0066FF"></asp:Label>
                    <br /></div>
                <div><br /></div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbtieude3" runat="server" Text="Mã Đọc Giả:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lbmadocgia" runat="server" Text="" style="color: #0066FF"></asp:Label>
                    <br /></div>
                <div><br /></div>
                 <div style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Label ID="lbtieude4" runat="server" Text="Số Tiền(*):"></asp:Label>
                     <asp:TextBox ID="txtsotien" runat="server" style="margin-left: 15px"></asp:TextBox>
                     <asp:Label ID="lbrongsotien" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                     <br /></div>
                  <div><br /></div>
                  <div style="text-align: left">&nbsp;&nbsp;<asp:Label ID="lbtieude5" runat="server" Text="Thanh Toán Chưa/Rồi:"></asp:Label>
                      <asp:DropDownList ID="drptrachua" runat="server" style="margin-left: 13px">
                          <asp:ListItem Value="Roi">Rồi</asp:ListItem>
                          <asp:ListItem Value="Chua">Chưa</asp:ListItem>
                      </asp:DropDownList>
                      <br /></div>
                  <div><br /></div>
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
            <div><br /></div>
                <div>
                    <asp:Button ID="btdongy" runat="server" Text="Đồng Ý" onclick="btdongy_Click" />
                    <asp:Button ID="btkhongdongy" runat="server" style="margin-left: 53px" 
                        Text="Không Đồng Ý" Width="97px" onclick="btkhongdongy_Click" />
                    <br /></div>
                  <div><br /></div></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

