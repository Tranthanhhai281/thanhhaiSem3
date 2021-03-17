<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="TraSach.aspx.cs" Inherits="ThuVien_QuanLy_LapLuotMuon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        .style6
        {
            width: 50px;
        }
        .style7
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="0" cellspacing="0" style=" width:750px" >
        <tr>
            <td colspan="3">
            <div><br /></div>
            <div style="text-align: center">
                <asp:Label ID="lbTitle" runat="server" Text="Trả Sách" 
                    style="text-align: center"></asp:Label></div>
                    <div>
                    <div><br /></div>
             <div style="text-align: center" >
                <asp:Label ID="lbThongBao" runat="server" style="text-align: center; font-style: italic; font-size: small;" 
                    ForeColor="#FF6666"></asp:Label>
                        </div>
                        <div><br /></div>
                </div>
            <div>
             <div >
                 <asp:GridView ID="grvthongtin" runat="server" CellPadding="4" 
                     ForeColor="#333333" GridLines="None" 
                     onrowdatabound="grvthongtin_RowDataBound" AutoGenerateColumns="False" >                     
                     <RowStyle BackColor="#EFF3FB" />
                     <Columns>
                         <asp:BoundField DataField="MaLuotMuon" HeaderText="MaLuotMuon" ReadOnly="True" 
                             SortExpression="MaLuotMuon" />
                         <asp:BoundField DataField="MaDocGia" HeaderText="Mã ĐọcGiả" 
                             SortExpression="MaDocGia" />
                         <asp:BoundField DataField="MaSach" HeaderText="MaSach" 
                             SortExpression="MaSach" />
                         <asp:BoundField DataField="MaNhanVien" HeaderText="MaNhanVien" 
                             SortExpression="MaNhanVien" />
                         <asp:BoundField DataField="NgayMuon" HeaderText="NgayMuon" 
                             SortExpression="NgayMuon" />
                         <asp:BoundField DataField="NgayTra" HeaderText="NgayTra" 
                             SortExpression="NgayTra" />
                         <asp:BoundField DataField="Tra/Chua" HeaderText="Tra/Chua" 
                             SortExpression="Tra/Chua" />
                         <asp:HyperLinkField DataNavigateUrlFields="MaLuotMuon" 
                             DataNavigateUrlFormatString="~/ThuVien/QuanLy/ChiTietTraSach.aspx?MaLuotMuon={0}&amp;duongdan=TraSach.aspx" 
                             HeaderText="Trả Sách" Text="Lập Trả Sách" />
                     </Columns>
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <EditRowStyle BackColor="#2461BF" />
                     <AlternatingRowStyle BackColor="White" />
                 </asp:GridView>
                 </div>
                </div>
            <div style="text-align: center">
                <br /></div>
                </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
             <div >
                 <br /></div>
              <div><br /></div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbTitleDG" runat="server" Text="Mã Đọc Giả(*):"></asp:Label>
                    <asp:TextBox ID="txtDG" runat="server" style="margin-left: 92px" Width="156px"></asp:TextBox>
                    <asp:Label ID="lbrongmadocgia" runat="server" style="color: #FF0000" 
                        Visible="False">(*)</asp:Label>
                </div>
               
                <div><br /></div>
                <div class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="lbTitleMaSach" runat="server" Text="Mã Sách(*):"></asp:Label>
                    <asp:TextBox ID="txtMaSach" runat="server" style="margin-left: 95px" 
                        Width="147px"></asp:TextBox>
                    <asp:Label ID="lbrongmasach" runat="server" style="color: #FF0000" 
                        Visible="False">(*)</asp:Label>
                    &nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtMaSach" ErrorMessage="Mã Sách Là Số" 
                        MaximumValue="9999" MinimumValue="0"></asp:RangeValidator>
                    <br />
                </div>
                <div>&nbsp;&nbsp;
                    <br /></div>
                <div><br /></div>
                </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
           
            <div> <br /></div>
            <div><br /></div>
            <div style="text-align: center">
                &nbsp;<asp:Button ID="btTim" runat="server" onclick="btTim_Click" Text="Tìm Kiếm" 
                    style="text-align: left; margin-left: 37px" />
                </div>
            <div>
                <br /></div>
               </td>
        </tr>
    </table>
   
</asp:Content>

 