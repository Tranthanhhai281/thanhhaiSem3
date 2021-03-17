<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="TraSach1.aspx.cs" Inherits="ThuVien_QuanLy_TraSach" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .style6
        {
            height: 141px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="style5">
        <tr>
            <td class="style6">
            <div style="text-align: center">
                 <asp:Label ID="lbTraSach" runat="server" Text="Trả Sách" ForeColor="#3333CC" 
                     style="text-align: center"></asp:Label>
                 <br /></div>
             <div style="text-align: center">
                 <br /></div>
              <div> </div>
               <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbMaDocGia" runat="server" Text="Mã Đọc Giả:"></asp:Label>&nbsp;<asp:TextBox 
                       ID="txtMaDocGia" runat="server"></asp:TextBox>
&nbsp;
                   <asp:Button ID="btTim" runat="server" Text="Tra Cứu" onclick="btTim_Click" />
                   <br /></div>
                <div><br /></div><div style="text-align: center">
                <asp:Label ID="lbcanhbao" runat="server" ForeColor="Red" 
                    style="font-size: medium"></asp:Label>
                </div>
                <div style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkcheckkAll" runat="server" onclick="lnkcheckkAll_Click" 
                        style="font-size: xx-small">Chọn Tất Cả</asp:LinkButton>
&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkUnCheck" runat="server" onclick="lnkUnCheck_Click" 
                        style="font-size: xx-small">Bỏ Chọn</asp:LinkButton>
&nbsp;&nbsp;
                    <asp:Button ID="btXoa" runat="server" Text="Xóa" onclick="btXoa_Click" />
                </div>
                <div><br /></div>
                </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:ObjectDataSource ID="ObjLuotMuon" runat="server" 
                    InsertMethod="ThemLuotMuon" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetLuotMuon" TypeName="LuotMuon">
                    <InsertParameters>
                        <asp:Parameter Name="maluotmuon" Type="Int32" />
                        <asp:Parameter Name="masach" Type="String" />
                        <asp:Parameter Name="madocgia" Type="String" />
                        <asp:Parameter Name="magiahan" Type="Int32" />
                        <asp:Parameter Name="manhanvien" Type="String" />
                        <asp:Parameter Name="ngaymuon" Type="String" />
                        <asp:Parameter Name="ngaytra" Type="String" />
                        <asp:Parameter Name="trasach" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <br />
                <div align="center">
                <asp:GridView ID="grwthongtin" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="MaLuotMuon" DataSourceID="ObjLuotMuon" 
                    onrowediting="grwthongtin_RowEditing" 
                    onrowupdating="grwthongtin_RowUpdating" BackColor="LightGoldenrodYellow" 
                    BorderColor="Tan" BorderWidth="5px" CellPadding="2" ForeColor="Black" 
                    GridLines="None" CellSpacing="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Cancel" Text="Cập Nhật" onclick="LinkButton1_Click"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="Lnk2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Thoát"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Sửa"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="MaLuotMuon">
                            <ItemTemplate>
                                <asp:CheckBox ID="chbxCheck" runat="server" />
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lượt Mượn" SortExpression="LuotMuon">
                            <EditItemTemplate>
                                <asp:Label ID="lbSoThuTu" runat="server" Text='<%# Eval("MaLuotMuon") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbLuotMuon1" runat="server" Text='<%# Bind("MaLuotMuon") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã Sách" SortExpression="MaSach">
                            <EditItemTemplate>
                                <asp:Label ID="lbMaSach" runat="server" Text='<%# Eval("MaSach") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("MaSach") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đọc Giả" SortExpression="MaDocGia">
                            <EditItemTemplate>
                                <asp:Label ID="lbMaDocGia" runat="server" Text='<%# Eval("MaDocGia") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gia Hạn" SortExpression="GiaHan">
                            <EditItemTemplate>
                                <asp:DropDownList ID="drpMaGiaHan" runat="server" DataSourceID="SqlGianHan" 
                                    DataTextField="TenGiaHan" DataValueField="MaGiaHan" 
                                    SelectedValue='<%# Bind("MaGiaHan") %>'>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlGianHan" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                    SelectCommand="SELECT [MaGiaHan], [TenGiaHan] FROM [GiaHan]">
                                </asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("MaGiaHan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nhân Viên" SortExpression="MaNhanVien">
                            <EditItemTemplate>
                                <asp:Label ID="lbMaNhanVien" runat="server" Text='<%# Eval("MaNhanVien") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("MaNhanVien") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Mượn" SortExpression="NgayMuon">
                            <EditItemTemplate>
                                <asp:DropDownList ID="drpNgayMuon" runat="server" 
                                    SelectedValue='<%# Eval_ngay(Eval("NgayMuon")) %>'>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem Value="5">04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:DropDownList ID="drpThangMuon" runat="server" SelectedValue='<%# Eval_thang(Eval("NgayMuon")) %>'>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtNamMuon" runat="server" Width="50px" Text='<%# Eval_nam(Eval("NgayTra")) %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("NgayMuon") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Trả" SortExpression="NgayTra">
                            <EditItemTemplate>
                                <asp:DropDownList ID="drpNgayTra" runat="server" 
                                    SelectedValue='<%# Eval_ngay(Eval("NgayTra")) %>'>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem Value="5">04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:DropDownList ID="drpThangTra" runat="server" SelectedValue='<%# Eval_thang(Eval("NgayTra")) %>'>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtNamTra" runat="server" Width="50px" Text='<%# Eval_nam(Eval("NgayTra")) %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# TreHen(Eval("NgayTra")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trả/Chưa" SortExpression="Tra/Chua">
                            <EditItemTemplate>
                                <asp:DropDownList ID="drpTraChua" runat="server" 
                                    SelectedValue='<%# trachua(Eval("[Tra/Chua]")) %>'>
                                    <asp:ListItem>Chua</asp:ListItem>
                                    <asp:ListItem>Roi</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("[Tra/Chua]") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <br />
   
</asp:Content>

