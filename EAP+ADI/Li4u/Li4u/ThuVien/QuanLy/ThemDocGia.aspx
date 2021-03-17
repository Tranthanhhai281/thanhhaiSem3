<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThemDocGia.aspx.cs" Inherits="ThuVien_DocGia_DangKy1" Title="Untitled Page" %>

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
         
       
        .style6
        {
            height: 20px;
        }
         
       
        .style8
        {
            height: 53px;
        }
        .style9
        {
            width: 220px;
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
                    &nbsp;<div><br /></div>
                    </td>
                <td class="style8">
                    </td>
                    
            </tr>
             <tr>
                <td class="style6">
                   </td>
                <td style="width:100px;">
                    <asp:Label ID="lbtieude1" runat="server" Text="Chọn Hình Thức Thêm:"></asp:Label>
                 </td>
                 <td class="style9">
                     <asp:RadioButtonList ID="radiochon" runat="server" 
                         onselectedindexchanged="radiochon_SelectedIndexChanged" 
                         AutoPostBack="True">
                         <asp:ListItem Selected="True" Value="0">Nhập Dữ Liệu</asp:ListItem>
                         <asp:ListItem Value="1">Dữ Liệu Excel</asp:ListItem>
                     </asp:RadioButtonList>
                 </td>
                <td class="style6">
                    </td>
                    
            </tr>
             <tr>
                <td >
                    &nbsp;</td>
                <td  class=" td2" align="center" colspan="2">
                    <div style="text-align: center">
                        <br />
                    </div>
                    </td>
                <td>
                    &nbsp;</td>                    
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
                <div style="text-align: center">
                    <br />
                    
                </div>
                <div style="text-align: left">
                    &nbsp;&nbsp;<asp:Label ID="lbdocgia" runat="server" Text="Mã Đọc Giả:(*)"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMaDG" runat="server" 
                        ontextchanged="txtTenDannhap_TextChanged" Width="148px"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="lbrongmadg" runat="server" style="color: #FF0000" Text="(*)" 
                        Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lbMadg" runat="server" ForeColor="#FF5050"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div>
                                                   
                    <br />
                    </div>
                <div style="text-align: left" >                   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbHoTen" runat="server" Text="Họ Tên:(*)"></asp:Label>
                    &nbsp;<asp:TextBox ID="txthoten" runat="server" Width="128px"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="lbrongten" runat="server" style="color: #FF0000" Text="(*)" 
                        Visible="False"></asp:Label>
                    &nbsp;
                </div>
                <div >
                    <br />
                </div>
                  <div style="text-align: left">                   
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lbGioi" runat="server" Text="Giới:"></asp:Label>
                      &nbsp;<asp:DropDownList ID="drpGioi" runat="server">
                          <asp:ListItem Value="1">Nam</asp:ListItem>
                          <asp:ListItem Value="2">Nữ</asp:ListItem>
                      </asp:DropDownList>
                      &nbsp;
                </div>
                 <div >
                    <br />
                </div>
                <div style="text-align: left" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbngaysinh" runat="server" 
                        Text="Ngày Sinh:"></asp:Label>
                    <asp:DropDownList ID="drpNgay" runat="server">
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
                    &nbsp;Tháng : &nbsp;<asp:DropDownList ID="drpThang" runat="server">
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
                    &nbsp;Năm :&nbsp;<asp:TextBox ID="txtNam" runat="server" Width="57px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lbrongnam" runat="server" style="color: #CC0000" 
                        Text="(*)" Visible="False"></asp:Label>
                    <asp:RangeValidator ID="RantxtNam" runat="server" ControlToValidate="txtNam" 
                        ErrorMessage="[Sai]" MaximumValue="9999" MinimumValue="1753"></asp:RangeValidator>
                    &nbsp;&nbsp;<asp:Label ID="lbcbtxtNam" runat="server" Font-Bold="False" 
                        ForeColor="Fuchsia" Text="Năm[1753--&gt;9999]"></asp:Label>
                </div>
                  
                <div><br />
                    </div>
                  <div style="text-align: left">                   
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                      <asp:Label ID="lbemail" runat="server" Text="Email:"></asp:Label>
                      &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="RegtxtEmail" runat="server" 
                          ControlToValidate="txtEmail" ErrorMessage="[Sai Đinh Dạng]" 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <br />
                    
                </div>
               <div style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Label ID="Label1" runat="server" Text="Chức Vụ:(*)"></asp:Label>
                   &nbsp;<asp:DropDownList ID="drpChucVu" runat="server">
                       <asp:ListItem Value="1">Sinh Viên</asp:ListItem>
                       <asp:ListItem Value="2">Cán Bộ</asp:ListItem>
                   </asp:DropDownList>
                    </div>
                <div>
                    &nbsp;<br />
                    
                </div>
                  <div style="text-align: left">                   
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbChonFile" runat="server" Text="Chọn Tập Tin:"></asp:Label>
                      &nbsp;&nbsp;
                      <asp:FileUpload ID="txtfileValue" runat="server" style="margin-left: 0px" 
                          Width="221px" />
                </div>
                <div><br /></div>
                <div style="text-align: left"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</div>
                   
                
                
                    &nbsp;</td>                    
                    
            </tr>
             <tr>
                <td >
                    &nbsp;</td>
                <td  class=" td2" align="center" colspan="2">
                <div>
                    <asp:Button ID="tbThem" runat="server" onclick="tbDangky_Click" 
                        Text="Thêm Đọc Giả" />
                    <asp:Button ID="btchon" runat="server" onclick="btchon_Click" 
                        style="margin-left: 78px" Text="Chọn" />
                    <br /></div>
                    &nbsp;<div>
                        <br /></div>
                    </td>
                <td>
                    &nbsp;</td>
                    
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

