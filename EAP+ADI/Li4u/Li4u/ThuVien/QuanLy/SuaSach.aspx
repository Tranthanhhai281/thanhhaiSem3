<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="SuaSach.aspx.cs" Inherits="ThuVien_QuanLy_SuaSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }        
        .style7
        {
            width: 50px;
        }       
        .style10
        {
            text-align: left;
        }
        
        .style11
        {
            height: 86px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3" class="style11" >
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
                <div style="text-align: left">
                    <asp:Label ID="lbma_sach" runat="server" Text="Mã Sách:"></asp:Label>
&nbsp;<asp:Label ID="lbMaSach" runat="server" Text="" 
                        style="text-align: left; color: #0000FF; text-decoration: underline"></asp:Label></div>
                <div><br /></div>
                <div class="style10">
                    <asp:Label ID="Label3" runat="server" Text="Tên Sách(*):"></asp:Label>
                    <asp:TextBox ID="txttensach" runat="server" style="margin-left: 34px" 
                        TabIndex="2" Width="273px"></asp:TextBox>
                    <asp:Label ID="lbtensach" runat="server" Text="(*)" style="color: #FF0000" 
                        Visible="False"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label4" runat="server" Text="Mã Loại(*):"></asp:Label>
                    <asp:FormView ID="frmloaisach" runat="server" DataKeyNames="MaSach" 
                        DataSourceID="sqlfromview">
                        <EditItemTemplate>
                            MaSach:
                            <asp:Label ID="MaSachLabel1" runat="server" Text='<%# Eval("MaSach") %>' />
                            <br />
                            MaPhanLoai:
                            <asp:TextBox ID="MaPhanLoaiTextBox" runat="server" 
                                Text='<%# Bind("MaPhanLoai") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                                CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            MaSach:
                            <asp:TextBox ID="MaSachTextBox" runat="server" Text='<%# Bind("MaSach") %>' />
                            <br />
                            MaPhanLoai:
                            <asp:TextBox ID="MaPhanLoaiTextBox" runat="server" 
                                Text='<%# Bind("MaPhanLoai") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                                CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            MaPhanLoai:
                            <asp:DropDownList ID="drploaisach" runat="server" DataSourceID="Sqlphanloai" 
                                DataTextField="TenPhanLoai" DataValueField="MaPhanLoai" 
                                SelectedValue='<%# Bind("MaPhanLoai") %>' style="margin-left: 42px" 
                                TabIndex="3">
                            </asp:DropDownList>
                            <br />
                            <asp:SqlDataSource ID="Sqlphanloai" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT * FROM [PhanLoai] ORDER BY [MaPhanLoai]">
                            </asp:SqlDataSource>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="sqlfromview" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [MaSach], [MaPhanLoai] FROM [Sach] WHERE ([MaSach] = @MaSach)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="MaSach" QueryStringField="MaSach" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
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
                    <asp:LinkButton ID="lnktacgia" runat="server" style="font-size: small">Thêm 
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
                        style="font-size: small" >Thêm Nhà Xuất Bản</asp:LinkButton>
                     <br /></div>
                    <div><br /></div>
                     <div><br /></div>
                <div class="style10"><asp:Label ID="Label8" runat="server" Text="Số Lượng(*):"></asp:Label>
                    <asp:TextBox ID="txtsoluong" runat="server" style="margin-left: 22px" 
                        Width="112px" TabIndex="6"></asp:TextBox>
                    <asp:Label ID="lbsoluong" runat="server" Text="(*)" style="color: #CC0000" 
                        Visible="False"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label9" runat="server" Text="Giá(*):"></asp:Label>
                    <asp:TextBox ID="txtgia" runat="server" style="margin-left: 63px" 
                        Width="105px" TabIndex="7"></asp:TextBox>
                    <asp:Label ID="lbgia" runat="server" Text="(*)" style="color: #FF0000" 
                        Visible="False"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label10" runat="server" Text="Số Trang(*):"></asp:Label>
                    <asp:TextBox ID="txtsotrang" runat="server" style="margin-left: 28px" 
                        Width="110px" TabIndex="8"></asp:TextBox>
                    <asp:Label ID="lbsotrang" runat="server" Text="(*)" style="color: #FF0000" 
                        Visible="False"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label11" runat="server" Text="Mượn/Đọc(*):"></asp:Label>
                    <asp:DropDownList ID="drpmuondoc" runat="server" style="margin-left: 24px" 
                        TabIndex="9">
                        <asp:ListItem Value="Muon">Mượn</asp:ListItem>
                        <asp:ListItem Value="Doc">Đọc</asp:ListItem>
                    </asp:DropDownList>
                    
                </div>
                <div><br /></div>
                 <div class="style10"><asp:Label ID="Label7" runat="server" Text="Tình Trạng(*):"></asp:Label>
                    <asp:DropDownList ID="drptinhtrang" runat="server" style="margin-left: 20px" 
                        TabIndex="9">
                        <asp:ListItem Value="Moi">Mới</asp:ListItem>
                        <asp:ListItem Value="Cu">Cũ</asp:ListItem>
                    </asp:DropDownList>
                     
                </div>
                <div><br /></div>
                 <div class="style10"><asp:Label ID="lbnamxb" runat="server" Text="Năm Xuất Bản(*):"></asp:Label>
                     <asp:TextBox ID="txtNamXuatBan" runat="server" Width="60px"></asp:TextBox>
                     <asp:Label ID="lbnamxuatban" runat="server" Text="(*)" style="color: #FF0000" 
                         Visible="False"></asp:Label>
                </div>
                <div><br /></div>
                 <div class="style10"><asp:Label ID="lbsc" runat="server" Text="Sách Còn(*):"></asp:Label>
                     <asp:TextBox ID="txtsachcon" runat="server" Width="60px" 
                         style="margin-left: 33px"></asp:TextBox>
                     <asp:Label ID="lbsachcon" runat="server" Text="(*)" style="color: #FF0000" 
                         Visible="False"></asp:Label>
                </div>
                 <div class="style10"><br /></div>    
                <div class="style10"><asp:Label ID="Label12" runat="server" Text="Ảnh Bìa(*):"></asp:Label>
                    <asp:FileUpload ID="filanh" runat="server" style="margin-left: 41px" 
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
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

