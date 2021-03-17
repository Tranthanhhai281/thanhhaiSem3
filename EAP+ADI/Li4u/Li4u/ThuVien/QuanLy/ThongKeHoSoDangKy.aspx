<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThongKeHoSoDangKy.aspx.cs" Inherits="ThuVien_QuanLy_ThongKeTacGia" Title="Untitled Page" %>

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
            <div style="text-align: center; background-color: #008080;">
                <asp:Label ID="lbtieude0" runat="server" Text="Thống Kê Hồ Sơ Đăng Ký Mượn Sách " 
                    style="color: #CCFFFF"></asp:Label>
                <br /></div>
                </td>
        </tr>
        <tr>
            <td class="style7">             
                &nbsp;</td>
            <td align="center" >
                <div><br /></div>
                <div style="text-align: left">
                    <asp:GridView ID="grvthongtin" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="3" DataKeyNames="STT" DataSourceID="sqlhosodangkymuon" 
                        ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="30">
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="True" 
                                SortExpression="STT" />
                            <asp:BoundField DataField="MaSach" HeaderText="Mã Sách" 
                                SortExpression="MaSach" />
                            <asp:BoundField DataField="MaDocGia" HeaderText="Mã Đọc Giả" 
                                SortExpression="MaDocGia" />
                            <asp:BoundField DataField="NgayDangKy" HeaderText="Ngày Đăng Ký" 
                                SortExpression="NgayDangKy" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlhosodangkymuon" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [DangKy]"></asp:SqlDataSource>
                    <br /></div>
                <div><asp:Button ID="btexcel" runat="server" onclick="btexcel_Click" 
                    Text="Xuất Excel" />
                <asp:Button ID="btword" runat="server" onclick="btword_Click" 
                    style="margin-left: 38px" Text="Xuất Word" />
                <asp:Button ID="btpdf" runat="server" onclick="btpdf_Click" 
                    style="margin-left: 37px" Text="Xuất Pdf" /><br /></div>
              <div style="text-align: center">
                  <br /></div></td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

