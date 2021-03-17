<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TimKiemTheoNXB.aspx.cs" Inherits="ThuVien_DocGia_TimKiemTheoNXB" Title="Untitled Page" %>

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
                <asp:Label ID="lbtieude" runat="server" Text=""></asp:Label></div>
            <div><br /></div>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
    <asp:GridView ID="grwthongtin" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="MaSach" DataSourceID="sqlNXB" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="580px" CellSpacing="4" AllowPaging="True" 
                    PageSize="5">
        <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:TemplateField HeaderText="Ảnh Bìa">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnhBia") %>' 
                    Tooltip='<%#"~/ThuVien/DocGia/ChiTietSach.aspx?MaSach="+Eval("MaSach") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                    ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>' 
                    PostBackUrl='<%# "~/ThuVien/DocGia/ChiTietSach.aspx?MaSach="+Eval("MaSach")+"&Duongdan=Default2.aspx" %>' 
                    Width="80px" />
                
                <br />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tên Sách">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" 
                    NavigateUrl='<%# Eval("MaSach", "~/ThuVien/DocGia/ChiTietSach.aspx?Masach={0}&Duongdan=Default2.aspx") %>' 
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
            <td class ="style8">
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
<asp:SqlDataSource ID="sqlNXB" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    DeleteCommand="DELETE FROM [Sach] WHERE [MaSach] = @MaSach" 
    InsertCommand="INSERT INTO [Sach] ([MaSach], [MaPhanLoai], [TenSach], [NamXuatBan], [Gia], [SoLuong], [NgayNhap], [TinhTrang], [SoTrang], [Muon/Doc], [SachCon], [AnhBia]) VALUES (@MaSach, @MaPhanLoai, @TenSach, @NamXuatBan, @Gia, @SoLuong, @NgayNhap, @TinhTrang, @SoTrang, @column1, @SachCon, @AnhBia)" 
    SelectCommand="SELECT Sach.MaPhanLoai, Sach.TenSach, Sach.NamXuatBan, Sach.Gia, Sach.SoLuong, Sach.NgayNhap, Sach.TinhTrang, Sach.SoTrang, Sach.[Muon/Doc], Sach.SachCon, Sach.AnhBia, XuatBan.MaNhaXuatBan, Sach.MaSach FROM XuatBan RIGHT OUTER JOIN Sach ON XuatBan.MaSach = Sach.MaSach WHERE (XuatBan.MaNhaXuatBan = @MaNhaXuatBan)" 
    
        
        UpdateCommand="UPDATE [Sach] SET [MaPhanLoai] = @MaPhanLoai, [TenSach] = @TenSach, [NamXuatBan] = @NamXuatBan, [Gia] = @Gia, [SoLuong] = @SoLuong, [NgayNhap] = @NgayNhap, [TinhTrang] = @TinhTrang, [SoTrang] = @SoTrang, [Muon/Doc] = @column1, [SachCon] = @SachCon, [AnhBia] = @AnhBia WHERE [MaSach] = @MaSach">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="0" Name="MaNhaXuatBan" 
            QueryStringField="MaNhaXuatBan" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="MaSach" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="MaPhanLoai" Type="Int32" />
        <asp:Parameter Name="TenSach" Type="String" />
        <asp:Parameter Name="NamXuatBan" Type="String" />
        <asp:Parameter Name="Gia" Type="String" />
        <asp:Parameter Name="SoLuong" Type="Int32" />
        <asp:Parameter Name="NgayNhap" Type="String" />
        <asp:Parameter Name="TinhTrang" Type="String" />
        <asp:Parameter Name="SoTrang" Type="String" />
        <asp:Parameter Name="column1" Type="String" />
        <asp:Parameter Name="SachCon" Type="Int32" />
        <asp:Parameter Name="AnhBia" Type="String" />
        <asp:Parameter Name="MaSach" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="MaSach" Type="Int32" />
        <asp:Parameter Name="MaPhanLoai" Type="Int32" />
        <asp:Parameter Name="TenSach" Type="String" />
        <asp:Parameter Name="NamXuatBan" Type="String" />
        <asp:Parameter Name="Gia" Type="String" />
        <asp:Parameter Name="SoLuong" Type="Int32" />
        <asp:Parameter Name="NgayNhap" Type="String" />
        <asp:Parameter Name="TinhTrang" Type="String" />
        <asp:Parameter Name="SoTrang" Type="String" />
        <asp:Parameter Name="column1" Type="String" />
        <asp:Parameter Name="SachCon" Type="Int32" />
        <asp:Parameter Name="AnhBia" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>
</asp:Content>

