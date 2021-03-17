<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ChiTietThemDocGia.aspx.cs" Inherits="ThuVien_DocGia_DangKy1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .td1 { width: 20px; }
         .td2  { width: 565px;
            font-family: Tahoma;
            text-align: center;
            color: #000000;
        }
         
       
        .style5
        {
            text-align: left;
        }
         
       
        .style8
        {
            height: 55px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server" >
    <asp:Panel ID="pnlDangKy" runat="server" Height="1044px">
        <table cellpadding="2" class=" ">
            <tr>
                <td class="style8" >
                    </td>
                <td  class="style8" align="center" colspan="2">
                <div>Thêm Đọc Giả</div>      
                    </td>
                <td class="style8">
                    </td>
                    
            </tr>
             
            
            <tr  >
                <td class="td1">
                    &nbsp;</td>
                <td class="td2" colspan="2">
                 <div style="text-align: center">                   
                     <asp:Label ID="lbThanhCong" runat="server" ForeColor="#0099FF"></asp:Label>
                     <asp:Label ID="lbCanhBao" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
                <div style="text-align: center">
                   <br />
                    
                </div>
                <div><br /></div>
                <div style="text-align: left"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbChonFile0" runat="server" Text="Chọn Tập Tin:"></asp:Label>
                    <asp:DropDownList ID="drpsheet" runat="server" style="margin-left: 11px">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="bthienthi" runat="server" onclick="bthienthi_Click" 
                        style="margin-left: 28px" Text="Hiển Thi" />
                    </div>
                   
                
                
                    &nbsp;</td>                    
                    
            </tr>
             <tr>
                <td >
                    &nbsp;</td>
                <td  class=" td2" align="center" colspan="2">
                <div>
                    <asp:Button ID="tbThem" runat="server" onclick="tbDangky_Click" 
                        Text="Thêm Đọc Giả" />
                    <br /></div>
                    &nbsp;<div>
                        <asp:GridView ID="grvthongtin" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="MaDocGia" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#E3EAEB" />
                            <Columns>
                                <asp:BoundField DataField="MaDocGia" HeaderText="MaDocGia" ReadOnly="True" 
                                    SortExpression="MaDocGia" />
                                <asp:BoundField DataField="MaChucVu" HeaderText="MaChucVu" 
                                    SortExpression="MaChucVu" />
                                <asp:BoundField DataField="HoTen" HeaderText="HoTen" SortExpression="HoTen" />
                                <asp:BoundField DataField="GioiTinh" HeaderText="GioiTinh" 
                                    SortExpression="GioiTinh" />
                                <asp:BoundField DataField="NamSinh" HeaderText="NamSinh" 
                                    SortExpression="NamSinh" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            </Columns>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br /></div>
                    </td>
                <td>
                    &nbsp;</td>
                    
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

