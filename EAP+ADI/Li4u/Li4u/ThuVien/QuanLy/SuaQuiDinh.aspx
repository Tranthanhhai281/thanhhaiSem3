<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="SuaQuiDinh.aspx.cs" Inherits="ThuVien_QuanLy_ThemTacGia" Title="Untitled Page" %>

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
            height: 77px;
        }
        .style9
        {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table class="style6">
        <tr>
            <td colspan="3">
                <div style="background-color: #008080; text-align: center;">
                    <asp:Label ID="lbtieude" runat="server" Text="Sửa Qui Định" 
                        style="color: #FFFFFF"></asp:Label></div>
                <div><br /></div></td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
                <div style="text-align: center">
                    <asp:Label ID="lbcanhbao" runat="server" style="color: #FF0000"></asp:Label>
                    <asp:Label ID="lbketqua" runat="server" style="color: #0000FF"></asp:Label>
                 </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="lbnxb" runat="server" Text="Lượng Sách Cho Cán Bộ Mượn(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtSachCB" runat="server" style="margin-left: 28px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrongsachcb" runat="server" style="color: #FF0000" Text="(*)" 
                        Visible="False"></asp:Label>
                &nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtSachCB" ErrorMessage="Ký Tự Số" Font-Bold="False" 
                        MaximumValue="9999" MinimumValue="0" style="font-style: italic; color: #FF00FF"></asp:RangeValidator>
                </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Lượng Sách Cho Sinh Viên Mượn(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtSachSV" runat="server" style="margin-left: 13px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrongsachsv" runat="server" style="color: #FF0000" Text="(*)" 
                        Visible="False"></asp:Label>
                &nbsp;
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ControlToValidate="txtSachSV" ErrorMessage="Ký Tự Số" Font-Bold="False" 
                        MaximumValue="9999" MinimumValue="0" style="color: #FF00FF; font-style: italic"></asp:RangeValidator>
                </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Số Lần Vi Phạm Tối Đa(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtlanvipham" runat="server" style="margin-left: 79px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrongviphamtoida" runat="server" style="color: #FF0000" 
                        Text="(*)" Visible="False"></asp:Label>
                &nbsp;
                    <asp:RangeValidator ID="RangeValidator3" runat="server" 
                        ControlToValidate="txtlanvipham" ErrorMessage="Ký Tự Số" Font-Bold="False" 
                        MaximumValue="9999" MinimumValue="0" style="color: #FF00FF; font-style: italic"></asp:RangeValidator>
                </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Thời Hạn Mượn Sách Sinh Viên(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtthoihansv" runat="server" style="margin-left: 28px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrongthoihansv" runat="server" style="color: #FF0000" 
                        Text="(*)" Visible="False"></asp:Label>
                &nbsp;
                    <asp:RangeValidator ID="RangeValidator4" runat="server" 
                        ControlToValidate="txtthoihansv" ErrorMessage="Ký Tự Số" Font-Bold="False" 
                        MaximumValue="9999" MinimumValue="0" style="font-style: italic; color: #FF00FF"></asp:RangeValidator>
                </div>
                <div><br /></div>
                <div>
                    <asp:Label ID="Label7" runat="server" Text="Thời Hạn Mượn Sach Cán Bộ(*):"></asp:Label>
                    <asp:TextBox
                        ID="txtthoihancb" runat="server" style="margin-left: 43px" Width="134px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbrongthoihancb" runat="server" style="color: #FF0000" 
                        Text="(*)" Visible="False"></asp:Label>
                &nbsp;
                    <asp:RangeValidator ID="RangeValidator5" runat="server" 
                        ControlToValidate="txtthoihancb" ErrorMessage="Ký Tự Số" Font-Bold="False" 
                        MaximumValue="9999" MinimumValue="0" style="color: #FF00FF; font-style: italic"></asp:RangeValidator>
                </div>
                <div></div></td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                <div><br /></div>
                <div style="text-align: center">
                    <asp:Button ID="btThem" runat="server" onclick="btthem_Click" Text="Cập Nhật" />
                    &nbsp;
                    <br /></div>
                <div><br /></div></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

