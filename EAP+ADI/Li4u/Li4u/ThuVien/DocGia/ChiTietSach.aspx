<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietSach.aspx.cs" Inherits="ThuVien_DocGia_ChiTietSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        
        .style7
        {
            width: 100%;
        }
        
        
        .style8
        {
            height: 84px;
        }
        
        
        .style9
        {
            height: 268px;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    
                    <table class="style7">
                        <tr>
                            <td colspan="2" style="background-color:#00CC99" >
                                <asp:Label ID="lbketqua" runat="server" style="color: #FFFFFF"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9" >
                                </td>
                            <td style="text-align: left" class="style9">
                    <asp:FormView ID="frmChiTietSach" runat="server" DataSourceID="sqlChiTietSach">
                        <ItemTemplate>
                            <table class="style7">
                                <tr>
                                    <td valign="middle">
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>' Height="200px" Width="150px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td style="text-align: left">
                                        <br />
&nbsp;<asp:Label ID="lbTenSach" runat="server" 
                        Text='<%# Bind("TenSach") %>' Font-Bold="False" style="color: #0000FF; font-size: small;" 
                                            Width="300px"></asp:Label>
                                        <br />
                                        Mã Sách:&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lbMaSach" runat="server" 
                        Text='<%# Bind("MaSach") %>' style="color: #FF0066"></asp:Label>
                                        <br />
                                        Thể Loại:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label3" runat="server" 
                        Text='<%# Bind("TenPhanLoai") %>' Font-Bold="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <br />
                                        Số Trang:&nbsp;&nbsp;&nbsp; &nbsp;
                                        <asp:Label ID="Label5" runat="server" 
                        Text='<%# Bind("SoTrang") %>' Font-Bold="False"></asp:Label>
                                        <br />
                                        Số Lượng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label6" runat="server" 
                        Text='<%# Bind("SoLuong") %>' Font-Bold="False"></asp:Label>
                                        <br />
                                        Mượn/Đọc:&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label7" runat="server" 
                        Text='<%# Bind("[Muon/Doc]") %>' Font-Bold="False"></asp:Label>
                                        <br />
                                        Ngày Nhập:&nbsp;&nbsp;
                                        <asp:Label ID="Label8" runat="server" 
                        Text='<%# Bind("NgayNhap") %>' Font-Bold="False"></asp:Label>
                                        <br />
                                        Tác Giả&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                        <asp:Label ID="Label9" runat="server" Font-Bold="False" 
                                            Text='<%# Tac_Gia(Eval("MaSach")) %>'></asp:Label>
                                        <br />
                                        NXB:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label10" runat="server" Font-Bold="False" 
                                            Text='<%# N_XB(Eval("MaSach")) %>'></asp:Label>
                                        <br />
                                        Năm XB:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label12" runat="server" Font-Bold="False" 
                                            Text='<%# Eval("NamXuatBan") %>'></asp:Label>
                                        <br />
                                        Sách Còn:&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label11" runat="server" 
                        Text='<%# Bind("SachCon") %>' Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td style="text-align: left">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
    
                    <asp:SqlDataSource ID="sqlChiTietSach" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        
                        
                        
                        SelectCommand="SELECT Sach.MaSach, Sach.MaPhanLoai AS Expr3, Sach.TenSach, Sach.NamXuatBan, Sach.Gia, Sach.SoLuong, Sach.NgayNhap, Sach.TinhTrang, Sach.SoTrang, Sach.[Muon/Doc], Sach.SachCon, Sach.AnhBia, PhanLoai.MaPhanLoai, PhanLoai.TenPhanLoai FROM PhanLoai INNER JOIN Sach ON PhanLoai.MaPhanLoai = Sach.MaPhanLoai WHERE (Sach.MaSach = @MaSach)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="MaSach" QueryStringField="MaSach" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    
                            </td>
                            
                        </tr>
                        <tr>
                        <td colspan="2" class="style8">
                            <div style="color: #000000"> 
                                <asp:HyperLink ID="hlnkDangKy" runat="server">Đăng Ký Mượn
                                </asp:HyperLink>
                                <asp:Label ID="lbThongBao" runat="server" 
                                    style="color: #FF0066; font-style: italic"></asp:Label>
                            </div>
                            <div><br /></div>
                            <div style="background-color: #008080"><br /></div>
                            <div><br /></div>
                            <div><br /></div>
                         </td>
                        </tr>
                    </table>    
        <br />           
        
</asp:Content>

