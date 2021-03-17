<%@ Page Language="C#" MasterPageFile="~/MasterPageQL.master" AutoEventWireup="true" CodeFile="SachThue.aspx.cs" Inherits="ThuVien_DocGia_SachTinHoc" Title="Untitled Page" %>

<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>

<script runat="server">

    
   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="Main">
    
    <div style="background-color: #00CC66"><asp:Label ID="lbTieuDe" runat="server" Text="Sách Thuế"></asp:Label></div>
    <asp:DataList ID="lvDemo" runat="server" CellSpacing="50" 
        RepeatDirection="Horizontal" 
        onselectedindexchanged="lvDemo_SelectedIndexChanged" 
        style="text-align: left; font-size: x-small;" CellPadding="2" 
        RepeatColumns="4">
    <ItemTemplate>    
   
        
     <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
         ImageUrl='<%# Anh_Bia(Eval("AnhBia")) %>'  Width="80px" 
            PostBackUrl='<%# "~/ThuVien/QuanLy/ChiTietSach.aspx?MaSach="+Eval("MaSach")+"&Duongdan=SachThue.aspx" %>' />
         
    

        <br />
         
    

        <br />
        <asp:HyperLink ID="hplnkTenSach" runat="server" 
            NavigateUrl='<%# "~/ThuVien/QuanLy/ChiTietSach.aspx?MaSach="+Eval("MaSach")+"&Duongdan=SachThue.aspx" %>' 
            style="color: #0000FF; font-size: small;" Text='<%#ten_sach(Eval("TenSach")) %>' 
            Width="130px"></asp:HyperLink>
        <br />
        <asp:Label ID="lbNgayNhap" runat="server" style="font-size: x-small" 
            Text='<%# Eval("NgayNhap") %>'></asp:Label>
         
    

 </ItemTemplate>
    </asp:DataList>
    <p>
        <asp:Label ID="lbThongBao" runat="server" Text="Label"></asp:Label>
    </p>
    <cc1:CollectionPager ID="CollectionPager1" runat="server" MaxPages="1000" 
        PageSize="4" SectionPadding="4" 
    ResultsFormat="Kết Quả {0}-{1} (of {2})">
    </cc1:CollectionPager>
    <p>
    </p>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSachPhanLoai" 
            TypeName="Sach">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="MaPhanLoai" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
                                                   
</asp:Content>


