<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThongKeSachQuaHan.aspx.cs" Inherits="ThuVien_QuanLy_ThongKeSachMuon" Title="Untitled Page" %>

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
            height: 20px;
        }
        .style9
        {
            height: 20px;
        }
                
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                <div style="text-align: center; background-color: #008080;">
                    <asp:Label ID="lbtieu0" runat="server" Text="Thống Kê Sách Quá Hạn" 
                        style="color: #FFFFFF"></asp:Label>
                    <br /></div>
                
                <div><br /></div>
                <div>
                    
                   </div>
                <div style="text-align: center">&nbsp;&nbsp;<asp:Label ID="lbthongbao" 
                        runat="server" style="text-align: center; color: #0000FF; font-style: italic"></asp:Label>
                    <br /></div>
            </td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
    <asp:GridView ID="grvthongtin" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="MaLuotMuon" ForeColor="#333333" GridLines="None" 
                    AllowPaging="True">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="MaLuotMuon" HeaderText="Lượt Mượn" ReadOnly="True" 
                SortExpression="MaLuotMuon" />
            <asp:BoundField DataField="MaSach" HeaderText="Mã Sách" 
                SortExpression="MaSach" />
            <asp:BoundField DataField="MaDocGia" HeaderText="Đọc Giả" 
                SortExpression="MaDocGia" />
            <asp:BoundField DataField="MaGiaHan" HeaderText="Gian Hạn" 
                SortExpression="MaGiaHan" />
            <asp:BoundField DataField="MaNhanVien" HeaderText="Nhân Viên" 
                SortExpression="MaNhanVien" />
            <asp:BoundField DataField="NgayMuon" HeaderText="Ngày Mượn" 
                SortExpression="NgayMuon" />
            <asp:BoundField DataField="NgayTra" HeaderText="Ngày Trả" 
                SortExpression="NgayTra" />
            <asp:BoundField DataField="Tra/Chua" HeaderText="Trả/Chưa" 
                SortExpression="Tra/Chua" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="text-align: center">
                &nbsp; &nbsp;
                <asp:Button ID="btexcel" runat="server" onclick="btexcel_Click" 
                    Text="Xuất Excel" />
                <asp:Button ID="btword" runat="server" onclick="btword_Click" 
                    style="margin-left: 38px; height: 26px;" Text="Xuất Word" />
                <asp:Button ID="btpdf" runat="server" onclick="btpdf_Click" 
                    style="margin-left: 37px" Text="Xuất Pdf" /></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

