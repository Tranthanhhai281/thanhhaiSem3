<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ChiTietHoSoLuotMuon.aspx.cs" Inherits="ThuVien_QuanLy_ThongKeTacGia" Title="Untitled Page" %>

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
                <asp:Label ID="lbtieude0" runat="server" Text="Chi Tiết Hồ Sơ Mượn Sách " 
                    style="color: #CCFFFF"></asp:Label>
                <br /></div>
                </td>
        </tr>
        <tr>
            <td class="style7">             
                &nbsp;</td>
            <td align="center" >
                <div style="text-align: left">
&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                    <br /></div>
                <div style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbthongbao" runat="server" 
                        style="text-align: center; color: #FF0000; font-style: italic"></asp:Label>
                    <br /></div>
                <div style="text-align: left">
                    <asp:DetailsView ID="dtlchitiet" runat="server" AutoGenerateRows="False" 
                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataKeyNames="MaLuotMuon" DataSourceID="sqlchitiet" 
                        GridLines="Horizontal" Height="50px" Width="271px">
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <Fields>
                            <asp:BoundField DataField="MaLuotMuon" HeaderText="Mã Lượt Mượn" 
                                ReadOnly="True" SortExpression="MaLuotMuon" />
                            <asp:BoundField DataField="MaGiaHan" HeaderText="Lần Gia Hạn" 
                                SortExpression="MaGiaHan" />
                            <asp:BoundField DataField="MaNhanVien" HeaderText="Nhân Viên Lập" 
                                SortExpression="MaNhanVien" />
                            <asp:BoundField DataField="NgayMuon" HeaderText="Ngày Mượn" 
                                SortExpression="NgayMuon" />
                            <asp:BoundField DataField="NgayTra" HeaderText="Ngày Trả" 
                                SortExpression="NgayTra" />
                        </Fields>
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="sqlchitiet" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [MaLuotMuon], [MaGiaHan], [MaNhanVien], [NgayMuon], [NgayTra] FROM [LuotMuon] WHERE ([MaLuotMuon] = @MaLuotMuon)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="MaLuotMuon" QueryStringField="MaLuotMuon" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br /></div>
                <div>
                    <asp:HyperLink ID="lnkquaylai" runat="server" 
                        NavigateUrl="~/ThuVien/QuanLy/ThongKeHoSoMuonSach.aspx">Quay Lại</asp:HyperLink>
                    <br /></div>
              <div style="text-align: center">
                  <br /></div></td>
            <td class="style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

