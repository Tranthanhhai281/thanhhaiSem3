<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="DangKyTaiKhoan.aspx.cs" Inherits="ThuVien_DocGia_DangKy1" Title="Untitled Page" %>

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
            text-align: left;
        }
         
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server" >
    <asp:Panel ID="pnlDangKy" runat="server" Height="1044px">
        <table cellpadding="2" class=" ">
            <tr>
                <td >
                    &nbsp;</td>
                <td  class=" td2" align="center">
                <div><br /></div>
                    Đăng Ký
                    <div><br /></div>
                    </td>
                <td>
                    &nbsp;</td>
                    
            </tr>
            <tr  >
                <td class="td1">
                    &nbsp;</td>
                <td class="td2">
                 <div style="text-align: center">                   
                     <asp:Label ID="lbThanhCong" runat="server" ForeColor="#0099FF"></asp:Label>
                     <asp:Label ID="lbCanhBao" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
                <div style="text-align: center">
                   <br />
                    
                </div>
                <div style="text-align: left">
                  <asp:Label ID="lbMaNhanVien" runat="server" Text="Mã Nhân Viên:(*)"></asp:Label>                 
                                                   
                    &nbsp;<asp:TextBox ID="txtMaNv" runat="server" Width="148px" 
                        ontextchanged="txtTenDannhap_TextChanged"></asp:TextBox>
                                                   
                    &nbsp;
                    <asp:RequiredFieldValidator ID="ReqtxtTenDangnhap" runat="server" 
                        ControlToValidate="txtMaNv" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                                                   
                    &nbsp;&nbsp;
                    <asp:Label ID="lbMaNv" runat="server" ForeColor="#FF5050"></asp:Label>
                                                   
                 </div>
                <div>                   
                   <br />
                </div>
                <div style="text-align: left">   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="blMatKhau" runat="server" Text="Mật Khẩu:(*)"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMatKhau" runat="server" Width="133px"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="ReqtxtMatKhau" runat="server" 
                        ControlToValidate="txtMatKhau" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbcbmatkhau" runat="server" Font-Bold="False" ForeColor="#CC00FF" 
                        Text="[Trên 6 Ký Tự]"></asp:Label>
                </div>
                <div >                   
                   <br />
                </div>
                <div style="text-align: left" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbNhapLai" runat="server" Text="Nhập Lại:(*)"></asp:Label>
                    
                    &nbsp;<asp:TextBox ID="txtNhaplai" runat="server" Width="128px"></asp:TextBox>
                    
                    &nbsp;
                    <asp:RequiredFieldValidator ID="ReqtxtNhapLai" runat="server" 
                        ControlToValidate="txtNhaplai" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                    &nbsp;                                        
                </div>
                <div>                   
                   <br />
                </div>
                <div class="style6">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbHo" runat="server" Text="Họ:(*)"></asp:Label>
                    
                    &nbsp;<asp:TextBox ID="txtHo" runat="server" Width="100px"></asp:TextBox>
                    
                    &nbsp;
                    <asp:RequiredFieldValidator ID="Reqtxtho" runat="server" 
                        ControlToValidate="txtHo" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                    
                </div>
                 <div>               
                   <br />
                </div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label ID="lbTen" runat="server" Text="Tên:(*)"></asp:Label>
                 
                    &nbsp;<asp:TextBox ID="txtTen" runat="server" Width="100px"></asp:TextBox>
                 
                    &nbsp;
                    <asp:RequiredFieldValidator ID="ReqtxtTen" runat="server" 
                        ControlToValidate="txtTen" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                 
                 </div>
                  <div>                   
                   <br />
                </div>
                
                  
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbGioi" runat="server" Text="Giới:(*)"></asp:Label>
                    
                    &nbsp;<asp:DropDownList ID="đrpGioi" runat="server">
                        <asp:ListItem Selected="True" Value="0">[Chọn Giới]</asp:ListItem>
                        <asp:ListItem Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="2">Nữ</asp:ListItem>
                    </asp:DropDownList>
                    
                    &nbsp;
                    <asp:CompareValidator ID="ComdrdGioi" runat="server" 
                        ControlToValidate="đrpGioi" ErrorMessage="(*)" Operator="NotEqual" 
                        ValueToCompare="0"></asp:CompareValidator>
                    
                </div>
                <div><br /></div>
                  <div>                                      
                      <asp:Label ID="lbNam" runat="server" Text="Ngày Sinh:(*)"></asp:Label>
                      &nbsp;<asp:DropDownList ID="drpNgay" runat="server">
                          <asp:ListItem Selected="True" Value="0">[Ngày]</asp:ListItem>
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
                      <asp:CompareValidator ID="ComdrpNgay" runat="server" 
                          ControlToValidate="drpNgay" ErrorMessage="(*)" Operator="NotEqual" 
                          ValueToCompare="0"></asp:CompareValidator>
                      &nbsp;<asp:DropDownList ID="drpThang" runat="server">
                          <asp:ListItem Value="0">[Tháng]</asp:ListItem>
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
                      <asp:CompareValidator ID="ComdrpThang" runat="server" 
                          ControlToValidate="drpThang" ErrorMessage="(*)" Operator="NotEqual" 
                          ValueToCompare="0"></asp:CompareValidator>
                      &nbsp;<asp:TextBox ID="txtNam" runat="server" Width="57px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ReqtxtNam" runat="server" 
                          ControlToValidate="txtNam" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                      &nbsp;<asp:RangeValidator ID="RantxtNam" runat="server" ControlToValidate="txtNam" 
                          ErrorMessage="[Sai]" MaximumValue="9999" MinimumValue="1753"></asp:RangeValidator>
                      &nbsp;
                      <asp:Label ID="lbcbtxtNam" runat="server" Font-Bold="False" ForeColor="Fuchsia" 
                          Text="Năm[1753--&gt;9999]"></asp:Label>
                   
                </div>
                  <div>                   
                   <br />
                </div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lbemail" runat="server" Text="Email:"></asp:Label>
                    
                    &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="RegtxtEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="[Sai Đinh Dạng]" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    
                </div>
               <div><br /></div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Chức Vụ:(*)"></asp:Label>
                    
                    &nbsp;<asp:DropDownList ID="drpChucVu" runat="server">
                        <asp:ListItem Value="0">[Chức Vụ]</asp:ListItem>
                        <asp:ListItem Value="1">Sinh Viên</asp:ListItem>
                        <asp:ListItem Value="2">Cán Bộ</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="drpChucVu" ErrorMessage="(*)" Operator="NotEqual" 
                        ValueToCompare="0"></asp:CompareValidator>
                    
                </div>
                  <div>                   
                   <br />
                </div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbChucVu" runat="server" Text="Hình:"></asp:Label>
                    &nbsp;<asp:FileUpload ID="flup" runat="server" Width="220px" />                                
                </div>
                  <div>                   
                   <br />
                 </div>
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                
                
                    &nbsp;</td>                    
                    
            </tr>
             <tr>
                <td >
                    &nbsp;</td>
                <td  class=" td2" align="center">
                <div>
                    <asp:Button ID="tbDangky" runat="server" onclick="tbDangky_Click" 
                        Text="Đăng Ký" />
                    <br /></div>
                    <asp:ObjectDataSource ID="OjbNhanVien" runat="server" InsertMethod="ThemNhanVien" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetNhanVien" 
                        TypeName="NhanVien">
                        <InsertParameters>
                            <asp:Parameter Name="manhavien" Type="String" />
                            <asp:Parameter Name="machucvu" Type="Int32" />
                            <asp:Parameter Name="maquyen" Type="Int32" />
                            <asp:Parameter Name="cauhoi" Type="Int32" />
                            <asp:Parameter Name="tendangnhap" Type="String" />
                            <asp:Parameter Name="matkhau" Type="String" />
                            <asp:Parameter Name="hoten" Type="String" />
                            <asp:Parameter Name="gioi" Type="String" />
                            <asp:Parameter Name="namsinh" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="anh" Type="String" />
                            <asp:Parameter Name="traloi" Type="String" />
                            <asp:Parameter Name="khoa" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    &nbsp;<div><br /></div>
                    </td>
                <td>
                    &nbsp;</td>
                    
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

