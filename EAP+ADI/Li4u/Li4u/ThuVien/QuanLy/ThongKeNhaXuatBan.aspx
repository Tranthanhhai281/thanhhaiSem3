<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThongKeNhaXuatBan.aspx.cs" Inherits="ThuVien_QuanLy_ThongKeTacGia" Title="Untitled Page" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
            <div style="text-align: center; background-color: #008080;">
                <asp:Label ID="lbtieude0" runat="server" Text=" Thống Kê Nhà Xuất Bản Theo Phân Loại Sách" 
                    style="color: #CCFFFF"></asp:Label>
                <br /></div>
                </td>
        </tr>
        <tr>
            <td class="style7">             
                &nbsp;</td>
            <td align="center" >
                <div><br /></div>
                 <div style="text-align: left">
                     <asp:Label ID="lbtieude1" runat="server" Text="Chọn Mã Phân Loai:"></asp:Label>
                     <asp:DropDownList ID="drpnhaxuatban" runat="server" AppendDataBoundItems="True" 
                         AutoPostBack="True" DataSourceID="sqlphanloai" DataTextField="TenPhanLoai" 
                         DataValueField="MaPhanLoai" style="margin-left: 38px">
                         <asp:ListItem Value="-1">Tất Cả</asp:ListItem>
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="sqlphanloai" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                         SelectCommand="SELECT * FROM [PhanLoai]"></asp:SqlDataSource>
                     <br /></div>
                  <div><br /></div>
              <div style="text-align: center">
                  <asp:GridView ID="grvthongtin" runat="server" AllowPaging="True" 
                      AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaNhaXuatBan" 
                      ForeColor="#333333" GridLines="None" PageSize="20" 
                      style="text-align: left">
                      <RowStyle BackColor="#E3EAEB" />
                      <Columns>
                          <asp:BoundField DataField="MaNhaXuatBan" HeaderText="Mã Nhà Xuất Bản" ReadOnly="True" 
                              SortExpression="MaNhaXuatBan" />
                          <asp:BoundField DataField="TenNhaXuatBan" HeaderText="Tên Nhà Xuất Bản" 
                              SortExpression="TenNhaXuatBan" />
                      </Columns>
                      <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                      <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                      <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#7C6F57" />
                      <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                  <asp:SqlDataSource ID="sqlnhaxuatbanALL" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                      SelectCommand="SELECT * FROM [NhaXuatBan]"></asp:SqlDataSource>
                  <asp:SqlDataSource ID="sqlchooce" runat="server" 
                      CacheExpirationPolicy="Sliding" 
                      ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                      
                      SelectCommand="SELECT DISTINCT NhaXuatBan.TenNhaXuatBan, NhaXuatBan.MaNhaXuatBan FROM NhaXuatBan INNER JOIN XuatBan ON NhaXuatBan.MaNhaXuatBan = XuatBan.MaNhaXuatBan INNER JOIN Sach ON XuatBan.MaSach = Sach.MaSach WHERE (Sach.MaPhanLoai = @MaPhanLoai)">
                      <SelectParameters>
                          <asp:ControlParameter ControlID="drpnhaxuatban" Name="MaPhanLoai" 
                              PropertyName="SelectedValue" />
                      </SelectParameters>
                  </asp:SqlDataSource>
                  <br /></div>
                  <div><asp:Button ID="btexcel" runat="server" onclick="btexcel_Click" 
                    Text="Xuất Excel" />
                <asp:Button ID="btword" runat="server" onclick="btword_Click" 
                    style="margin-left: 38px" Text="Xuất Word" />
                <asp:Button ID="btpdf" runat="server" onclick="btpdf_Click" 
                    style="margin-left: 37px" Text="Xuất Pdf" /></div>
                  </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

