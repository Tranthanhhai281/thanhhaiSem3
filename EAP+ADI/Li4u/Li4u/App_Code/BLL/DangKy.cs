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
/// Summary description for DangKy
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class DangKy
{
    private DangKyTableAdapter _dangky = null;
    protected DangKyTableAdapter dang_ky
    {
        get {
            if (_dangky == null)
                _dangky = new DangKyTableAdapter();
            return _dangky;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.DangKyDataTable GetDangKy()
    {
        return this.dang_ky.GetDangKy();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.DangKyDataTable GetByMaDG(string MaDG)
    {
        return this.dang_ky.GetByMaDG(MaDG);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.DangKyDataTable GetSachDG(int MaSach,string MaDG)
    {
        return this.dang_ky.GetSachDG(MaSach, MaDG);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemDangKy(int _STT,int? _MaSach,string _MaDocGia,string _NgayDangKy,string _NgayDenMuon )
    {

        Data.DangKyDataTable ban_DK = new Data.DangKyDataTable();
        Data.DangKyRow hang_DK = ban_DK.NewDangKyRow();

        hang_DK.STT = _STT;
        if (_MaSach == null) hang_DK.SetMaSachNull();
        else hang_DK.MaSach = _MaSach.Value;
        if (_MaDocGia == null) hang_DK.SetMaDocGiaNull();
        else hang_DK.MaDocGia = _MaDocGia;
        if (_NgayDangKy == null) hang_DK.SetNgayDangKyNull();
        else hang_DK.NgayDangKy = _NgayDangKy;
        if (_NgayDenMuon == null) hang_DK.SetNgayDenMuonNull();
        else hang_DK.NgayDenMuon = _NgayDenMuon;
        ban_DK.AddDangKyRow(hang_DK);
        int bien = dang_ky.Update(ban_DK);
        return bien == 1;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteDK(int? MaSach, string MaDG,int STT)
    {
        int xoahang = dang_ky.DeleteDK(MaSach, MaDG, STT);
        return xoahang == 1;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool Delete_DK(int MaSach, string MaDG)
    {
        int xoahang = dang_ky.Delete_DK(MaSach, MaDG);
        return xoahang == 1;
    }
}
