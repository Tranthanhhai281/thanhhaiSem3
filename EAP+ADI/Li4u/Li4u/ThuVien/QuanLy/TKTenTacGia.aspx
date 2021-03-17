<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="TKTenTacGia.aspx.cs" Inherits="ThuVien_QuanLy_TKTenTacGia" Title="Untitled Page" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style7">
        <tr>
            <td colspan="3">
                <div>
                    <asp:Label ID="lbtieude" runat="server" Text=""></asp:Label> </div>
                <div><br /></div></td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
    <asp:GridView ID="grwthongtin" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="MaSach" DataSourceID="sqlTenTacGia" Width="580px" 
        CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5" 
                    CellSpacing="4">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="Ảnh">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                        ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>' 
                        PostBackUrl='<%# "~/ThuVien/QuanLy/ChiTietSach.aspx?MaSach="+Eval("MaSach") %>' 
                        Width="80px" />
                    <br />
                    <br />
                    <asp:Label ID="lbmasach" runat="server" style="color: #FF0000" 
                        Text='<%# Eval("MaSach") %>'></asp:Label>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Sách">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" 
                        NavigateUrl='<%# Eval("MaSach", "~/ThuVien/QuanLy/ChiTietSach.aspx?MaSach={0}") %>' 
                        Text='<%# Eval("TenSach", "{0}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ngày Nhập" SortExpression="NgayNhap">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NgayNhap") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" 
                        style="font-size: small" Text='<%# Bind("NgayNhap") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Năm Xuất Bản" SortExpression="NamXuatBan">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NamXuatBan") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" 
                        style="font-size: small" Text='<%# Bind("NamXuatBan") %>'></asp:Label>
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
<asp:SqlDataSource ID="sqlTenTacGia" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT Sach.MaSach AS Expr1, Sach.MaPhanLoai, Sach.TenSach, Sach.NamXuatBan, Sach.Gia, Sach.SoLuong, Sach.NgayNhap, Sach.TinhTrang, Sach.SoTrang, Sach.[Muon/Doc], Sach.SachCon, Sach.AnhBia, TacGia.TenTacGia, Viet.MaTacGia, Viet.MaSach FROM Sach LEFT OUTER JOIN Viet ON Sach.MaSach = Viet.MaSach LEFT OUTER JOIN TacGia ON Viet.MaTacGia = TacGia.MaTacGia WHERE (TacGia.TenTacGia LIKE '%' + @TenSach + '%')">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="" Name="TenSach" 
            QueryStringField="TenTacGia" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>

