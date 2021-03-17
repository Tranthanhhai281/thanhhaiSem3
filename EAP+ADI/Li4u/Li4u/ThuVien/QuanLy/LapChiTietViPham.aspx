<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="LapChiTietViPham.aspx.cs" Inherits="ThuVien_QuanLy_LapChiTietHoaDon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 20px;
        }
        .style8
        {
            width: 722px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
            <div style="text-align: center"><asp:Label ID="lbtieude0" runat="server" Text="Lập Chi Tiết Vi Phạm"></asp:Label></div>
            <div><br /></div>
            <div>
                <asp:Label ID="lbthongbao" runat="server"></asp:Label>
                <br /></div>
            <div><br /></div>
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
            <div style="text-align: left">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbtieude1" runat="server" Text="Mã Vi Phạm:"></asp:Label>
                &nbsp;
                <asp:Label ID="lbmavipham" runat="server" style="color: #0000FF"></asp:Label>
                <br /></div>
            <div><br /></div>
            <div style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbtieude2" runat="server" Text="Mã Sách:"></asp:Label>
                &nbsp;
                <asp:Label ID="lbmasach" runat="server" style="color: #0000FF"></asp:Label>
                <br /></div>
            <div><br /></div>
            <div style="text-align: left">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbtieude3" runat="server" Text="Mã Đọc Giả:"></asp:Label>
                &nbsp;
                <asp:Label ID="lbmadocgia" runat="server" style="color: #0033CC"></asp:Label>
                <br /></div>
            <div><br /></div>
            <div style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbtieude4" runat="server" Text="Hết Hạn(*):"></asp:Label>
                      &nbsp;Ngày: <asp:DropDownList ID="drpNgay" runat="server" 
                    style="margin-left: 11px">
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
                      &nbsp;&nbsp; Tháng: <asp:DropDownList ID="drpThang" runat="server" 
                    style="margin-left: 13px">
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
                      &nbsp;&nbsp; Năm:<asp:TextBox ID="txtNam" runat="server" Width="58px" 
                    style="margin-left: 21px"></asp:TextBox>
                      &nbsp;<asp:Label ID="lbthongbaorongnam" runat="server" 
                    style="color: #FF0000" Text="(*)"></asp:Label>
&nbsp; <asp:RangeValidator ID="RantxtNam" runat="server" ControlToValidate="txtNam" 
                          ErrorMessage="[Sai]" MaximumValue="9999" MinimumValue="1753"></asp:RangeValidator>
                      &nbsp;
                      <asp:Label ID="lbcbtxtNam" runat="server" Font-Bold="False" ForeColor="Fuchsia" 
                          Text="Năm[1753--&gt;9999]"></asp:Label></div>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                
                <div><br /></div>
                <div style="text-align: center">
                    <asp:Button ID="btdongy" runat="server" onclick="btdongy_Click" Text="Đồng Ý" 
                        Width="69px" />
                    <asp:Button ID="btkhongdongy" runat="server" style="margin-left: 74px" 
                        Text="Không Đồng Ý" onclick="btkhongdongy_Click" />
                    <br /></div>&nbsp;</td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

