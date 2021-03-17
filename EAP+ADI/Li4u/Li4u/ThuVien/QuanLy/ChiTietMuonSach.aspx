<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ChiTietMuonSach.aspx.cs" Inherits="ThuVien_QuanLy_LapLuotMuon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        .style6
        {
            width: 50px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="0" cellspacing="0" style=" width:750px" >
        <tr>
            <td colspan="3">
            <div><br /></div>
            <div style="text-align: center">
                <asp:Label ID="lbTitle" runat="server" Text="Chi Tiết Trả Sách" 
                    style="text-align: center"></asp:Label></div>
            <div>
             <div >
                 <br /></div>
                </div>
            <div style="text-align: center">
                <asp:Label ID="lbThongBao" runat="server" style="text-align: center" 
                    ForeColor="#FF6666"></asp:Label>
                <br /></div>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
             <div>
                 <br /></div>
              <div style="text-align: left">
                  <asp:SqlDataSource ID="sqldangky" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                      
                      
                      
                      SelectCommand="SELECT STT, MaSach, MaDocGia, NgayDangKy, NgayDenMuon FROM DangKy WHERE (STT = @STT)">
                      <SelectParameters>
                          <asp:QueryStringParameter Name="STT" QueryStringField="STT" />
                      </SelectParameters>
                  </asp:SqlDataSource>
                  <asp:DetailsView ID="dtlchitiet" runat="server" DataSourceID="sqldangky" 
                      Height="50px" Width="125px" AutoGenerateRows="False" CellPadding="4" 
                      ForeColor="#333333" GridLines="Horizontal">
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                      <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                      <Fields>
                          <asp:TemplateField HeaderText="STT" SortExpression="STT">
                              <ItemTemplate>
                                  <asp:Label ID="lbstt" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                              </InsertItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="MaSach" SortExpression="MaSach">
                              <ItemTemplate>
                                  <asp:Label ID="lbmasach" runat="server" Text='<%# Bind("MaSach") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MaSach") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MaSach") %>'></asp:TextBox>
                              </InsertItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="MaDocGia" SortExpression="MaDocGia">
                              <ItemTemplate>
                                  <asp:Label ID="lbmadocgia" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:TextBox>
                              </InsertItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="NgayDangKy" HeaderText="NgayDangKy" 
                              SortExpression="NgayDangKy" />
                          <asp:BoundField DataField="NgayDenMuon" HeaderText="NgayDenMuon" 
                              SortExpression="NgayDenMuon" />
                      </Fields>
                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#999999" />
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                  </asp:DetailsView>
                  <br /></div>
                <div><br /></div>
                </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
           
            <div> 
                <asp:Label ID="lbKetQua" runat="server" 
                    style="color: #0000FF; font-style: italic"></asp:Label>
                <br /></div>
            <div><br /></div>
            <div style="text-align: center">
                <asp:Button ID="btLap" runat="server" Text="Đồng Ý" onclick="btLap_Click1" 
                    Width="71px" />
                &nbsp;<asp:Button ID="btkhongdongy" runat="server" style="margin-left: 34px" 
                    Text="Không Đồng Ý" Width="95px" onclick="btkhongdongy_Click" />
                </div>
            <div>
                <br /></div>
               </td>
        </tr>
    </table>
   
</asp:Content>

 