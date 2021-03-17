<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="TKTuaSach.aspx.cs" Inherits="ThuVien_QuanLy_TKTuaSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style1
        {
        	width:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style7">
        <tr>
            <td colspan="3">
                <div>
                    <asp:Label ID="lbtieude" runat="server" Text=""></asp:Label>
                </div>
            
                <div><br /></div></td>
        </tr>
        <tr>
            <td  class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="grwthongtin" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaSach" 
                    DataSourceID="sqlTuaSach" GridLines="None" ForeColor="#333333" 
                    PageSize="5" CellSpacing="4">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="Ảnh">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                                    ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>' Width="80px" 
                                    PostBackUrl='<%# "~/ThuVien/DocGia/ChiTietSach.aspx?MaSach="+Eval("MaSach") %>' />
                                <br />
                                <br />
                                <asp:Label ID="lbmasach" runat="server" style="color: #FF0000" 
                                    Text='<%# Eval("MaSach") %>'></asp:Label>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Sách">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" 
                                    NavigateUrl='<%# "~/ThuVien/QuanLy/ChiTietSach.aspx?MaSach="+Eval("MaSach") %>' 
                                    Text='<%# Eval("TenSach", "{0}") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Năm Xuât Bản" SortExpression="NamXuatBan">
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
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
    <asp:SqlDataSource ID="sqlTuaSach" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        
        
                    SelectCommand="SELECT TenSach, NamXuatBan, SoLuong, NgayNhap, AnhBia, MaSach FROM Sach WHERE (TenSach LIKE '%' + @TenSach + '%')">
        <SelectParameters>
            <asp:QueryStringParameter Name="TenSach" QueryStringField="TenSach" 
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
            </td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>

