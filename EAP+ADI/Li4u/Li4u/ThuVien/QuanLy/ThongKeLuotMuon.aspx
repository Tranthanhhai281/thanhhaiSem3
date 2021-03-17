<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ThongKeLuotMuon.aspx.cs" Inherits="ThuVien_QuanLy_ThongKeSachMuon" Title="Untitled Page" %>

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
            width: 20px;
            height: 20px;
        }
        .style9
        {
            height: 20px;
        }
        .style12
        {
            width: 142px;
           
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                <div style="text-align: center; background-color: #008080;">
                    <asp:Label ID="lbtieu0" runat="server" Text="Thống Kê Lượt Mượn" 
                        style="color: #FFFFFF"></asp:Label>
                    <br /></div>
                
                <div><br /></div>
                <div>
                    <table class="style6">
                        <tr>
                            <td class="style12" bgcolor="#66FF99" >
                                <asp:Label ID="Label1" runat="server" Text="Chọn Chi Tiết Thống Kê:"></asp:Label>
                            </td>
                            <td style="background-color: #00FF99;"  >
                                <asp:RadioButtonList ID="radiochon" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="0">Năm</asp:ListItem>
                                    <asp:ListItem Value="1">Tháng</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="2">Tất Cả</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;
                                <asp:Label ID="lbtieude1" runat="server" Text="Mời Bạn Nhập Thông Tin:"></asp:Label>
                    <asp:DropDownList ID="drpThang" runat="server" style="margin-left: 31px" Visible="False">
                          
                          <asp:ListItem Value="01">Tháng 01</asp:ListItem>
                          <asp:ListItem Value="02">Tháng 02</asp:ListItem>
                          <asp:ListItem Value="03">Tháng 03</asp:ListItem>
                          <asp:ListItem Value="04">Tháng 04</asp:ListItem>
                          <asp:ListItem Value="05">Tháng 05</asp:ListItem>
                          <asp:ListItem Value="06">Tháng 06</asp:ListItem>
                          <asp:ListItem Value="07">Tháng 07</asp:ListItem>
                          <asp:ListItem Value="08">Tháng 08</asp:ListItem>
                          <asp:ListItem Value="09">Tháng 09</asp:ListItem>
                          <asp:ListItem Value="10">Tháng 10</asp:ListItem>
                          <asp:ListItem Value="11">Tháng 11</asp:ListItem>
                          <asp:ListItem Value="12">Tháng 12</asp:ListItem>
                      </asp:DropDownList>
                    <asp:TextBox ID="txtnam" runat="server" style="margin-left: 30px" Width="65px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lbthongbaorong" runat="server" style="color: #FF0000" Text="(*)" 
                                    Visible="False"></asp:Label>
                    <asp:Button ID="btthongke" runat="server" style="margin-left: 27px" 
        Text="Thống Kê" onclick="btthongke_Click" />
                            </td>
                        </tr>
                    </table>
                   </div>
                <div style="text-align: center">&nbsp;&nbsp;<asp:Label ID="lbthongbao" 
                        runat="server" style="text-align: center; color: #0000FF; font-style: italic"></asp:Label>
                    <br /></div>
            </td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
    <asp:GridView ID="grvthongtin" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="MaLuotMuon" ForeColor="#333333" GridLines="None" 
                    AllowPaging="True" Font-Names="Times New Roman">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="MaLuotMuon" HeaderText="Lượt Mượn" ReadOnly="True" 
                SortExpression="MaLuotMuon" />
            <asp:BoundField DataField="MaSach" HeaderText="Mã Sách" 
                SortExpression="MaSach" />
            <asp:BoundField DataField="MaDocGia" HeaderText="Đọc Giả" 
                SortExpression="MaDocGia" />
            <asp:BoundField DataField="MaGiaHan" HeaderText="Gian Hạn" 
                SortExpression="MaGiaHan" />
            <asp:BoundField DataField="MaNhanVien" HeaderText="Nhân Viên" 
                SortExpression="MaNhanVien" />
            <asp:BoundField DataField="NgayMuon" HeaderText="Ngày Mượn" 
                SortExpression="NgayMuon" />
            <asp:BoundField DataField="NgayTra" HeaderText="Ngày Trả" 
                SortExpression="NgayTra" />
            <asp:BoundField DataField="Tra/Chua" HeaderText="Trả/Chưa" 
                SortExpression="Tra/Chua" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
            Font-Names="Times New Roman" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="btexcel" runat="server" onclick="btexcel_Click" 
                    Text="Xuất Excel" />
                <asp:Button ID="btword" runat="server" onclick="btword_Click" 
                    style="margin-left: 38px" Text="Xuất Word" />
                <asp:Button ID="btpdf" runat="server" onclick="btpdf_Click" 
                    style="margin-left: 37px" Text="Xuất Pdf" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

