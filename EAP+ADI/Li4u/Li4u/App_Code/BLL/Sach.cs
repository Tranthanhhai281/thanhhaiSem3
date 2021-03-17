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
/// Summary description for Sach
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class Sach
{
    private SachTableAdapter _sach = null;
    protected SachTableAdapter sach_
    {
        get
        {
            if (_sach == null)
                _sach = new SachTableAdapter();
            return _sach;
        }
    }
    //tìm kiếm sách
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select,true)]
    public Data.SachDataTable GetSach()
    {
        return this.sach_.GetSach();
    }
   

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetMaSach(int MaSach)
    {
        return this.sach_.GetMaSach(MaSach);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetbyTenSach(string TenSach)
    {
        return this.sach_.GetbyTenSach(TenSach);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetbyTenTG(string TenTacGia)
    {
        return this.sach_.GetbyTenTG(TenTacGia);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetbyNamXuatBan(string NamXB)
    {
        return this.sach_.GetbyNamXuatBan(NamXB);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetbyMaTacGia(int MaTacGia)
    {
        return this.sach_.GetbyMaTacGia(MaTacGia);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Sach_Con"></param>
    /// <param name="_masach"></param>
    /// <returns></returns>
    ///                                  //update SachCon
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update,true)]
    public bool UpdateSachCon(int? Sach_Con, int _masach)
    {
        Data.SachDataTable ban_sach = sach_.GetMaSach(_masach);
        if (ban_sach.Count == 0)
            return false;
        else
        {
            Data.SachRow Sach_row = ban_sach[0];
            if (Sach_Con == null) Sach_row.SetSachConNull();
            else Sach_row.SachCon = Sach_Con.Value;
            int bien = sach_.Update(Sach_row);
            return bien == 1;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateSach(int MaSach,int? MaPhanLoai,string TenSach,string NamXuatBan,string Gia,int? SoLuong,
        string NgayNhap,string TinhTrang,string SoTrang,string Muon,int? SachCon,string AnhBia)
    {
        Data.SachDataTable ban_sach = sach_.GetMaSach(MaSach);
        if (ban_sach.Count == 0)
            return false;
        else
        {
            Data.SachRow Sach_row = ban_sach[0];
            if (MaPhanLoai == null) Sach_row.SetMaPhanLoaiNull();
            else Sach_row.MaPhanLoai=MaPhanLoai.Value;
            if (TenSach == null) Sach_row.SetTenSachNull();
            else Sach_row.TenSach = TenSach;
            if (NamXuatBan == null) Sach_row.SetNamXuatBanNull();
            else Sach_row.NamXuatBan = NamXuatBan;
            if (Gia == null) Sach_row.SetGiaNull();
            else Sach_row.Gia = Gia;
            if (SoLuong == null) Sach_row.SetSoLuongNull();
            else Sach_row.SoLuong = SoLuong.Value;
            if (NgayNhap == null) Sach_row.SetNgayNhapNull();
            else Sach_row.NgayNhap = NgayNhap;
            if (TinhTrang == null) Sach_row.SetTinhTrangNull();
            else Sach_row.TinhTrang = TinhTrang;
            if (Muon == null) Sach_row.Set_Muon_DocNull();
            else Sach_row._Muon_Doc = Muon;
            if (SachCon == null) Sach_row.SetSachConNull();
            else Sach_row.SachCon = SachCon.Value;
            if (AnhBia == null) Sach_row.SetAnhBiaNull();
            else Sach_row.AnhBia = AnhBia;
            int bien = sach_.Update(Sach_row);
            return bien == 1;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.SachDataTable GetSachPhanLoai(int MaPhanLoai)
    {
        return this.sach_.GetSachPhanLoai(MaPhanLoai);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert,true)]
    public bool ThemSach(int MaSach, int? MaPhanLoai, string TenSach, string NamXuatBan, string Gia, int? SoLuong, string NgayNhap, string TinhTrang, string SoTrang, string DocMuon, int? SachCon, string AnhBia)
    {
            Data.SachDataTable ban_sach = new Data.SachDataTable();
            Data.SachRow Sach_row = ban_sach.NewSachRow();
            Sach_row.MaSach = MaSach;
            if (MaPhanLoai == null) Sach_row.SetMaPhanLoaiNull();
            else Sach_row.MaPhanLoai = MaPhanLoai.Value;
            if (TenSach == null) Sach_row.SetTenSachNull();
            else Sach_row.TenSach = TenSach;
            if (NamXuatBan == null) Sach_row.SetTenSachNull();
            else Sach_row.NamXuatBan = NamXuatBan;
            if (Gia == null) Sach_row.SetGiaNull();
            else Sach_row.Gia = Gia;
            if (SoLuong == null) Sach_row.SetSoLuongNull();
            else Sach_row.SoLuong = SoLuong.Value;
            if (NgayNhap == null) Sach_row.SetNgayNhapNull();
            else Sach_row.NgayNhap = NgayNhap;
            if (TinhTrang == null) Sach_row.SetTinhTrangNull();
            else Sach_row.TinhTrang = TinhTrang;
            if (SoTrang == null) Sach_row.SetSoTrangNull();
            else Sach_row.SoTrang = SoTrang;
            if (DocMuon == null) Sach_row.Set_Muon_DocNull();
            else Sach_row._Muon_Doc=DocMuon;
            if (SachCon == null) Sach_row.SetSachConNull();
            else Sach_row.SachCon = SachCon.Value;
            if (AnhBia == null) Sach_row.SetAnhBiaNull();
            else Sach_row.AnhBia = AnhBia;
            ban_sach.AddSachRow(Sach_row);
            int bien = sach_.Update(ban_sach);
            return bien == 1;        
    }
}