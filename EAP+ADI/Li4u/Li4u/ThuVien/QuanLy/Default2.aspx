<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="ThuVien_QuanLy_Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="Button" style="width: 56px" />    
    
    <br />
    <asp:FileUpload ID="filupexcel" runat="server" style="margin-left: 0px" 
                          Width="221px" />
    <asp:Label ID="lbCanhBao" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
</asp:Content>

