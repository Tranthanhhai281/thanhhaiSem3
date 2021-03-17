<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ChiTietSach.aspx.cs" Inherits="ThuVien_DocGia_ChiTietSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        
        .style7
        {
            width: 100%;
        }
        
        
        .style8
        {
            color: #000000;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    
                    <table class="style7">
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td style="text-align: left">
    
                    <asp:SqlDataSource ID="sqlChiTietSach" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"                
                        
                        SelectCommand="SELECT Sach.MaSach, Sach.MaPhanLoai AS Expr3, Sach.TenSach, Sach.NamXuatBan, Sach.Gia, Sach.SoLuong, Sach.NgayNhap, Sach.TinhTrang, Sach.SoTrang, Sach.[Muon/Doc], Sach.SachCon, Sach.AnhBia, PhanLoai.MaPhanLoai, PhanLoai.TenPhanLoai FROM PhanLoai INNER JOIN Sach ON PhanLoai.MaPhanLoai = Sach.MaPhanLoai WHERE (Sach.MaSach = @MaSach)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="MaSach" QueryStringField="MaSach" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    <div>
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
                        Text='<%# Bind("TenSach") %>' Font-Bold="False" style="color: #0000FF; font-size: large;" 
                                            Width="300px"></asp:Label>
                                        <br />
                                        <span class="style8">Mã Sách</span><span class="style8">:&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="lbMaSach" runat="server" 
                        Text='<%# Bind("MaSach") %>' style="color: #FF0066; text-decoration: underline;"></asp:Label>
                                        <br />
                                        <span class="style8">&nbsp;Loại:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("TenPhanLoai") %>'></asp:Label>
                                        <br />
                                        Số Trang:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("SoTrang") %>'></asp:Label>
&nbsp;<br />
                                        Số Lượng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label6" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("SoLuong") %>'></asp:Label>
                                        <br />
                                        Mượn/Đọc:&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label7" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("[Muon/Doc]") %>'></asp:Label>
                                        <br />
                                        Ngày Nhập:&nbsp;&nbsp;
                                        <asp:Label ID="Label8" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("NgayNhap") %>'></asp:Label>
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
                                        <asp:Label ID="Label11" runat="server" Font-Bold="False" 
                                            Text='<%# Bind("SachCon") %>'></asp:Label>
                                        </span>
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
                               </div>
                              <div>
                                  <asp:LinkButton ID="lnkbtxoa" runat="server" onclick="lnkbtxoa_Click">Xóa Sách</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                                  <asp:HyperLink ID="hlnksuasach" runat="server" 
                                      style="color: #0000FF; text-decoration: underline">Sửa Sách</asp:HyperLink>
                                  &nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:HyperLink ID="hlnkthemsach" runat="server" 
                                      style="color: #0000FF; text-decoration: underline">Thêm Sách</asp:HyperLink>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td style="text-align: left">
    
                                &nbsp;</td>
                        </tr>
                    </table>
    
        <br />
        
                    
        
</asp:Content>

