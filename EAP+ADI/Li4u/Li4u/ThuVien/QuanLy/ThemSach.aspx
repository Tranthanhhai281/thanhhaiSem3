<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThemSach.aspx.cs" Inherits="ThuVien_QuanLy_ThemSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }        
        .style7
        {
            width: 75px;
        }          
        
        .style9
        {
            width: 75px;
            text-align: left;
        }
        .style10
        {
            text-align: left;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3" >
                 <div><br /></div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Thêm Sách Mới"></asp:Label>
                    </div>
                    <div><br /></div>
                    <div style="font-size: small">
                    <asp:Label ID="lbthongbao" runat="server" 
                            style="font-size: small; color: #FF0000; font-style: italic"></asp:Label>
                    </div>
                    <div><br /></div>
                </td>
        </tr>
        <tr>
            <td class="style7">
                <div><br /></div></td>
            <td>             
                <div><br /></div>
                <div class="style10">
                    <asp:Label ID="Label3" runat="server" Text="Tên Sách(*):"></asp:Label>
                    <asp:TextBox ID="txttensach" runat="server" style="margin-left: 34px" 
                        TabIndex="2"></asp:TextBox>
                    <asp:Label ID="lbtensach" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label4" runat="server" Text="Mã Loại(*):"></asp:Label>
                    <asp:DropDownList ID="drploaisach" runat="server" style="margin-left: 42px" 
                        DataSourceID="Sqlphanloai" DataTextField="TenPhanLoai" 
                        DataValueField="MaPhanLoai" TabIndex="3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Sqlphanloai" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [PhanLoai]"></asp:SqlDataSource>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label5" runat="server" Text="Tác Giả(*):"></asp:Label>
                    <asp:DropDownList ID="drptacgia" runat="server" style="margin-left: 42px" 
                        DataSourceID="Sqltacgia" DataTextField="TenTacGia" DataValueField="MaTacGia" 
                        TabIndex="4">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="tbchontg" runat="server" 
                        onclick="tbchontg_Click" Text="Chọn" />
                    &nbsp;&nbsp;
                    <asp:ListBox ID="lsttacgia" runat="server" 
                        onselectedindexchanged="lsttacgia_SelectedIndexChanged"></asp:ListBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btxoaTG" runat="server" Text="Xóa" onclick="btxoaTG_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="lsttgvalue" runat="server"></asp:ListBox>
&nbsp;<asp:SqlDataSource ID="Sqltacgia" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [TacGia]"></asp:SqlDataSource>
                </div>
                 <div><br /></div>
                 <div class="style10">
                    <asp:LinkButton ID="lnktacgia" runat="server" style="font-size: small" 
                         onclick="lnktacgia_Click">Thêm 
                    Tác Giả</asp:LinkButton>
                     <br /></div>  
                      <div><br /></div>  
                <div class="style10"><asp:Label ID="Label6" runat="server" Text="Nhà Xuất Bản(*):"></asp:Label>
                    <asp:DropDownList ID="drpnhaxuatban" runat="server" 
                        DataSourceID="Sqlnhaxuatban" DataTextField="TenNhaXuatBan" 
                        DataValueField="MaNhaXuatBan" TabIndex="5">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btchonxb" runat="server" Text="Chọn" onclick="btchonxb_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ListBox ID="lstnxb" runat="server"></asp:ListBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btxoanxb" runat="server" Text="Xóa" onclick="btxoanxb_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="lstxbvalue" runat="server"></asp:ListBox>
&nbsp;<asp:SqlDataSource ID="Sqlnhaxuatban" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [NhaXuatBan]"></asp:SqlDataSource>
                </div>
                 <div class="style10">
                     <asp:LinkButton ID="lnkcapnhatnxb" runat="server" 
                        style="font-size: small" onclick="lnkcapnhatnxb_Click" >Thêm Nhà Xuất Bản</asp:LinkButton>
                     <br /></div>
                    <div><br /></div>
                     <div><br /></div>
                <div class="style10"><asp:Label ID="Label8" runat="server" Text="Số Lượng(*):"></asp:Label>
                    <asp:TextBox ID="txtsoluong" runat="server" style="margin-left: 25px" 
                        Width="112px" TabIndex="6"></asp:TextBox>
                    <asp:Label ID="lbsoluong" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label9" runat="server" Text="Giá(*):"></asp:Label>
                    <asp:TextBox ID="txtgia" runat="server" style="margin-left: 63px" 
                        Width="105px" TabIndex="7"></asp:TextBox>
                    <asp:Label ID="lbgia" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label10" runat="server" Text="Số Trang(*):"></asp:Label>
                    <asp:TextBox ID="txtsotrang" runat="server" style="margin-left: 28px" 
                        Width="110px" TabIndex="8"></asp:TextBox>
                    <asp:Label ID="lbsotrang" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label11" runat="server" Text="Mượn/Đọc(*):"></asp:Label>
                    <asp:DropDownList ID="drpmuondoc" runat="server" style="margin-left: 18px" 
                        TabIndex="9">
                        <asp:ListItem Value="Muon">Mượn</asp:ListItem>
                        <asp:ListItem Value="Doc">Đọc</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div><br /></div>
                 <div class="style10"><asp:Label ID="Label7" runat="server" Text="Tình Trạng(*):"></asp:Label>
                    <asp:DropDownList ID="drptinhtrang" runat="server" style="margin-left: 18px" 
                        TabIndex="9">
                        <asp:ListItem Value="Moi">Mới</asp:ListItem>
                        <asp:ListItem Value="Cu">Cũ</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div><br /></div>
                 <div class="style10"><asp:Label ID="lbnxb" runat="server" Text="Năm Xuất Bản(*):"></asp:Label>
                     <asp:TextBox ID="txtNamXuatBan" runat="server" Width="60px"></asp:TextBox>
                     <asp:Label ID="lbnamxuatban" runat="server" Text="(*)" style="color: #FF0000"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label12" runat="server" Text="Ảnh Bìa(*):"></asp:Label>
                    <asp:FileUpload ID="filanh" runat="server" style="margin-left: 34px" 
                        TabIndex="10" />
                </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="lbketqua" runat="server" 
                        style="font-size: small; font-style: italic; color: #009933"></asp:Label>
                    <br /></div>
                <div><br /></div>
                <div>
                    <asp:Button ID="btNhap" runat="server" Text="Đồng ý" onclick="btNhap_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btkhongdongy" runat="server" Text="Không Đồng Ý" 
                        onclick="btkhongdongy_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                <div></div>
                
            </td>
            <td class="style9">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

