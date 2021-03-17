<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="LapLuotMuon.aspx.cs" Inherits="ThuVien_QuanLy_LapLuotMuon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        .style6
        {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="0" cellspacing="0" style=" width:750px" >
        <tr>
            <td colspan="3">
            <div><br /></div>
            <div style="text-align: center">
                <asp:Label ID="lbTitle" runat="server" Text="Lập Lượt Mượn" 
                    style="text-align: center"></asp:Label></div>
            <div><br /></div>
            <div style="text-align: center">
                <asp:Label ID="lbThongBao" runat="server" style="text-align: center" 
                    ForeColor="#FF6666"></asp:Label>
                <br /></div>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
             <div align="center">
                 <asp:GridView ID="grvthongtin" runat="server" CellPadding="4" 
                     ForeColor="#333333" GridLines="None" >
                     <RowStyle BackColor="#EFF3FB" />
                     <Columns>
                         <asp:HyperLinkField DataNavigateUrlFields="STT" 
                             DataNavigateUrlFormatString="~/ThuVien/QuanLy/ChiTietMuonSach.aspx?STT={0}" 
                             DataTextFormatString="{0}" HeaderText="Cho  Mượn Sách" Text="Cho Mượn Sách" />
                     </Columns>
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <EditRowStyle BackColor="#2461BF" />
                     <AlternatingRowStyle BackColor="White" />
                 </asp:GridView>
                 <br /></div>
              <div><br /></div>
                <div>
                    <asp:Label ID="lbTitleDG" runat="server" Text="Mã Đọc Giả(*):"></asp:Label>
                    <asp:TextBox ID="txtDG" runat="server"></asp:TextBox>
                &nbsp;<asp:Label ID="lbrongmadocgia" runat="server" style="color: #FF0066" 
                        Text="(*)" Visible="False"></asp:Label>
                </div>
               
                <div><br /></div>
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbTitleMaSach" runat="server" Text="Mã Sách(*):"></asp:Label>
                    <asp:TextBox ID="txtMaSach" runat="server"></asp:TextBox>
                &nbsp;
                    <asp:Label ID="lbrongmasach" runat="server" style="color: #FF0066" Text="(*)" 
                        Visible="False"></asp:Label>
                &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtMaSach" ErrorMessage="Ký Tự Số" MaximumValue="9999" 
                        MinimumValue="0"></asp:RangeValidator>
                </div>
                <div>
                    <br /></div>
                </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
            <div><br /></div>
            <div>
                <asp:Label ID="lbKetQua" runat="server" ForeColor="Blue"></asp:Label>
                <br /></div>
            <div><br /></div>
            <div style="text-align: center">
                <asp:Button ID="btLap" runat="server" Text="Đồng Ý" onclick="btLap_Click1" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btTim" runat="server" onclick="btTim_Click" Text="Tìm Kiếm" />
                </div>
            <div><br /></div>
               </td>
        </tr>
    </table>
   
</asp:Content>

 