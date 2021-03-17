using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataTableAdapters;

/// <summary>
/// Summary description for DocGia
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class DocGia
{
    private DocGiaTableAdapter _docgia = null;
    protected DocGiaTableAdapter doc_gia      
    {get 
        {
            if (_docgia == null)
                _docgia = new DocGiaTableAdapter();
            return _docgia;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.DocGiaDataTable GetDocGia()
    {
        return this.doc_gia.GetDocGia();
    }
    /*[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemDocGia(string madocgia,int? machucvu,string hoten,string gioi,string namsinh,string email)
     {
         Data.DocGiaDataTable DG_tb = new Data.DocGiaDataTable();
         Data.DocGiaRow DG_rows = DG_tb.NewDocGiaRow();
         DG_rows.MaDocGia = madocgia;        
         if (hoten == null) DG_rows.SetHoTenNull();
         else DG_rows.HoTen = hoten;
         if (gioi == null) DG_rows.SetGioiTinhNull();
         else DG_rows.GioiTinh = gioi;
         if (namsinh == null) DG_rows.SetNamSinhNull();
         else DG_rows.NamSinh = namsinh;
         if (email == null) DG_rows.SetEmailNull();
         else DG_rows.Email = email; 
         DG_tb.AddDocGiaRow(DG_rows);
         int bien = doc_gia.Update(DG_tb);
         return bien == 1;
          
     }*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.DocGiaDataTable GetByMaDG(String MaDG)
    {
        return this.doc_gia.GetByMaDG(MaDG);
    }


}
