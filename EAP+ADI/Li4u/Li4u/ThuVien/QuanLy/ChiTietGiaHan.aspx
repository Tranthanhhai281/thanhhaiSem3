<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="ChiTietGiaHan.aspx.cs" Inherits="ThuVien_QuanLy_LapLuotMuon" Title="Untitled Page" %>

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
                <asp:Label ID="lbTitle" runat="server" Text="Chi Tiết Gia Hạn" 
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
                  <asp:DetailsView ID="dtlchitiet" runat="server" AutoGenerateRows="False" 
                      BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                      CellPadding="3" CellSpacing="2" DataKeyNames="MaLuotMuon" 
                      DataSourceID="SqlLuotMuon" Height="50px" Width="125px">
                      <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                      <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                      <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                      <Fields>
                          <asp:TemplateField HeaderText="MaLuotMuon" SortExpression="MaLuotMuon">
                              <EditItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("MaLuotMuon") %>'></asp:Label>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MaLuotMuon") %>'></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="lbmaluotmuon" runat="server" Text='<%# Bind("MaLuotMuon") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="MaSach" SortExpression="MaSach">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MaSach") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MaSach") %>'></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="lbmasach" runat="server" Text='<%# Bind("MaSach") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="MaDocGia" SortExpression="MaDocGia">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="lbmadocgia" runat="server" Text='<%# Bind("MaDocGia") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Fields>
                      <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                  </asp:DetailsView>
                  <asp:SqlDataSource ID="SqlLuotMuon" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                      
                      
                      SelectCommand="SELECT MaLuotMuon, MaSach, MaDocGia FROM LuotMuon WHERE (MaLuotMuon = @MaLuotMuon)">
                      <SelectParameters>
                          <asp:QueryStringParameter Name="MaLuotMuon" QueryStringField="MaLuotMuon" 
                              Type="Int32" />
                      </SelectParameters>
                  </asp:SqlDataSource>
                  <br /></div>
                <div style="text-align: left">
                    <asp:Label ID="lbtieude1" runat="server" Text="Lần Gia Hạn:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lblangiahan" runat="server" style="color: #0000FF"></asp:Label>
                    <br /></div>
                    <div><br /></div>
                    <div style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbtieude2" runat="server" Text="Ngày Trả:"></asp:Label>
&nbsp;
                        <asp:Label ID="lbngaytra" runat="server" style="color: #0000FF"></asp:Label>
                        <br /></div>
                    <div><br /></div>
                </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
           
            <div> <br /></div>
            <div><br /></div>
            <div style="text-align: center">
                <asp:Button ID="btLap" runat="server" Text="Đồng Ý" onclick="btLap_Click1" 
                    Width="71px" />
                &nbsp;<asp:Button ID="btkhongdongy" runat="server" style="margin-left: 34px" 
                    Text="Không Đồng Ý" Width="95px" onclick="btkhongdongy_Click" />
                <asp:Button ID="btchitietvipham" runat="server" style="margin-left: 37px; height: 26px;" 
                    Text="Chi Tiết Trễ Hẹn" Width="104px" onclick="btchitietvipham_Click" />
                </div>
            <div>
                <br /></div>
               </td>
        </tr>
    </table>
   
</asp:Content>

 