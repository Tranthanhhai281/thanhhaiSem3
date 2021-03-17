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
/// Summary description for LuotMuon
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class LuotMuon
{
    private LuotMuonTableAdapter _luotmuon = null;
    protected LuotMuonTableAdapter luot_muon
    {
        get{
        if(_luotmuon==null)
            
                _luotmuon = new LuotMuonTableAdapter();
        return _luotmuon;
            
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.LuotMuonDataTable GetLuotMuon()
    {
        return this.luot_muon.GetLuotMuon();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.LuotMuonDataTable GetSachDG(int ma_sach,string ma_dg)
    {
        return this.luot_muon.GetSachDG(ma_sach, ma_dg);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.LuotMuonDataTable GetbyMaDG(string MaDG)
    {
        return this.luot_muon.GetbyMaDG(MaDG);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.LuotMuonDataTable GetbyMaLuotMuon(int _MaLuotMuon)
    {
        return this.luot_muon.GetbyMaLuotMuon(_MaLuotMuon);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemLuotMuon(int maluotmuon,int? masach,string madocgia,int? magiahan,string manhanvien,string ngaymuon,string ngaytra,string trasach)
    {
        Data.LuotMuonDataTable ban_luotmuon = new Data.LuotMuonDataTable();
        Data.LuotMuonRow hang_luotMuon = ban_luotmuon.NewLuotMuonRow();
        
        hang_luotMuon.MaLuotMuon = maluotmuon;
        if (masach == null) hang_luotMuon.SetMaSachNull();
        else hang_luotMuon.MaSach = masach.Value;
        if(madocgia==null)hang_luotMuon.SetMaDocGiaNull();
        else hang_luotMuon.MaDocGia=madocgia;
        if(magiahan==null) hang_luotMuon.SetMaGiaHanNull();
        else hang_luotMuon.MaGiaHan=magiahan.Value;
        if(manhanvien==null) hang_luotMuon.SetMaNhanVienNull();
        else hang_luotMuon.MaNhanVien=manhanvien;
        if(ngaymuon==null) hang_luotMuon.SetNgayMuonNull();
        else hang_luotMuon.NgayMuon=ngaymuon;
        if(ngaytra==null) hang_luotMuon.SetNgayTraNull();
        else hang_luotMuon.NgayTra=ngaytra;
        ban_luotmuon.AddLuotMuonRow(hang_luotMuon);
        int bien = luot_muon.Update(ban_luotmuon);
        return bien == 1;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool SuaLuotMuon(int? MaGiaHan,string MaNhanVien,string NgayMuon,string NgayTra,string Tra ,int MaLuotMuon)
    {
        Data.LuotMuonDataTable ban_luotmuon = luot_muon.GetbyMaLuotMuon(MaLuotMuon);
        if (ban_luotmuon.Count<0)
            return false;
        else
        {
            Data.LuotMuonRow hang_luotmuon = ban_luotmuon[0];
            if (MaGiaHan == null) hang_luotmuon.SetMaGiaHanNull();
            else hang_luotmuon.MaGiaHan = MaGiaHan.Value;
            if (MaNhanVien == null)hang_luotmuon.SetMaNhanVienNull();
            else hang_luotmuon.MaNhanVien = MaNhanVien;
            if (NgayMuon == null) hang_luotmuon.SetNgayMuonNull();
            else hang_luotmuon.NgayMuon = NgayMuon;
            if (NgayTra == null) hang_luotmuon.SetNgayTraNull();
            else hang_luotmuon.NgayTra = NgayTra;
            if (Tra == null)hang_luotmuon.Set_Tra_ChuaNull();
            else hang_luotmuon._Tra_Chua = Tra;
            int bien = luot_muon.Update(hang_luotmuon);
            return bien == 1;
        }

    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete,true)]
    protected bool DeleteLuotMuon(int MaLuotMuon)
    {
        int bien = luot_muon.Delete(MaLuotMuon);
        return bien == 1;
    }

}
