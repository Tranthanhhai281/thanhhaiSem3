<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TKTenNhaXuatBan.aspx.cs" Inherits="ThuVien_DocGia_TkNhaXuatBan" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style8
        {
            width: 20px;
        }
        .style9
        {
            height: 52px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style7">
        <tr>
            <td colspan="3" class="style9">
            <div>
                <asp:Label ID="lbtieude" runat="server" Text=""></asp:Label></div>
                <div><br /></div>&nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
    <asp:GridView ID="grwthongtin" runat="server" AutoGenerateColumns="False" 
        DataSourceID="sqlTennxB" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    PageSize="5" AllowPaging="True" CellSpacing="4">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="Ảnh">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                        ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>' Width="80px" 
                        PostBackUrl='<%# "~/ThuVien/DocGia/ChiTietSach.aspx?MaSach="+Eval("MaSach")+"&Duongdan=Default2.aspx" %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Sách">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" 
                        NavigateUrl='<%# Eval("MaSach", "~/ThuVien/DocGia/ChiTietSach.aspx?MaSach={0}&Duongdan=Default2.aspx") %>' 
                        Text='<%# Eval("TenSach", "{0}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Năm Xuất Bản" SortExpression="NamXuatBan">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NamXuatBan") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" 
                        Text='<%# Bind("NamXuatBan") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ngày Nhập" SortExpression="NgayNhap">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NgayNhap") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" 
                        Text='<%# Bind("NgayNhap") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlTennxB" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        
        
        
        SelectCommand="SELECT Sach.TenSach, Sach.NamXuatBan, Sach.SoLuong, Sach.NgayNhap, Sach.AnhBia, NhaXuatBan.TenNhaXuatBan, XuatBan.MaNhaXuatBan, XuatBan.MaSach AS Expr2, Sach.MaSach FROM Sach LEFT OUTER JOIN XuatBan ON Sach.MaSach = XuatBan.MaSach LEFT OUTER JOIN NhaXuatBan ON XuatBan.MaNhaXuatBan = NhaXuatBan.MaNhaXuatBan WHERE (NhaXuatBan.TenNhaXuatBan LIKE '%' + @TenNhaXuatBan + '%')">
        <SelectParameters>
            <asp:QueryStringParameter Name="TenNhaXuatBan" QueryStringField="TenNhaXuatBan" 
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

