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
/// Summary description for XuatBan
/// </summary>
public class XuatBan
{
    private XuatBanTableAdapter _xuatban = null;
    protected XuatBanTableAdapter Xuat_Ban
    {
        get
        {
            if (_xuatban == null)
                _xuatban = new XuatBanTableAdapter();
            return _xuatban;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.XuatBanDataTable GetXuatBan(){
        return this.Xuat_Ban.GetXuatBan();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemXuatBan(int MaNhaXuatBan, int MaSach)
    {
        Data.XuatBanDataTable ban_xuatban = new Data.XuatBanDataTable();
        Data.XuatBanRow xuatban = ban_xuatban.NewXuatBanRow();
        xuatban.MaNhaXuatBan = MaNhaXuatBan;
        xuatban.MaSach = MaSach;
        ban_xuatban.AddXuatBanRow(xuatban);
        int bien = Xuat_Ban.Update(ban_xuatban);
        return bien == 1;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteXuatBan(int MaNhaXuatBan,int MaSach)
    {
        int xoahang = Xuat_Ban.Delete(MaNhaXuatBan, MaSach);
        return xoahang == 1;
    }
}

