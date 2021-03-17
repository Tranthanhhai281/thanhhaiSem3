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
/// Summary description for NhanVien
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class NhanVien
{
    private NhanVienTableAdapter _nhanvien = null;

	protected NhanVienTableAdapter nhan_vien
    {get 
        {
            if (_nhanvien == null)
                _nhanvien = new NhanVienTableAdapter();
            return _nhanvien;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.NhanVienDataTable GetNhanVien()
    {
        return this.nhan_vien.GetNhanVien();
    }
     [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemNhanVien(string manhavien,int? machucvu,
         string matkhau,string hoten,string gioi,string namsinh,string email,string anh)
     {
         Data.NhanVienDataTable Nv_tb = new Data.NhanVienDataTable();
         Data.NhanVienRow Nv_rows = Nv_tb.NewNhanVienRow();
         Nv_rows.MaNhanVien = manhavien;
         if (machucvu == null) Nv_rows.SetMaChucVuNull();
         else Nv_rows.MaChucVu = machucvu.Value;
         if (matkhau == null) Nv_rows.SetMatKhauNull();
         else Nv_rows.MatKhau = matkhau;
         if (hoten == null) Nv_rows.SetHotenNull();
         else Nv_rows.Hoten = hoten;
         if (gioi == null) Nv_rows.SetGioiTinhNull();
         else Nv_rows.GioiTinh = gioi;
         if (namsinh == null) Nv_rows.SetNamSinhNull();
         else Nv_rows.NamSinh = namsinh;
         if (email == null) Nv_rows.SetEmailNull();
         else Nv_rows.Email = email;
         if (anh == null) Nv_rows.SetAnhTuongTruongNull();
         else Nv_rows.AnhTuongTruong = anh;         
         Nv_tb.AddNhanVienRow(Nv_rows);
         int bien = nhan_vien.Update(Nv_tb);
         return bien == 1;
     }
   
}
